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
        bool eOlustu = false;
        int gridSize = 0;
        int robotCount = 0;
        int goalCount = 0;

        string wsUserName = "admin";
        string wsPassword = "HamzAsya";

        List<RobotWebSocket> robotSocketList;
        List<PictureBox> _robotList;
        List<PictureBox> _goalList;
        List<GoalPoint> _goalPointList;
        List<List<Node>> _nodes;
        List<List<GridPiont>> points;

        GridMap _map;

        bool ctrlPressed = false;
        string[] pressedPanel = null;

        private string _wslink = "ws://fatih.tuga.com.tr:8180/robots/iot/";
        private string proxyUrl;

        public frmMain()
        {
            InitializeComponent();
            robotSocketList = new List<RobotWebSocket>();
            _nodes = new List<List<Node>>();
            _robotList = new List<PictureBox>();
            _goalList = new List<PictureBox>();
            _goalPointList = new List<GoalPoint>();
            _map = new GridMap();
            _map.ObstaclePoints = new List<ObstaclePiont>();
            points = new List<List<GridPiont>>();
        }

        public void DrawGrid(int x)
        {
            gridSize = x;
            pnlCenter.Controls.Clear();
            //Graphics g = this.pnlCenter.CreateGraphics();
            //g.Clear(Color.WhiteSmoke);
            //Pen p = new Pen(Color.Red, 1);

            var width = pnlCenter.Width - 20; //Padding 10 left and 10 right pixels
            var height = pnlCenter.Height - 20; //Padding 10 top and 10 bottom pixels

            int numX = width / x;
            int numY = height / x; ;

            for (int i = 0; i <= numX; i++)
            {
                for (int j = 0; j <= numY; j++)
                {
                    Panel pnl = new Panel();
                    var pX = (i * x) + (x / 2);
                    var pY = (j * x) + (x / 2);

                    pnl.Size = new Size(5, 5);
                    pnl.BorderStyle = BorderStyle.None;
                    pnl.BackColor = Color.Blue;
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

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = iOTClient.Properties.Resources.close2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = iOTClient.Properties.Resources.close;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            pnlLeft.Height = this.Height;
            pnlTop.Width = this.Width - pnlLeft.Width;
            pnlCenter.Width = this.Width - pnlLeft.Width - 2;
            pnlCenter.Height = this.Height - pnlTop.Height - 2;
            pRobot.Draggable(true);
            pRobot.BringToFront();
            pObstacle.Draggable(true);
            pObstacle.BringToFront();
            pGoal.Draggable(true);
            pGoal.BringToFront();

            GetMapList();
        }
        public void GetMapList()
        {
            try
            {
                WebRequest req = WebRequest.Create(@"http://fatih.tuga.com.tr:8180/robots/maplist/");
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(wsUserName + ":" + wsPassword));

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

                    if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().Contains("Obstacle"))
                    {
                        picture.BackColor = ((PictureBox)sender).BackColor;
                        picture.Tag = "Obstacle";
                    }
                    else if (((PictureBox)sender).Tag != null && ((PictureBox)sender).Tag.ToString().Contains("Robot"))
                    {
                        robotCount++;
                        ((PictureBox)sender).Tag = "Robot" + robotCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "Robot";
                        picture.Paint += new PaintEventHandler(this.pRobot_Paint);
                    }
                    else
                    {
                        goalCount++;
                        ((PictureBox)sender).Tag = "Goal" + goalCount.ToString();
                        picture.BackColor = Color.Transparent;
                        picture.Tag = "Goal";

                        picture.Paint += new PaintEventHandler(this.pGoal_Paint);
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
                    obj.Dispose();
                }
                else
                {

                    int x = Convert.ToInt32(txtX.Text);
                    int carpanLeft = (obj.Left - pnlLeft.Width) / x;
                    int carpanTop = (obj.Top - pnlTop.Height) / x;

                    int leftPos = (obj.Left - pnlLeft.Width) > (carpanLeft * x + x / 2) ? x * (carpanLeft + 1) : x * carpanLeft;
                    int topPos = (obj.Top - pnlTop.Height) > (carpanTop * x + x / 2) ? x * (carpanTop + 1) : x * carpanTop;

                    if (leftPos < 0 || topPos < 0)
                    {
                        if (obj.Tag != null && obj.Tag.ToString().Contains("Robot"))
                        {
                            robotCount--;
                            obj.Dispose();
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().Contains("Goal"))
                        {
                            goalCount--;
                        }

                        obj.Dispose();
                    }
                    else
                    {
                        obj.Location = new Point(leftPos, topPos);

                        if (obj.Tag != null && obj.Tag.ToString().Contains("Obstacle"))
                        {
                            obj.Size = new Size(gridSize, gridSize);
                        }
                        else if (obj.Tag != null && obj.Tag.ToString().Contains("Robot"))
                        {
                            obj.Paint += new PaintEventHandler(picture_Paint);
                            obj.Size = new Size(x, x);

                            WebSocket ws = null;

                            _robotList.Add(obj);
                            WsConnectSayHi(ws, obj.Tag.ToString(), obj.Location);
                        }
                        else
                        {
                            _goalList.Add(obj);
                            obj.Paint += new PaintEventHandler(picture_Paint);
                            obj.Size = new Size(x, x);
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


                if (obj.Tag != null && obj.Tag.ToString().Contains("Robot"))
                {
                    var ws = robotSocketList.Where(w => w.name == obj.Tag.ToString()).First()._ws;

                    string textKonum = "{\"message\":\"Son Konumum: x:" + obj.Location.X + "; y:" + obj.Location.Y + "\"}";
                    ws.SendAsync(textKonum, delegate (bool completed) { });
                }

                if (obj.Tag != null && obj.Tag.ToString().Contains("Goal"))
                {
                    _goalPointList.Clear();
                    foreach (var item in pnlCenter.Controls)
                    {
                        if (item.GetType() == typeof(PictureBox) && ((PictureBox)item).Tag.ToString().Contains("Goal"))
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
                e.Graphics.DrawString(text, font, Brushes.Red, 0, -2);
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


            foreach (var item in pnlCenter.Controls)
            {
                if (item.GetType() == typeof(PictureBox))
                {
                    var obj = (PictureBox)item;
                    if (obj.Tag != null && obj.Tag.ToString().Contains("Obstacle"))
                    {
                        int dist = Convert.ToInt32(txtX.Text);
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
                WebRequest req = WebRequest.Create(@"http://fatih.tuga.com.tr:8180/robots/maplist/");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(wsUserName + ":" + wsPassword));
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
                                ws.SendAsync(textKonum, delegate (bool completed3) { });
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
                WebRequest req = WebRequest.Create(@"http://fatih.tuga.com.tr:8180/robots/goallist/");
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(wsUserName + ":" + wsPassword));
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

        private void cbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearPanel.PerformClick();
            if (((ComboboxItem)cbMap.SelectedItem).Distance != null)
            {
                ///
                txtX.Text = ((ComboboxItem)cbMap.SelectedItem).Distance.ToString();
                btnGridCreate.PerformClick();
                ///
                var mapId = ((ComboboxItem)cbMap.SelectedItem).Value.ToString();

                WebRequest req = WebRequest.Create(@"http://fatih.tuga.com.tr:8180/robots/getmap/" + mapId + "/");
                req.Method = "GET";
                req.ContentType = "application/json";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(wsUserName + ":" + wsPassword));

                var getResponse = (HttpWebResponse)req.GetResponse();
                System.IO.Stream newStream = getResponse.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(newStream);
                var result = sr.ReadToEnd();

                var mspS = JsonConvert.DeserializeObject<string>(result);

                var mspList = JsonConvert.DeserializeObject<List<ServerMapObstacle>>(mspS);

                if (mspList.Count > 0)
                {
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

                    foreach (var item in mspList)
                    {
                        PictureBox picture = new PictureBox();

                        picture.BackColor = pObstacle.BackColor;
                        picture.Tag = pObstacle.Tag;

                        picture.BorderStyle = BorderStyle.None;
                        picture.Location = new Point(item.fields.Left, item.fields.Top);

                        picture.Size = new Size(item.fields.Right - item.fields.Left, item.fields.Bottom - item.fields.Top);
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

                    //SetNodes();
                }
            }
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

    public class MapGoals
    {
        public int MapId { get; set; }
        public List<GoalPoint> GoalPoints { get; set; }
    }

    public class GridMap
    {
        public List<ObstaclePiont> ObstaclePoints { get; set; }
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

    public class ServerMessage
    {
        public string message { get; set; }
    }



    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public object Distance { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class RobotPath
    {
        public PictureBox Robot { get; set; }
        public Point Point { get; set; }
    }
}
