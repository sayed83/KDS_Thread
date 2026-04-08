namespace KDS_Thread.ThreadForm
{
    partial class frmDeleteSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteSchedule));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtgridJob = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(56, 101);
            this.chkAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 111;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // dtgridJob
            // 
            this.dtgridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridJob.EnableHeadersVisualStyles = false;
            this.dtgridJob.Location = new System.Drawing.Point(105, 44);
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
            this.dtgridJob.Size = new System.Drawing.Size(125, 123);
            this.dtgridJob.TabIndex = 108;
            this.dtgridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridJob_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(45, 86);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(649, 228);
            this.gvListData.TabIndex = 109;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(47, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 106;
            this.label4.Text = "Job No. :";
            // 
            // txtJobNo
            // 
            this.txtJobNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtJobNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNo.Location = new System.Drawing.Point(105, 20);
            this.txtJobNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(126, 23);
            this.txtJobNo.TabIndex = 105;
            this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            this.txtJobNo.Enter += new System.EventHandler(this.txtJobNo_Enter);
            this.txtJobNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNo_KeyDown);
            this.txtJobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Image = global::KDS_Thread.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(599, 331);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 32);
            this.btnDelete.TabIndex = 110;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(287, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 107;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmDeleteSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(729, 394);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtgridJob);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeleteSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete CS Schedule";
            this.Load += new System.EventHandler(this.frmDeleteSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dtgridJob;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJobNo;
    }
}