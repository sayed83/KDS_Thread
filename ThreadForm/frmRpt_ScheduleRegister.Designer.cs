namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_ScheduleRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ScheduleRegister));
            this.dtgridJob = new System.Windows.Forms.DataGridView();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gridShade = new System.Windows.Forms.DataGridView();
            this.dtgvCount = new System.Windows.Forms.DataGridView();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtGvRepresentative = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRep = new System.Windows.Forms.TextBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtGvCustomer = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRetailer = new System.Windows.Forms.TextBox();
            this.dtgridRetailer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridRetailer)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgridJob
            // 
            this.dtgridJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridJob.EnableHeadersVisualStyles = false;
            this.dtgridJob.Location = new System.Drawing.Point(546, 54);
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
            this.dtgridJob.Size = new System.Drawing.Size(133, 146);
            this.dtgridJob.TabIndex = 168;
            this.dtgridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridJob_CellClick);
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(416, 53);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(126, 23);
            this.txtJob.TabIndex = 167;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(360, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 166;
            this.label10.Text = "Job No.:";
            // 
            // gridShade
            // 
            this.gridShade.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShade.EnableHeadersVisualStyles = false;
            this.gridShade.Location = new System.Drawing.Point(546, 106);
            this.gridShade.Margin = new System.Windows.Forms.Padding(2);
            this.gridShade.MultiSelect = false;
            this.gridShade.Name = "gridShade";
            this.gridShade.ReadOnly = true;
            this.gridShade.RowHeadersVisible = false;
            this.gridShade.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gridShade.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridShade.RowTemplate.Height = 28;
            this.gridShade.Size = new System.Drawing.Size(119, 141);
            this.gridShade.TabIndex = 162;
            this.gridShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShade_CellClick);
            // 
            // dtgvCount
            // 
            this.dtgvCount.BackgroundColor = System.Drawing.Color.Beige;
            this.dtgvCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvCount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCount.EnableHeadersVisualStyles = false;
            this.dtgvCount.Location = new System.Drawing.Point(546, 75);
            this.dtgvCount.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvCount.MultiSelect = false;
            this.dtgvCount.Name = "dtgvCount";
            this.dtgvCount.ReadOnly = true;
            this.dtgvCount.RowHeadersVisible = false;
            this.dtgvCount.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvCount.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvCount.RowTemplate.Height = 28;
            this.dtgvCount.Size = new System.Drawing.Size(178, 146);
            this.dtgvCount.TabIndex = 165;
            this.dtgvCount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCount_CellClick);
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCount.Location = new System.Drawing.Point(416, 79);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(126, 23);
            this.txtCount.TabIndex = 164;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            this.txtCount.Enter += new System.EventHandler(this.txtCount_Enter);
            this.txtCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCount_KeyDown);
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(365, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 161;
            this.label8.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(416, 105);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(126, 23);
            this.txtShade.TabIndex = 160;
            this.txtShade.TextChanged += new System.EventHandler(this.txtShade_TextChanged);
            this.txtShade.Enter += new System.EventHandler(this.txtShade_Enter);
            this.txtShade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShade_KeyDown);
            this.txtShade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShade_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(355, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 159;
            this.label9.Text = "Product :";
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbSortBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Items.AddRange(new object[] {
            "Count",
            "Shade",
            "Job"});
            this.cmbSortBy.Location = new System.Drawing.Point(135, 162);
            this.cmbSortBy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(125, 23);
            this.cmbSortBy.TabIndex = 158;
            this.cmbSortBy.SelectedIndexChanged += new System.EventHandler(this.cmbSortBy_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(77, 165);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 157;
            this.label7.Text = "Sort By :";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(135, 135);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(125, 23);
            this.cmbZone.TabIndex = 156;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(90, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 155;
            this.label6.Text = "Zone :";
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(135, 108);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 143;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(93, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 154;
            this.label5.Text = "Unit :";
            // 
            // dtGvRepresentative
            // 
            this.dtGvRepresentative.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtGvRepresentative.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvRepresentative.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGvRepresentative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvRepresentative.EnableHeadersVisualStyles = false;
            this.dtGvRepresentative.Location = new System.Drawing.Point(583, 162);
            this.dtGvRepresentative.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvRepresentative.MultiSelect = false;
            this.dtGvRepresentative.Name = "dtGvRepresentative";
            this.dtGvRepresentative.ReadOnly = true;
            this.dtGvRepresentative.RowHeadersVisible = false;
            this.dtGvRepresentative.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvRepresentative.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGvRepresentative.RowTemplate.Height = 28;
            this.dtGvRepresentative.Size = new System.Drawing.Size(178, 146);
            this.dtGvRepresentative.TabIndex = 153;
            this.dtGvRepresentative.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvRepresentative_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(343, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 152;
            this.label3.Text = "Sales Rep. :";
            // 
            // txtRep
            // 
            this.txtRep.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRep.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRep.Location = new System.Drawing.Point(416, 159);
            this.txtRep.Margin = new System.Windows.Forms.Padding(2);
            this.txtRep.Name = "txtRep";
            this.txtRep.Size = new System.Drawing.Size(126, 23);
            this.txtRep.TabIndex = 151;
            this.txtRep.TextChanged += new System.EventHandler(this.txtRep_TextChanged);
            this.txtRep.Enter += new System.EventHandler(this.txtRep_Enter);
            this.txtRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRep_KeyDown);
            this.txtRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRep_KeyPress);
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(135, 81);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 150;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(75, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 149;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(135, 54);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 148;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(59, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 147;
            this.label2.Text = "From Date :";
            // 
            // dtGvCustomer
            // 
            this.dtGvCustomer.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtGvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvCustomer.EnableHeadersVisualStyles = false;
            this.dtGvCustomer.Location = new System.Drawing.Point(546, 129);
            this.dtGvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvCustomer.MultiSelect = false;
            this.dtGvCustomer.Name = "dtGvCustomer";
            this.dtGvCustomer.ReadOnly = true;
            this.dtGvCustomer.RowHeadersVisible = false;
            this.dtGvCustomer.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtGvCustomer.RowTemplate.Height = 28;
            this.dtGvCustomer.Size = new System.Drawing.Size(178, 146);
            this.dtGvCustomer.TabIndex = 146;
            this.dtGvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvCustomer_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(345, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 144;
            this.label4.Text = "Customer :";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCustomer.Location = new System.Drawing.Point(416, 132);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(126, 23);
            this.txtCustomer.TabIndex = 142;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(435, 295);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 37);
            this.btnRefresh.TabIndex = 163;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(305, 296);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(107, 36);
            this.btnPreview.TabIndex = 145;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(354, 189);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 170;
            this.label11.Text = "Retailer :";
            // 
            // txtRetailer
            // 
            this.txtRetailer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRetailer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetailer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRetailer.Location = new System.Drawing.Point(416, 186);
            this.txtRetailer.Margin = new System.Windows.Forms.Padding(2);
            this.txtRetailer.Name = "txtRetailer";
            this.txtRetailer.Size = new System.Drawing.Size(126, 23);
            this.txtRetailer.TabIndex = 169;
            this.txtRetailer.TextChanged += new System.EventHandler(this.txtRetailer_TextChanged);
            this.txtRetailer.Enter += new System.EventHandler(this.txtRetailer_Enter);
            this.txtRetailer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRetailer_KeyDown);
            this.txtRetailer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetailer_KeyPress);
            // 
            // dtgridRetailer
            // 
            this.dtgridRetailer.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dtgridRetailer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridRetailer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridRetailer.EnableHeadersVisualStyles = false;
            this.dtgridRetailer.Location = new System.Drawing.Point(557, 191);
            this.dtgridRetailer.Margin = new System.Windows.Forms.Padding(2);
            this.dtgridRetailer.MultiSelect = false;
            this.dtgridRetailer.Name = "dtgridRetailer";
            this.dtgridRetailer.ReadOnly = true;
            this.dtgridRetailer.RowHeadersVisible = false;
            this.dtgridRetailer.RowHeadersWidth = 62;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgridRetailer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgridRetailer.RowTemplate.Height = 28;
            this.dtgridRetailer.Size = new System.Drawing.Size(133, 146);
            this.dtgridRetailer.TabIndex = 171;
            this.dtgridRetailer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridRetailer_CellClick);
            // 
            // frmRpt_ScheduleRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(826, 372);
            this.Controls.Add(this.dtgridRetailer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRetailer);
            this.Controls.Add(this.dtgridJob);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gridShade);
            this.Controls.Add(this.dtgvCount);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtShade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtGvRepresentative);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRep);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtGvCustomer);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRpt_ScheduleRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Schedule Register Report";
            this.Load += new System.EventHandler(this.frmRpt_ScheduleRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridRetailer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgridJob;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView gridShade;
        private System.Windows.Forms.DataGridView dtgvCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtGvRepresentative;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRep;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtGvCustomer;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRetailer;
        private System.Windows.Forms.DataGridView dtgridRetailer;
    }
}