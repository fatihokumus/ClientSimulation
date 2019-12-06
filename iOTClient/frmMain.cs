using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using WebSocketSharp;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading;
using System.ComponentModel;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace iOTClient
{
    public partial class frmMain : Form
    {
        bool formCreated = false;
        bool eOlustu = false;
        int gridSize = 0;
        int robotCount = 0;
        int goalCount = 0;
        int vehicleCount = 0;
        int transferredObjectCount = 0;
        int workStationCount = 0;
        int chargeSCount = 0;
        int waitingSCount = 0;
        int startSCount = 0;
        int finishSCount = 0;
        public static string _mapId = "0";


        List<RobotWebSocket> robotSocketList;
        List<PictureBox> _robotList;
        List<PictureBox> _goalList;
        List<PictureBox> _vehicleList;
        List<PictureBox> _transferredObjectList;
        public static List<PictureBox> _workStationList;
        List<PictureBox> _waitingSList;
        public static List<PictureBox> _startSList;
        List<PictureBox> _finishSList;
        List<PictureBox> _chargeSList;
        List<GoalPoint> _goalPointList;
        List<VehiclePoint> _vehiclePointList;
        List<TransferredObjectPoint> _transferredObjectPointList;
        List<WorkStationPoint> _workStationPointList;
        List<WaitingStationPoint> _waitingSPointList;
        List<ChargeStationPoint> _chargeSPointList;
        List<StartStationPoint> _startSPointList;
        List<FinishStationPoint> _finishSPointList;
        List<List<Node>> _nodes;
        List<List<GridPiont>> points;

        GridMap _map;

        bool ctrlPressed = false;
        string[] pressedPanel = null;

        private string _wslink = "ws://" + Program._wslink + "/robots/iot/";
        private string proxyUrl;

        public frmMain()
        {
            InitializeComponent();
            robotSocketList = new List<RobotWebSocket>();
            _nodes = new List<List<Node>>();
            _robotList = new List<PictureBox>();
            _goalList = new List<PictureBox>();
            _transferredObjectList = new List<PictureBox>();
            _vehicleList = new List<PictureBox>();
            _workStationList = new List<PictureBox>();
            _waitingSList = new List<PictureBox>();
            _chargeSList = new List<PictureBox>();
            _startSList = new List<PictureBox>();
            _finishSList = new List<PictureBox>();
            _goalPointList = new List<GoalPoint>();
            _transferredObjectPointList = new List<TransferredObjectPoint>();
            _vehiclePointList = new List<VehiclePoint>();
            _workStationPointList = new List<WorkStationPoint>();
            _waitingSPointList = new List<WaitingStationPoint>();
            _chargeSPointList = new List<ChargeStationPoint>();
            _startSPointList = new List<StartStationPoint>();
            _finishSPointList = new List<FinishStationPoint>();
            _map = new GridMap();
            _map.ObstaclePoints = new List<ObstaclePiont>();
            _map.WorkStationPoints = new List<WorkStationPoint>();
            _map.ChargeStationPoints = new List<ChargeStationPoint>();
            _map.WaitingStationPoints = new List<WaitingStationPoint>();
            _map.StartStationPoints = new List<StartStationPoint>();
            _map.FinishStationPoints = new List<FinishStationPoint>();
            points = new List<List<GridPiont>>();

        }

        public void DrawGrid(int x)
        {
            gridSize = x;
            pnlCenter.Controls.Clear();
            //Graphics g = this.pnlCenter.CreateGraphics();
            //g.Clear(Color.WhiteSmoke);
            //Pen p = new Pen(Color.Red, 1);

            var width = pnlCenter.Width - 10; //Padding 10 left and 10 right pixels
            var height = pnlCenter.Height - 10; //Padding 10 top and 10 bottom pixels



            int numX = width / x;
            int numY = height / x; ;

            for (int i = 0; i < numX; i++)
            {
                for (int j = 0; j < numY; j++)
                {
                    Panel pnl = new Panel();
                    var pX = (i * x) + (x / 2);
                    var pY = (j * x) + (x / 2);

                    pnl.Size = new Size(2, 2);
                    pnl.BorderStyle = BorderStyle.None;
                    pnl.BackColor = Color.Black;
                    pnl.MouseDown += new MouseEventHandler(this.Panel_MouseDown);
                    pnl.Location = new Point(pX, pY);
                    pnl.Tag = "label" + i.ToString() + "_" + j.ToString();
                    pnlCenter.Controls.Add(pnl);
                    pnl.SendToBack();

                    //g.DrawLine(p, pX - 1 + 10, pY + 10, pX + 1 + 10, pY + 10);
                    //g.DrawLine(p, pX + 10, pY - 1 + 10, pX + 10, pY + 1 + 10);
                }
            }


        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            var pnl = ((Panel)sender);
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                var keys = pnl.Tag.ToString().Replace("label", "").Split('_');

                if (ctrlPressed == false)
                {
                    ctrlPressed = true;
                    pressedPanel = keys;
                }
                else
                {
                    ctrlPressed = false;

                    var sx = Convert.ToInt32(pressedPanel[0]);
                    var sy = Convert.ToInt32(pressedPanel[1]);
                    var fx = Convert.ToInt32(keys[0]);
                    var fy = Convert.ToInt32(keys[1]);

                    PictureBox pObstacle = null;

                    foreach (var ctrl in pnlLeft.Controls)
                    {
                        if (ctrl.GetType() == typeof(PictureBox))
                        {
                            if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().Contains("Obstacle"))
                            {
                                pObstacle = ((PictureBox)ctrl);
                            }
                        }
                    }

                    for (int i = sx; i <= fx; i++)
                    {
                        for (int j = sy; j <= fy; j++)
                        {
                            var pX = i * gridSize;
                            var pY = j * gridSize;

                            PictureBox picture = new PictureBox();

                            picture.BackColor = pObstacle.BackColor;
                            picture.Tag = pObstacle.Tag;

                            picture.BorderStyle = BorderStyle.None;
                            picture.Location = new Point(pX, pY);

                            picture.Size = new Size(gridSize, gridSize);
                            picture.MouseDown += new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove += new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp += new MouseEventHandler(this.Object_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);
                        }
                    }

                    SetNodes();
                }
            }
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGridCreate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtX.Text);
            DrawGrid(x);
            _nodes = InitNodes();
            _map.Height = pnlCenter.Height;
            _map.Width = pnlCenter.Width;
            _map.Distance = x;
        }

        //public List<List<GridNode>> InitMap()
        //{
        //    List<List<GridNode>> result = new List<List<GridNode>>();

        //    for (int i = 0; i < pnlCenter.Width; i++)
        //    {
        //        List<GridNode> _row = new List<GridNode>(); 
        //        for (int j = 0; j < pnlCenter.Height; j++)
        //        {
        //            var local = new GridNode()
        //            {
        //                _point = new Point(i, j),
        //                isGoal = false,
        //                isRobot = false,
        //                isWall = false,
        //                isSpace = true
        //            };

        //            _row.Add(local);
        //        }
        //        result.Add(_row);
        //    }

        //    return result;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            pnlLeft.Height = this.Height;
            pnlTop.Width = this.Width - pnlLeft.Width;
            pnlCenterParent.Width = this.Width - pnlLeft.Width - 17;
            pnlCenterParent.Height = this.Height - pnlTop.Height - pnlBottom.Height - 35;
            pRobot.Draggable(true);
            pRobot.BringToFront();
            pObstacle.Draggable(true);
            pObstacle.BringToFront();
            pTransferredObject.Draggable(true);
            pTransferredObject.BringToFront();
            pWorkStation.Draggable(true);
            pWorkStation.BringToFront();
            pWaitingS.Draggable(true);
            pWaitingS.BringToFront();
            pChargeS.Draggable(true);
            pChargeS.BringToFront();
            pStartS.Draggable(true);
            pStartS.BringToFront();
            pFinishS.Draggable(true);
            pFinishS.BringToFront();
            pVehicle.Draggable(true);
            pVehicle.BringToFront();

            GetMapList();

            
        }
        public void GetMapList()
        {
            try
            {
                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/maplist/");
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));

                var getResponse = (HttpWebResponse)req.GetResponse();
                System.IO.Stream newStream = getResponse.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
                var result = sr.ReadToEnd();

                var mspS = JsonConvert.DeserializeObject<string>(result);

                var mspList = JsonConvert.DeserializeObject<List<ServerMap>>(mspS);

                foreach (var item in mspList)
                {
                    ComboboxItem cmb = new ComboboxItem();
                    cmb.Text = item.fields.Name;
                    cmb.Value = item.pk;
                    cmb.Distance = item.fields.Distance;

                    cbMap.Items.Add(cmb);
                }
                cbMap.SelectedIndex = 0;



                // MessageBox.Show("The map has been uploaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Object_MouseDown(object sender, MouseEventArgs e)
        {
            if (eOlustu == false)
            {
                if (sender.GetType() == typeof(PictureBox))
                {
                    PictureBox picture = new PictureBox();

                    if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("O"))
                    {
                        picture.BackColor = ((PictureBox)sender).BackColor;
                        picture.Tag = "O";
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("R"))
                    {
                        robotCount++;
                        ((PictureBox)sender).Tag = "R" + robotCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "R";
                        picture.Paint += new PaintEventHandler(this.pRobot_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("G"))
                    {
                        goalCount++;
                        ((PictureBox)sender).Tag = "G" + goalCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "G";

                        picture.Paint += new PaintEventHandler(this.pGoal_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("T"))
                    {
                        transferredObjectCount++;
                        ((PictureBox)sender).Tag = "T" + transferredObjectCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "T";

                        picture.Paint += new PaintEventHandler(this.pTransferredObject_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("V"))
                    {
                        vehicleCount++;
                        ((PictureBox)sender).Tag = "V" + vehicleCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "V";

                        picture.Paint += new PaintEventHandler(this.pVehicle_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("M"))
                    {
                        workStationCount++;
                        ((PictureBox)sender).Tag = "M" + workStationCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "M";

                        picture.Paint += new PaintEventHandler(this.pWorkStation_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("C"))
                    {
                        chargeSCount++;
                        ((PictureBox)sender).Tag = "C" + chargeSCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "C";

                        //picture.Paint += new PaintEventHandler(this.pGoal_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("W"))
                    {
                        waitingSCount++;
                        ((PictureBox)sender).Tag = "W" + waitingSCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "W";

                        // picture.Paint += new PaintEventHandler(this.pGoal_Paint);
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("S"))
                    {
                        startSCount++;
                        ((PictureBox)sender).Tag = "S" + startSCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "S";

                        // picture.Paint += new PaintEventHandler(this.pGoal_Paint);
                    }

                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().StartsWith("F"))
                    {
                        finishSCount++;
                        ((PictureBox)sender).Tag = "F" + finishSCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "F";

                        // picture.Paint += new PaintEventHandler(this.pGoal_Paint);
                    }

                    picture.BorderStyle = BorderStyle.None;

                    picture.Location = ((PictureBox)sender).Location;
                    picture.Size = ((PictureBox)sender).Size;
                    picture.Image = ((PictureBox)sender).Image;
                    picture.MouseDown += new MouseEventHandler(this.Object_MouseDown);
                    picture.MouseMove += new MouseEventHandler(this.Object_MouseMove);
                    picture.MouseUp += new MouseEventHandler(this.Object_MouseUp);
                    picture.ContextMenuStrip = cmObject;
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    pnlCenter.SendToBack();
                    pnlLeft.SendToBack();

                    pnlLeft.Controls.Add(picture);
                    picture.BringToFront();
                    this.Controls.Add(((PictureBox)sender));
                    ((PictureBox)sender).BringToFront();
                    picture.Draggable(true);

                }
            }
            eOlustu = true;
        }

        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            //lblX.Text = ((PictureBox)sender).Left.ToString();
            //lblY.Text = ((PictureBox)sender).Top.ToString();
        }

        private void Object_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {
                PictureBox obj = ((PictureBox)sender);
                eOlustu = false;

                if (gridSize <= 0)
                {
                    MessageBox.Show("Please Create Distance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    robotCount = 0;
                    goalCount = 0;
                    transferredObjectCount = 0;
                    vehicleCount = 0;
                    workStationCount = 0;
                    chargeSCount = 0;
                    waitingSCount = 0;
                    obj.Dispose();
                }
                else
                {

                    int x = Convert.ToInt32(txtX.Text);
                    int carpanLeft = (obj.Left - pnlLeft.Width) / x;
                    int carpanTop = (obj.Top - pnlTop.Height) / x;

                    int leftPos = (obj.Left - pnlLeft.Width) > (carpanLeft * x + x / 2) ? x * (carpanLeft + 1) : x * carpanLeft;
                    int topPos = (obj.Top - pnlTop.Height) > (carpanTop * x + x / 2) ? x * (carpanTop + 1) : x * carpanTop;

                    if (leftPos < 0 || topPos < 0) // harita içinde deðilse sil
                    {
                        if (obj.Tag != null && obj.Tag.ToString().StartsWith("R"))
                        {
                            robotCount--;
                            obj.Dispose();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("G"))
                        {
                            goalCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("T"))
                        {
                            transferredObjectCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("M"))
                        {
                            workStationCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("W"))
                        {
                            waitingSCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("C"))
                        {
                            chargeSCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("S"))
                        {
                            startSCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("F"))
                        {
                            finishSCount--;
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("V"))
                        {
                            vehicleCount--;
                        }

                        obj.Dispose();
                    }
                    else
                    {
                        obj.Location = new Point(leftPos, topPos);

                        if (obj.Tag != null && obj.Tag.ToString().StartsWith("O"))
                        {
                            obj.Size = new Size(gridSize, gridSize);
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("R"))
                        {
                            frmAddRobot frm = new frmAddRobot();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Paint -= new PaintEventHandler(this.pRobot_Paint);
                                
                                obj.Image = global::iOTClient.Properties.Resources.turtlebot_2_lg_free;
                                obj.Paint += new PaintEventHandler(picture_Paint);
                                obj.Size = new Size(x, Convert.ToInt32(x * 1.2));
                                obj.Tag = frm._code.StartsWith("R")? frm._code : ("R" + frm._code);
                                WebSocket ws = null;

                                _robotList.Add(obj);

                                WsConnectSayHi(ws, obj.Tag.ToString(), obj.Location);
                            }
                            else
                                obj.Dispose();
                               
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("G"))
                        {
                            obj.Paint -= new PaintEventHandler(this.pGoal_Paint);
                            //obj.Image = null;
                            obj.Image = global::iOTClient.Properties.Resources.goal_free;
                            obj.Paint += new PaintEventHandler(picture_Paint);
                            obj.Size = new Size(x, Convert.ToInt32(x * 1.4));
                            _goalList.Add(obj);

                            _goalPointList.Add(
                                new GoalPoint()
                                {
                                    Code = obj.Tag.ToString(),
                                    Left = obj.Left,
                                    Bottom = obj.Bottom,
                                    Right = obj.Right,
                                    Top = obj.Top
                                }
                                );
                            SendGoalToServer();
                            WsConnectLoadGoals();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("V"))
                        {
                            obj.Paint -= new PaintEventHandler(this.pVehicle_Paint);
                            //obj.Image = null;
                            obj.Image = global::iOTClient.Properties.Resources.bos_dok_arabasi;
                            obj.Paint += new PaintEventHandler(picture_Paint);
                            obj.Size = new Size(x, x);
                            _vehicleList.Add(obj);

                            frmAddVehicle frm = new frmAddVehicle();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                _vehiclePointList.Add(
                                new VehiclePoint()
                                {
                                    Code = frm._code,
                                    Left = obj.Left,
                                    Bottom = obj.Bottom,
                                    Right = obj.Right,
                                    Top = obj.Top,
                                    CenterX = obj.Right - (x / 2),
                                    CenterY = obj.Bottom - (x / 2)
                                }
                                );

                                obj.Tag = frm._code;
                                WebSocket ws = null;

                                WsConnectSayHi(ws, obj.Tag.ToString(), obj.Location);
                            }
                            else
                            {
                                obj.Dispose();
                            }
                                
                           
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("T"))
                        {
                            frmAddTransferredObject frm = new frmAddTransferredObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Paint -= new PaintEventHandler(this.pTransferredObject_Paint);
                                obj.Image = global::iOTClient.Properties.Resources.kumas;
                                obj.Paint += new PaintEventHandler(picture_Paint);
                                obj.Size = new Size(x, Convert.ToInt32(x * 1.2));
                                obj.Tag = "T" + frm._code;

                                _transferredObjectList.Add(obj);

                                _transferredObjectPointList.Add(
                                 new TransferredObjectPoint()
                                 {
                                     Code = obj.Tag.ToString(),
                                     Left = obj.Left,
                                     Bottom = obj.Bottom,
                                     Right = obj.Right,
                                     Top = obj.Top,
                                     TaskOrder = frm._taskorder
                                 }
                                 );

                                // Send TransferObject to Server

                                var entity = new TransferObject()
                                {
                                    Barcode = frm._code,
                                    LastPosX = frm._centerX,
                                    LastPosY = frm._centerY,
                                    MapId = Convert.ToInt32(_mapId),
                                    isNewObject = true,
                                    Length = frm._length,
                                    StartStationId = frm._startStationId,
                                    TaskHistories = new List<TaskHistory>()
                                };

                                obj.Location = new Point(frm._centerX, frm._centerY);

                                var workOrders = frm._taskorder.Split(',');

                                int _order = 1;
                                foreach (var item in workOrders)
                                {
                                    var history = new TaskHistory()
                                    {
                                        WorkOrder = _order,
                                        WorkStationCode = item.Replace("M","")
                                    };
                                    entity.TaskHistories.Add(history);
                                    _order++;
                                }

                                string json = JsonConvert.SerializeObject(entity);
                                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/addtransferobject/");
                                req.Method = "POST";
                                req.ContentType = "application/json";
                                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));
                                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                                req.ContentLength = byteArray.Length;

                                using (System.IO.Stream requestStream = req.GetRequestStream())
                                {
                                    requestStream.Write(byteArray, 0, byteArray.Length);
                                }

                                using (WebResponse response = req.GetResponse())
                                {
                                    using (System.IO.Stream responseStream = response.GetResponseStream())
                                    {
                                        System.IO.StreamReader rdr = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                                        string Json = rdr.ReadToEnd(); // response from server
                                    }
                                }

                                WsConnectLoadTransferObjects();
                            }
                            else
                                obj.Dispose();


                            WebSocket ws = null;
                            WsConnectSayHi(ws, obj.Tag.ToString(), obj.Location);
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("M"))
                        {
                            
                            obj.Paint -= new PaintEventHandler(this.pWorkStation_Paint);
                            obj.Image = global::iOTClient.Properties.Resources.machine_free;
                            obj.SizeMode = PictureBoxSizeMode.CenterImage;
                            obj.BackColor = Color.LightGray;
                            


                            frmAddObject frm = new frmAddObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Size = new Size(x * frm._width, x * frm._height);
                                _workStationList.Add(obj);

                                if (_workStationPointList.Where(w => w.Code == ("M" + frm._code)).Count() > 1)
                                {
                                    MessageBox.Show("There is another object with same code. Please try again.");
                                    obj.Dispose();
                                }
                                else
                                {
                                    obj.Tag = "M" + frm._code;
                                    _workStationPointList.Add(
                                    new WorkStationPoint()
                                    {
                                        Code = frm._code,
                                        Name = frm._name,
                                        isActive = true,
                                        EnterPosX = obj.Left,
                                        EnterPosY = obj.Top,
                                        ExitPosX = obj.Left,
                                        ExitPosY = obj.Bottom,
                                        Position = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                                    + "]",

                                    }
                                    );

                                    obj.Name = "M" + frm._code;

                                    obj.Paint += new PaintEventHandler(picture_Paint);
                                }
                            }
                            else
                            {
                                obj.Dispose();
                            }


                            //SendGoalToServer();
                            //WsConnectLoadGoals();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("C"))
                        {
                            _chargeSList.Add(obj);
                            obj.Image = global::iOTClient.Properties.Resources.ChargeSatationFree;


                            frmAddObject frm = new frmAddObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Size = new Size(x * frm._width, x * frm._height);
                                if (_chargeSPointList.Where(w => w.Code == ("C" + frm._code)).Count() > 1)
                                {
                                    MessageBox.Show("There is another object with same code. Please try again.");
                                    obj.Dispose();
                                }
                                else
                                {
                                    obj.Tag = "C" + frm._code;
                                    _chargeSPointList.Add(
                                    new ChargeStationPoint()
                                    {
                                        Code = frm._code,
                                        Name = frm._name,
                                        isActive = true,
                                        isFull = false,
                                        Position = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                                    + "]",
                                        CenterX = obj.Right - (x / 2),
                                        CenterY = obj.Bottom - (x / 2)
                                    }
                                    );

                                    obj.Name = "C" + frm._code;

                                    obj.Paint += new PaintEventHandler(picture_Paint);
                                }
                            }
                            else
                            {
                                obj.Dispose();
                            }

                            //SendGoalToServer();
                            //WsConnectLoadGoals();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("W"))
                        {
                            _waitingSList.Add(obj);
                            obj.Image = global::iOTClient.Properties.Resources.WaitingStationFree;



                            frmAddObject frm = new frmAddObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Size = new Size(x * frm._width, x * frm._height);
                                if (_waitingSPointList.Where(w => w.Code == ("W" + frm._code)).Count() > 1)
                                {
                                    MessageBox.Show("There is another object with same code. Please try again.");
                                    obj.Dispose();
                                }
                                else
                                {
                                    obj.Tag = "W" + frm._code;
                                    _waitingSPointList.Add(
                                    new WaitingStationPoint()
                                    {
                                        Code = frm._code,
                                        Name = frm._name,
                                        isActive = true,
                                        isFull = false,
                                        Position = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                                  + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "},"
                                                    + "]",
                                        CenterX = obj.Right - (x / 2),
                                        CenterY = obj.Bottom - (x / 2)
                                    }
                                    );

                                    obj.Name = "W" + frm._code;

                                    obj.Paint += new PaintEventHandler(picture_Paint);
                                }
                            }
                            else
                            {
                                obj.Dispose();
                            }


                            //SendGoalToServer();
                            //WsConnectLoadGoals();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("S"))
                        {
                            _startSList.Add(obj);
                            obj.Image = global::iOTClient.Properties.Resources.StartStationFree;



                            frmAddObject frm = new frmAddObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Size = new Size(x * frm._width, x * frm._height);
                                if (_startSPointList.Where(w => w.Code == ("S" + frm._code)).Count() > 1)
                                {
                                    MessageBox.Show("There is another object with same code. Please try again.");
                                    obj.Dispose();
                                }
                                else
                                {
                                    obj.Tag = "S" + frm._code;
                                    _startSPointList.Add(
                                    new StartStationPoint()
                                    {
                                        Code = frm._code,
                                        Name = frm._name,
                                        isActive = true,
                                        isFull = false,
                                        Position = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                                  + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "},"
                                                    + "]",
                                        CenterX = obj.Right - (x / 2),
                                        CenterY = obj.Bottom - (x / 2)
                                    }
                                    );

                                    obj.Name = "S" + frm._code;

                                    obj.Paint += new PaintEventHandler(picture_Paint);
                                }
                            }
                            else
                            {
                                obj.Dispose();
                            }


                            //SendGoalToServer();
                            //WsConnectLoadGoals();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().StartsWith("F"))
                        {
                            _finishSList.Add(obj);
                            obj.Image = global::iOTClient.Properties.Resources.FinishStationFree;



                            frmAddObject frm = new frmAddObject();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                obj.Size = new Size(x * frm._width, x * frm._height);
                                if (_finishSPointList.Where(w => w.Code == ("F" + frm._code)).Count() > 1)
                                {
                                    MessageBox.Show("There is another object with same code. Please try again.");
                                    obj.Dispose();
                                }
                                else
                                {
                                    obj.Tag = "F" + frm._code;
                                    _finishSPointList.Add(
                                    new FinishStationPoint()
                                    {
                                        Code = frm._code,
                                        Name = frm._name,
                                        isActive = true,
                                        isFull = false,
                                        Position = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                                  + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                                  + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "},"
                                                    + "]",
                                        CenterX = obj.Right - (x / 2),
                                        CenterY = obj.Bottom - (x / 2)
                                    }
                                    );

                                    obj.Name = "F" + frm._code;

                                    obj.Paint += new PaintEventHandler(picture_Paint);
                                }
                            }
                            else
                            {
                                obj.Dispose();
                            }


                            //SendGoalToServer();
                            //WsConnectLoadGoals();
                        }


                        obj.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                        obj.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                        obj.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                        obj.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);

                        pnlCenter.Controls.Add(obj);
                        obj.BringToFront();

                        SetNodes();
                        //SendMapToServer();
                    }


                }

            }


            //var loc = ((PictureBox)sender).Location;

            //var basX = pnlCenter.Left;
            //var basY = pnlCenter.Top;
            //var bitX = pnlCenter.Right;
            //var bitY = pnlCenter.Bottom;


            //var objBasX = obj.Left;
            //var objBasY = obj.Top;
            //var objBitX = obj.Right;
            //var objBitY = obj.Bottom;


            ////            if(((PictureBox)sender).Location.)

            //if (objBitX >= basX && objBasX <= bitX && objBitY >= basY && objBasY <= bitY)
            //{
            //    foreach (var item in pnlCenter.Controls)
            //    {
            //        if (item.GetType() == typeof(PictureBox))
            //        {

            //            var itemBasX = basX + ((PictureBox)item).Left;
            //            var itemBasY = basY + ((PictureBox)item).Top;
            //            var itemBitX = basX + ((PictureBox)item).Right;
            //            var itemBitY = basY + ((PictureBox)item).Bottom;




            //            var itemWidth = ((PictureBox)item).Width;
            //            var itemHeight = ((PictureBox)item).Height;

            //            int objAlan = 0;
            //            if (itemBasY > objBasY && (itemBasY - objBasY) <= 47 && itemBasX < objBasX && (objBasX - itemBasX) <= 50) // sol alt köþe
            //                objAlan = Math.Abs(itemBitX - objBasX) * Math.Abs(itemBasY - objBitY);
            //            else if (itemBasY <= objBasY && (objBasY - itemBasY) <= 47 && itemBasX < objBasX && (objBasX - itemBasX) <= 50) // sol üst köþe
            //                objAlan = Math.Abs(itemBitX - objBasX) * Math.Abs(objBasY - itemBitY);
            //            else if (itemBasY > objBasY && (itemBasY - objBasY) <= 47 && itemBasX >= objBasX && (itemBasX - objBasX) <= 50) // sað alt köþe
            //                objAlan = Math.Abs(objBitX - itemBasX) * Math.Abs(itemBasY - objBitY);
            //            else if (itemBasY <= objBasY && (objBasY - itemBasY) <= 47 && itemBasX >= objBasX && (itemBasX - objBasX) <= 50) // sað üst köþe
            //                objAlan = Math.Abs(objBitX - itemBasX) * Math.Abs(objBasY - itemBitY);


            //            if (objAlan > 0 && objAlan >= (itemWidth * itemWidth) / 2)
            //            {

            //                if (itemBasX == 339 && itemBasY == 189)
            //                {
            //                }

            //                ((PictureBox)item).BackColor = ((PictureBox)sender).BackColor;
            //                ((PictureBox)item).ContextMenuStrip = cmObject;

            //                //HaritaGonderAsync();
            //            }


            //        }
            //    }
            //}

            //pnlCenter.Controls.Add(obj);
            //obj.Dispose();

        }

        private void ObjectonMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {
                PictureBox obj = ((PictureBox)sender);

                int x = Convert.ToInt32(txtX.Text);
                int carpanLeft = obj.Left / x;
                int carpanTop = obj.Top / x;

                int leftPos = obj.Left > (carpanLeft * x + x / 2) ? x * (carpanLeft + 1) : x * carpanLeft;
                int topPos = obj.Top > (carpanTop * x + x / 2) ? x * (carpanTop + 1) : x * carpanTop;

                obj.Location = new Point(leftPos, topPos);


                if (obj.Tag != null && ( obj.Tag.ToString().StartsWith("R") || obj.Tag.ToString().StartsWith("V")))
                {
                    var ws = robotSocketList.Where(w => w.name == obj.Tag.ToString()).First()._ws;

                    string textKonum = "{\"message\":\"Son Konumum: x:" + obj.Location.X + "; y:" + obj.Location.Y + "\"}";
                    ws.SendAsync(textKonum, delegate (bool completed) { });
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("G"))
                {
                    _goalPointList.Clear();
                    foreach (var item in pnlCenter.Controls)
                    {
                        if (item.GetType() == typeof(PictureBox) && ((PictureBox)item).Tag.ToString().StartsWith("G"))
                        {
                            _goalPointList.Add(
                                new GoalPoint()
                                {
                                    Code = ((PictureBox)item).Tag.ToString(),
                                    Left = ((PictureBox)item).Left,
                                    Bottom = ((PictureBox)item).Bottom,
                                    Right = ((PictureBox)item).Right,
                                    Top = ((PictureBox)item).Top
                                }
                            );
                        }
                    }
                    SendGoalToServer();
                    WsConnectLoadGoals();
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("T"))
                {
                    _goalPointList.Clear();
                    foreach (var item in pnlCenter.Controls)
                    {
                        if (item.GetType() == typeof(PictureBox) && ((PictureBox)item).Tag.ToString().StartsWith("T"))
                        {
                            _goalPointList.Add(
                                new GoalPoint()
                                {
                                    Code = ((PictureBox)item).Tag.ToString(),
                                    Left = ((PictureBox)item).Left,
                                    Bottom = ((PictureBox)item).Bottom,
                                    Right = ((PictureBox)item).Right,
                                    Top = ((PictureBox)item).Top
                                }
                            );
                        }
                    }
                    SendGoalToServer();
                    WsConnectLoadGoals();
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("M"))
                {
                    string pos = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                    + "]";
                    
                    _workStationPointList.Where(w => w.Code == obj.Name.Replace("M", "")).ToList().ForEach(f =>  { f.Position = pos; f.EnterPosX = obj.Left; f.EnterPosY = obj.Top; f.ExitPosX = obj.Left; f.ExitPosY = obj.Bottom; });
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("W"))
                {
                    var centerX = obj.Right - (x / 2);
                    var centerY = obj.Bottom - (x / 2);
                    string pos = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                    + "]";
                    _waitingSPointList.Where(w => w.Code == obj.Name).ToList().ForEach(f => { f.Position = pos; f.CenterX = centerX; f.CenterY = centerY; });
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("C"))
                {
                    var centerX = obj.Right - (x / 2);
                    var centerY = obj.Bottom - (x / 2);
                    string pos = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                    + "]";
                    _chargeSPointList.Where(w => w.Code == obj.Name).ToList().ForEach(f => { f.Position = pos; f.CenterX = centerX; f.CenterY = centerY; });
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("S"))
                {
                    var centerX = obj.Right - (x / 2);
                    var centerY = obj.Bottom - (x / 2);
                    string pos = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                    + "]";
                    _startSPointList.Where(w => w.Code == obj.Name).ToList().ForEach(f => { f.Position = pos; f.CenterX = centerX; f.CenterY = centerY; });
                }
                else if (obj.Tag != null && obj.Tag.ToString().StartsWith("F"))
                {
                    var centerX = obj.Right - (x / 2);
                    var centerY = obj.Bottom - (x / 2);
                    string pos = "[{" + obj.Left.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Top.ToString() + "},"
                                    + "{" + obj.Right.ToString() + "," + obj.Bottom.ToString() + "},"
                                    + "{" + obj.Left.ToString() + "," + obj.Bottom.ToString() + "}"
                                    + "]";
                    _finishSPointList.Where(w => w.Code == obj.Name).ToList().ForEach(f => { f.Position = pos; f.CenterX = centerX; f.CenterY = centerY; });
                }
            }


            //var loc = ((PictureBox)sender).Location;

            //var basX = pnlCenter.Left;
            //var basY = pnlCenter.Top;
            //var bitX = pnlCenter.Right;
            //var bitY = pnlCenter.Bottom;


            //var objBasX = obj.Left;
            //var objBasY = obj.Top;
            //var objBitX = obj.Right;
            //var objBitY = obj.Bottom;


            ////            if(((PictureBox)sender).Location.)

            //if (objBitX >= basX && objBasX <= bitX && objBitY >= basY && objBasY <= bitY)
            //{
            //    foreach (var item in pnlCenter.Controls)
            //    {
            //        if (item.GetType() == typeof(PictureBox))
            //        {

            //            var itemBasX = basX + ((PictureBox)item).Left;
            //            var itemBasY = basY + ((PictureBox)item).Top;
            //            var itemBitX = basX + ((PictureBox)item).Right;
            //            var itemBitY = basY + ((PictureBox)item).Bottom;




            //            var itemWidth = ((PictureBox)item).Width;
            //            var itemHeight = ((PictureBox)item).Height;

            //            int objAlan = 0;
            //            if (itemBasY > objBasY && (itemBasY - objBasY) <= 47 && itemBasX < objBasX && (objBasX - itemBasX) <= 50) // sol alt köþe
            //                objAlan = Math.Abs(itemBitX - objBasX) * Math.Abs(itemBasY - objBitY);
            //            else if (itemBasY <= objBasY && (objBasY - itemBasY) <= 47 && itemBasX < objBasX && (objBasX - itemBasX) <= 50) // sol üst köþe
            //                objAlan = Math.Abs(itemBitX - objBasX) * Math.Abs(objBasY - itemBitY);
            //            else if (itemBasY > objBasY && (itemBasY - objBasY) <= 47 && itemBasX >= objBasX && (itemBasX - objBasX) <= 50) // sað alt köþe
            //                objAlan = Math.Abs(objBitX - itemBasX) * Math.Abs(itemBasY - objBitY);
            //            else if (itemBasY <= objBasY && (objBasY - itemBasY) <= 47 && itemBasX >= objBasX && (itemBasX - objBasX) <= 50) // sað üst köþe
            //                objAlan = Math.Abs(objBitX - itemBasX) * Math.Abs(objBasY - itemBitY);


            //            if (objAlan > 0 && objAlan >= (itemWidth * itemWidth) / 2)
            //            {

            //                if (itemBasX == 339 && itemBasY == 189)
            //                {
            //                }

            //                ((PictureBox)item).BackColor = ((PictureBox)sender).BackColor;
            //                ((PictureBox)item).ContextMenuStrip = cmObject;

            //                //HaritaGonderAsync();
            //            }


            //        }
            //    }
            //}

            //pnlCenter.Controls.Add(obj);
            //obj.Dispose();

        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                var text = ((PictureBox)sender).Tag.ToString();
                e.Graphics.DrawString(text, font, Brushes.Black, 0, -2);
            }
        }

        private void tsSil_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuSubmitted = sender as ToolStripMenuItem;
            if (menuSubmitted != null)
            {
                var obj = ((PictureBox)((ContextMenuStrip)menuSubmitted.Owner).SourceControl);
                if (robotSocketList.Count > 0)
                {
                    var ws = robotSocketList.Where(w => w.name == obj.Tag.ToString()).FirstOrDefault();
                    if (ws != null)
                    {
                        ws._ws.Close();
                        robotSocketList.Remove(ws);
                    }
                }
                obj.Dispose();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnClearPanel_Click(object sender, EventArgs e)
        {
            pnlCenter.Controls.Clear();
            gridSize = 0;
            robotCount = 0;
            goalCount = 0;
            transferredObjectCount = 0;
            vehicleCount = 0;
            workStationCount = 0;
            chargeSCount = 0;
            waitingSCount = 0;
        }

        private void btnMotionPlan_Click(object sender, EventArgs e)
        {
            if (!bgMotionPlan.IsBusy)
                bgMotionPlan.RunWorkerAsync();
            else
                MessageBox.Show("Þu anda çalýþan bir iþ parçacýðý bulunmaktadýr. Lütfen bitmesini bekleyiniz");
        }

        private void bgMotionPlan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int fromX = 0, fromY = 0, toX = 0, toY = 0;


            fromX = _robotList[0].Left + ((_robotList[0].Right - _robotList[0].Left) / 2);
            fromY = _robotList[0].Top + ((_robotList[0].Bottom - _robotList[0].Top) / 2);

            toX = _goalList[0].Left + ((_goalList[0].Right - _goalList[0].Left) / 2);
            toY = _goalList[0].Top + ((_goalList[0].Bottom - _goalList[0].Top) / 2);


            var path2 = AStar.FindPath(ref _nodes, _nodes[fromX][fromY], _nodes[toX][toY]);

            //pnlCenter.Invoke(new Action(() =>
            //{
            //    ExtendedPanel pnl = new ExtendedPanel(path2);
            //    pnl.Size = pnlCenter.Size;
            //    pnl.Location = new Point(0, 0);

            //    pnlCenter.Controls.Add(pnl);
            //    pnl.BringToFront();
            //}));


        }

        public void SetNodes()
        {
            _map.ObstaclePoints.Clear();

            _map.WorkStationPoints = _workStationPointList;

            _map.ChargeStationPoints = _chargeSPointList;

            _map.WaitingStationPoints = _waitingSPointList;

            _map.StartStationPoints = _startSPointList;

            _map.FinishStationPoints = _finishSPointList;

            foreach (var item in pnlCenter.Controls)
            {
                if (item.GetType() == typeof(PictureBox))
                {
                    var obj = (PictureBox)item;
                    int dist = Convert.ToInt32(txtX.Text);
                    if (obj.Tag != null && obj.Tag.ToString().StartsWith("O"))
                    {
                        _map.ObstaclePoints.Add(new ObstaclePiont()
                        {
                            Left = obj.Left,
                            Right = obj.Right,
                            Bottom = obj.Bottom,
                            Top = obj.Top,
                            CenterX = obj.Left / dist,
                            CenterY = obj.Top / dist
                        });

                        var l = obj.Left - 15 < 0 ? 0 : obj.Left - 15;
                        var r = obj.Right + 15 >= pnlCenter.Width ? pnlCenter.Width - 1 : obj.Right + 15;
                        var t = obj.Top - 15 < 0 ? 0 : obj.Top - 15;
                        var b = obj.Bottom + 15 >= pnlCenter.Height ? pnlCenter.Height - 1 : obj.Bottom + 15;

                        for (int j = t; j < b; j++)
                        {
                            _nodes[l][j].isWall = true;
                        }

                        for (int j = t; j < b; j++)
                        {
                            _nodes[r - 1][j].isWall = true;
                        }

                        //üst çizgi
                        for (int j = l; j < r; j++)
                        {
                            _nodes[j][t].isWall = true;
                        }

                        // right line
                        for (int j = l; j < r; j++)
                        {
                            _nodes[j][b - 1].isWall = true;
                        }

                    }

                }

            }
        }

        private void btnClearPath_Click(object sender, EventArgs e)
        {
            foreach (var item in pnlCenter.Controls)
            {
                if (item.GetType() == typeof(ExtendedPanel))
                {
                    ((ExtendedPanel)item).Dispose();
                }
            }
        }

        private List<List<Node>> InitNodes()
        {

            List<List<Node>> nodes = new List<List<Node>>();
            for (int x = 0; x < pnlCenter.Width; x++)
            {
                List<Node> nX = new List<Node>();
                for (int y = 0; y < pnlCenter.Height; y++)
                {
                    Node nY = new Node();
                    nY.Pos = new Point(x, y);

                    if (y > 0)
                    {
                        nY.Up = nX[y - 1];
                        nX[y - 1].Down = nY;
                    }
                    //Left
                    if (x > 0)
                    {
                        nY.Left = nodes[x - 1][y];
                        nodes[x - 1][y].Right = nY;
                    }
                    //UpLeft
                    if (x > 0 && y > 0)
                    {
                        nY.ULeft = nodes[x - 1][y - 1];
                        nodes[x - 1][y - 1].DRight = nY;
                    }
                    //DownLeft
                    if (x > 0 && y < (pnlCenter.Height - 1))
                    {
                        nY.DLeft = nodes[x - 1][y + 1];
                        nodes[x - 1][y + 1].URight = nY;
                    }
                    nX.Add(nY);
                }
                nodes.Add(nX);
            }

            return nodes;
        }

        public void SendMapToServer()
        {
            try
            {
                MessageBox.Show("This will take a little time. Please wait", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetNodes();

                _map.MapId = Convert.ToInt32(((ComboboxItem)cbMap.SelectedItem).Value);
                string json = JsonConvert.SerializeObject(_map);
                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/maplist/");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                req.ContentLength = byteArray.Length;

                using (System.IO.Stream requestStream = req.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                using (WebResponse response = req.GetResponse())
                {
                    using (System.IO.Stream responseStream = response.GetResponseStream())
                    {
                        System.IO.StreamReader rdr = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd(); // response from server
                    }
                }
                MessageBox.Show("The map has been uploaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void WsConnectSayHi(WebSocket ws, string roomName, Point p)
        {
            try
            {
                if (ws != null && ws.IsAlive)
                {
                    return;
                }

                var link = _wslink + roomName + "/";
                ws = new WebSocket(link);

                //ws.SetHeaders(headers);
                proxyUrl = null;
                ws.SetProxy(proxyUrl, string.Empty, string.Empty);
                ws.OnError += Ws_OnError;
                ws.OnClose += Ws_OnClose;
                ws.OnMessage += Ws_OnMessage;
                ws.OnOpen += Ws_OnOpen;

                ws.Connect();

                robotSocketList.Add(new RobotWebSocket() { name = roomName, _ws = ws });

                string textMerhaba = "{\"message\":\"Merhaba\"}";
                ws.SendAsync(textMerhaba, delegate (bool completed)
                {
                    if (completed)
                    {
                        string textName = "{\"message\":\"Benim adým:" + roomName + "\"}";
                        ws.SendAsync(textName, delegate (bool completed2)
                        {
                            if (completed2)
                            {
                                string textKonum = "{\"message\":\"Son Konumum: x:" + p.X + "; y:" + p.Y + "\"}";
                                ws.SendAsync(textKonum, delegate (bool completed3) {
                                });
                            }
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendGoalToServer()
        {
            try
            {
                MapGoals mapGoals = new MapGoals();
                mapGoals.MapId = Convert.ToInt32(((ComboboxItem)cbMap.SelectedItem).Value);
                mapGoals.GoalPoints = _goalPointList;

                string json = JsonConvert.SerializeObject(mapGoals);
                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/goallist/");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                req.ContentLength = byteArray.Length;

                using (System.IO.Stream requestStream = req.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                using (WebResponse response = req.GetResponse())
                {
                    using (System.IO.Stream responseStream = response.GetResponseStream())
                    {
                        System.IO.StreamReader rdr = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd(); // response from server
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void SendTransferredObjectToServer()
        {
            try
            {
                MapGoals mapGoals = new MapGoals();
                mapGoals.MapId = Convert.ToInt32(((ComboboxItem)cbMap.SelectedItem).Value);
                mapGoals.GoalPoints = _goalPointList;

                string json = JsonConvert.SerializeObject(mapGoals);
                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/goallist/");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                req.ContentLength = byteArray.Length;

                using (System.IO.Stream requestStream = req.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                using (WebResponse response = req.GetResponse())
                {
                    using (System.IO.Stream responseStream = response.GetResponseStream())
                    {
                        System.IO.StreamReader rdr = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd(); // response from server
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void WsConnectLoadGoals()
        {
            try
            {
                var link = _wslink + "loadgoal/";
                WebSocket ws = new WebSocket(link);

                //ws.SetHeaders(headers);
                proxyUrl = null;
                ws.SetProxy(proxyUrl, string.Empty, string.Empty);
                ws.OnError += Ws_OnError;
                ws.OnClose += Ws_OnClose;
                ws.OnMessage += Ws_OnMessage;
                ws.OnOpen += Ws_OnOpen;

                ws.Connect();

                string textMerhaba = "{\"message\":\"Load Goals\"}";
                ws.SendAsync(textMerhaba, delegate (bool completed) { });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WsConnectLoadTransferObjects()
        {
            try
            {
                var link = _wslink + "loadtransferobjects/";
                WebSocket ws = new WebSocket(link);

                //ws.SetHeaders(headers);
                proxyUrl = null;
                ws.SetProxy(proxyUrl, string.Empty, string.Empty);
                ws.OnError += Ws_OnError;
                ws.OnClose += Ws_OnClose;
                ws.OnMessage += Ws_OnMessage;
                ws.OnOpen += Ws_OnOpen;

                ws.Connect();

                string textMerhaba = "{\"message\":\"Load Transfer Objects\"}";
                ws.SendAsync(textMerhaba, delegate (bool completed) { });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    Ws_OnError(sender, e);
                });
                return;
            }

            MessageBox.Show(e.Message, this.Text);
            CloseWebSocket((WebSocket)sender);
        }

        private void CloseWebSocket(WebSocket ws)
        {
            if (ws != null && ws.IsAlive)
            {
                ws.OnClose -= Ws_OnClose;
                ws.Close();
                ws = null;
            }
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Ws_OnClose(sender, e);
                });
                return;
            }

            MessageBox.Show(this, string.Format("WebSocket closed. {0}",
                e.Reason), this.Text);

            CloseWebSocket((WebSocket)sender);
        }


        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data == "{\"message\": \"Orada misin?\"}")
            {
                string textKonum = "{\"message\":\"Evet\"}";
                ((WebSocket)sender).SendAsync(textKonum, delegate (bool completed) { });
            }
            else if (e.Data.Contains("ClearPath"))
            {
                points.Clear();
            }
            else if (e.Data.Contains("Rota"))
            {
                BackgroundWorker bcg = new BackgroundWorker();
                bcg.DoWork += new DoWorkEventHandler(bcmessage_DoWork);
                bcg.RunWorkerAsync(argument: e.Data);

                //[[5,4],[4,4],[3,5],[2,6],[1,5],[0,4]]
            }
            //TODO: Mesaj geldiðinde ve göndedrildiðinde burasý çalýþacak
        }

        private void bcmessage_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var data = JsonConvert.DeserializeObject<ServerMessage>((string)e.Argument);
            var datastring = data.message.Replace("Rota:", "");
            var mData = datastring.Split(':');
            var algo = mData[0];

            var rota = mData[2].Replace("[", "").Replace("]", "");
            var list = rota.Split(',');

            var pList = new List<GridPiont>();
            for (int i = 0; i < list.Length; i += 2)
            {
                pList.Add(new GridPiont() { XPoint = Convert.ToInt32(list[i]), YPoint = Convert.ToInt32(list[i + 1]) });
            }

            int x = Convert.ToInt32(txtX.Text);

            PictureBox ctrl = null;

            foreach (var item in pnlCenter.Controls)
            {
                if (item.GetType() == typeof(ExtendedPanel))
                {

                    ((ExtendedPanel)item).Invoke(new Action(() =>
                    {
                        ((ExtendedPanel)item).SendToBack();
                    }));

                }
                else if (item.GetType() == typeof(PictureBox))
                {
                    if (((PictureBox)item).Tag != null && ((PictureBox)item).Tag.ToString() == mData[1])
                    {
                        ctrl = ((PictureBox)item);
                    }
                }

            }
            points.Add(pList);
            var pnlPath = new ExtendedPanel(points, x);
            pnlPath.Size = pnlCenter.Size;
            pnlPath.Location = new Point(0, 0);

            pnlCenter.Invoke(new Action(() =>
            {
                pnlCenter.Controls.Add(pnlPath);
                pnlPath.BringToFront();
            }));




            if (ctrl != null)
            {
                if (algo.ToLower() == "dijkstra")
                {
                    for (int h = 0; h <= pList.Count - 1; h++)
                    {
                        var currentRP = new RobotPath()
                        {
                            Robot = ctrl,
                            Point = new Point((pList[h].XPoint * x), (pList[h].YPoint * x))
                        };
                        //BackgroundWorker bcg = new BackgroundWorker();
                        //bcg.DoWork += new DoWorkEventHandler(bcg_DoWork);
                        //bcg.RunWorkerAsync(argument: currentRP);

                        ctrl.Invoke(new Action(() =>
                        {
                            ctrl.Location = currentRP.Point;
                            ctrl.BringToFront();
                        }));
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    for (int h = pList.Count - 1; h >= 0; h--)
                    {
                        var currentRP = new RobotPath()
                        {
                            Robot = ctrl,
                            Point = new Point((pList[h].XPoint * x), (pList[h].YPoint * x))
                        };
                        //BackgroundWorker bcg = new BackgroundWorker();
                        //bcg.DoWork += new DoWorkEventHandler(bcg_DoWork);
                        //bcg.RunWorkerAsync(argument: currentRP);

                        ctrl.Invoke(new Action(() =>
                        {
                            ctrl.Location = currentRP.Point;
                            ctrl.BringToFront();
                        }));
                        Thread.Sleep(500);
                    }
                }

            }

        }


        private void bcg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var rp = (RobotPath)e.Argument;

        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            // Baðlantý oluþtuðunda yapýlacaklar
        }

        private void btnUploadMap_Click(object sender, EventArgs e)
        {
            SendMapToServer();
        }

        private void pRobot_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                e.Graphics.DrawString("Robot", font, Brushes.Black, 0, -2);
            }
        }

        private void pGoal_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                e.Graphics.DrawString("Goal", font, Brushes.Black, 0, -2);
            }
        }

        private void pTransferredObject_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                e.Graphics.DrawString("TrObj", font, Brushes.Black, 0, -2);
            }
        }

        private void pWorkStation_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                e.Graphics.DrawString("WorkStation", font, Brushes.Black, 0, -2);
            }
        }

        private void pVehicle_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                e.Graphics.DrawString("Vehicle", font, Brushes.Black, 0, -2);
            }
        }



        private void cbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearPanel.PerformClick();
            if (((ComboboxItem)cbMap.SelectedItem).Distance != null)
            {
                ///
                txtX.Text = ((ComboboxItem)cbMap.SelectedItem).Distance.ToString();
                btnGridCreate.PerformClick();
                ///
                _mapId = ((ComboboxItem)cbMap.SelectedItem).Value.ToString();

                WebRequest req = WebRequest.Create("http://" + Program._wslink + "/robots/getmap/" + _mapId + "/");
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Program._wsUserName + ":" + Program._wsPassword));

                var getResponse = (HttpWebResponse)req.GetResponse();
                System.IO.Stream newStream = getResponse.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
                var result = sr.ReadToEnd();

                var ms = JsonConvert.DeserializeObject<ServerMapEnvironments>(result);


                /// Load obstacles
                
                if(ms.obstacle != "[]" && ms.obstacle != "")
                {
                    //var obstacleS = JsonConvert.DeserializeObject<string>(ms.obstacle);
                    var obstacleList = JsonConvert.DeserializeObject<List<ServerMapObstacle>>(ms.obstacle);
                    if (obstacleList.Count > 0)
                    {
                        PictureBox pObstacle = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("O"))
                                {
                                    pObstacle = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in obstacleList)
                        {
                            PictureBox picture = new PictureBox();

                            picture.BackColor = pObstacle.BackColor;
                            picture.Tag = pObstacle.Tag;

                            picture.BorderStyle = BorderStyle.None;
                            picture.Location = new Point(item.fields.Left, item.fields.Top);

                            picture.Size = new Size(item.fields.Right - item.fields.Left, item.fields.Bottom - item.fields.Top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;


                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);
                        }

                        //SetNodes();
                    }
                }


                /// Load workstations
                if(ms.workstation != "[]" && ms.workstation != "")
                {
                    _workStationPointList.Clear();
                    //var workstationS = JsonConvert.DeserializeObject<string>(ms.workstation);
                    var workstationList = JsonConvert.DeserializeObject<List<ServerMapWorkStation>>(ms.workstation);
                    if (workstationList.Count > 0)
                    {
                        PictureBox pWorkstation = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("M"))
                                {
                                    pWorkstation = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in workstationList)
                        {
                            _workStationPointList.Add(
                                   new WorkStationPoint()
                                   {
                                       pk = item.pk,
                                       Code = item.fields.Code,
                                       Name = item.fields.Name,
                                       isActive = item.fields.isActive,
                                       Position = item.fields.Position,
                                       EnterPosX = item.fields.EnterPosX,
                                       EnterPosY = item.fields.EnterPosY,
                                       ExitPosX = item.fields.ExitPosX,
                                       ExitPosY = item.fields.ExitPosY,
                                   }
                                   );

                            PictureBox picture = new PictureBox();

                            picture.BackColor = pWorkstation.BackColor;
                            picture.Tag = "M" + item.fields.Code;
                            picture.Image = global::iOTClient.Properties.Resources.machine_free;
                            picture.SizeMode = PictureBoxSizeMode.CenterImage;
                            picture.BackColor = Color.LightGray;
                            picture.BorderStyle = BorderStyle.None;
                            picture.Paint += new PaintEventHandler(picture_Paint);
                            picture.Name = item.fields.Code;

                            string position = item.fields.Position;
                            position = position.Replace("[", "").Replace("]", "").Replace("},", " ").Replace("{", "").Replace("}", "");

                            var posList = position.Split(' ');
                            int left = 0;
                            int top = 0;
                            int right = 0;
                            int bottom = 0;
                            for (int i = 0; i < posList.Length; i++)
                            {
                                if (i == 0)
                                {
                                    var points = posList[i].Split(',');
                                    left = Convert.ToInt32(points[0]);
                                    top = Convert.ToInt32(points[1]);
                                }
                                else if (i == 2)
                                {
                                    var points = posList[i].Split(',');
                                    right = Convert.ToInt32(points[0]);
                                    bottom = Convert.ToInt32(points[1]);
                                }

                            }

                            picture.Location = new Point(left, top);

                            picture.Size = new Size(right - left, bottom - top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);

                            _workStationList.Add(picture);
                        }

                        //SetNodes();
                    }
                }

                /// Load waitingstations
                if (ms.waitingstation != "[]" && ms.waitingstation != "")
                {
                    _waitingSPointList.Clear();
                    var waitingstationList = JsonConvert.DeserializeObject<List<ServerMapWaitingStation>>(ms.waitingstation);
                    if (waitingstationList.Count > 0)
                    {
                        PictureBox pwaitingstation = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("W"))
                                {
                                    pwaitingstation = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in waitingstationList)
                        {
                            _waitingSPointList.Add(
                                   new WaitingStationPoint()
                                   {
                                       Code = item.fields.Code,
                                       Name = item.fields.Name,
                                       isActive = item.fields.isActive,
                                       isFull = item.fields.isFull,
                                       Position = item.fields.Position,
                                       CenterX = item.fields.CenterX,
                                       CenterY = item.fields.CenterY
                                   }
                                   );

                            PictureBox picture = new PictureBox();

                            picture.BackColor = pwaitingstation.BackColor;
                            picture.Tag = "W" + item.fields.Code;
                            picture.Image = global::iOTClient.Properties.Resources.WaitingStationFree;
                            picture.SizeMode = PictureBoxSizeMode.CenterImage;
                            picture.BackColor = Color.LightGray;
                            picture.BorderStyle = BorderStyle.None;
                            picture.Paint += new PaintEventHandler(picture_Paint);
                            picture.Name = item.fields.Code;

                            string position = item.fields.Position;
                            position = position.Replace("[", "").Replace("]", "").Replace("},", " ").Replace("{", "").Replace("}", "");

                            var posList = position.Split(' ');
                            int left = 0;
                            int top = 0;
                            int right = 0;
                            int bottom = 0;
                            for (int i = 0; i < posList.Length; i++)
                            {
                                if (i == 0)
                                {
                                    var points = posList[i].Split(',');
                                    left = Convert.ToInt32(points[0]);
                                    top = Convert.ToInt32(points[1]);
                                }
                                else if (i == 2)
                                {
                                    var points = posList[i].Split(',');
                                    right = Convert.ToInt32(points[0]);
                                    bottom = Convert.ToInt32(points[1]);
                                }

                            }

                            picture.Location = new Point(left, top);

                            picture.Size = new Size(right - left, bottom - top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);

                            _waitingSList.Add(picture);
                        }

                        //SetNodes();
                    }
                }


                /// Load chargingstations
                if (ms.chargingstation != "[]" && ms.chargingstation != "")
                {
                    _chargeSPointList.Clear();
                    var chargingstationList = JsonConvert.DeserializeObject<List<ServerMapChargingStation>>(ms.chargingstation);
                    if (chargingstationList.Count > 0)
                    {
                        PictureBox pchargingstation = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("C"))
                                {
                                    pchargingstation = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in chargingstationList)
                        {
                            _chargeSPointList.Add(
                                    new ChargeStationPoint()
                                    {
                                        Code = item.fields.Code,
                                        Name = item.fields.Name,
                                        isActive = item.fields.isActive,
                                        isFull = item.fields.isFull,
                                        Position = item.fields.Position,
                                        CenterX = item.fields.CenterX,
                                        CenterY = item.fields.CenterY
                                    }
                                    );

                            

                            PictureBox picture = new PictureBox();

                            picture.BackColor = pchargingstation.BackColor;
                            picture.Tag = "C" + item.fields.Code;
                            picture.Image = global::iOTClient.Properties.Resources.ChargeSatationFree;
                            picture.SizeMode = PictureBoxSizeMode.CenterImage;
                            picture.BackColor = Color.LightGray;
                            picture.BorderStyle = BorderStyle.None;
                            picture.Paint += new PaintEventHandler(picture_Paint);
                            picture.Name = item.fields.Code;

                            string position = item.fields.Position;
                            position = position.Replace("[", "").Replace("]", "").Replace("},", " ").Replace("{", "").Replace("}", "");

                            var posList = position.Split(' ');
                            int left = 0;
                            int top = 0;
                            int right = 0;
                            int bottom = 0;
                            for (int i = 0; i < posList.Length; i++)
                            {
                                if (i == 0)
                                {
                                    var points = posList[i].Split(',');
                                    left = Convert.ToInt32(points[0]);
                                    top = Convert.ToInt32(points[1]);
                                }
                                else if (i == 2)
                                {
                                    var points = posList[i].Split(',');
                                    right = Convert.ToInt32(points[0]);
                                    bottom = Convert.ToInt32(points[1]);
                                }

                            }

                            picture.Location = new Point(left, top);

                            picture.Size = new Size(right - left, bottom - top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);

                            _chargeSList.Add(picture);
                        }

                        //SetNodes();
                    }
                }

                /// Load startstations
                if (ms.startstation != "[]" && ms.startstation != "")
                {
                    _startSPointList.Clear();
                    var startstationList = JsonConvert.DeserializeObject<List<ServerMapStartStation>>(ms.startstation);
                    if (startstationList.Count > 0)
                    {
                        PictureBox pstartstation = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("S"))
                                {
                                    pstartstation = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in startstationList)
                        {
                            _startSPointList.Add(
                                    new StartStationPoint()
                                    {
                                        Code = item.fields.Code,
                                        Name = item.fields.Name,
                                        isActive = item.fields.isActive,
                                        isFull = item.fields.isFull,
                                        Position = item.fields.Position,
                                        CenterX = item.fields.CenterX,
                                        CenterY = item.fields.CenterY
                                    }
                                    );



                            PictureBox picture = new PictureBox();

                            picture.BackColor = pstartstation.BackColor;
                            picture.Tag = "S" + item.fields.Code;
                            picture.Image = global::iOTClient.Properties.Resources.StartStationFree;
                            picture.SizeMode = PictureBoxSizeMode.CenterImage;
                            picture.BackColor = Color.LightGray;
                            picture.BorderStyle = BorderStyle.None;
                            picture.Paint += new PaintEventHandler(picture_Paint);
                            picture.Name = item.fields.Code;

                            string position = item.fields.Position;
                            position = position.Replace("[", "").Replace("]", "").Replace("},", " ").Replace("{", "").Replace("}", "");

                            var posList = position.Split(' ');
                            int left = 0;
                            int top = 0;
                            int right = 0;
                            int bottom = 0;
                            for (int i = 0; i < posList.Length; i++)
                            {
                                if (i == 0)
                                {
                                    var points = posList[i].Split(',');
                                    left = Convert.ToInt32(points[0]);
                                    top = Convert.ToInt32(points[1]);
                                }
                                else if (i == 2)
                                {
                                    var points = posList[i].Split(',');
                                    right = Convert.ToInt32(points[0]);
                                    bottom = Convert.ToInt32(points[1]);
                                }

                            }

                            picture.Location = new Point(left, top);

                            picture.Size = new Size(right - left, bottom - top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);

                            _startSList.Add(picture);
                        }

                        //SetNodes();
                    }
                }


                /// Load finishstations
                if (ms.finishstation != "[]" && ms.finishstation != "")
                {
                    _finishSPointList.Clear();
                    var finishstationList = JsonConvert.DeserializeObject<List<ServerMapFinishStation>>(ms.finishstation);
                    if (finishstationList.Count > 0)
                    {
                        PictureBox pfinishstation = null;

                        foreach (var ctrl in pnlLeft.Controls)
                        {
                            if (ctrl.GetType() == typeof(PictureBox))
                            {
                                if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("F"))
                                {
                                    pfinishstation = ((PictureBox)ctrl);
                                }
                            }
                        }

                        foreach (var item in finishstationList)
                        {
                            _finishSPointList.Add(
                                    new FinishStationPoint()
                                    {
                                        Code = item.fields.Code,
                                        Name = item.fields.Name,
                                        isActive = item.fields.isActive,
                                        isFull = item.fields.isFull,
                                        Position = item.fields.Position,
                                        CenterX = item.fields.CenterX,
                                        CenterY = item.fields.CenterY
                                    }
                                    );



                            PictureBox picture = new PictureBox();

                            picture.BackColor = pfinishstation.BackColor;
                            picture.Tag = "F" + item.fields.Code;
                            picture.Image = global::iOTClient.Properties.Resources.FinishStationFree;
                            picture.SizeMode = PictureBoxSizeMode.CenterImage;
                            picture.BackColor = Color.LightGray;
                            picture.BorderStyle = BorderStyle.None;
                            picture.Paint += new PaintEventHandler(picture_Paint);
                            picture.Name = item.fields.Code;

                            string position = item.fields.Position;
                            position = position.Replace("[", "").Replace("]", "").Replace("},", " ").Replace("{", "").Replace("}", "");

                            var posList = position.Split(' ');
                            int left = 0;
                            int top = 0;
                            int right = 0;
                            int bottom = 0;
                            for (int i = 0; i < posList.Length; i++)
                            {
                                if (i == 0)
                                {
                                    var points = posList[i].Split(',');
                                    left = Convert.ToInt32(points[0]);
                                    top = Convert.ToInt32(points[1]);
                                }
                                else if (i == 2)
                                {
                                    var points = posList[i].Split(',');
                                    right = Convert.ToInt32(points[0]);
                                    bottom = Convert.ToInt32(points[1]);
                                }

                            }

                            picture.Location = new Point(left, top);

                            picture.Size = new Size(right - left, bottom - top);
                            picture.MouseDown -= new MouseEventHandler(this.Object_MouseDown);
                            picture.MouseMove -= new MouseEventHandler(this.Object_MouseMove);
                            picture.MouseUp -= new MouseEventHandler(this.Object_MouseUp);
                            picture.MouseUp += new MouseEventHandler(this.ObjectonMap_MouseUp);
                            picture.ContextMenuStrip = cmObject;
                            picture.ContextMenuStrip = cmObject;
                            pnlCenter.SendToBack();

                            picture.BringToFront();
                            pnlCenter.Controls.Add(picture);
                            picture.BringToFront();
                            picture.Draggable(true);

                            _finishSList.Add(picture);
                        }

                        //SetNodes();
                    }
                }


                /// Load waitingstation
                //var waitingstationS = JsonConvert.DeserializeObject<string>(ms.waitingstation);
                //var waitingstationList = JsonConvert.DeserializeObject<List<ServerMapWaitingStation>>(waitingstationS);
                //if (waitingstationList.Count > 0)
                //{
                //    PictureBox pObstacle = null;

                //    foreach (var ctrl in pnlLeft.Controls)
                //    {
                //        if (ctrl.GetType() == typeof(PictureBox))
                //        {
                //            if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("Obstacle"))
                //            {
                //                pObstacle = ((PictureBox)ctrl);
                //            }
                //        }
                //    }

                //    foreach (var item in waitingstationList)
                //    {
                //        PictureBox picture = new PictureBox();

                //        picture.BackColor = pObstacle.BackColor;
                //        picture.Tag = pObstacle.Tag;

                //        picture.BorderStyle = BorderStyle.None;
                //        picture.Location = new Point(item.fields.Left, item.fields.Top);

                //        picture.Size = new Size(item.fields.Right - item.fields.Left, item.fields.Bottom - item.fields.Top);
                //        picture.MouseDown += new MouseEventHandler(this.Object_MouseDown);
                //        picture.MouseMove += new MouseEventHandler(this.Object_MouseMove);
                //        picture.MouseUp += new MouseEventHandler(this.Object_MouseUp);
                //        picture.ContextMenuStrip = cmObject;
                //        pnlCenter.SendToBack();

                //        picture.BringToFront();
                //        pnlCenter.Controls.Add(picture);
                //        picture.BringToFront();
                //        picture.Draggable(true);
                //    }

                //}

                ///// Load chargingstation
                //var chargingstationS = JsonConvert.DeserializeObject<string>(ms.chargingstation);
                //var chargingstationList = JsonConvert.DeserializeObject<List<ServerMapChargingStation>>(chargingstationS);
                //if (chargingstationList.Count > 0)
                //{
                //    PictureBox pObstacle = null;

                //    foreach (var ctrl in pnlLeft.Controls)
                //    {
                //        if (ctrl.GetType() == typeof(PictureBox))
                //        {
                //            if (((PictureBox)ctrl).Tag != null && ((PictureBox)ctrl).Tag.ToString().StartsWith("Obstacle"))
                //            {
                //                pObstacle = ((PictureBox)ctrl);
                //            }
                //        }
                //    }

                //    foreach (var item in chargingstationList)
                //    {
                //        PictureBox picture = new PictureBox();

                //        picture.BackColor = pObstacle.BackColor;
                //        picture.Tag = pObstacle.Tag;

                //        picture.BorderStyle = BorderStyle.None;
                //        picture.Location = new Point(item.fields.Left, item.fields.Top);

                //        picture.Size = new Size(item.fields.Right - item.fields.Left, item.fields.Bottom - item.fields.Top);
                //        picture.MouseDown += new MouseEventHandler(this.Object_MouseDown);
                //        picture.MouseMove += new MouseEventHandler(this.Object_MouseMove);
                //        picture.MouseUp += new MouseEventHandler(this.Object_MouseUp);
                //        picture.ContextMenuStrip = cmObject;
                //        pnlCenter.SendToBack();

                //        picture.BringToFront();
                //        pnlCenter.Controls.Add(picture);
                //        picture.BringToFront();
                //        picture.Draggable(true);
                //    }

                //    //SetNodes();
                //}


            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

    public class RobotWebSocket
    {
        public string name { get; set; }
        public WebSocket _ws { get; set; }
    }

    public class GridPiont
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }
    }

    public class ObstaclePiont
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
    }

    public class GoalPoint
    {
        public string Code { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
    }


    public class VehiclePoint
    {
        public string Code { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
    }

    public class TransferredObjectPoint
    {
        public string Code { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public string TaskOrder { get; set; }
    }

    public class WorkStationPoint
    {
        public int pk { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public int EnterPosX { get; set; }
        public int EnterPosY { get; set; }
        public int ExitPosX { get; set; }
        public int ExitPosY { get; set; }
    }

    public class WaitingStationPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public bool isFull { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
    }

    public class ChargeStationPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public bool isFull { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }

    }

    public class StartStationPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public bool isFull { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }

    }

    public class FinishStationPoint
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public bool isFull { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }

    }

    public class MapGoals
    {
        public int MapId { get; set; }
        public List<GoalPoint> GoalPoints { get; set; }
    }

    public class GridMap
    {
        public List<ObstaclePiont> ObstaclePoints { get; set; }
        public List<WorkStationPoint> WorkStationPoints { get; set; }
        public List<ChargeStationPoint> ChargeStationPoints { get; set; }
        public List<WaitingStationPoint> WaitingStationPoints { get; set; }
        public List<StartStationPoint> StartStationPoints { get; set; }
        public List<FinishStationPoint> FinishStationPoints { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MapId { get; set; }
        public int Distance { get; set; }
    }

    public class ServerMap
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapFields fields { get; set; }
    }

    public class ServerMapFields
    {
        public string Name { get; set; }
        public int SubNet { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Distance { get; set; }
    }

    public class ServerTransferVehicle
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerTransferVehicleFields fields { get; set; }
    }

    public class ServerTransferVehicleFields
    {
        public string Barcode { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public int? LastPosX { get; set; }
        public int? LastPosY { get; set; }
    }


    public class ServerRobot
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerRobotFields fields { get; set; }
    }

    public class ServerRobotFields
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool isActive { get; set; }
        public int? LastCoordX { get; set; }
        public int? LastCoordY { get; set; }
    }

    public class ServerStartStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerStartStationFields fields { get; set; }
    }

    public class ServerStartStationFields
    {
        public string Code { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public int? CenterX { get; set; }
        public int? CenterY { get; set; }
    }

    public class ServerMapEnvironments
    {
        public string obstacle { get; set; }
        public string workstation { get; set; }
        public string waitingstation { get; set; }
        public string chargingstation { get; set; }
        public string startstation { get; set; }
        public string finishstation { get; set; }
    }

    public class ServerMapObstacle
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapObstacleFields fields { get; set; }
    }

    public class ServerMapObstacleFields
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Map { get; set; }
    }

    public class ServerMapWorkStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapWorkStationFields fields { get; set; }
    }

    public class ServerMapWorkStationFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string Position { get; set; }
        public int EnterPosX { get; set; }
        public int EnterPosY { get; set; }
        public int ExitPosX { get; set; }
        public int ExitPosY { get; set; }
        public int Map { get; set; }
    }

    public class ServerMapWaitingStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapWaitingStationFields fields { get; set; }
    }

    public class ServerMapWaitingStationFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public string Position { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Map { get; set; }
    }


    public class ServerMapChargingStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapChargingStationFields fields { get; set; }
    }

    public class ServerMapChargingStationFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public string Position { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Map { get; set; }
    }


    public class ServerMapStartStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapStartStationFields fields { get; set; }
    }

    public class ServerMapStartStationFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public string Position { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Map { get; set; }
    }


    public class ServerMapFinishStation
    {
        public string model { get; set; }
        public int pk { get; set; }
        public ServerMapFinishStationFields fields { get; set; }
    }

    public class ServerMapFinishStationFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isFull { get; set; }
        public string Position { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Map { get; set; }
    }




    public class ServerMessage
    {
        public string message { get; set; }
    }



    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public object Distance { get; set; }
        public object CenterX { get; set; }
        public object CenterY { get; set; }

        public override string ToString()
        {
            return Text;
        }


    }

    public class TransferObject
    {
        public List<TaskHistory> TaskHistories { get; set; }
        public int MapId { get; set; }
        public int StartStationId { get; set; }
        public int TransferVehicleId { get; set; }
        public bool isNewObject { get; set; }
        public string Barcode { get; set; }
        public int LastPosX { get; set; }
        public int LastPosY { get; set; }
        public int Length { get; set; }
        public string _transferVehicleCode { get; set; }
    }

    public class TaskHistory
    {
        public int WorkOrder { get; set; }
        public string WorkStationCode { get; set; }
    }

    public class RobotPath
    {
        public PictureBox Robot { get; set; }
        public Point Point { get; set; }
    }
}
