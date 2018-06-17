using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Forms.MetaWCF;

namespace Forms
{
    public partial class main_Form : Form
    {
        private readonly WcfMetaServiceClient service;

        private readonly List<DataBaseModel> databases;

        private int cafeId;

        public main_Form()
        {
            InitializeComponent();

            service = new WcfMetaServiceClient();
            databases = service.GetAll().ToList();

            this.databases_dataGrid.SelectionChanged += new System.EventHandler(this.databases_dataGrid_SelectionChanged);

            databases_dataGrid.DataSource = databases.Where(db => db.DatabaseInfo.Contains("cafe")).ToList();

            service.Close();
        }

        private void manufacture_button_Click(object sender, EventArgs e)
        {
            var manufacture_db = databases.Find(db => db.DatabaseInfo.Contains("manufacture"));

            new manufacture_Form(manufacture_db.Id).Show();
        }

        private void databases_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
            {
                var row = ((DataGridView)sender).SelectedRows[0];

                cafeId = Int32.Parse(row.Cells["Id"].FormattedValue.ToString());
            }
        }

        private void open_button_Click(object sender, EventArgs e)
        {
            new cafe_Form(cafeId).Show();
        }

        private void main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Close();
        }
    }
}
