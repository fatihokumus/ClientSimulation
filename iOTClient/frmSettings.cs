using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iOTClient
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Program._wslink = txtAdress.Text;
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtAdress.Text = Program._wslink;
        }
    }
}
