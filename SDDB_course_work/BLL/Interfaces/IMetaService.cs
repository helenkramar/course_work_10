using System.Threading.Tasks;
using System.Collections.Generic;

using DAL.Entities;

namespace BLL.Interfaces
{
	public interface IMetaService
	{
		Task<IEnumerable<DataBase>> GetAllAsync();
	}
}