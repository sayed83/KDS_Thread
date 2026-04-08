namespace KDS_Thread.ThreadForm
{
    partial class frmMachineBreakdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachineBreakdown));
            this.label16 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMchType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(325, 43);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 15);
            this.label16.TabIndex = 106;
            this.label16.Text = "Shift :";
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(376, 40);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(125, 23);
            this.cmbShift.TabIndex = 105;
            // 
            // gvListData
            // 
            this.gvListData.AllowUserToDeleteRows = false;
            this.gvListData.AllowUserToResizeColumns = false;
            this.gvListData.AllowUserToResizeRows = false;
            this.gvListData.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.Location = new System.Drawing.Point(37, 215);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.MultiSelect = false;
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(576, 95);
            this.gvListData.TabIndex = 104;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(401, 338);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 36);
            this.btnRefresh.TabIndex = 103;
            this.btnRefresh.Text = " Refresh";
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
            this.btnSave.Location = new System.Drawing.Point(515, 338);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(113, 40);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(125, 23);
            this.dtDate.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(62, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 100;
            this.label1.Text = "Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(42, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 108;
            this.label4.Text = "Machine :";
            // 
            // cmbMachine
            // 
            this.cmbMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Location = new System.Drawing.Point(113, 95);
            this.cmbMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(125, 23);
            this.cmbMachine.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(303, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 110;
            this.label3.Text = "Remarks :";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemark.Location = new System.Drawing.Point(376, 69);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(212, 54);
            this.txtRemark.TabIndex = 111;
            this.txtRemark.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(33, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 113;
            this.label2.Text = "Mch. Type :";
            // 
            // cmbMchType
            // 
            this.cmbMchType.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbMchType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMchType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMchType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMchType.FormattingEnabled = true;
            this.cmbMchType.Items.AddRange(new object[] {
            "Select",
            "DY",
            "SW",
            "WI"});
            this.cmbMchType.Location = new System.Drawing.Point(113, 67);
            this.cmbMchType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMchType.Name = "cmbMchType";
            this.cmbMchType.Size = new System.Drawing.Size(125, 23);
            this.cmbMchType.TabIndex = 112;
            this.cmbMchType.SelectedIndexChanged += new System.EventHandler(this.cmbMchType_SelectedIndexChanged);
            // 
            // frmMachineBreakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(654, 410);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMchType);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMachine);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMachineBreakdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine Breakdown";
            this.Load += new System.EventHandler(this.frmMachineBreakdown_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMachine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMchType;
    }
}