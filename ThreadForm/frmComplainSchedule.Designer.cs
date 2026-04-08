namespace KDS_Thread.ThreadForm
{
    partial class frmComplainSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComplainSchedule));
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtMinKG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMchKG = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlanMachine = new System.Windows.Forms.ComboBox();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.gridJob = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(44, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 67;
            this.label6.Text = "Order ID :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.Location = new System.Drawing.Point(254, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 23);
            this.btnSearch.TabIndex = 165;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "Chattogram",
            "Dhaka"});
            this.cmbUnit.Location = new System.Drawing.Point(519, 24);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(465, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 153;
            this.label5.Text = "Unit :";
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(33, 139);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(904, 174);
            this.gvListData.TabIndex = 154;
            this.gvListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellClick);
            this.gvListData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(701, 335);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 34);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.MintCream;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::KDS_Thread.Properties.Resources.save_icon;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(822, 334);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 35);
            this.btnConfirm.TabIndex = 155;
            this.btnConfirm.Text = "  Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtMinKG
            // 
            this.txtMinKG.AutoSize = true;
            this.txtMinKG.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinKG.ForeColor = System.Drawing.Color.Navy;
            this.txtMinKG.Location = new System.Drawing.Point(829, 55);
            this.txtMinKG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMinKG.Name = "txtMinKG";
            this.txtMinKG.Size = new System.Drawing.Size(13, 13);
            this.txtMinKG.TabIndex = 164;
            this.txtMinKG.Text = "0";
            this.txtMinKG.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(787, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 163;
            this.label9.Text = "(KG)";
            // 
            // txtMchKG
            // 
            this.txtMchKG.AutoSize = true;
            this.txtMchKG.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMchKG.ForeColor = System.Drawing.Color.Navy;
            this.txtMchKG.Location = new System.Drawing.Point(753, 52);
            this.txtMchKG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMchKG.Name = "txtMchKG";
            this.txtMchKG.Size = new System.Drawing.Size(13, 13);
            this.txtMchKG.TabIndex = 162;
            this.txtMchKG.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(675, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 161;
            this.label4.Text = "Plan Mch. :";
            // 
            // cmbPlanMachine
            // 
            this.cmbPlanMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbPlanMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPlanMachine.FormattingEnabled = true;
            this.cmbPlanMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbPlanMachine.Location = new System.Drawing.Point(749, 26);
            this.cmbPlanMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlanMachine.Name = "cmbPlanMachine";
            this.cmbPlanMachine.Size = new System.Drawing.Size(94, 23);
            this.cmbPlanMachine.TabIndex = 160;
            this.cmbPlanMachine.SelectedIndexChanged += new System.EventHandler(this.cmbPlanMachine_SelectedIndexChanged);
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Location = new System.Drawing.Point(519, 51);
            this.dtPlanDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(125, 23);
            this.dtPlanDate.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(446, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 158;
            this.label1.Text = "Plan Date :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(119, 26);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(125, 23);
            this.txtJob.TabIndex = 71;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // gridJob
            // 
            this.gridJob.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.gridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJob.Location = new System.Drawing.Point(121, 53);
            this.gridJob.Margin = new System.Windows.Forms.Padding(2);
            this.gridJob.Name = "gridJob";
            this.gridJob.RowHeadersVisible = false;
            this.gridJob.RowHeadersWidth = 62;
            this.gridJob.RowTemplate.Height = 28;
            this.gridJob.Size = new System.Drawing.Size(123, 120);
            this.gridJob.TabIndex = 166;
            this.gridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridJob_CellClick);
            this.gridJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridJob_KeyPress);
            // 
            // frmComplainSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(967, 408);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.gridJob);
            this.Controls.Add(this.txtMinKG);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMchKG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlanMachine);
            this.Controls.Add(this.dtPlanDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmComplainSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complain Schedule";
            this.Load += new System.EventHandler(this.frmComplainSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label txtMinKG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtMchKG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlanMachine;
        private System.Windows.Forms.DateTimePicker dtPlanDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.DataGridView gridJob;
    }
}