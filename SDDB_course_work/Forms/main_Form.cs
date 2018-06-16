using System;
using System.Linq;
using System.Windows.Forms;

using DAL.EF;

namespace Forms
{
    public partial class main_Form : Form
    {
        private MetaContext context;

        public main_Form()
        {
            InitializeComponent();
            context = new MetaContext("Meta Context");
        }

        private void cafe_button_Click(object sender, EventArgs e)
        {
            new cafe_Form().Show();
        }

        private void manufacture_button_Click(object sender, EventArgs e)
        {
            new manufacture_Form().Show();
        }

        private void main_Form_Load(object sender, EventArgs e)
        {
            var b = context.DataBases.ToList();
        }
    }
}
