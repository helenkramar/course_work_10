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
	public class ConnectionDetailsRepository : IRepository<ConnectionDetails>
	{
		private readonly MetaContext context;

		public ConnectionDetailsRepository(MetaContext context) {this.context = context;}

		public async Task<ConnectionDetails> GetAsync(int id)
			=> await context.ConnectionDetails.FindAsync(id);

		public async Task<IEnumerable<ConnectionDetails>> FindAsync(Expression<Func<ConnectionDetails, bool>> predicate)
			=> await context.ConnectionDetails.Where(predicate).ToListAsync();

		public async Task<ConnectionDetails> CreateAsync(ConnectionDetails item)
        //=> (await context.ConnectionDetails.AddAsync(item)).Entity;
        {
            var db = await context.ConnectionDetails.FirstOrDefaultAsync(p => p.Id.Equals(item.Id));
            if (db == null)
            {
                context.ConnectionDetails.Add(item);
                context.SaveChanges();
            }
            return item;
        }

        public void Update(ConnectionDetails item)// => context.ConnectionDetails.Update(item);
        { throw new NotImplementedException(); }

        public async void Remove(int id)
		{
			var entity = await context.ConnectionDetails.FindAsync(id);
			if (entity != null)
			{
				context.ConnectionDetails.Remove(entity);
			}
		}
	}
}
