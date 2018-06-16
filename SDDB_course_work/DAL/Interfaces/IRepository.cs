using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DAL.Interfaces
{
	public interface IRepository<T>
	{
		Task<T> GetAsync(int id);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
		Task<T> CreateAsync(T item);
		void Update(T item);
		void Remove(int id);
	}
}
