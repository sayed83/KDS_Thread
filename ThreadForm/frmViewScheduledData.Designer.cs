namespace KDS_Thread.ThreadForm
{
    partial class frmViewScheduledData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewScheduledData));
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.dtgvShade = new System.Windows.Forms.DataGridView();
            this.dtgvJob = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSchMachine = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTotalPack = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShade_Transfer = new System.Windows.Forms.Label();
            this.lblJob_Transfer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).BeginInit();
            this.SuspendLayout();
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(118, 54);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 78;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(56, 59);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 77;
            this.label13.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(118, 25);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 76;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(38, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 75;
            this.label2.Text = "From Date :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1050, 413);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 184;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(13, 116);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvListData.Size = new System.Drawing.Size(1136, 291);
            this.gvListData.TabIndex = 183;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            this.gvListData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(310, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 190;
            this.label7.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(371, 24);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(125, 23);
            this.txtJob.TabIndex = 189;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(317, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 188;
            this.label6.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(371, 50);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(125, 23);
            this.txtShade.TabIndex = 185;
            this.txtShade.TextChanged += new System.EventHandler(this.txtShade_TextChanged);
            this.txtShade.Enter += new System.EventHandler(this.txtShade_Enter);
            this.txtShade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShade_KeyDown);
            this.txtShade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShade_KeyPress);
            // 
            // dtgvShade
            // 
            this.dtgvShade.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvShade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvShade.EnableHeadersVisualStyles = false;
            this.dtgvShade.Location = new System.Drawing.Point(376, 75);
            this.dtgvShade.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvShade.Name = "dtgvShade";
            this.dtgvShade.RowHeadersVisible = false;
            this.dtgvShade.RowHeadersWidth = 62;
            this.dtgvShade.RowTemplate.Height = 28;
            this.dtgvShade.Size = new System.Drawing.Size(107, 120);
            this.dtgvShade.TabIndex = 191;
            this.dtgvShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvShade_CellClick);
            // 
            // dtgvJob
            // 
            this.dtgvJob.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgvJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvJob.EnableHeadersVisualStyles = false;
            this.dtgvJob.Location = new System.Drawing.Point(421, 50);
            this.dtgvJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvJob.Name = "dtgvJob";
            this.dtgvJob.RowHeadersVisible = false;
            this.dtgvJob.RowHeadersWidth = 62;
            this.dtgvJob.RowTemplate.Height = 28;
            this.dtgvJob.Size = new System.Drawing.Size(123, 130);
            this.dtgvJob.TabIndex = 192;
            this.dtgvJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvJob_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(549, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 187;
            this.label5.Text = "Sch. Mch :";
            // 
            // cmbSchMachine
            // 
            this.cmbSchMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbSchMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSchMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSchMachine.FormattingEnabled = true;
            this.cmbSchMachine.Location = new System.Drawing.Point(619, 21);
            this.cmbSchMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSchMachine.Name = "cmbSchMachine";
            this.cmbSchMachine.Size = new System.Drawing.Size(125, 23);
            this.cmbSchMachine.TabIndex = 186;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(646, 59);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 33);
            this.btnSearch.TabIndex = 193;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTotalPack
            // 
            this.lblTotalPack.AutoSize = true;
            this.lblTotalPack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPack.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalPack.Location = new System.Drawing.Point(940, 422);
            this.lblTotalPack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPack.Name = "lblTotalPack";
            this.lblTotalPack.Size = new System.Drawing.Size(17, 19);
            this.lblTotalPack.TabIndex = 197;
            this.lblTotalPack.Text = "0";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalQty.Location = new System.Drawing.Point(768, 422);
            this.lblTotalQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(17, 19);
            this.lblTotalQty.TabIndex = 196;
            this.lblTotalQty.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(846, 422);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 19);
            this.label11.TabIndex = 195;
            this.label11.Text = "Total PKG :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(677, 422);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 194;
            this.label1.Text = "Total QTY  :";
            // 
            // lblShade_Transfer
            // 
            this.lblShade_Transfer.AutoSize = true;
            this.lblShade_Transfer.Location = new System.Drawing.Point(41, 427);
            this.lblShade_Transfer.Name = "lblShade_Transfer";
            this.lblShade_Transfer.Size = new System.Drawing.Size(35, 13);
            this.lblShade_Transfer.TabIndex = 198;
            this.lblShade_Transfer.Text = "label3";
            // 
            // lblJob_Transfer
            // 
            this.lblJob_Transfer.AutoSize = true;
            this.lblJob_Transfer.Location = new System.Drawing.Point(82, 428);
            this.lblJob_Transfer.Name = "lblJob_Transfer";
            this.lblJob_Transfer.Size = new System.Drawing.Size(35, 13);
            this.lblJob_Transfer.TabIndex = 199;
            this.lblJob_Transfer.Text = "label3";
            // 
            // frmViewScheduledData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1162, 466);
            this.Controls.Add(this.lblJob_Transfer);
            this.Controls.Add(this.lblShade_Transfer);
            this.Controls.Add(this.lblTotalPack);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvJob);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtgvShade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtShade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSchMachine);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewScheduledData";
            this.Text = "Scheduled Data For Planning";
            this.Load += new System.EventHandler(this.frmViewScheduledData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.DataGridView dtgvShade;
        private System.Windows.Forms.DataGridView dtgvJob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSchMachine;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTotalPack;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShade_Transfer;
        private System.Windows.Forms.Label lblJob_Transfer;
    }
}