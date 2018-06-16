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

        public async Task<IEnumerable<Position>> FindAsync(Expression<Func<Position, bool>> predicate)
            => await context.Positions.Where(predicate).ToListAsync();

        public async Task<Position> CreateAsync(Position item)
        {
            var pos = await context.Positions.FirstOrDefaultAsync(p => p.Name.Equals(item.Name) && p.Cost.Equals(item.Cost));
            if (pos != null)
            {
                pos.Amount += item.Amount;

                context.Entry(pos).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                context.Positions.Add(item);
                context.SaveChanges();
            }
            return item;
        }



        //public async Task<Position> CreateAsync(Position item)
        //	=> (await context.Positions.AddAsync(item)).Entity;

        public void Update(Position item)
        { throw new NotImplementedException(); }//=> context.Positions.Update(item);

		public async void Remove(int id)
		{
			var entity = await context.Positions.FindAsync(id);
			if (entity != null)
			{
				context.Positions.Remove(entity);
			}			
		}
	}
}
