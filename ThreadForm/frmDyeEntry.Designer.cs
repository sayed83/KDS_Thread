namespace KDS_Thread.ThreadForm
{
    partial class frmDyeEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDyeEntry));
            this.label4 = new System.Windows.Forms.Label();
            this.txtDyeLot = new System.Windows.Forms.TextBox();
            this.dtDyeDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.gridDyeLot = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(38, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 55;
            this.label4.Text = "DyeLot :";
            // 
            // txtDyeLot
            // 
            this.txtDyeLot.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDyeLot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDyeLot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDyeLot.Location = new System.Drawing.Point(95, 46);
            this.txtDyeLot.Margin = new System.Windows.Forms.Padding(2);
            this.txtDyeLot.Name = "txtDyeLot";
            this.txtDyeLot.Size = new System.Drawing.Size(130, 23);
            this.txtDyeLot.TabIndex = 54;
            this.txtDyeLot.TextChanged += new System.EventHandler(this.txtDyeLot_TextChanged);
            this.txtDyeLot.Enter += new System.EventHandler(this.txtDyeLot_Enter);
            this.txtDyeLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDyeLot_KeyDown);
            this.txtDyeLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDyeLot_KeyPress);
            // 
            // dtDyeDate
            // 
            this.dtDyeDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDyeDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDyeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDyeDate.Location = new System.Drawing.Point(526, 49);
            this.dtDyeDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDyeDate.Name = "dtDyeDate";
            this.dtDyeDate.Size = new System.Drawing.Size(108, 23);
            this.dtDyeDate.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(455, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Dye Date :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(257, 46);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 57;
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
            this.btnRefresh.Location = new System.Drawing.Point(797, 335);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 35);
            this.btnRefresh.TabIndex = 56;
            this.btnRefresh.Text = "Refresh";
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
            this.btnSave.Location = new System.Drawing.Point(691, 335);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(676, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 59;
            this.label1.Text = "Shift :";
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbShift.Location = new System.Drawing.Point(721, 48);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(97, 23);
            this.cmbShift.TabIndex = 58;
            // 
            // gridDyeLot
            // 
            this.gridDyeLot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDyeLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDyeLot.EnableHeadersVisualStyles = false;
            this.gridDyeLot.Location = new System.Drawing.Point(95, 71);
            this.gridDyeLot.Margin = new System.Windows.Forms.Padding(2);
            this.gridDyeLot.MultiSelect = false;
            this.gridDyeLot.Name = "gridDyeLot";
            this.gridDyeLot.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDyeLot.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDyeLot.RowHeadersVisible = false;
            this.gridDyeLot.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gridDyeLot.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDyeLot.RowTemplate.Height = 28;
            this.gridDyeLot.Size = new System.Drawing.Size(129, 125);
            this.gridDyeLot.TabIndex = 60;
            this.gridDyeLot.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDyeLot_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(30, 154);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(862, 153);
            this.gvListData.TabIndex = 61;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            this.gvListData.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellMouseLeave);
            this.gvListData.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvListData_CellMouseMove);
            this.gvListData.SelectionChanged += new System.EventHandler(this.gvListData_SelectionChanged);
            // 
            // frmDyeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(929, 430);
            this.Controls.Add(this.gridDyeLot);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDyeLot);
            this.Controls.Add(this.dtDyeDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmDyeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dyeing Entry";
            this.Load += new System.EventHandler(this.frmDyeEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDyeLot;
        private System.Windows.Forms.DateTimePicker dtDyeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.DataGridView gridDyeLot;
        private System.Windows.Forms.DataGridView gvListData;
    }
}