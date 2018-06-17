using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService
{
    public class WcfService2 : IWcfService2
    {
        public string GetData2(int value)
        {
            return string.Format("You entered: {0}", value);
        }

    }
}
