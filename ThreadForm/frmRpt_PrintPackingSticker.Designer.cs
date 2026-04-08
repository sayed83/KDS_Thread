namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_PrintPackingSticker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_PrintPackingSticker));
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgridJob = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNoPrint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPKQty = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAddCarton = new System.Windows.Forms.CheckBox();
            this.txtTotalCarton = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLeftOverQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCartonPack = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDeliveryAddress = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(68, 12);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(126, 23);
            this.dtDate.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 80;
            this.label2.Text = "Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(237, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 88;
            this.label4.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(295, 15);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(138, 23);
            this.txtJob.TabIndex = 81;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtgridJob);
            this.panel1.Controls.Add(this.gvListData);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtJob);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 488);
            this.panel1.TabIndex = 90;
            // 
            // dtgridJob
            // 
            this.dtgridJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridJob.EnableHeadersVisualStyles = false;
            this.dtgridJob.Location = new System.Drawing.Point(295, 42);
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
            this.dtgridJob.Size = new System.Drawing.Size(138, 146);
            this.dtgridJob.TabIndex = 113;
            this.dtgridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridJob_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(14, 82);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gvListData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvListData.Size = new System.Drawing.Size(632, 383);
            this.gvListData.TabIndex = 114;
            this.gvListData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvListData_CellContentDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(487, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 33);
            this.btnSearch.TabIndex = 90;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Turquoise;
            this.label1.Location = new System.Drawing.Point(32, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 92;
            this.label1.Text = "Job No. :";
            // 
            // txtJobNoPrint
            // 
            this.txtJobNoPrint.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJobNoPrint.Enabled = false;
            this.txtJobNoPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNoPrint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNoPrint.Location = new System.Drawing.Point(90, 88);
            this.txtJobNoPrint.Margin = new System.Windows.Forms.Padding(2);
            this.txtJobNoPrint.Name = "txtJobNoPrint";
            this.txtJobNoPrint.Size = new System.Drawing.Size(193, 25);
            this.txtJobNoPrint.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Turquoise;
            this.label5.Location = new System.Drawing.Point(40, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 95;
            this.label5.Text = "Buyer :";
            // 
            // txtBuyer
            // 
            this.txtBuyer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtBuyer.Enabled = false;
            this.txtBuyer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuyer.Location = new System.Drawing.Point(90, 35);
            this.txtBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(193, 25);
            this.txtBuyer.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Turquoise;
            this.label6.Location = new System.Drawing.Point(19, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 97;
            this.label6.Text = "Customer :";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCustomer.Location = new System.Drawing.Point(90, 61);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(193, 25);
            this.txtCustomer.TabIndex = 96;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Turquoise;
            this.label7.Location = new System.Drawing.Point(39, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 99;
            this.label7.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Enabled = false;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(90, 169);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(111, 25);
            this.txtShade.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Turquoise;
            this.label8.Location = new System.Drawing.Point(39, 199);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 101;
            this.label8.Text = "Count :";
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCount.Enabled = false;
            this.txtCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCount.Location = new System.Drawing.Point(90, 196);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(111, 25);
            this.txtCount.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Turquoise;
            this.label9.Location = new System.Drawing.Point(45, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 103;
            this.label9.Text = "Style :";
            // 
            // txtStyle
            // 
            this.txtStyle.BackColor = System.Drawing.Color.GhostWhite;
            this.txtStyle.Enabled = false;
            this.txtStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStyle.Location = new System.Drawing.Point(90, 115);
            this.txtStyle.Margin = new System.Windows.Forms.Padding(2);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(193, 25);
            this.txtStyle.TabIndex = 102;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Turquoise;
            this.label10.Location = new System.Drawing.Point(45, 145);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 105;
            this.label10.Text = "Color :";
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.Color.GhostWhite;
            this.txtColor.Enabled = false;
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtColor.Location = new System.Drawing.Point(90, 142);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(193, 25);
            this.txtColor.TabIndex = 104;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label11.Location = new System.Drawing.Point(50, 226);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 15);
            this.label11.TabIndex = 107;
            this.label11.Text = "QTY :";
            // 
            // txtPKQty
            // 
            this.txtPKQty.BackColor = System.Drawing.Color.GhostWhite;
            this.txtPKQty.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPKQty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPKQty.Location = new System.Drawing.Point(90, 223);
            this.txtPKQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtPKQty.Name = "txtPKQty";
            this.txtPKQty.Size = new System.Drawing.Size(111, 27);
            this.txtPKQty.TabIndex = 106;
            this.txtPKQty.TextChanged += new System.EventHandler(this.txtPKQty_TextChanged);
            this.txtPKQty.Enter += new System.EventHandler(this.txtPKQty_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Navy;
            this.groupBox1.Controls.Add(this.cmbDeliveryAddress);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.txtBuyer);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtJobNoPrint);
            this.groupBox1.Controls.Add(this.txtPKQty);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtStyle);
            this.groupBox1.Controls.Add(this.txtShade);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepPink;
            this.groupBox1.Location = new System.Drawing.Point(705, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 488);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Packing Sticker";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.Green;
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(222, 430);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(129, 36);
            this.btnPreview.TabIndex = 143;
            this.btnPreview.Text = "   Preview Sticker";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkAddCarton);
            this.panel2.Controls.Add(this.txtTotalCarton);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtLeftOverQty);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtCartonPack);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(22, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 108);
            this.panel2.TabIndex = 110;
            // 
            // chkAddCarton
            // 
            this.chkAddCarton.AutoSize = true;
            this.chkAddCarton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddCarton.Location = new System.Drawing.Point(182, 40);
            this.chkAddCarton.Name = "chkAddCarton";
            this.chkAddCarton.Size = new System.Drawing.Size(94, 19);
            this.chkAddCarton.TabIndex = 114;
            this.chkAddCarton.Text = "Add 1carton";
            this.chkAddCarton.UseVisualStyleBackColor = true;
            this.chkAddCarton.CheckedChanged += new System.EventHandler(this.chkAddCarton_CheckedChanged);
            // 
            // txtTotalCarton
            // 
            this.txtTotalCarton.BackColor = System.Drawing.Color.GhostWhite;
            this.txtTotalCarton.Enabled = false;
            this.txtTotalCarton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCarton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalCarton.Location = new System.Drawing.Point(110, 63);
            this.txtTotalCarton.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalCarton.Name = "txtTotalCarton";
            this.txtTotalCarton.Size = new System.Drawing.Size(67, 27);
            this.txtTotalCarton.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label13.Location = new System.Drawing.Point(22, 69);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 113;
            this.label13.Text = "Total Carton :";
            // 
            // txtLeftOverQty
            // 
            this.txtLeftOverQty.BackColor = System.Drawing.Color.GhostWhite;
            this.txtLeftOverQty.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftOverQty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLeftOverQty.Location = new System.Drawing.Point(110, 35);
            this.txtLeftOverQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtLeftOverQty.Name = "txtLeftOverQty";
            this.txtLeftOverQty.Size = new System.Drawing.Size(67, 27);
            this.txtLeftOverQty.TabIndex = 110;
            this.txtLeftOverQty.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Turquoise;
            this.label12.Location = new System.Drawing.Point(14, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 15);
            this.label12.TabIndex = 111;
            this.label12.Text = "Leftover QTY :";
            // 
            // txtCartonPack
            // 
            this.txtCartonPack.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCartonPack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartonPack.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCartonPack.Location = new System.Drawing.Point(110, 7);
            this.txtCartonPack.Margin = new System.Windows.Forms.Padding(2);
            this.txtCartonPack.Name = "txtCartonPack";
            this.txtCartonPack.Size = new System.Drawing.Size(67, 27);
            this.txtCartonPack.TabIndex = 108;
            this.txtCartonPack.TextChanged += new System.EventHandler(this.txtCartonPack_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Turquoise;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 109;
            this.label3.Text = "Qty per carton :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(940, 528);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 183;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Turquoise;
            this.label14.Location = new System.Drawing.Point(19, 387);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 144;
            this.label14.Text = "Delivery :";
            // 
            // cmbDeliveryAddress
            // 
            this.cmbDeliveryAddress.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbDeliveryAddress.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeliveryAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDeliveryAddress.FormattingEnabled = true;
            this.cmbDeliveryAddress.Items.AddRange(new object[] {
            "Select",
            "Chattogram",
            "Dhaka"});
            this.cmbDeliveryAddress.Location = new System.Drawing.Point(80, 384);
            this.cmbDeliveryAddress.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDeliveryAddress.Name = "cmbDeliveryAddress";
            this.cmbDeliveryAddress.Size = new System.Drawing.Size(271, 24);
            this.cmbDeliveryAddress.TabIndex = 145;
            // 
            // frmRpt_PrintPackingSticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1096, 578);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_PrintPackingSticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing Sticker Report";
            this.Load += new System.EventHandler(this.frmRpt_PrintPackingSticker_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dtgridJob;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNoPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPKQty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCartonPack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalCarton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLeftOverQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAddCarton;
        private System.Windows.Forms.ComboBox cmbDeliveryAddress;
        private System.Windows.Forms.Label label14;
    }
}