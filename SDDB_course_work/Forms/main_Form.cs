using System;
using System.Linq;
using System.Windows.Forms;

using DAL.EF;

namespace Forms
{
    public partial class main_Form : Form
    {
        private MetaContext context;

        private string connectionStr;

        public main_Form()
        {
            InitializeComponent();
            context = new MetaContext("Meta Context");

            var b = context.DataBases.First();
            var details = b.ConnectionDetails;

            var directory = @"C:\dbs";

            connectionStr = $@"Data source={details.Host};AttachDbFilename={directory}{details.DatabaseName};Integrated Security={details.IntegratedSecurity};";

            var p = new PositionContext(connectionStr);
            var l = p.Positions.ToList();
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
