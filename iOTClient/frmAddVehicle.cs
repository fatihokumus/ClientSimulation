using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iOTClient
{
    public partial class frmAddVehicle : Form
    {
        public string _code;

        public frmAddVehicle()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _code = ((ComboboxItem)cmbTransferVehicle.SelectedItem).Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAddVehicle_Load(object sender, EventArgs e)
        {
            GetTransferVehicles();
        }

        public void GetTransferVehicles()
        {
            WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/gettransfervehiclelist/" + frmMain._mapId);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));

            var getResponse = (HttpWebResponse)req.GetResponse();
            System.IO.Stream newStream = getResponse.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
            var result = sr.ReadToEnd();

            var transferVehicleS = JsonConvert.DeserializeObject<string>(result);

            var transferVehicleList = JsonConvert.DeserializeObject<List<ServerTransferVehicle>>(transferVehicleS);

            cmbTransferVehicle.Items.Clear();

            foreach (var item in transferVehicleList)
            {
                ComboboxItem cmb = new ComboboxItem();
                cmb.Text = item.fields.Barcode.ToString();
                cmb.Value = item.pk;

                cmbTransferVehicle.Items.Add(cmb);
            }
            if (transferVehicleList.Count() > 0)
                cmbTransferVehicle.SelectedIndex = 0;
        }

    }
}
