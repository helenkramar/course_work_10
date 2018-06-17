using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    
    public class WcfService1 : IWcfService1
    {
        public string GetData1(int value)
        {
            return string.Format("You entered: {0}", value);
        }

    }
}
