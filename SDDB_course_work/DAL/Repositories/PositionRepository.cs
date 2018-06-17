using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data.Entity;

using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PositionRepository : IRepository<Position>
    {
        private readonly PositionContext context;

        public PositionRepository(PositionContext context)
        { this.context = context; }

        public async Task<Position> GetAsync(int id)
            => await context.Positions.FindAsync(id);

        public Position Get(int id)
            => context.Positions.Find(id);


        public async Task<IEnumerable<Position>> FindAsync(Expression<Func<Position, bool>> predicate)
            => await context.Positions.Where(predicate).ToListAsync();

        public IEnumerable<Position> Find(Expression<Func<Position, bool>> predicate)
            => context.Positions.Where(predicate).ToList();


        public async Task<Position> CreateAsync(Position item)
        {
            var res = await Task.Factory.StartNew(() =>
            {
                context.Positions.Add(item);
                context.SaveChanges();
                return item;
            });

            return res;
        }

        public Position Create(Position item)
        {
            context.Positions.Add(item);
            context.SaveChanges();
            return item;
        }

        public async void UpdateAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public void Update(Position item)
        {
            var entity = context.Positions.Find(item.Id);
            if (entity != null)
            {
                entity.Amount = item.Amount;
                entity.Cost = item.Cost;

                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public async void RemoveAsync(int id)
        {
            var entity = await context.Positions.FindAsync(id);
            if (entity != null)
            {
                context.Positions.Remove(entity);
            }
        }

        public void Remove(int id)
        {
            var entity = context.Positions.Find(id);
            if (entity != null)
            {
                context.Positions.Remove(entity);
            }
        }
    }
}
