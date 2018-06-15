using System;
using System.Windows.Forms;
using DAL.EF;
using Forms.Controllers;

namespace Forms
{
    public partial class manufacture_Form : Form
    {
        private ManufactureContext manufactureContext;

        public manufacture_Form()
        {
            InitializeComponent();
            manufactureContext = new ManufactureContext("Manufacture Context");
        }

        private void manufacture_Form_Load(object sender, System.EventArgs e)
        {
            manufacture_dataGrid.DataSource = ManufactureController.GetPositions(manufactureContext);

            this.manufacture_dataGrid.SelectionChanged += new System.EventHandler(this.manufacture_dataGrid_SelectionChanged);

            var desserts = ManufactureController.GetDesserts();
            positionsName_comboBox.DataSource = desserts;

            int index = 1;
            positionsName_comboBox.SelectedIndex = index;
            positionsName_comboBox.DisplayMember = desserts[index];
            //positionsName_comboBox.ValueMember = desserts[index];
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);

            ManufactureController.SendPositions(manufactureContext, text, amount, cost);

            manufacture_dataGrid.DataSource = ManufactureController.GetPositions(manufactureContext);
        }

        private void cook_button_Click(object sender, EventArgs e)
        {
            var text = positionsName_comboBox.SelectedItem.ToString();
            var amount = Int32.Parse(positionsAmount_textBox.Text);
            var cost = Double.Parse(positionsCost_textBox.Text);

            ManufactureController.AddPositions(manufactureContext, text, amount, cost);

            MessageBox.Show($"'{text}': {amount}");
        }

        private void manufacture_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            var row = ((DataGridView)sender).SelectedRows[0];

            positionsName_comboBox.SelectedItem = row.Cells[1].Value.ToString();
            positionsAmount_textBox.Text = row.Cells[2].Value.ToString();
            positionsCost_textBox.Text = row.Cells[3].Value.ToString();
        }
    }
}
