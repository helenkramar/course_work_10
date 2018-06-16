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
{this.context = context;}

		public async Task<DataBase> GetAsync(int id)
			=> await context.DataBases.FindAsync(id);

		public async Task<IEnumerable<DataBase>> FindAsync(Expression<Func<DataBase, bool>> predicate)
			=> await context.DataBases.Where(predicate).ToListAsync();

		public async Task<DataBase> CreateAsync(DataBase item)
        //=> (await context.DataBases.AddAsync(item)).Entity;
        {
            var db = await context.DataBases.FirstOrDefaultAsync(p => p.Name.Equals(item.Name));
            if (db == null)
            {
                context.DataBases.Add(item);
                context.SaveChanges();
            }
            return item;
        }

		public void Update(DataBase item)
        { throw new NotImplementedException(); }//=> context.DataBases.Update(item);

        public async void Remove(int id)
		{
			var entity = await context.DataBases.FindAsync(id);
			if (entity != null)
			{
				context.DataBases.Remove(entity);
			}
		}
	}
}