namespace KDS_Thread.ThreadForm
{
    partial class frmPlanningSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanningSchedule));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSumStockQty = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMinKG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMchKG = new System.Windows.Forms.Label();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlanMachine = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbSchMachine = new System.Windows.Forms.ComboBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewSchBalance = new System.Windows.Forms.Button();
            this.gridShade = new System.Windows.Forms.DataGridView();
            this.gridJob = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDayTotal = new System.Windows.Forms.Label();
            this.lblDayTotalLot = new System.Windows.Forms.Label();
            this.lblTotalPack = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvUsedCapacity = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUnitDhaka = new System.Windows.Forms.CheckBox();
            this.chkUnitCTG = new System.Windows.Forms.CheckBox();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOrdLocation = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsedCapacity)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbOrdLocation);
            this.groupBox1.Controls.Add(this.cmbProduct);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSumStockQty);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtMinKG);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMchKG);
            this.groupBox1.Controls.Add(this.txtStockQty);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtJob);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtShade);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPlanMachine);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmbSchMachine);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.cmbCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(21, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(757, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(567, 49);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(172, 21);
            this.cmbProduct.TabIndex = 190;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(506, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 189;
            this.label1.Text = "Product :";
            // 
            // lblSumStockQty
            // 
            this.lblSumStockQty.AutoSize = true;
            this.lblSumStockQty.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumStockQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSumStockQty.Location = new System.Drawing.Point(670, 81);
            this.lblSumStockQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSumStockQty.Name = "lblSumStockQty";
            this.lblSumStockQty.Size = new System.Drawing.Size(13, 13);
            this.lblSumStockQty.TabIndex = 93;
            this.lblSumStockQty.Text = "0";
            this.lblSumStockQty.Visible = false;
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(93, 48);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(121, 23);
            this.dtToDate.TabIndex = 74;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(31, 53);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 73;
            this.label13.Text = "To Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(493, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 92;
            this.label3.Text = "Stock QTY :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(562, 110);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 37);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMinKG
            // 
            this.txtMinKG.AutoSize = true;
            this.txtMinKG.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinKG.ForeColor = System.Drawing.Color.Navy;
            this.txtMinKG.Location = new System.Drawing.Point(418, 109);
            this.txtMinKG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMinKG.Name = "txtMinKG";
            this.txtMinKG.Size = new System.Drawing.Size(13, 13);
            this.txtMinKG.TabIndex = 72;
            this.txtMinKG.Text = "0";
            this.txtMinKG.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(376, 106);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "(KG)";
            // 
            // txtMchKG
            // 
            this.txtMchKG.AutoSize = true;
            this.txtMchKG.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMchKG.ForeColor = System.Drawing.Color.Navy;
            this.txtMchKG.Location = new System.Drawing.Point(342, 106);
            this.txtMchKG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtMchKG.Name = "txtMchKG";
            this.txtMchKG.Size = new System.Drawing.Size(13, 13);
            this.txtMchKG.TabIndex = 68;
            this.txtMchKG.Text = "0";
            // 
            // txtStockQty
            // 
            this.txtStockQty.BackColor = System.Drawing.Color.GhostWhite;
            this.txtStockQty.Enabled = false;
            this.txtStockQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQty.ForeColor = System.Drawing.Color.Navy;
            this.txtStockQty.Location = new System.Drawing.Point(567, 76);
            this.txtStockQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(94, 23);
            this.txtStockQty.TabIndex = 91;
            this.txtStockQty.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(32, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 67;
            this.label7.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(94, 101);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(120, 23);
            this.txtJob.TabIndex = 66;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(39, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 65;
            this.label6.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(93, 75);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(121, 23);
            this.txtShade.TabIndex = 57;
            this.txtShade.TextChanged += new System.EventHandler(this.txtShade_TextChanged);
            this.txtShade.Enter += new System.EventHandler(this.txtShade_Enter);
            this.txtShade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShade_KeyDown);
            this.txtShade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShade_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(264, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 61;
            this.label4.Text = "Plan Mch. :";
            // 
            // cmbPlanMachine
            // 
            this.cmbPlanMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbPlanMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPlanMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPlanMachine.FormattingEnabled = true;
            this.cmbPlanMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbPlanMachine.Location = new System.Drawing.Point(338, 80);
            this.cmbPlanMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlanMachine.Name = "cmbPlanMachine";
            this.cmbPlanMachine.Size = new System.Drawing.Size(94, 23);
            this.cmbPlanMachine.TabIndex = 60;
            this.cmbPlanMachine.SelectedIndexChanged += new System.EventHandler(this.cmbPlanMachine_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(267, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 63;
            this.label5.Text = "Sch. Mch :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(514, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 15);
            this.label16.TabIndex = 90;
            this.label16.Text = "Count :";
            // 
            // cmbSchMachine
            // 
            this.cmbSchMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbSchMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSchMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSchMachine.FormattingEnabled = true;
            this.cmbSchMachine.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbSchMachine.Location = new System.Drawing.Point(338, 51);
            this.cmbSchMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSchMachine.Name = "cmbSchMachine";
            this.cmbSchMachine.Size = new System.Drawing.Size(94, 23);
            this.cmbSchMachine.TabIndex = 62;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(93, 23);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(121, 23);
            this.dtFromDate.TabIndex = 64;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // cmbCount
            // 
            this.cmbCount.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(567, 21);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(93, 23);
            this.cmbCount.TabIndex = 89;
            this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.cmbCount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 56;
            this.label2.Text = "From Date :";
            // 
            // btnViewSchBalance
            // 
            this.btnViewSchBalance.BackColor = System.Drawing.Color.Snow;
            this.btnViewSchBalance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewSchBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSchBalance.Image = global::KDS_Thread.Properties.Resources.document_yellow_icon;
            this.btnViewSchBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewSchBalance.Location = new System.Drawing.Point(893, 163);
            this.btnViewSchBalance.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewSchBalance.Name = "btnViewSchBalance";
            this.btnViewSchBalance.Size = new System.Drawing.Size(127, 37);
            this.btnViewSchBalance.TabIndex = 94;
            this.btnViewSchBalance.Text = "  View Scheduled";
            this.btnViewSchBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewSchBalance.UseVisualStyleBackColor = false;
            this.btnViewSchBalance.Click += new System.EventHandler(this.btnViewSchBalance_Click);
            // 
            // gridShade
            // 
            this.gridShade.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShade.EnableHeadersVisualStyles = false;
            this.gridShade.Location = new System.Drawing.Point(124, 149);
            this.gridShade.Margin = new System.Windows.Forms.Padding(2);
            this.gridShade.MultiSelect = false;
            this.gridShade.Name = "gridShade";
            this.gridShade.ReadOnly = true;
            this.gridShade.RowHeadersVisible = false;
            this.gridShade.RowHeadersWidth = 62;
            this.gridShade.RowTemplate.Height = 28;
            this.gridShade.Size = new System.Drawing.Size(111, 124);
            this.gridShade.TabIndex = 68;
            this.gridShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShade_CellClick);
            // 
            // gridJob
            // 
            this.gridJob.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJob.EnableHeadersVisualStyles = false;
            this.gridJob.Location = new System.Drawing.Point(115, 176);
            this.gridJob.Margin = new System.Windows.Forms.Padding(2);
            this.gridJob.MultiSelect = false;
            this.gridJob.Name = "gridJob";
            this.gridJob.ReadOnly = true;
            this.gridJob.RowHeadersVisible = false;
            this.gridJob.RowHeadersWidth = 62;
            this.gridJob.RowTemplate.Height = 28;
            this.gridJob.Size = new System.Drawing.Size(130, 140);
            this.gridJob.TabIndex = 69;
            this.gridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridJob_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(21, 215);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(1132, 267);
            this.gvListData.TabIndex = 70;
            this.gvListData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentClick);
            this.gvListData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(701, 485);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 73;
            this.label8.Text = "Total Qty :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(701, 504);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 19);
            this.label10.TabIndex = 74;
            this.label10.Text = "Total Lot  :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(707, 522);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 19);
            this.label11.TabIndex = 75;
            this.label11.Text = "Total KG :";
            // 
            // lblDayTotal
            // 
            this.lblDayTotal.AutoSize = true;
            this.lblDayTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblDayTotal.Location = new System.Drawing.Point(788, 486);
            this.lblDayTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDayTotal.Name = "lblDayTotal";
            this.lblDayTotal.Size = new System.Drawing.Size(17, 19);
            this.lblDayTotal.TabIndex = 76;
            this.lblDayTotal.Text = "0";
            // 
            // lblDayTotalLot
            // 
            this.lblDayTotalLot.AutoSize = true;
            this.lblDayTotalLot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayTotalLot.ForeColor = System.Drawing.Color.Navy;
            this.lblDayTotalLot.Location = new System.Drawing.Point(788, 504);
            this.lblDayTotalLot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDayTotalLot.Name = "lblDayTotalLot";
            this.lblDayTotalLot.Size = new System.Drawing.Size(17, 19);
            this.lblDayTotalLot.TabIndex = 77;
            this.lblDayTotalLot.Text = "0";
            // 
            // lblTotalPack
            // 
            this.lblTotalPack.AutoSize = true;
            this.lblTotalPack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPack.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalPack.Location = new System.Drawing.Point(788, 523);
            this.lblTotalPack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPack.Name = "lblTotalPack";
            this.lblTotalPack.Size = new System.Drawing.Size(17, 19);
            this.lblTotalPack.TabIndex = 78;
            this.lblTotalPack.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvUsedCapacity);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(856, 53);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(297, 89);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Used Capacity";
            // 
            // gvUsedCapacity
            // 
            this.gvUsedCapacity.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvUsedCapacity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvUsedCapacity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsedCapacity.Location = new System.Drawing.Point(4, 20);
            this.gvUsedCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.gvUsedCapacity.MultiSelect = false;
            this.gvUsedCapacity.Name = "gvUsedCapacity";
            this.gvUsedCapacity.ReadOnly = true;
            this.gvUsedCapacity.RowHeadersVisible = false;
            this.gvUsedCapacity.RowHeadersWidth = 62;
            this.gvUsedCapacity.RowTemplate.Height = 28;
            this.gvUsedCapacity.Size = new System.Drawing.Size(289, 64);
            this.gvUsedCapacity.TabIndex = 70;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1042, 163);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 37);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1048, 501);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 34);
            this.btnClose.TabIndex = 72;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.MintCream;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::KDS_Thread.Properties.Resources.check_16;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(917, 500);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 35);
            this.btnConfirm.TabIndex = 71;
            this.btnConfirm.Text = "  Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Controls.Add(this.chkUnitDhaka);
            this.groupBox3.Controls.Add(this.chkUnitCTG);
            this.groupBox3.Controls.Add(this.dtPlanDate);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(21, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(759, 43);
            this.groupBox3.TabIndex = 93;
            this.groupBox3.TabStop = false;
            // 
            // chkUnitDhaka
            // 
            this.chkUnitDhaka.AutoSize = true;
            this.chkUnitDhaka.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnitDhaka.ForeColor = System.Drawing.Color.SeaShell;
            this.chkUnitDhaka.Location = new System.Drawing.Point(489, 12);
            this.chkUnitDhaka.Margin = new System.Windows.Forms.Padding(2);
            this.chkUnitDhaka.Name = "chkUnitDhaka";
            this.chkUnitDhaka.Size = new System.Drawing.Size(78, 25);
            this.chkUnitDhaka.TabIndex = 59;
            this.chkUnitDhaka.Text = "Dhaka";
            this.chkUnitDhaka.UseVisualStyleBackColor = true;
            this.chkUnitDhaka.CheckedChanged += new System.EventHandler(this.chkUnitDhaka_CheckedChanged);
            // 
            // chkUnitCTG
            // 
            this.chkUnitCTG.AutoSize = true;
            this.chkUnitCTG.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnitCTG.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.chkUnitCTG.Location = new System.Drawing.Point(349, 12);
            this.chkUnitCTG.Margin = new System.Windows.Forms.Padding(2);
            this.chkUnitCTG.Name = "chkUnitCTG";
            this.chkUnitCTG.Size = new System.Drawing.Size(120, 25);
            this.chkUnitCTG.TabIndex = 58;
            this.chkUnitCTG.Text = "Chattogram";
            this.chkUnitCTG.UseVisualStyleBackColor = true;
            this.chkUnitCTG.CheckedChanged += new System.EventHandler(this.chkUnitCTG_CheckedChanged);
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPlanDate.Location = new System.Drawing.Point(162, 13);
            this.dtPlanDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(125, 23);
            this.dtPlanDate.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.SeaShell;
            this.label14.Location = new System.Drawing.Point(23, 13);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 21);
            this.label14.TabIndex = 56;
            this.label14.Text = "Planning Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(268, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 15);
            this.label12.TabIndex = 192;
            this.label12.Text = "Ord. Loc. :";
            // 
            // cmbOrdLocation
            // 
            this.cmbOrdLocation.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbOrdLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOrdLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrdLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbOrdLocation.FormattingEnabled = true;
            this.cmbOrdLocation.Location = new System.Drawing.Point(338, 23);
            this.cmbOrdLocation.Margin = new System.Windows.Forms.Padding(2);
            this.cmbOrdLocation.Name = "cmbOrdLocation";
            this.cmbOrdLocation.Size = new System.Drawing.Size(94, 23);
            this.cmbOrdLocation.TabIndex = 191;
            // 
            // frmPlanningSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1179, 550);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnViewSchBalance);
            this.Controls.Add(this.gridShade);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotalPack);
            this.Controls.Add(this.lblDayTotalLot);
            this.Controls.Add(this.lblDayTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gridJob);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmPlanningSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planning Schedule";
            this.Load += new System.EventHandler(this.frmPlanningSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsedCapacity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlanMachine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.DataGridView gridShade;
        private System.Windows.Forms.DataGridView gridJob;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtMchKG;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDayTotal;
        private System.Windows.Forms.Label lblDayTotalLot;
        private System.Windows.Forms.Label lblTotalPack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvUsedCapacity;
        private System.Windows.Forms.Label txtMinKG;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.Label lblSumStockQty;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkUnitDhaka;
        private System.Windows.Forms.CheckBox chkUnitCTG;
        private System.Windows.Forms.DateTimePicker dtPlanDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnViewSchBalance;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSchMachine;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbOrdLocation;
    }
}