using System.Threading.Tasks;
using System.Data.Entity;

using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
	public sealed class MetaUnitOfWork : IMetaUnitOfWork
	{
		private readonly MetaContext context;
        
        public MetaUnitOfWork(string connection) 
        //	IRepository<ConnectionDetails> connectionDetailsRepository)
        //public MetaUnitOfWork(MetaContext context, IRepository<DataBase> databaseRepository,
        //	IRepository<ConnectionDetails> connectionDetailsRepository)
        {
            context = new MetaContext(connection);
            DatabaseRepository = new DataBaseRepository(context);
            ConnectionDetailsRepository = new ConnectionDetailsRepository(context);
            //         this.context = context;
            //DatabaseRepository = databaseRepository;
            //ConnectionDetailsRepository = connectionDetailsRepository;
        }

		public IRepository<DataBase> DatabaseRepository { get; }
		public IRepository<ConnectionDetails> ConnectionDetailsRepository { get; }

		public async Task SaveAsync() => await context.SaveChangesAsync();
        public void Save() => context.SaveChanges();
    }
}
