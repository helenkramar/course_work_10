﻿using System;
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

        public ConnectionDetails Get(int id)
            => context.ConnectionDetails.Find(id);

        public async Task<IEnumerable<ConnectionDetails>> FindAsync(Expression<Func<ConnectionDetails, bool>> predicate)
			=> await context.ConnectionDetails.Where(predicate).ToListAsync();

        public IEnumerable<ConnectionDetails> Find(Expression<Func<ConnectionDetails, bool>> predicate)
            => context.ConnectionDetails.Where(predicate).ToList();

        public async Task<ConnectionDetails> CreateAsync(ConnectionDetails item)
        {
            var res = await Task.Factory.StartNew(() => {
                context.ConnectionDetails.Add(item);
                context.SaveChanges();
                return item;
            });

            return res;
        }

	    public ConnectionDetails Create(ConnectionDetails item)
	    {
	        throw new NotImplementedException();
	    }

	    public async void UpdateAsync(ConnectionDetails item)
	    {
	        throw new NotImplementedException();
	    }

	    public void Update(ConnectionDetails item)
	    {
	        throw new NotImplementedException();
	    }

        public async void RemoveAsync(int id)
		{
			var entity = await context.ConnectionDetails.FindAsync(id);
			if (entity != null)
			{
				context.ConnectionDetails.Remove(entity);
			}
		}
        public  void Remove(int id)
        {
            var entity = context.ConnectionDetails.Find(id);
            if (entity != null)
            {
                context.ConnectionDetails.Remove(entity);
            }
        }
    }
}
