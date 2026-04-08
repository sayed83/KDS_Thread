namespace KDS_Thread.ThreadForm
{
    partial class frmUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAdd));
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(338, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Status :";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.GhostWhite;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLocation.Location = new System.Drawing.Point(154, 152);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(121, 23);
            this.txtLocation.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(95, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "User ID :";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.GhostWhite;
            this.txtUserId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserId.Location = new System.Drawing.Point(155, 125);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(121, 23);
            this.txtUserId.TabIndex = 22;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Select",
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(392, 154);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 23);
            this.cmbStatus.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(87, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Location :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KDS_Thread.Properties.Resources.save_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(426, 216);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(65, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Employee ID :";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.BackColor = System.Drawing.Color.Snow;
            this.txtEmpCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEmpCode.Location = new System.Drawing.Point(155, 53);
            this.txtEmpCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Size = new System.Drawing.Size(121, 23);
            this.txtEmpCode.TabIndex = 21;
            this.txtEmpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpCode_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(312, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "User Name :";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserName.Location = new System.Drawing.Point(392, 125);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(121, 23);
            this.txtUserName.TabIndex = 23;
            // 
            // frmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(602, 326);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New User Add";
            this.Load += new System.EventHandler(this.frmUserAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
    }
}