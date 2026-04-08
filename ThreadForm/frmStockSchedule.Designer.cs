namespace KDS_Thread.ThreadForm
{
    partial class frmWhiteSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhiteSchedule));
            this.dtgvJob = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.dtSchDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.lblDayTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvJob
            // 
            this.dtgvJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvJob.EnableHeadersVisualStyles = false;
            this.dtgvJob.Location = new System.Drawing.Point(148, 80);
            this.dtgvJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvJob.Name = "dtgvJob";
            this.dtgvJob.RowHeadersVisible = false;
            this.dtgvJob.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvJob.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvJob.RowTemplate.Height = 28;
            this.dtgvJob.Size = new System.Drawing.Size(135, 128);
            this.dtgvJob.TabIndex = 196;
            this.dtgvJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvJob_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(90, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 195;
            this.label7.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(148, 53);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(125, 23);
            this.txtJob.TabIndex = 194;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // dtSchDate
            // 
            this.dtSchDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSchDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSchDate.Location = new System.Drawing.Point(148, 26);
            this.dtSchDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtSchDate.Name = "dtSchDate";
            this.dtSchDate.Size = new System.Drawing.Size(125, 23);
            this.dtSchDate.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(50, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 198;
            this.label2.Text = "Schedule Date :";
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(22, 154);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(839, 202);
            this.gvListData.TabIndex = 200;
            this.gvListData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentClick);
            this.gvListData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellValueChanged);
            // 
            // lblDayTotal
            // 
            this.lblDayTotal.AutoSize = true;
            this.lblDayTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblDayTotal.Location = new System.Drawing.Point(532, 393);
            this.lblDayTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDayTotal.Name = "lblDayTotal";
            this.lblDayTotal.Size = new System.Drawing.Size(17, 19);
            this.lblDayTotal.TabIndex = 204;
            this.lblDayTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(445, 392);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 203;
            this.label8.Text = "Total Qty :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.MintCream;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::KDS_Thread.Properties.Resources.check_16;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(635, 384);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(109, 36);
            this.btnConfirm.TabIndex = 202;
            this.btnConfirm.Text = " Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(762, 384);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 201;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(657, 101);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 32);
            this.btnSearch.TabIndex = 197;
            this.btnSearch.Text = " Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(317, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 206;
            this.label1.Text = "Shade :";
            // 
            // cmbShade
            // 
            this.cmbShade.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShade.FormattingEnabled = true;
            this.cmbShade.Items.AddRange(new object[] {
            "Select",
            "BLACK",
            "WHITE",
            "RYWHT"});
            this.cmbShade.Location = new System.Drawing.Point(367, 23);
            this.cmbShade.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShade.Name = "cmbShade";
            this.cmbShade.Size = new System.Drawing.Size(104, 23);
            this.cmbShade.TabIndex = 205;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(498, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 208;
            this.label3.Text = "Stock QTY :";
            // 
            // txtStockQty
            // 
            this.txtStockQty.BackColor = System.Drawing.Color.GhostWhite;
            this.txtStockQty.Enabled = false;
            this.txtStockQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQty.ForeColor = System.Drawing.Color.Navy;
            this.txtStockQty.Location = new System.Drawing.Point(572, 49);
            this.txtStockQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(94, 23);
            this.txtStockQty.TabIndex = 207;
            this.txtStockQty.Text = "0";
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(572, 23);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(172, 21);
            this.cmbProduct.TabIndex = 212;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(511, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 211;
            this.label4.Text = "Product :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(318, 55);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 15);
            this.label16.TabIndex = 210;
            this.label16.Text = "Count :";
            // 
            // cmbCount
            // 
            this.cmbCount.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(368, 49);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(103, 23);
            this.cmbCount.TabIndex = 209;
            this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.cmbCount_SelectedIndexChanged);
            // 
            // frmWhiteSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(896, 441);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStockQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbShade);
            this.Controls.Add(this.lblDayTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtgvJob);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.dtSchDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtJob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWhiteSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Schedule";
            this.Load += new System.EventHandler(this.frmWhiteSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvJob;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.DateTimePicker dtSchDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblDayTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount;
    }
}