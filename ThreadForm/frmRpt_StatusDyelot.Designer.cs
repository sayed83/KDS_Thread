namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_StatusDyelot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_StatusDyelot));
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDyeMachine = new System.Windows.Forms.ComboBox();
            this.gridDyeLot = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDyeLot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWinMachine = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(421, 230);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(107, 36);
            this.btnPreview.TabIndex = 142;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(137, 169);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 138;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(95, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 139;
            this.label5.Text = "Unit :";
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(137, 141);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 146;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(73, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 145;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(137, 114);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 144;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(57, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 143;
            this.label2.Text = "From Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(332, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 155;
            this.label6.Text = "Dye Machine :";
            // 
            // cmbDyeMachine
            // 
            this.cmbDyeMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbDyeMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDyeMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDyeMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDyeMachine.FormattingEnabled = true;
            this.cmbDyeMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbDyeMachine.Location = new System.Drawing.Point(421, 111);
            this.cmbDyeMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDyeMachine.Name = "cmbDyeMachine";
            this.cmbDyeMachine.Size = new System.Drawing.Size(109, 23);
            this.cmbDyeMachine.TabIndex = 154;
            // 
            // gridDyeLot
            // 
            this.gridDyeLot.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.gridDyeLot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDyeLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDyeLot.EnableHeadersVisualStyles = false;
            this.gridDyeLot.Location = new System.Drawing.Point(266, 230);
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
            this.gridDyeLot.Size = new System.Drawing.Size(118, 112);
            this.gridDyeLot.TabIndex = 158;
            this.gridDyeLot.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDyeLot_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(79, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 157;
            this.label4.Text = "DyeLot :";
            // 
            // txtDyeLot
            // 
            this.txtDyeLot.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDyeLot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDyeLot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDyeLot.Location = new System.Drawing.Point(135, 227);
            this.txtDyeLot.Margin = new System.Windows.Forms.Padding(2);
            this.txtDyeLot.Name = "txtDyeLot";
            this.txtDyeLot.Size = new System.Drawing.Size(127, 23);
            this.txtDyeLot.TabIndex = 156;
            this.txtDyeLot.TextChanged += new System.EventHandler(this.txtDyeLot_TextChanged);
            this.txtDyeLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDyeLot_KeyDown);
            this.txtDyeLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDyeLot_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(329, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 159;
            this.label3.Text = "Win. Machine :";
            // 
            // cmbWinMachine
            // 
            this.cmbWinMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbWinMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbWinMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWinMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbWinMachine.FormattingEnabled = true;
            this.cmbWinMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbWinMachine.Location = new System.Drawing.Point(421, 139);
            this.cmbWinMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWinMachine.Name = "cmbWinMachine";
            this.cmbWinMachine.Size = new System.Drawing.Size(109, 23);
            this.cmbWinMachine.TabIndex = 160;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.LightPink;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Select",
            "Dyeing",
            "Winding",
            "Packing",
            "RFD"});
            this.cmbStatus.Location = new System.Drawing.Point(263, 22);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(168, 28);
            this.cmbStatus.TabIndex = 161;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(187, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 162;
            this.label7.Text = "Status :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(91, 199);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 164;
            this.label8.Text = "Shift :";
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShift.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(137, 196);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(125, 23);
            this.cmbShift.TabIndex = 163;
            // 
            // frmRpt_StatusDyelot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(656, 389);
            this.Controls.Add(this.gridDyeLot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbWinMachine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDyeLot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDyeMachine);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRpt_StatusDyelot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Status Report";
            this.Load += new System.EventHandler(this.frmRpt_StatusDyelot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDyeLot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDyeMachine;
        private System.Windows.Forms.DataGridView gridDyeLot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDyeLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWinMachine;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbShift;
    }
}