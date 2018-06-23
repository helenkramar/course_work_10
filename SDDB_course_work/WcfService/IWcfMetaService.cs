using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

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
