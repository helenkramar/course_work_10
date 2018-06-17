using System.Threading.Tasks;

using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
	public sealed class MetaUnitOfWork : IMetaUnitOfWork
	{
		private readonly MetaContext context;
        
        public MetaUnitOfWork(string connection) 
        {
            context = new MetaContext(connection);
            DatabaseRepository = new DataBaseRepository(context);
            ConnectionDetailsRepository = new ConnectionDetailsRepository(context);
        }

		public IRepository<DataBase> DatabaseRepository { get; }
		public IRepository<ConnectionDetails> ConnectionDetailsRepository { get; }

		public async Task SaveAsync() => await context.SaveChangesAsync();
        public void Save() => context.SaveChanges();
    }
}
