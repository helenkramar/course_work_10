using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IWcfService2
    {
        [OperationContract]
        string GetData2(int value);

    }
}
