namespace KDS_Thread.ThreadForm
{
    partial class frmUnitMchLotSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnitMchLotSet));
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalLot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCTG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDhk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textIntr = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDyeMachine = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(151, 68);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(108, 23);
            this.dtFromDate.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(108, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "Unit :";
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(151, 122);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(109, 23);
            this.cmbUnit.TabIndex = 34;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(73, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "From Date :";
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(151, 95);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(108, 23);
            this.dtToDate.TabIndex = 39;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(89, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "To Date :";
            // 
            // txtTotalLot
            // 
            this.txtTotalLot.BackColor = System.Drawing.Color.GhostWhite;
            this.txtTotalLot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalLot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalLot.Location = new System.Drawing.Point(415, 92);
            this.txtTotalLot.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalLot.Name = "txtTotalLot";
            this.txtTotalLot.Size = new System.Drawing.Size(99, 23);
            this.txtTotalLot.TabIndex = 40;
            this.txtTotalLot.TextChanged += new System.EventHandler(this.txtTotalLot_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(348, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Total Lot :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(329, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Chattogram :";
            // 
            // txtCTG
            // 
            this.txtCTG.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCTG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCTG.Location = new System.Drawing.Point(415, 117);
            this.txtCTG.Margin = new System.Windows.Forms.Padding(2);
            this.txtCTG.Name = "txtCTG";
            this.txtCTG.Size = new System.Drawing.Size(99, 23);
            this.txtCTG.TabIndex = 42;
            this.txtCTG.TextChanged += new System.EventHandler(this.txtCTG_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(361, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "Dhaka :";
            // 
            // textDhk
            // 
            this.textDhk.BackColor = System.Drawing.Color.GhostWhite;
            this.textDhk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDhk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textDhk.Location = new System.Drawing.Point(415, 144);
            this.textDhk.Margin = new System.Windows.Forms.Padding(2);
            this.textDhk.Name = "textDhk";
            this.textDhk.Size = new System.Drawing.Size(99, 23);
            this.textDhk.TabIndex = 44;
            this.textDhk.TextChanged += new System.EventHandler(this.textDhk_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(352, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "Internal :";
            // 
            // textIntr
            // 
            this.textIntr.BackColor = System.Drawing.Color.GhostWhite;
            this.textIntr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIntr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textIntr.Location = new System.Drawing.Point(415, 170);
            this.textIntr.Margin = new System.Windows.Forms.Padding(2);
            this.textIntr.Name = "textIntr";
            this.textIntr.Size = new System.Drawing.Size(99, 23);
            this.textIntr.TabIndex = 46;
            this.textIntr.TextChanged += new System.EventHandler(this.textIntr_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(423, 276);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 32);
            this.btnRefresh.TabIndex = 48;
            this.btnRefresh.Text = "  Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KDS_Thread.Properties.Resources.save_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(312, 276);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 32);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(348, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 159;
            this.label8.Text = "Machine :";
            // 
            // cmbDyeMachine
            // 
            this.cmbDyeMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbDyeMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDyeMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDyeMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDyeMachine.FormattingEnabled = true;
            this.cmbDyeMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbDyeMachine.Location = new System.Drawing.Point(415, 65);
            this.cmbDyeMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDyeMachine.Name = "cmbDyeMachine";
            this.cmbDyeMachine.Size = new System.Drawing.Size(99, 23);
            this.cmbDyeMachine.TabIndex = 158;
            // 
            // frmUnitMchLotSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(621, 382);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDyeMachine);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textIntr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textDhk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCTG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalLot);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmUnitMchLotSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Lot Capacity";
            this.Load += new System.EventHandler(this.frmUnitMchLotSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalLot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCTG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDhk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textIntr;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDyeMachine;
    }
}