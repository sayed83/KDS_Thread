namespace KDS_Thread.ThreadForm
{
    partial class frmUpdateSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSchedule));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtgridJob = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSchDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.dtTransferDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbShade = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(105, 148);
            this.chkAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 118;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // dtgridJob
            // 
            this.dtgridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridJob.EnableHeadersVisualStyles = false;
            this.dtgridJob.Location = new System.Drawing.Point(187, 56);
            this.dtgridJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgridJob.MultiSelect = false;
            this.dtgridJob.Name = "dtgridJob";
            this.dtgridJob.ReadOnly = true;
            this.dtgridJob.RowHeadersVisible = false;
            this.dtgridJob.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgridJob.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgridJob.RowTemplate.Height = 28;
            this.dtgridJob.Size = new System.Drawing.Size(125, 124);
            this.dtgridJob.TabIndex = 115;
            this.dtgridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridJob_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(93, 136);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(657, 211);
            this.gvListData.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(102, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 113;
            this.label4.Text = "Job No. :";
            // 
            // txtJobNo
            // 
            this.txtJobNo.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJobNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNo.Location = new System.Drawing.Point(161, 30);
            this.txtJobNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(126, 23);
            this.txtJobNo.TabIndex = 112;
            this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            this.txtJobNo.Enter += new System.EventHandler(this.txtJobNo_Enter);
            this.txtJobNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNo_KeyDown);
            this.txtJobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(61, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 120;
            this.label3.Text = "Schedule Date :";
            // 
            // cmbSchDate
            // 
            this.cmbSchDate.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbSchDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSchDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSchDate.FormattingEnabled = true;
            this.cmbSchDate.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbSchDate.Location = new System.Drawing.Point(161, 56);
            this.cmbSchDate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSchDate.Name = "cmbSchDate";
            this.cmbSchDate.Size = new System.Drawing.Size(126, 23);
            this.cmbSchDate.TabIndex = 119;
            this.cmbSchDate.SelectedIndexChanged += new System.EventHandler(this.cmbSchDate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(393, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 122;
            this.label1.Text = "Machine :";
            // 
            // cmbMachine
            // 
            this.cmbMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbMachine.Location = new System.Drawing.Point(460, 59);
            this.cmbMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(109, 23);
            this.cmbMachine.TabIndex = 121;
            // 
            // dtTransferDate
            // 
            this.dtTransferDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransferDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTransferDate.Location = new System.Drawing.Point(460, 32);
            this.dtTransferDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtTransferDate.Name = "dtTransferDate";
            this.dtTransferDate.Size = new System.Drawing.Size(117, 23);
            this.dtTransferDate.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(365, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 123;
            this.label2.Text = "Transfer Date :";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTransfer.Image = global::KDS_Thread.Properties.Resources.right_arrow1;
            this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfer.Location = new System.Drawing.Point(547, 377);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(95, 32);
            this.btnTransfer.TabIndex = 117;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(655, 89);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 32);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(657, 377);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 32);
            this.btnRefresh.TabIndex = 125;
            this.btnRefresh.Text = "  Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(108, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 193;
            this.label6.Text = "Shade :";
            // 
            // cmbShade
            // 
            this.cmbShade.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShade.FormattingEnabled = true;
            this.cmbShade.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbShade.Location = new System.Drawing.Point(161, 86);
            this.cmbShade.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShade.Name = "cmbShade";
            this.cmbShade.Size = new System.Drawing.Size(126, 23);
            this.cmbShade.TabIndex = 194;
            // 
            // frmUpdateSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(813, 462);
            this.Controls.Add(this.dtgridJob);
            this.Controls.Add(this.cmbShade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtTransferDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMachine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSchDate);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmUpdateSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Schedule Date";
            this.Load += new System.EventHandler(this.frmUpdateSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.DataGridView dtgridJob;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSchDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMachine;
        private System.Windows.Forms.DateTimePicker dtTransferDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbShade;
    }
}