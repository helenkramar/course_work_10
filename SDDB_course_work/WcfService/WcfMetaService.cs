using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using BLL.Services;
using DAL.Entities;

namespace WcfService
{
    
    public class WcfMetaService : IWcfMetaService
    {
        private readonly MetaService serv;
        IMapper iMapper;

        public WcfMetaService()
        {
            serv = new MetaService(@"Data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\dbs\cafedb.mdf;Integrated Security=True;");
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<DataBase, DataBaseModel>();

            });
            iMapper = config.CreateMapper();
        }

        public IEnumerable<DataBaseModel> GetAll() =>
             iMapper.Map<IEnumerable<DataBase>, IEnumerable<DataBaseModel>>(serv.GetAll());

        // test method of WcfMetaService
        public string GetData1(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }

    
}


