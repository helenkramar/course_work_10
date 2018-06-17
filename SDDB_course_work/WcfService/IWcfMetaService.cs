using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IWcfMetaService
    {
        [OperationContract]
        string GetData1(int value);

        [OperationContract]
        IEnumerable<DataBaseModel> GetAll();

    }

    [DataContract]
    public class DataBaseModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DatabaseInfo { get; set; }

        
    }
}
