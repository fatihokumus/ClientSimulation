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
    public partial class frmAddTransferredObject : Form
    {
        public string _code;
        public string _name;
        public int _width;
        public int _height;
        public string _taskorder;

        public frmAddTransferredObject()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _code = txtCode.Text;
            _name = txtName.Text;
            _width = Convert.ToInt32(txtWidth.Text);
            _height = Convert.ToInt32(txtHeigth.Text);

            _taskorder = "";
            for (int i = 0; i < lbTaskOrder.Items.Count; i++)
            {
                if (i < lbTaskOrder.Items.Count - 1)
                    _taskorder += lbTaskOrder.Items[i].ToString() + ",";
                else
                    _taskorder += lbTaskOrder.Items[i].ToString();

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAddTransferredObject_Load(object sender, EventArgs e)
        {
            foreach (var item in frmMain._workStationList)
            {
                lbWorkStation.Items.Add(item.Tag.ToString());
            }
        }

        private void btnToTaskOrder_Click(object sender, EventArgs e)
        {
            if (lbWorkStation.SelectedItems.Count > 0)
            {
                lbTaskOrder.Items.Add(lbWorkStation.SelectedItems[0]);
                lbWorkStation.Items.Remove(lbWorkStation.SelectedItems[0]);
            }
        }

        private void btnToWorkStation_Click(object sender, EventArgs e)
        {
            if (lbTaskOrder.SelectedItems.Count > 0)
            {
                lbWorkStation.Items.Add(lbTaskOrder.SelectedItems[0]);
                lbTaskOrder.Items.Remove(lbTaskOrder.SelectedItems[0]);
            }
        }
    }
}
