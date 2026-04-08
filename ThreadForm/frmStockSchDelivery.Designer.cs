namespace KDS_Thread.ThreadForm
{
    partial class frmStockSchDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockSchDelivery));
            this.lblDayTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgvJob = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.dtSchDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDayTotal
            // 
            this.lblDayTotal.AutoSize = true;
            this.lblDayTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblDayTotal.Location = new System.Drawing.Point(545, 385);
            this.lblDayTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDayTotal.Name = "lblDayTotal";
            this.lblDayTotal.Size = new System.Drawing.Size(17, 19);
            this.lblDayTotal.TabIndex = 215;
            this.lblDayTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(458, 384);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 214;
            this.label8.Text = "Total Qty :";
            // 
            // dtgvJob
            // 
            this.dtgvJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvJob.EnableHeadersVisualStyles = false;
            this.dtgvJob.Location = new System.Drawing.Point(135, 63);
            this.dtgvJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvJob.Name = "dtgvJob";
            this.dtgvJob.RowHeadersVisible = false;
            this.dtgvJob.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvJob.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvJob.RowTemplate.Height = 28;
            this.dtgvJob.Size = new System.Drawing.Size(125, 127);
            this.dtgvJob.TabIndex = 207;
            this.dtgvJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvJob_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(35, 142);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(839, 217);
            this.gvListData.TabIndex = 211;
            this.gvListData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentClick);
            this.gvListData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellValueChanged);
            // 
            // dtSchDate
            // 
            this.dtSchDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSchDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSchDate.Location = new System.Drawing.Point(415, 37);
            this.dtSchDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtSchDate.Name = "dtSchDate";
            this.dtSchDate.Size = new System.Drawing.Size(125, 23);
            this.dtSchDate.TabIndex = 210;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(318, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 209;
            this.label2.Text = "Delivery Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(73, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 206;
            this.label7.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(135, 37);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(125, 23);
            this.txtJob.TabIndex = 205;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.MintCream;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::KDS_Thread.Properties.Resources.check_16;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(651, 375);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(109, 36);
            this.btnConfirm.TabIndex = 213;
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
            this.btnClose.Location = new System.Drawing.Point(775, 375);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 212;
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
            this.btnSearch.Location = new System.Drawing.Point(594, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 32);
            this.btnSearch.TabIndex = 208;
            this.btnSearch.Text = " Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmStockSchDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(907, 430);
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
            this.Name = "frmStockSchDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Delivery";
            this.Load += new System.EventHandler(this.frmStockSchDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDayTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dtgvJob;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.DateTimePicker dtSchDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJob;
    }
}