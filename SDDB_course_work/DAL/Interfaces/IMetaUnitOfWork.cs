using System.Threading.Tasks;

using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IMetaUnitOfWork
	{
		IRepository<DataBase> DatabaseRepository { get; }
		IRepository<ConnectionDetails> ConnectionDetailsRepository { get; }

		Task SaveAsync();
        void Save();
    }
}
