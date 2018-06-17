using System.Threading.Tasks;
using System.Collections.Generic;

using DAL.Entities;

namespace BLL.Interfaces
{
	public interface IPositionService
	{
		Task<Position> CreateAsync(Position entity, int databaseId);
        Position Create(Position entity, int databaseId);

        Task UpdateAsync(Position entity, int databaseId);
        void Update(Position entity, int databaseId);

        Task DeleteAsync(int employeeId, int databaseId);
        void Delete(int employeeId, int databaseId);

        Task<IEnumerable<Position>> GetAllAsync(int databaseId);
        IEnumerable<Position> GetAll(int databaseId);
    }
}
