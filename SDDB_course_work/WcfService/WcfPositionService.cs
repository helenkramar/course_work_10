using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using BLL.Services;
using DAL.Entities;

namespace WcfService
{
    public class WcfPositionService : IWcfPositionService
    {
        private readonly PositionService serv;
        IMapper iMapper;

        public WcfPositionService()
        {
            serv = new PositionService(@"Data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\dbs\cafedb.mdf;Integrated Security=True;");
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Position, PositionModel>();
                cfg.CreateMap<PositionModel, Position>();

            });
            iMapper = config.CreateMapper();
        }
        
        public IEnumerable<PositionModel> GetAll(int databaseId)
            => iMapper.Map<IEnumerable<Position>, IEnumerable<PositionModel>>(serv.GetAll(databaseId));

        public PositionModel Create(PositionModel entity, int databaseId)
            => iMapper.Map<Position, PositionModel>(serv.Create(iMapper.Map<PositionModel, Position>(entity), databaseId));

        public void Update(PositionModel entity, int databaseId)
        {
            serv.Update(iMapper.Map<PositionModel, Position>(entity), databaseId);
        }

        public void Delete(int entityId, int databaseId)
        {
            serv.Delete(entityId, databaseId);
        }

        public string GetData2(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public int GetPositionAmount(string position, int databaseId)
        {
            var c = GetAll(databaseId).Where(item => item.Name.Equals(position));

            int result = 0;
            c.ToList().ForEach((item) => { result += item.Amount;});
            return result;
        }
    }
}
