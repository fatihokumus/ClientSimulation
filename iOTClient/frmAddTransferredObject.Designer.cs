namespace iOTClient
{
    partial class frmAddTransferredObject
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnToTaskOrder = new System.Windows.Forms.Button();
            this.btnToWorkStation = new System.Windows.Forms.Button();
            this.lbWorkStation = new System.Windows.Forms.ListBox();
            this.lbTaskOrder = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStartStation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 58);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(325, 22);
            this.txtCode.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(124, 262);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 43);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(292, 262);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(159, 43);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Work Stations";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(760, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Task Order";
            // 
            // btnToTaskOrder
            // 
            this.btnToTaskOrder.Location = new System.Drawing.Point(704, 91);
            this.btnToTaskOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToTaskOrder.Name = "btnToTaskOrder";
            this.btnToTaskOrder.Size = new System.Drawing.Size(53, 28);
            this.btnToTaskOrder.TabIndex = 4;
            this.btnToTaskOrder.Text = ">";
            this.btnToTaskOrder.UseVisualStyleBackColor = true;
            this.btnToTaskOrder.Click += new System.EventHandler(this.btnToTaskOrder_Click);
            // 
            // btnToWorkStation
            // 
            this.btnToWorkStation.Location = new System.Drawing.Point(704, 128);
            this.btnToWorkStation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToWorkStation.Name = "btnToWorkStation";
            this.btnToWorkStation.Size = new System.Drawing.Size(53, 28);
            this.btnToWorkStation.TabIndex = 4;
            this.btnToWorkStation.Text = "<";
            this.btnToWorkStation.UseVisualStyleBackColor = true;
            this.btnToWorkStation.Click += new System.EventHandler(this.btnToWorkStation_Click);
            // 
            // lbWorkStation
            // 
            this.lbWorkStation.FormattingEnabled = true;
            this.lbWorkStation.ItemHeight = 16;
            this.lbWorkStation.Location = new System.Drawing.Point(517, 58);
            this.lbWorkStation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbWorkStation.Name = "lbWorkStation";
            this.lbWorkStation.Size = new System.Drawing.Size(179, 244);
            this.lbWorkStation.TabIndex = 10;
            // 
            // lbTaskOrder
            // 
            this.lbTaskOrder.FormattingEnabled = true;
            this.lbTaskOrder.ItemHeight = 16;
            this.lbTaskOrder.Location = new System.Drawing.Point(763, 58);
            this.lbTaskOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbTaskOrder.Name = "lbTaskOrder";
            this.lbTaskOrder.Size = new System.Drawing.Size(179, 244);
            this.lbTaskOrder.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Start Statiton";
            // 
            // cmbStartStation
            // 
            this.cmbStartStation.FormattingEnabled = true;
            this.cmbStartStation.Location = new System.Drawing.Point(124, 134);
            this.cmbStartStation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStartStation.Name = "cmbStartStation";
            this.cmbStartStation.Size = new System.Drawing.Size(325, 24);
            this.cmbStartStation.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Length (m)";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(124, 96);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLength.Mask = "00000";
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(325, 22);
            this.txtLength.TabIndex = 14;
            this.txtLength.Text = "1";
            this.txtLength.ValidatingType = typeof(int);
            // 
            // frmAddTransferredObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 321);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStartStation);
            this.Controls.Add(this.lbTaskOrder);
            this.Controls.Add(this.lbWorkStation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnToWorkStation);
            this.Controls.Add(this.btnToTaskOrder);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddTransferredObject";
            this.Text = "Add Transfer Object";
            this.Load += new System.EventHandler(this.frmAddTransferredObject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnToTaskOrder;
        private System.Windows.Forms.Button btnToWorkStation;
        private System.Windows.Forms.ListBox lbWorkStation;
        private System.Windows.Forms.ListBox lbTaskOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStartStation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtLength;
    }
}