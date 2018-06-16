using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;

namespace Forms.Controllers
{
    public static class CafeController
    {
        public static List<Position> GetPositions(this CafeContext context)
        {
            return context.Positions.ToList();
        }

        public static void Admission(this CafeContext context, Position position)
        {
            var pos = context.Positions.FirstOrDefault(p => p.Name.Equals(position.Name) && p.Cost.Equals(position.Cost));
            if (pos != null)
            {
                pos.Amount += position.Amount;

                context.Entry(pos).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                context.Positions.Add(position);
                context.SaveChanges();
            }
        }

        public static void SellPositions(this CafeContext context, string name, int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Amount above 0!");

            var position = context.Positions.FirstOrDefault(p => p.Name.Equals(name));

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