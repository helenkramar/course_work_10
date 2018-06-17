using System;
using System.Linq;
using System.Windows.Forms;
using Forms.Controllers;

using BLL.Services;

namespace Forms
{
    public partial class manufacture_Form : Form
    {
        private int dbId;
        private readonly string connectionStr;
        private PositionService service;

        public manufacture_Form(int dbId, string conStr)
        {
            InitializeComponent();

            this.dbId = dbId;
            connectionStr = conStr;
            service = new PositionService(connectionStr);
        }

        private void LoadGrid()
        {
            manufacture_dataGrid.DataSource = ManufactureController.GetPositions(service, dbId);
        }

        private void LoadDessertsCombobox()
        {
            var desserts = ManufactureController.GetDesserts();
            positionsName_comboBox.DataSource = desserts;

            int index = 1;
            positionsName_comboBox.SelectedIndex = index;
            positionsName_comboBox.DisplayMember = desserts[index];
        }

        private void LoadCafesCombobox()
        {
            var metaService = new MetaService(connectionStr);
            var databases = metaService.GetAll().Where(db => db.DatabaseInfo.Contains("cafe")).Select(db => db.Name).ToList();
           
            cafes_comboBox.DataSource = databases;

            int index = 0;
            positionsName_comboBox.SelectedIndex = index;
            positionsName_comboBox.DisplayMember = databases[index];
        }

        private void manufacture_Form_Load(object sender, System.EventArgs e)
        {
            LoadGrid();

            this.manufacture_dataGrid.SelectionChanged += new System.EventHandler(this.manufacture_dataGrid_SelectionChanged);

            LoadDessertsCombobox();

            LoadCafesCombobox();
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);
            var cafeName = cafes_comboBox.SelectedValue.ToString();

            var metaService = new MetaService(connectionStr);
            var cafeId = metaService.GetAll().First(db => db.Name.Equals(cafeName)).Id;

            service.SendPositions(dbId, cafeId, text, amount, cost);

            LoadGrid();
        }

        private void cook_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);

            if (amount < 1)
            {
                MessageBox.Show($"Invalid amount: '{amount}'!");
                return;
            }

            service.AddPositions(dbId, text, amount, cost);

            LoadGrid();
        }

        private void manufacture_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView) sender).SelectedRows.Count > 0)
            {
                var row = ((DataGridView)sender).SelectedRows[0];

                positionsName_comboBox.SelectedItem = row.Cells[1].Value.ToString();
                positionsAmount_textBox.Text = row.Cells[2].Value.ToString();
                positionsCost_textBox.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
