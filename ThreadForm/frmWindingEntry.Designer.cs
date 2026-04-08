namespace KDS_Thread.ThreadForm
{
    partial class frmWindingEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWindingEntry));
            this.gridDyeLot = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDyeLot = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWinMachine = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDyeLot
            // 
            this.gridDyeLot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDyeLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDyeLot.EnableHeadersVisualStyles = false;
            this.gridDyeLot.Location = new System.Drawing.Point(91, 64);
            this.gridDyeLot.Margin = new System.Windows.Forms.Padding(2);
            this.gridDyeLot.MultiSelect = false;
            this.gridDyeLot.Name = "gridDyeLot";
            this.gridDyeLot.ReadOnly = true;
            this.gridDyeLot.RowHeadersVisible = false;
            this.gridDyeLot.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gridDyeLot.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDyeLot.RowTemplate.Height = 28;
            this.gridDyeLot.Size = new System.Drawing.Size(127, 116);
            this.gridDyeLot.TabIndex = 73;
            this.gridDyeLot.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDyeLot_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(20, 130);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(789, 178);
            this.gvListData.TabIndex = 74;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            this.gvListData.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellMouseLeave);
            this.gvListData.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvListData_CellMouseMove);
            this.gvListData.SelectionChanged += new System.EventHandler(this.gvListData_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(627, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 72;
            this.label1.Text = "Shift :";
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(678, 42);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(97, 23);
            this.cmbShift.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(32, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 68;
            this.label4.Text = "DyeLot :";
            // 
            // txtDyeLot
            // 
            this.txtDyeLot.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDyeLot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDyeLot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDyeLot.Location = new System.Drawing.Point(91, 40);
            this.txtDyeLot.Margin = new System.Windows.Forms.Padding(2);
            this.txtDyeLot.Name = "txtDyeLot";
            this.txtDyeLot.Size = new System.Drawing.Size(129, 23);
            this.txtDyeLot.TabIndex = 62;
            this.txtDyeLot.TextChanged += new System.EventHandler(this.txtDyeLot_TextChanged);
            this.txtDyeLot.Enter += new System.EventHandler(this.txtDyeLot_Enter);
            this.txtDyeLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDyeLot_KeyDown);
            this.txtDyeLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDyeLot_KeyPress);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(492, 42);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(108, 23);
            this.dtDate.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(447, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 65;
            this.label2.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(425, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "Machine :";
            // 
            // cmbWinMachine
            // 
            this.cmbWinMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbWinMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWinMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbWinMachine.FormattingEnabled = true;
            this.cmbWinMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbWinMachine.Location = new System.Drawing.Point(492, 69);
            this.cmbWinMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWinMachine.Name = "cmbWinMachine";
            this.cmbWinMachine.Size = new System.Drawing.Size(109, 23);
            this.cmbWinMachine.TabIndex = 66;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(249, 39);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 63;
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
            this.btnRefresh.Location = new System.Drawing.Point(713, 344);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 35);
            this.btnRefresh.TabIndex = 69;
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
            this.btnSave.Location = new System.Drawing.Point(598, 344);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmWindingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(859, 414);
            this.Controls.Add(this.gridDyeLot);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDyeLot);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbWinMachine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmWindingEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winding Entry";
            this.Load += new System.EventHandler(this.frmWindingEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDyeLot;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDyeLot;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbWinMachine;
    }
}