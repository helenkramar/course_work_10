using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ConsoleClient2.WCFService;
using ConsoleClient2.FirstWcf;
using ConsoleClient2.SecondWcf;

namespace ConsoleClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Service1Client client = new Service1Client();
            //Console.WriteLine(client.GetData(45));
            //Console.WriteLine(client.GetData(88));
            //Console.WriteLine((client.GetDataUsingDataContract(new CompositeType())).StringValue);
            //client.Close();
            //Console.WriteLine("press any key to continue");
            //Console.ReadKey();

            WcfService1Client cl1 = new WcfService1Client();
            Console.WriteLine(cl1.GetData1(45));
            cl1.Close();

            WcfService2Client cl2 = new WcfService2Client();
            Console.WriteLine(cl2.GetData2(88));
            cl2.Close();
            Console.ReadKey();


        }
    }
}
