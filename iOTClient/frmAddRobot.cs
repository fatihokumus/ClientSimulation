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
    public partial class frmAddRobot : Form
    {
        public string _code;

        public frmAddRobot()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _code = ((ComboboxItem)cmbRobot.SelectedItem).Text;
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
            GetRobots();
        }

        public void GetRobots()
        {
            WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/getrobotlist/" + frmMain._mapId);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));

            var getResponse = (HttpWebResponse)req.GetResponse();
            System.IO.Stream newStream = getResponse.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
            var result = sr.ReadToEnd();

            var robotS = JsonConvert.DeserializeObject<string>(result);

            var robotList = JsonConvert.DeserializeObject<List<ServerRobot>>(robotS);

            cmbRobot.Items.Clear();

            foreach (var item in robotList)
            {
                ComboboxItem cmb = new ComboboxItem();
                cmb.Text = item.fields.Code.ToString();
                cmb.Value = item.pk;

                cmbRobot.Items.Add(cmb);
            }
            cmbRobot.SelectedIndex = 0;
        }

    }
}
