using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DAL.Interfaces
{
	public interface IRepository<T>
	{
		Task<T> GetAsync(int id);
        T Get(int id);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        Task<T> CreateAsync(T item);
        T Create(T item);

        void UpdateAsync(T item);
        void Update(T item);

        void RemoveAsync(int id);
        void Remove(int id);
	}
}
