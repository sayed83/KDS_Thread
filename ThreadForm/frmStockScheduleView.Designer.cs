namespace KDS_Thread.ThreadForm
{
    partial class frmStockScheduleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockScheduleView));
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(393, 71);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 33);
            this.btnSearch.TabIndex = 198;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(366, 20);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 197;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(304, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 196;
            this.label13.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(143, 20);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 195;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(67, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 194;
            this.label2.Text = "From Date :";
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.Location = new System.Drawing.Point(43, 144);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.MultiSelect = false;
            this.gvListData.Name = "gvListData";
            this.gvListData.ReadOnly = true;
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(715, 165);
            this.gvListData.TabIndex = 199;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(659, 325);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 200;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStockScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(795, 389);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStockScheduleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Schedule View";
            this.Load += new System.EventHandler(this.frmStockScheduleView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnClose;
    }
}