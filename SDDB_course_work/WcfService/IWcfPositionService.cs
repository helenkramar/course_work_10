using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WcfService
{
    [ServiceContract]
    public interface IWcfPositionService
    {
        [OperationContract]
        string GetData2(int value);

        [OperationContract]
        IEnumerable<PositionModel> GetAll(int databaseId);

        [OperationContract]
        PositionModel Create(PositionModel entity, int databaseId);

        [OperationContract]
         void Update(PositionModel entity, int databaseId);

        [OperationContract]
        void Delete(int entityId, int databaseId);

    }

    [DataContract]
    public class PositionModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public double Cost { get; set; }
    }
}
