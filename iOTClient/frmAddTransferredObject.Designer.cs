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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeigth = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnToTaskOrder = new System.Windows.Forms.Button();
            this.btnToWorkStation = new System.Windows.Forms.Button();
            this.lbWorkStation = new System.Windows.Forms.ListBox();
            this.lbTaskOrder = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(87, 21);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(325, 22);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 53);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(325, 22);
            this.txtName.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 286);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(195, 286);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(87, 85);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Mask = "00";
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(325, 22);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "1";
            this.txtWidth.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Height";
            // 
            // txtHeigth
            // 
            this.txtHeigth.Location = new System.Drawing.Point(87, 117);
            this.txtHeigth.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeigth.Mask = "00";
            this.txtHeigth.Name = "txtHeigth";
            this.txtHeigth.Size = new System.Drawing.Size(325, 22);
            this.txtHeigth.TabIndex = 3;
            this.txtHeigth.Text = "1";
            this.txtHeigth.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Work Stations";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(712, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Task Order";
            // 
            // btnToTaskOrder
            // 
            this.btnToTaskOrder.Location = new System.Drawing.Point(656, 110);
            this.btnToTaskOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnToTaskOrder.Name = "btnToTaskOrder";
            this.btnToTaskOrder.Size = new System.Drawing.Size(53, 28);
            this.btnToTaskOrder.TabIndex = 4;
            this.btnToTaskOrder.Text = ">";
            this.btnToTaskOrder.UseVisualStyleBackColor = true;
            this.btnToTaskOrder.Click += new System.EventHandler(this.btnToTaskOrder_Click);
            // 
            // btnToWorkStation
            // 
            this.btnToWorkStation.Location = new System.Drawing.Point(656, 146);
            this.btnToWorkStation.Margin = new System.Windows.Forms.Padding(4);
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
            this.lbWorkStation.Location = new System.Drawing.Point(470, 31);
            this.lbWorkStation.Name = "lbWorkStation";
            this.lbWorkStation.Size = new System.Drawing.Size(179, 244);
            this.lbWorkStation.TabIndex = 10;
            // 
            // lbTaskOrder
            // 
            this.lbTaskOrder.FormattingEnabled = true;
            this.lbTaskOrder.ItemHeight = 16;
            this.lbTaskOrder.Location = new System.Drawing.Point(715, 31);
            this.lbTaskOrder.Name = "lbTaskOrder";
            this.lbTaskOrder.Size = new System.Drawing.Size(179, 244);
            this.lbTaskOrder.TabIndex = 11;
            // 
            // frmAddTransferredObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 328);
            this.Controls.Add(this.lbTaskOrder);
            this.Controls.Add(this.lbWorkStation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnToWorkStation);
            this.Controls.Add(this.btnToTaskOrder);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtHeigth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddTransferredObject";
            this.Text = "Add Work Station";
            this.Load += new System.EventHandler(this.frmAddTransferredObject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtHeigth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnToTaskOrder;
        private System.Windows.Forms.Button btnToWorkStation;
        private System.Windows.Forms.ListBox lbWorkStation;
        private System.Windows.Forms.ListBox lbTaskOrder;
    }
}