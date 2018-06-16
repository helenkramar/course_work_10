using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IPositionUnitOfWork
	{
		IRepository<Position> PositionRepository { get; }

		Task SaveAsync();
	}
}
