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
            this.label3 = new System.Windows.Forms.Label();
            this.pRobot = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.pGoal = new System.Windows.Forms.PictureBox();
            this.pObstacle = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMotionPlan = new System.Windows.Forms.Button();
            this.btnClearPath = new System.Windows.Forms.Button();
            this.btnClearPanel = new System.Windows.Forms.Button();
            this.btnGridCreate = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.cmObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsSil = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.bgMotionPlan = new System.ComponentModel.BackgroundWorker();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pRobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pObstacle)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.cmObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.pRobot);
            this.pnlLeft.Controls.Add(this.label6);
            this.pnlLeft.Controls.Add(this.label5);
            this.pnlLeft.Controls.Add(this.lblY);
            this.pnlLeft.Controls.Add(this.lblX);
            this.pnlLeft.Controls.Add(this.pGoal);
            this.pnlLeft.Controls.Add(this.pObstacle);
            this.pnlLeft.Controls.Add(this.panel1);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(91, 593);
            this.pnlLeft.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(14, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Robot";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pRobot
            // 
            this.pRobot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pRobot.Image = ((System.Drawing.Image)(resources.GetObject("pRobot.Image")));
            this.pRobot.Location = new System.Drawing.Point(22, 101);
            this.pRobot.Name = "pRobot";
            this.pRobot.Size = new System.Drawing.Size(50, 70);
            this.pRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pRobot.TabIndex = 11;
            this.pRobot.TabStop = false;
            this.pRobot.Tag = "Robot1";
            this.pRobot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pRobot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pRobot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(7, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Goal";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(15, 177);
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
            this.lblY.Location = new System.Drawing.Point(51, 571);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 3;
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(51, 555);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 3;
            // 
            // pGoal
            // 
            this.pGoal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pGoal.Image = global::iOTClient.Properties.Resources.target1;
            this.pGoal.Location = new System.Drawing.Point(22, 275);
            this.pGoal.Name = "pGoal";
            this.pGoal.Size = new System.Drawing.Size(50, 50);
            this.pGoal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pGoal.TabIndex = 2;
            this.pGoal.TabStop = false;
            this.pGoal.Tag = "Goal";
            this.pGoal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Object_MouseDown);
            this.pGoal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Object_MouseMove);
            this.pGoal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Object_MouseUp);
            // 
            // pObstacle
            // 
            this.pObstacle.BackColor = System.Drawing.Color.Black;
            this.pObstacle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pObstacle.Location = new System.Drawing.Point(22, 197);
            this.pObstacle.Name = "pObstacle";
            this.pObstacle.Size = new System.Drawing.Size(50, 50);
            this.pObstacle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pObstacle.TabIndex = 2;
            this.pObstacle.TabStop = false;
            this.pObstacle.Tag = "Obstacle";
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
            this.panel1.Size = new System.Drawing.Size(91, 64);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(-4, 29);
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
            this.label2.Location = new System.Drawing.Point(-5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "iOT Client";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            this.pnlTop.Controls.Add(this.comboBox1);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnMotionPlan);
            this.pnlTop.Controls.Add(this.btnClearPath);
            this.pnlTop.Controls.Add(this.btnClearPanel);
            this.pnlTop.Controls.Add(this.btnGridCreate);
            this.pnlTop.Controls.Add(this.txtX);
            this.pnlTop.Location = new System.Drawing.Point(91, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1012, 64);
            this.pnlTop.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A - Star",
            "D - Star",
            "PSO"});
            this.comboBox1.Location = new System.Drawing.Point(370, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "A - Star";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::iOTClient.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(979, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 33);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Distance";
            // 
            // btnMotionPlan
            // 
            this.btnMotionPlan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMotionPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMotionPlan.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnMotionPlan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMotionPlan.Location = new System.Drawing.Point(266, 34);
            this.btnMotionPlan.Name = "btnMotionPlan";
            this.btnMotionPlan.Size = new System.Drawing.Size(101, 26);
            this.btnMotionPlan.TabIndex = 5;
            this.btnMotionPlan.Text = "Motion Plan";
            this.btnMotionPlan.UseVisualStyleBackColor = false;
            this.btnMotionPlan.Click += new System.EventHandler(this.btnMotionPlan_Click);
            // 
            // btnClearPath
            // 
            this.btnClearPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPath.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClearPath.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearPath.Location = new System.Drawing.Point(477, 33);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(81, 26);
            this.btnClearPath.TabIndex = 5;
            this.btnClearPath.Text = "Clear Path";
            this.btnClearPath.UseVisualStyleBackColor = false;
            this.btnClearPath.Click += new System.EventHandler(this.btnClearPath_Click);
            // 
            // btnClearPanel
            // 
            this.btnClearPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClearPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPanel.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnClearPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearPanel.Location = new System.Drawing.Point(184, 34);
            this.btnClearPanel.Name = "btnClearPanel";
            this.btnClearPanel.Size = new System.Drawing.Size(79, 26);
            this.btnClearPanel.TabIndex = 5;
            this.btnClearPanel.Text = "Clear Map";
            this.btnClearPanel.UseVisualStyleBackColor = false;
            this.btnClearPanel.Click += new System.EventHandler(this.btnClearPanel_Click);
            // 
            // btnGridCreate
            // 
            this.btnGridCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGridCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGridCreate.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnGridCreate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGridCreate.Location = new System.Drawing.Point(122, 34);
            this.btnGridCreate.Name = "btnGridCreate";
            this.btnGridCreate.Size = new System.Drawing.Size(59, 26);
            this.btnGridCreate.TabIndex = 5;
            this.btnGridCreate.Text = "Create";
            this.btnGridCreate.UseVisualStyleBackColor = false;
            this.btnGridCreate.Click += new System.EventHandler(this.btnGridCreate_Click);
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.txtX.Location = new System.Drawing.Point(69, 35);
            this.txtX.Multiline = true;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(50, 24);
            this.txtX.TabIndex = 4;
            this.txtX.Text = "50";
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
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Location = new System.Drawing.Point(91, 65);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1012, 527);
            this.pnlCenter.TabIndex = 7;
            // 
            // bgMotionPlan
            // 
            this.bgMotionPlan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMotionPlan_DoWork);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 593);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cloud Based iOT Client Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pRobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pObstacle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.cmObject.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pGoal;
        private System.Windows.Forms.PictureBox pObstacle;
        private System.Windows.Forms.ContextMenuStrip cmObject;
        private System.Windows.Forms.ToolStripMenuItem tsSil;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnClearPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pRobot;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnMotionPlan;
        private System.ComponentModel.BackgroundWorker bgMotionPlan;
        private System.Windows.Forms.Button btnClearPath;
        private System.Windows.Forms.Label label4;
    }
}

