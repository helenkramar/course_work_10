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
        public static void Initialize(this ManufactureContext context)
        {
            // mock
            Position first = new Position { Name = Desserts.cake.ToString(), Amount = 4, Cost = 2.3 };
            Position second = new Position { Name = Desserts.cookie.ToString(), Amount = 14, Cost = 3.5 };
            Position third = new Position { Name = Desserts.candy.ToString(), Amount = 40, Cost = 2.7 };

            List<Position> listPosition = new List<Position> { first, second, third };
            context.Positions.AddRange(listPosition);
            //
        }

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