using System;
using System.Windows.Forms;
using DAL.EF;
using Forms.Controllers;

namespace Forms
{
    public partial class cafe_Form : Form
    {
        private CafeContext cafeContext;

        public cafe_Form(string connectionStr)
        {
           InitializeComponent();
           //cafeContext = new CafeContext("CafeContext");
        }

        private void LoadGrid()
        {
            cafe_dataGrid.DataSource = CafeController.GetPositions(cafeContext);
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

            CafeController.SellPositions(cafeContext, text, amount);

            LoadGrid();
        }

        private void cafe_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
            {
                var row = ((DataGridView)sender).SelectedRows[0];

                positionsName_textBox.Text = row.Cells[1].Value.ToString();
                positionsAmount_textBox.Text = row.Cells[2].Value.ToString();
                positionCost_textBox.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
