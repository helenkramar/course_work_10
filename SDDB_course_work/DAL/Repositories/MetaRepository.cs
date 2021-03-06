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
	public class DataBaseRepository : IRepository<DataBase>
	{
		private readonly MetaContext context;

	    public DataBaseRepository(MetaContext context)
	    {
	        this.context = context;
	    }

		public async Task<DataBase> GetAsync(int id)
			=> await context.DataBases.FindAsync(id);

        public DataBase Get(int id)
            => context.DataBases.Find(id);

        public async Task<IEnumerable<DataBase>> FindAsync(Expression<Func<DataBase, bool>> predicate)
			=> await context.DataBases.Where(predicate).ToListAsync();

        public IEnumerable<DataBase> Find(Expression<Func<DataBase, bool>> predicate)
            =>  context.DataBases.Where(predicate).ToList();

        public async Task<DataBase> CreateAsync(DataBase item)
        {
            var res = await Task.Factory.StartNew(() => {
                context.DataBases.Add(item);
                context.SaveChanges();
                return item;
            });

            return res;
        }

        public DataBase Create(DataBase item)
        {
            context.DataBases.Add(item);
            context.SaveChanges();
            return item;
        }


	    public async void UpdateAsync(DataBase item)
	    {
	        throw new NotImplementedException();
	    }

	    public void Update(DataBase item)
	    {
	        throw new NotImplementedException();
	    }

        public async void RemoveAsync(int id)
		{
			var entity = await context.DataBases.FindAsync(id);
			if (entity != null)
			{
				context.DataBases.Remove(entity);
			}
		}

        public  void Remove(int id)
        {
            var entity = context.DataBases.Find(id);
            if (entity != null)
            {
                context.DataBases.Remove(entity);
            }
        }
    }
}
