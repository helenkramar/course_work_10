using System.Threading.Tasks;
using System.Collections.Generic;

using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

using BLL.Interfaces;

namespace BLL.Services
{
	public class MetaService : IMetaService
	{
		private readonly IMetaUnitOfWork uow;

		public MetaService(string connection)
        //=> this.uow = uow;
        { uow = new MetaUnitOfWork(connection); }

		public async Task<IEnumerable<DataBase>> GetAllAsync() =>
			await uow.DatabaseRepository.FindAsync(db => true);

        public IEnumerable<DataBase> GetAll() =>
             uow.DatabaseRepository.Find(db => true);
    }
}
