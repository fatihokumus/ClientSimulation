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
    public partial class frmAddObject : Form
    {
        public string _code;
        public string _name;
        public int _width;
        public int _height;

        public frmAddObject()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _code = txtCode.Text;
            _name = txtName.Text;
            _width = Convert.ToInt32(txtWidth.Text);
            _height = Convert.ToInt32(txtHeigth.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
