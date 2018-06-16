using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;

namespace Forms.Controllers
{
    public static class ManufactureController
    {
        public static List<Position> GetPositions(this ManufactureContext context)
        {
            return context.Positions.Local.ToList();
        }

        public static List<string> GetDesserts()
        {
            return Enum.GetNames(typeof(Desserts)).ToList();
        }

        public static void AddPositions(this ManufactureContext context, string name, int amount, double cost)
        {
            var position = context.Positions.FirstOrDefault(p => p.Name.Equals(name) && p.Cost.Equals(cost));

            if (position != null)
            {
                position.Amount += amount;

                context.Entry(position).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                position = new Position
                {
                    Name = name,
                    Amount = amount,
                    Cost = cost
                };

                context.Positions.Add(position);
                context.SaveChanges();
            }
        }

        public static void SendPositions(this ManufactureContext context, string name, int amount, double cost)
        {
            WriteOff(context, name, amount, cost);
           
            var cafeContext = new CafeContext("CafeContext");

            cafeContext.Admission(new Position()
            {
                Name = name,
                Amount = amount,
                Cost = cost
            });
        }

        private static void WriteOff(ManufactureContext context, string name, int amount, double cost)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Amount above 0!");

            var position = context.Positions.FirstOrDefault(p => p.Name.Equals(name) && p.Cost.Equals(cost));

            if (position != null && position.Amount >= amount)
            {
                position.Amount -= amount;
                if (position.Amount < 0)
                    context.Entry(position).State = EntityState.Modified;

                if (position.Amount == 0)
                    context.Positions.Remove(position);

                context.SaveChanges();
            }
        }
    }
}