using System.Threading.Tasks;
using System.Collections.Generic;

using BLL.Interfaces;
using BLL.Infrastructure;

using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
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

			return await uow.PositionRepository.FindAsync(pos => true);
		}

        public IEnumerable<Position> GetAll(int databaseId)
        {
            GetContext(databaseId);

            return uow.PositionRepository.Find(emp => true);
        }

        public async Task<Position> CreateAsync(Position entity, int databaseId)
		{
			await GetContextAsync(databaseId);

			var result = await uow.PositionRepository.CreateAsync(entity);
			await uow.SaveAsync();

			return result;
		}

        public Position Create(Position entity, int databaseId)
        {
            GetContext(databaseId);

            var result = uow.PositionRepository.Create(entity);
            uow.Save();

            return result;
        }

        public async Task UpdateAsync(Position entity, int databaseId)
        {
            await GetContextAsync(databaseId);

            uow.PositionRepository.Update(entity);
            await uow.SaveAsync();
        }

        public void Update(Position entity, int databaseId)
		{
			GetContext(databaseId);

			uow.PositionRepository.Update(entity);
			uow.Save();
		}

        public async Task DeleteAsync(int employeeId, int databaseId)
        {
            await GetContextAsync(databaseId);

            uow.PositionRepository.Remove(employeeId);
            await uow.SaveAsync();
        }

        public void Delete(int employeeId, int databaseId)
		{
			GetContext(databaseId);

			uow.PositionRepository.Remove(employeeId);
			uow.Save();
		}

		private async Task GetContextAsync(int databaseId)
		{
			var connectionDetails = (await metaUow.DatabaseRepository.GetAsync(databaseId)).ConnectionDetails;
			var connection = ConnectionBuilder.Build(connectionDetails);
			//var builder = new DbContextOptionsBuilder()
			//	.UseSqlServer(connection);
			uow = new PositionUnitOfWork(connection);
		}

        private void GetContext(int databaseId)
        {
            var connectionDetails = (metaUow.DatabaseRepository.Get(databaseId)).ConnectionDetails;
            var connection = ConnectionBuilder.Build(connectionDetails);
            //var builder = new DbContextOptionsBuilder()
            //	.UseSqlServer(connection);
            uow = new PositionUnitOfWork(connection);
        }
    }
}
