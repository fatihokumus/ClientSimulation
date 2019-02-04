namespace iOTClient
{
    partial class iotRobot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iotRobot));
            this.lblRobot = new System.Windows.Forms.Label();
            this.pRobotImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pRobotImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRobot
            // 
            this.lblRobot.AutoSize = true;
            this.lblRobot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRobot.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.lblRobot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRobot.Location = new System.Drawing.Point(0, 0);
            this.lblRobot.Name = "lblRobot";
            this.lblRobot.Size = new System.Drawing.Size(44, 17);
            this.lblRobot.TabIndex = 8;
            this.lblRobot.Text = "Robot";
            this.lblRobot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pRobotImage
            // 
            this.pRobotImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pRobotImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRobotImage.Image = ((System.Drawing.Image)(resources.GetObject("pRobotImage.Image")));
            this.pRobotImage.Location = new System.Drawing.Point(0, 17);
            this.pRobotImage.Name = "pRobotImage";
            this.pRobotImage.Size = new System.Drawing.Size(94, 133);
            this.pRobotImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pRobotImage.TabIndex = 9;
            this.pRobotImage.TabStop = false;
            // 
            // iotRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pRobotImage);
            this.Controls.Add(this.lblRobot);
            this.Name = "iotRobot";
            this.Size = new System.Drawing.Size(94, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pRobotImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRobot;
        private System.Windows.Forms.PictureBox pRobotImage;
    }
}
