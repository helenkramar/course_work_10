using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL.Services;
using DAL.Entities;

using Forms.MetaWCF;
using Forms.PositionWCF;

namespace Forms
{
    public partial class main_Form : Form
    {
        private const string metaConnStr =
            @"Data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\dbs\metadb.mdf;Integrated Security=True;";

        private MetaService service;

        private List<DataBase> databases;

        public main_Form()
        {
            InitializeComponent();

            service = new MetaService(metaConnStr);
            databases = service.GetAll().ToList();

            /////////////////
            //WcfMetaServiceClient cl1 = new WcfMetaServiceClient();
            //Console.WriteLine(cl1.GetData1(45));
            //IEnumerable<DataBaseModel> dbs = cl1.GetAll();
            //dbs = null;
            //dbs = cl1.GetAll();
            //cl1.Close();

            //WcfPositionServiceClient cl2 = new WcfPositionServiceClient();
            //Console.WriteLine(cl2.GetData2(88));
            //IEnumerable<PositionModel> pos = cl2.GetAll(2);
            //cl2.Create(new PositionModel() { Name = "brbr", Amount = 10, Cost = 5.2 }, 2);
            //cl2.Create(new PositionModel() { Name = "ruru", Amount = 100, Cost = 2.8 }, 2);
            //pos = cl2.GetAll(2);
            //PositionModel found = pos.First();
            //found.Amount = 99;
            //found.Cost = 3.9;
            //cl2.Update(found, 2);
            //pos = cl2.GetAll(2);
            //cl2.Delete(found.Id, 2);
            //pos = cl2.GetAll(2);
            //cl2.Close();
            /////////////////
        }

        private void cafe_button_Click(object sender, EventArgs e)
        {
            var cafe_db = databases.Find(db => db.Name.Equals("CafeDataBase"));

            new cafe_Form(cafe_db.Id, metaConnStr).Show();
        }

        private void manufacture_button_Click(object sender, EventArgs e)
        {
            var manufactire_db = databases.Find(db => db.Name.Equals("ManufactureDataBase"));

            new manufacture_Form(manufactire_db.Id, metaConnStr).Show();
        }
    }
}
