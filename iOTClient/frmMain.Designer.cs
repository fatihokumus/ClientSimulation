namespace iOTClient
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pWaitingS = new System.Windows.Forms.PictureBox();
            this.cmObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsSil = new System.Windows.Forms.ToolStripMenuItem();
            this.pFinishS = new System.Windows.Forms.PictureBox();
            this.pStartS = new System.Windows.Forms.PictureBox();
            this.pChargeS = new System.Windows.Forms.PictureBox();
            this.pWorkStation = new System.Windows.Forms.PictureBox();
            this.pTransferredObject = new System.Windows.Forms.PictureBox();
            this.pRobot = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.pGoal = new System.Windows.Forms.PictureBox();
            this.pObstacle = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearPath = new System.Windows.Forms.Button();
            this.btnMotionPlan = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.btnGridCreate = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.btnClearPanel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadMap = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.bgMotionPlan = new System.ComponentModel.BackgroundWorker();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pVehicle = new System.Windows.Forms.PictureBox();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWaitingS)).BeginInit();
            this.cmObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFinishS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStartS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChargeS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWorkStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTransferredObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pObstacle)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlLeft.Controls.Add(this.pVehicle);
            this.pnlLeft.Controls.Add(this.pWaitingS);
            this.pnlLeft.Controls.Add(this.pFinishS);
            this.pnlLeft.Controls.Add(this.pStartS);
            this.pnlLeft.Controls.Add(this.pChargeS);
            this.pnlLeft.Controls.Add(this.pWorkStation);
            this.pnlLeft.Controls.Add(this.pTransferredObject);
            this.pnlLeft.Controls.Add(this.pRobot);
            this.pnlLeft.Controls.Add(this.label5);
            this.pnlLeft.Controls.Add(this.lblY);
            this.pnlLeft.Controls.Add(this.lblX);
            this.pnlLeft.Controls.Add(this.pGoal);
            this.pnlLeft.Controls.Add(this.pObstacle);
            this.pnlLeft.Controls.Add(this.panel1);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(91, 710);
            this.pnlLeft.TabIndex = 4;
            // 
            // pWaitingS
            // 
            this.pWaitingS.ContextMenuStrip = this.cmObject;
            this.pWaitingS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pWaitingS.Image = global::iOTClient.Properties.Resources.WaitingStation;
            this.pWaitingS.Location = new System.Drawing.Point(22, 555);
            this.pWaitingS.Name = "pWaitingS";
            this.pWaitingS.Size = new System.Drawing.Size(50, 50);
            this.pWaitingS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pWaitingS.TabIndex = 15;
            this.pWaitingS.TabStop = false;
            this.pWaitingS.Tag = "W";
            this.pWaitingS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pWaitingS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pWaitingS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // cmObject
            // 
            this.cmObject.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSil});
            this.cmObject.Name = "contextMenuStrip1";
            this.cmObject.Size = new System.Drawing.Size(87, 26);
            // 
            // tsSil
            // 
            this.tsSil.Name = "tsSil";
            this.tsSil.Size = new System.Drawing.Size(86, 22);
            this.tsSil.Text = "Sil";
            this.tsSil.Click += new System.EventHandler(this.tsSil_Click);
            // 
            // pFinishS
            // 
            this.pFinishS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pFinishS.Image = global::iOTClient.Properties.Resources.FinishStation;
            this.pFinishS.Location = new System.Drawing.Point(22, 667);
            this.pFinishS.Name = "pFinishS";
            this.pFinishS.Size = new System.Drawing.Size(50, 50);
            this.pFinishS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pFinishS.TabIndex = 14;
            this.pFinishS.TabStop = false;
            this.pFinishS.Tag = "F";
            this.pFinishS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pFinishS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pFinishS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pStartS
            // 
            this.pStartS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pStartS.Image = global::iOTClient.Properties.Resources.StartStation;
            this.pStartS.Location = new System.Drawing.Point(22, 611);
            this.pStartS.Name = "pStartS";
            this.pStartS.Size = new System.Drawing.Size(50, 50);
            this.pStartS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pStartS.TabIndex = 14;
            this.pStartS.TabStop = false;
            this.pStartS.Tag = "S";
            this.pStartS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pStartS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pStartS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pChargeS
            // 
            this.pChargeS.ContextMenuStrip = this.cmObject;
            this.pChargeS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pChargeS.Image = global::iOTClient.Properties.Resources.ChargeSatation;
            this.pChargeS.Location = new System.Drawing.Point(23, 499);
            this.pChargeS.Name = "pChargeS";
            this.pChargeS.Size = new System.Drawing.Size(50, 50);
            this.pChargeS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pChargeS.TabIndex = 14;
            this.pChargeS.TabStop = false;
            this.pChargeS.Tag = "C";
            this.pChargeS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pChargeS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pChargeS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pWorkStation
            // 
            this.pWorkStation.ContextMenuStrip = this.cmObject;
            this.pWorkStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pWorkStation.Image = ((System.Drawing.Image)(resources.GetObject("pWorkStation.Image")));
            this.pWorkStation.Location = new System.Drawing.Point(23, 432);
            this.pWorkStation.Name = "pWorkStation";
            this.pWorkStation.Size = new System.Drawing.Size(50, 61);
            this.pWorkStation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pWorkStation.TabIndex = 13;
            this.pWorkStation.TabStop = false;
            this.pWorkStation.Tag = "M1";
            this.pWorkStation.Paint += new System.Windows.Forms.PaintEventHandler(this.pWorkStation_Paint);
            this.pWorkStation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pWorkStation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pWorkStation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pTransferredObject
            // 
            this.pTransferredObject.ContextMenuStrip = this.cmObject;
            this.pTransferredObject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pTransferredObject.Image = global::iOTClient.Properties.Resources.dokarabasi;
            this.pTransferredObject.Location = new System.Drawing.Point(22, 298);
            this.pTransferredObject.Name = "pTransferredObject";
            this.pTransferredObject.Size = new System.Drawing.Size(50, 61);
            this.pTransferredObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pTransferredObject.TabIndex = 12;
            this.pTransferredObject.TabStop = false;
            this.pTransferredObject.Tag = "T1";
            this.pTransferredObject.Paint += new System.Windows.Forms.PaintEventHandler(this.pTransferredObject_Paint);
            this.pTransferredObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pTransferredObject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pTransferredObject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pRobot
            // 
            this.pRobot.ContextMenuStrip = this.cmObject;
            this.pRobot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pRobot.Image = ((System.Drawing.Image)(resources.GetObject("pRobot.Image")));
            this.pRobot.Location = new System.Drawing.Point(22, 85);
            this.pRobot.Name = "pRobot";
            this.pRobot.Size = new System.Drawing.Size(50, 70);
            this.pRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pRobot.TabIndex = 11;
            this.pRobot.TabStop = false;
            this.pRobot.Tag = "R1";
            this.pRobot.Paint += new System.Windows.Forms.PaintEventHandler(this.pRobot_Paint);
            this.pRobot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pRobot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pRobot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Obstacle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(51, 695);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 3;
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(50, 720);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 3;
            // 
            // pGoal
            // 
            this.pGoal.ContextMenuStrip = this.cmObject;
            this.pGoal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pGoal.Image = global::iOTClient.Properties.Resources.goal;
            this.pGoal.Location = new System.Drawing.Point(22, 231);
            this.pGoal.Name = "pGoal";
            this.pGoal.Size = new System.Drawing.Size(50, 61);
            this.pGoal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pGoal.TabIndex = 2;
            this.pGoal.TabStop = false;
            this.pGoal.Tag = "G1";
            this.pGoal.Paint += new System.Windows.Forms.PaintEventHandler(this.pGoal_Paint);
            this.pGoal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pGoal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pGoal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pObstacle
            // 
            this.pObstacle.BackColor = System.Drawing.Color.Gray;
            this.pObstacle.ContextMenuStrip = this.cmObject;
            this.pObstacle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pObstacle.Location = new System.Drawing.Point(22, 175);
            this.pObstacle.Name = "pObstacle";
            this.pObstacle.Size = new System.Drawing.Size(50, 50);
            this.pObstacle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pObstacle.TabIndex = 2;
            this.pObstacle.TabStop = false;
            this.pObstacle.Tag = "O";
            this.pObstacle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pObstacle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pObstacle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 80);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(-4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "Çalýk Denim\r\nAr-Ge";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(-5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "iOT Client";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Location = new System.Drawing.Point(91, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1012, 80);
            this.pnlTop.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(171)))));
            this.panel3.Controls.Add(this.btnClearPath);
            this.panel3.Controls.Add(this.btnMotionPlan);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Location = new System.Drawing.Point(521, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 65);
            this.panel3.TabIndex = 10;
            // 
            // btnClearPath
            // 
            this.btnClearPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPath.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClearPath.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearPath.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPath.Image")));
            this.btnClearPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearPath.Location = new System.Drawing.Point(196, 8);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(114, 48);
            this.btnClearPath.TabIndex = 5;
            this.btnClearPath.Text = "Clear Path";
            this.btnClearPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearPath.UseVisualStyleBackColor = false;
            this.btnClearPath.Click += new System.EventHandler(this.btnClearPath_Click);
            // 
            // btnMotionPlan
            // 
            this.btnMotionPlan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMotionPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMotionPlan.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnMotionPlan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMotionPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnMotionPlan.Image")));
            this.btnMotionPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMotionPlan.Location = new System.Drawing.Point(12, 30);
            this.btnMotionPlan.Name = "btnMotionPlan";
            this.btnMotionPlan.Size = new System.Drawing.Size(180, 27);
            this.btnMotionPlan.TabIndex = 5;
            this.btnMotionPlan.Text = "      Plan Motion";
            this.btnMotionPlan.UseVisualStyleBackColor = false;
            this.btnMotionPlan.Click += new System.EventHandler(this.btnMotionPlan_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A - Star",
            "D - Star",
            "PSO"});
            this.comboBox1.Location = new System.Drawing.Point(12, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "A - Star";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(171)))));
            this.panel2.Controls.Add(this.cbMap);
            this.panel2.Controls.Add(this.btnGridCreate);
            this.panel2.Controls.Add(this.txtX);
            this.panel2.Controls.Add(this.btnClearPanel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnUploadMap);
            this.panel2.Location = new System.Drawing.Point(4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 66);
            this.panel2.TabIndex = 9;
            // 
            // cbMap
            // 
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Location = new System.Drawing.Point(322, 9);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(181, 21);
            this.cbMap.TabIndex = 9;
            this.cbMap.SelectedIndexChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // btnGridCreate
            // 
            this.btnGridCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGridCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridCreate.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnGridCreate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGridCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnGridCreate.Image")));
            this.btnGridCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGridCreate.Location = new System.Drawing.Point(73, 9);
            this.btnGridCreate.Name = "btnGridCreate";
            this.btnGridCreate.Size = new System.Drawing.Size(124, 48);
            this.btnGridCreate.TabIndex = 5;
            this.btnGridCreate.Text = "Create Map";
            this.btnGridCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGridCreate.UseVisualStyleBackColor = false;
            this.btnGridCreate.Click += new System.EventHandler(this.btnGridCreate_Click);
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.txtX.Location = new System.Drawing.Point(13, 32);
            this.txtX.Multiline = true;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(57, 24);
            this.txtX.TabIndex = 4;
            this.txtX.Text = "50";
            // 
            // btnClearPanel
            // 
            this.btnClearPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPanel.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClearPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPanel.Image")));
            this.btnClearPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearPanel.Location = new System.Drawing.Point(202, 9);
            this.btnClearPanel.Name = "btnClearPanel";
            this.btnClearPanel.Size = new System.Drawing.Size(114, 48);
            this.btnClearPanel.TabIndex = 5;
            this.btnClearPanel.Text = "Clear Map";
            this.btnClearPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearPanel.UseVisualStyleBackColor = false;
            this.btnClearPanel.Click += new System.EventHandler(this.btnClearPanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Distance";
            // 
            // btnUploadMap
            // 
            this.btnUploadMap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUploadMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadMap.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnUploadMap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUploadMap.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadMap.Image")));
            this.btnUploadMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadMap.Location = new System.Drawing.Point(321, 31);
            this.btnUploadMap.Name = "btnUploadMap";
            this.btnUploadMap.Size = new System.Drawing.Size(182, 26);
            this.btnUploadMap.TabIndex = 5;
            this.btnUploadMap.Text = "    Upload Map";
            this.btnUploadMap.UseVisualStyleBackColor = false;
            this.btnUploadMap.Click += new System.EventHandler(this.btnUploadMap_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Location = new System.Drawing.Point(91, 79);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1100, 800);
            this.pnlCenter.TabIndex = 7;
            // 
            // bgMotionPlan
            // 
            this.bgMotionPlan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMotionPlan_DoWork);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 710);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1105, 22);
            this.pnlBottom.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1065, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1065, -16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 3;
            // 
            // pVehicle
            // 
            this.pVehicle.ContextMenuStrip = this.cmObject;
            this.pVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pVehicle.Image = global::iOTClient.Properties.Resources.bos_dok_arabasi;
            this.pVehicle.Location = new System.Drawing.Point(22, 365);
            this.pVehicle.Name = "pVehicle";
            this.pVehicle.Size = new System.Drawing.Size(50, 61);
            this.pVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pVehicle.TabIndex = 16;
            this.pVehicle.TabStop = false;
            this.pVehicle.Tag = "V1";
            this.pVehicle.Paint += new System.Windows.Forms.PaintEventHandler(this.pVehicle_Paint);
            this.pVehicle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pVehicle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pVehicle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 732);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cloud Based iOT Client Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWaitingS)).EndInit();
            this.cmObject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFinishS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStartS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChargeS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWorkStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTransferredObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pObstacle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pVehicle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGridCreate;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.PictureBox pGoal;
        private System.Windows.Forms.PictureBox pObstacle;
        private System.Windows.Forms.ContextMenuStrip cmObject;
        private System.Windows.Forms.ToolStripMenuItem tsSil;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnClearPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pRobot;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnMotionPlan;
        private System.ComponentModel.BackgroundWorker bgMotionPlan;
        private System.Windows.Forms.Button btnClearPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUploadMap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbMap;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pTransferredObject;
        private System.Windows.Forms.PictureBox pWorkStation;
        private System.Windows.Forms.PictureBox pChargeS;
        private System.Windows.Forms.PictureBox pWaitingS;
        private System.Windows.Forms.PictureBox pStartS;
        private System.Windows.Forms.PictureBox pFinishS;
        private System.Windows.Forms.PictureBox pVehicle;
    }
}

