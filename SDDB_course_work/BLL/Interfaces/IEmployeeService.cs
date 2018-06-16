using System.Threading.Tasks;
using System.Collections.Generic;

using DAL.Entities;

namespace BLL.Interfaces
{
	public interface IPositionService
	{
		Task<Position> CreateAsync(Position entity, int databaseId);
		Task Update(Position entity, int databaseId);
		Task Delete(int employeeId, int databaseId);
		Task<IEnumerable<Position>> GetAllAsync(int databaseId);
	}
}
