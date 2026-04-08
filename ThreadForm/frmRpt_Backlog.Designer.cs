namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_Backlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_Backlog));
            this.gvProduct = new System.Windows.Forms.DataGridView();
            this.gvRetailer = new System.Windows.Forms.DataGridView();
            this.txtRetailer = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbReport = new System.Windows.Forms.ComboBox();
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.gridJob = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetailer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).BeginInit();
            this.SuspendLayout();
            // 
            // gvProduct
            // 
            this.gvProduct.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.gvProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProduct.EnableHeadersVisualStyles = false;
            this.gvProduct.Location = new System.Drawing.Point(541, 193);
            this.gvProduct.Margin = new System.Windows.Forms.Padding(2);
            this.gvProduct.MultiSelect = false;
            this.gvProduct.Name = "gvProduct";
            this.gvProduct.ReadOnly = true;
            this.gvProduct.RowHeadersVisible = false;
            this.gvProduct.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvProduct.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProduct.RowTemplate.Height = 28;
            this.gvProduct.Size = new System.Drawing.Size(178, 141);
            this.gvProduct.TabIndex = 159;
            this.gvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProduct_CellClick);
            // 
            // gvRetailer
            // 
            this.gvRetailer.BackgroundColor = System.Drawing.Color.OliveDrab;
            this.gvRetailer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvRetailer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvRetailer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRetailer.EnableHeadersVisualStyles = false;
            this.gvRetailer.Location = new System.Drawing.Point(541, 165);
            this.gvRetailer.Margin = new System.Windows.Forms.Padding(2);
            this.gvRetailer.MultiSelect = false;
            this.gvRetailer.Name = "gvRetailer";
            this.gvRetailer.ReadOnly = true;
            this.gvRetailer.RowHeadersVisible = false;
            this.gvRetailer.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gvRetailer.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvRetailer.RowTemplate.Height = 28;
            this.gvRetailer.Size = new System.Drawing.Size(178, 146);
            this.gvRetailer.TabIndex = 162;
            this.gvRetailer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRetailer_CellClick);
            // 
            // txtRetailer
            // 
            this.txtRetailer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRetailer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetailer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRetailer.Location = new System.Drawing.Point(385, 165);
            this.txtRetailer.Margin = new System.Windows.Forms.Padding(2);
            this.txtRetailer.Name = "txtRetailer";
            this.txtRetailer.Size = new System.Drawing.Size(150, 23);
            this.txtRetailer.TabIndex = 161;
            this.txtRetailer.TextChanged += new System.EventHandler(this.txtRetailer_TextChanged);
            this.txtRetailer.Enter += new System.EventHandler(this.txtRetailer_Enter);
            this.txtRetailer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRetailer_KeyDown);
            this.txtRetailer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetailer_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(443, 344);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 37);
            this.btnRefresh.TabIndex = 160;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(324, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 158;
            this.label8.Text = "Product :";
            // 
            // txtProduct
            // 
            this.txtProduct.BackColor = System.Drawing.Color.GhostWhite;
            this.txtProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProduct.Location = new System.Drawing.Point(385, 193);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(2);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(150, 23);
            this.txtProduct.TabIndex = 157;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            this.txtProduct.Enter += new System.EventHandler(this.txtProduct_Enter);
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduct_KeyDown);
            this.txtProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(324, 171);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 156;
            this.label9.Text = "Retailer :";
            // 
            // cmbReport
            // 
            this.cmbReport.BackColor = System.Drawing.Color.LightPink;
            this.cmbReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(126, 34);
            this.cmbReport.Margin = new System.Windows.Forms.Padding(2);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(255, 23);
            this.cmbReport.TabIndex = 155;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(68, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 154;
            this.label7.Text = "Report :";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "All",
            "Chattogram",
            "Dhaka"});
            this.cmbZone.Location = new System.Drawing.Point(126, 195);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(125, 23);
            this.cmbZone.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(81, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 152;
            this.label6.Text = "Zone :";
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(126, 168);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 139;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(84, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 151;
            this.label5.Text = "Unit :";
            // 
            // dtGvRepresentative
            // 
            this.dtGvRepresentative.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtGvRepresentative.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvRepresentative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvRepresentative.EnableHeadersVisualStyles = false;
            this.dtGvRepresentative.Location = new System.Drawing.Point(541, 140);
            this.dtGvRepresentative.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvRepresentative.MultiSelect = false;
            this.dtGvRepresentative.Name = "dtGvRepresentative";
            this.dtGvRepresentative.ReadOnly = true;
            this.dtGvRepresentative.RowHeadersVisible = false;
            this.dtGvRepresentative.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvRepresentative.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGvRepresentative.RowTemplate.Height = 28;
            this.dtGvRepresentative.Size = new System.Drawing.Size(178, 146);
            this.dtGvRepresentative.TabIndex = 150;
            this.dtGvRepresentative.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvRepresentative_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(312, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 149;
            this.label3.Text = "Sales Rep. :";
            // 
            // txtRep
            // 
            this.txtRep.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRep.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRep.Location = new System.Drawing.Point(385, 139);
            this.txtRep.Margin = new System.Windows.Forms.Padding(2);
            this.txtRep.Name = "txtRep";
            this.txtRep.Size = new System.Drawing.Size(150, 23);
            this.txtRep.TabIndex = 148;
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
            this.dtToDate.Location = new System.Drawing.Point(126, 140);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 147;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(66, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 146;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(126, 113);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 145;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(50, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 144;
            this.label2.Text = "From Date :";
            // 
            // dtGvCustomer
            // 
            this.dtGvCustomer.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dtGvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvCustomer.EnableHeadersVisualStyles = false;
            this.dtGvCustomer.Location = new System.Drawing.Point(541, 112);
            this.dtGvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvCustomer.MultiSelect = false;
            this.dtGvCustomer.Name = "dtGvCustomer";
            this.dtGvCustomer.ReadOnly = true;
            this.dtGvCustomer.RowHeadersVisible = false;
            this.dtGvCustomer.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGvCustomer.RowTemplate.Height = 28;
            this.dtGvCustomer.Size = new System.Drawing.Size(178, 146);
            this.dtGvCustomer.TabIndex = 143;
            this.dtGvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvCustomer_CellClick);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(327, 345);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(96, 36);
            this.btnPreview.TabIndex = 142;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(314, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 141;
            this.label4.Text = "Customer :";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCustomer.Location = new System.Drawing.Point(385, 112);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(150, 23);
            this.txtCustomer.TabIndex = 140;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDeliveryDate.Location = new System.Drawing.Point(519, 37);
            this.dtDeliveryDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.Size = new System.Drawing.Size(125, 23);
            this.dtDeliveryDate.TabIndex = 164;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(421, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 163;
            this.label10.Text = "Delivery As On :";
            // 
            // gridJob
            // 
            this.gridJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJob.EnableHeadersVisualStyles = false;
            this.gridJob.Location = new System.Drawing.Point(128, 247);
            this.gridJob.Margin = new System.Windows.Forms.Padding(2);
            this.gridJob.MultiSelect = false;
            this.gridJob.Name = "gridJob";
            this.gridJob.ReadOnly = true;
            this.gridJob.RowHeadersVisible = false;
            this.gridJob.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gridJob.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridJob.RowTemplate.Height = 28;
            this.gridJob.Size = new System.Drawing.Size(123, 134);
            this.gridJob.TabIndex = 170;
            this.gridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridJob_CellClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(64, 224);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 15);
            this.label11.TabIndex = 169;
            this.label11.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(126, 222);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(125, 23);
            this.txtJob.TabIndex = 168;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // frmRpt_Backlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(743, 452);
            this.Controls.Add(this.gridJob);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.gvProduct);
            this.Controls.Add(this.gvRetailer);
            this.Controls.Add(this.dtGvRepresentative);
            this.Controls.Add(this.txtRetailer);
            this.Controls.Add(this.dtDeliveryDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRep);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.dtGvCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRpt_Backlog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backlog Report";
            this.Load += new System.EventHandler(this.frmRpt_Backlog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRetailer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvProduct;
        private System.Windows.Forms.DataGridView gvRetailer;
        private System.Windows.Forms.TextBox txtRetailer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbReport;
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
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView gridJob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtJob;
    }
}