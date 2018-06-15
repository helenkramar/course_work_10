using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class main_Form : Form
    {
        public main_Form()
        {
            InitializeComponent();
        }

        private void cafe_button_Click(object sender, EventArgs e)
        {
            new cafe_Form().Show();
        }

        private void manufacture_button_Click(object sender, EventArgs e)
        {
            new manufacture_Form().Show();

        }
    }
}
