﻿using Newtonsoft.Json;
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
    public partial class frmAddTransferredObject : Form
    {
        public string _code;
        public string _taskorder;
        public int _startStationId;
        public int _centerX;
        public int _centerY;
        public int _length;


        public frmAddTransferredObject()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _code = txtCode.Text;
            _startStationId = (int)((ComboboxItem)cmbStartStation.SelectedItem).Value;
            _centerX = (int)((ComboboxItem)cmbStartStation.SelectedItem).CenterX;
            _centerY = (int)((ComboboxItem)cmbStartStation.SelectedItem).CenterY;
            _length = Convert.ToInt32(txtLength.Text);

            _taskorder = "";

            if (lbTaskOrder.Items.Count > 0)
            {
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
            else
            {
                MessageBox.Show("Please choose task order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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

            GetTransferVehicles();
            GetStartStations();
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

            
        }

        public void GetStartStations()
        {
            WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/getstartstationlist/" + frmMain._mapId);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));

            var getResponse = (HttpWebResponse)req.GetResponse();
            System.IO.Stream newStream = getResponse.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
            var result = sr.ReadToEnd();

            var startStationS = JsonConvert.DeserializeObject<string>(result);

            var startStationList = JsonConvert.DeserializeObject<List<ServerStartStation>>(startStationS);

            cmbStartStation.Items.Clear();

            foreach (var item in startStationList)
            {
                ComboboxItem cmb = new ComboboxItem();
                cmb.Text = "S" + item.fields.Code.ToString();
                cmb.Value = item.pk;
                cmb.CenterX = item.fields.CenterX;
                cmb.CenterY = item.fields.CenterY;

                cmbStartStation.Items.Add(cmb);
            }
            cmbStartStation.SelectedIndex = 0;
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
