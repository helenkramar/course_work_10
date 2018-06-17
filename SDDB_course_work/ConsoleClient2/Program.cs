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
            
            WcfMetaServiceClient cl1 = new WcfMetaServiceClient();
            Console.WriteLine(cl1.GetData1(45));
            IEnumerable<DataBaseModel> dbs = cl1.GetAll();
            dbs = null;
            dbs = cl1.GetAll();
            cl1.Close();

            WcfPositionServiceClient cl2 = new WcfPositionServiceClient();
            Console.WriteLine(cl2.GetData2(88));
            IEnumerable<PositionModel> pos = cl2.GetAll(2);
            cl2.Create(new PositionModel() { Name = "brbr", Amount = 10, Cost = 5.2 }, 2);
            cl2.Create(new PositionModel() { Name = "ruru", Amount = 100, Cost = 2.8 }, 2);
            pos = cl2.GetAll(2);
            PositionModel found = pos.First();
            found.Amount = 99;
            found.Cost = 3.9;
            cl2.Update(found, 2);
            pos = cl2.GetAll(2);
            cl2.Delete(found.Id, 2);
            pos = cl2.GetAll(2);
            cl2.Close();
            Console.ReadKey();


        }
    }
}
