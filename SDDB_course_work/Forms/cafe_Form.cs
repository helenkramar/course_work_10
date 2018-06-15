using System.Windows.Forms;
using DAL.EF;

namespace Forms
{
    public partial class cafe_Form : Form
    {
        private CafeContext cafeContext;

        public cafe_Form()
        {
           InitializeComponent();
           cafeContext = new CafeContext("CafeContext");
        }

        private void cafe_Form_Load(object sender, System.EventArgs e)
        {
            var data = cafeContext.Positions;
            cafe_dataGrid.DataSource = data;
        }

        private void sell_button_Click(object sender, System.EventArgs e)
        {

        }
    }
}
