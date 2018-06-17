using System;
using System.Threading.Tasks;

using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
	public sealed class PositionUnitOfWork : IPositionUnitOfWork, IDisposable
    {
		private readonly PositionContext context;

		public PositionUnitOfWork(string connection)
		{			
			context = new PositionContext(connection);
            PositionRepository = new PositionRepository(context);			
		}

		public IRepository<Position> PositionRepository { get; }		

		public async Task SaveAsync() => await context.SaveChangesAsync();
        public void Save() => context.SaveChanges();

        public void Dispose()
        {
            context.Dispose();
        }

        ~PositionUnitOfWork()
        {
            Dispose();
        }
    }
}
