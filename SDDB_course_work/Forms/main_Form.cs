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
        private const string metaConnStr =
            @"Data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\dbs\metadb.mdf;Integrated Security=True;";

        private MetaService service;

        private List<DataBase> databases;

        public main_Form()
        {
            InitializeComponent();

            service = new MetaService(metaConnStr);
            databases = service.GetAll().ToList();
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
