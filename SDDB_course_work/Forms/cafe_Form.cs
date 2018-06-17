using System;
using System.Windows.Forms;

using Forms.Controllers;
using Forms.PositionWCF;

namespace Forms
{
    public partial class cafe_Form : Form
    {
        private readonly int dbId;
        private readonly WcfPositionServiceClient service;

        public cafe_Form(int dbId)
        {
            InitializeComponent();

            this.dbId = dbId;
            service = new WcfPositionServiceClient();

            this.Text += $" {dbId}";
        }

        private void LoadGrid()
        {
            cafe_dataGrid.DataSource = CafeController.GetPositions(service, dbId);
        }

        private void cafe_Form_Load(object sender, System.EventArgs e)
        {
            LoadGrid();

            this.cafe_dataGrid.SelectionChanged += new System.EventHandler(this.cafe_dataGrid_SelectionChanged);
        }

        private void sell_button_Click(object sender, System.EventArgs e)
        {
            var text = positionsName_textBox.Text;
            var amount = Int32.Parse(positionsAmount_textBox.Text);

            if (amount < 1)
            {
                MessageBox.Show($"Wrong amount: '{amount}'!");
                return;
            }

            service.SellPositions(dbId, text, amount);

            LoadGrid();
        }

        private void cafe_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
            {
                var row = ((DataGridView)sender).SelectedRows[0];

                positionsName_textBox.Text = row.Cells["Name"].Value.ToString();
                positionsAmount_textBox.Text = row.Cells["Amount"].Value.ToString();
                positionCost_textBox.Text = row.Cells["Cost"].Value.ToString();
            }
        }

        private void cafe_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Close();
        }
    }
}
