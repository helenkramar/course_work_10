using System.Threading.Tasks;
using System.Collections.Generic;

using BLL.Interfaces;
using BLL.Infrastructure;

using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace dataProcessing.Services
{
	public class PositionService : IPositionService
	{
		private readonly IMetaUnitOfWork metaUow;
		private IPositionUnitOfWork uow;

        public PositionService(string connection)// => this.metaUow = metaUow;
        {
            metaUow = new MetaUnitOfWork(connection);
            //uow = new PositionUnitOfWork(connection);
        }

        public async Task<IEnumerable<Position>> GetAllAsync(int databaseId)
		{
			await GetContextAsync(databaseId);

			return await uow.PositionRepository.FindAsync(emp => true);
		}

		public async Task<Position> CreateAsync(Position entity, int databaseId)
		{
			await GetContextAsync(databaseId);

			var result = await uow.PositionRepository.CreateAsync(entity);
			await uow.SaveAsync();

			return result;
		}

		public async Task Update(Position entity, int databaseId)
		{
			await GetContextAsync(databaseId);

			uow.PositionRepository.Update(entity);
			await uow.SaveAsync();
		}

		public async Task Delete(int employeeId, int databaseId)
		{
			await GetContextAsync(databaseId);

			uow.PositionRepository.Remove(employeeId);
			await uow.SaveAsync();
		}

		private async Task GetContextAsync(int databaseId)
		{
			var connectionDetails = (await metaUow.DatabaseRepository.GetAsync(databaseId)).ConnectionDetails;
			var connection = ConnectionBuilder.Build(connectionDetails);
			//var builder = new DbContextOptionsBuilder()
			//	.UseSqlServer(connection);
			uow = new PositionUnitOfWork(connection);
		}
	}
}
