using System;
using System.Windows.Forms;
using dataProcessing.Services;
using Forms.Controllers;

using DAL.EF;

namespace Forms
{
    public partial class manufacture_Form : Form
    {
        private ManufactureContext manufactureContext;

        public manufacture_Form(string connectionStr)
        {
            InitializeComponent();
            var service = new PositionService(connectionStr);
        }

        private void LoadGrid()
        {
            manufacture_dataGrid.DataSource = ManufactureController.GetPositions(manufactureContext);
        }

        private void manufacture_Form_Load(object sender, System.EventArgs e)
        {
            LoadGrid();

            this.manufacture_dataGrid.SelectionChanged += new System.EventHandler(this.manufacture_dataGrid_SelectionChanged);

            var desserts = ManufactureController.GetDesserts();
            positionsName_comboBox.DataSource = desserts;

            int index = 1;
            positionsName_comboBox.SelectedIndex = index;
            positionsName_comboBox.DisplayMember = desserts[index];
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);

            ManufactureController.SendPositions(manufactureContext, text, amount, cost);

            LoadGrid();
        }

        private void cook_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);

            ManufactureController.AddPositions(manufactureContext, text, amount, cost);

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
