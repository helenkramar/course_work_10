using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL.Infrastructure;
using BLL.Services;

using DAL.EF;
using DAL.Entities;

namespace Forms
{
    public partial class main_Form : Form
    {
        private const string metsStr =
            @"Data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\dbs\cafedb.mdf;Integrated Security=True;";

        private MetaContext context;

        private string connectionStr;

        private List<DataBase> databases;

        public main_Form()
        {
            InitializeComponent();
            //context = new MetaContext("Meta Context");

            var ms = new MetaService(
                metsStr);
            databases = ms.GetAll().ToList();
        }

        private void cafe_button_Click(object sender, EventArgs e)
        {
            var cafe_db = databases.Find(db => db.Name.Equals("CafeDataBase"));

            var m = new PositionService(metsStr);
            var p = m.GetAll(cafe_db.Id);

            m.Create(new Position { Name = "cookie", Amount = 1, Cost = 3 }, cafe_db.Id);

            var t = m.GetAll(cafe_db.Id).ToList().Find(po => po.Name.Equals("cookie"));
            t.Amount = 10;
            m.Update(t, cafe_db.Id);

            p = m.GetAll(cafe_db.Id);

            //new cafe_Form(ConnectionBuilder.Build(cafe_db.ConnectionDetails)).Show();
        }

        private void manufacture_button_Click(object sender, EventArgs e)
        {
            var manufactire_db = databases.Find(db => db.Name.Equals("ManufactureDataBase"));

            var m = new PositionService(metsStr);
            var p = m.GetAll(manufactire_db.Id);

            m.Create(new Position{Name = "cookie", Amount = 2, Cost = 3}, manufactire_db.Id);
           
        }

        private void main_Form_Load(object sender, EventArgs e)
        {
            //var b = context.DataBases.ToList();
        }
    }
}
