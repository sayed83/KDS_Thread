namespace KDS_Thread.ThreadForm
{
    partial class frmBookingCSView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookingCSView));
            this.dtgvJob = new System.Windows.Forms.DataGridView();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgvShade = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.dtgvColor = new System.Windows.Forms.DataGridView();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRepres = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtGvRepres = new System.Windows.Forms.DataGridView();
            this.lblTotalPack = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGvCustomer = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbFamily = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblShade_Transfer = new System.Windows.Forms.Label();
            this.lblJob_Transfer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvJob
            // 
            this.dtgvJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvJob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvJob.EnableHeadersVisualStyles = false;
            this.dtgvJob.Location = new System.Drawing.Point(101, 44);
            this.dtgvJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvJob.MultiSelect = false;
            this.dtgvJob.Name = "dtgvJob";
            this.dtgvJob.ReadOnly = true;
            this.dtgvJob.RowHeadersVisible = false;
            this.dtgvJob.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvJob.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvJob.RowTemplate.Height = 28;
            this.dtgvJob.Size = new System.Drawing.Size(123, 140);
            this.dtgvJob.TabIndex = 174;
            this.dtgvJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvJob_CellClick);
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(98, 17);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(126, 23);
            this.txtJob.TabIndex = 169;
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
            this.label10.Location = new System.Drawing.Point(40, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 15);
            this.label10.TabIndex = 172;
            this.label10.Text = "Job No. :";
            // 
            // dtgvShade
            // 
            this.dtgvShade.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtgvShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvShade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvShade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvShade.EnableHeadersVisualStyles = false;
            this.dtgvShade.Location = new System.Drawing.Point(101, 71);
            this.dtgvShade.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvShade.MultiSelect = false;
            this.dtgvShade.Name = "dtgvShade";
            this.dtgvShade.ReadOnly = true;
            this.dtgvShade.RowHeadersVisible = false;
            this.dtgvShade.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvShade.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvShade.RowTemplate.Height = 28;
            this.dtgvShade.Size = new System.Drawing.Size(119, 135);
            this.dtgvShade.TabIndex = 171;
            this.dtgvShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvShade_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(47, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 170;
            this.label8.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(98, 44);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(126, 23);
            this.txtShade.TabIndex = 173;
            this.txtShade.TextChanged += new System.EventHandler(this.txtShade_TextChanged);
            this.txtShade.Enter += new System.EventHandler(this.txtShade_Enter);
            this.txtShade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShade_KeyDown);
            this.txtShade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShade_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MintCream;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KDS_Thread.Properties.Resources.search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(857, 75);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 33);
            this.btnSearch.TabIndex = 177;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(588, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 178;
            this.label5.Text = "Color :";
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.Color.GhostWhite;
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtColor.Location = new System.Drawing.Point(634, 14);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(151, 23);
            this.txtColor.TabIndex = 179;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            this.txtColor.Enter += new System.EventHandler(this.txtColor_Enter);
            this.txtColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColor_KeyDown);
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColor_KeyPress);
            // 
            // dtgvColor
            // 
            this.dtgvColor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvColor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvColor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvColor.EnableHeadersVisualStyles = false;
            this.dtgvColor.Location = new System.Drawing.Point(651, 41);
            this.dtgvColor.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvColor.MultiSelect = false;
            this.dtgvColor.Name = "dtgvColor";
            this.dtgvColor.ReadOnly = true;
            this.dtgvColor.RowHeadersVisible = false;
            this.dtgvColor.RowHeadersWidth = 62;
            this.dtgvColor.RowTemplate.Height = 28;
            this.dtgvColor.Size = new System.Drawing.Size(142, 123);
            this.dtgvColor.TabIndex = 180;
            this.dtgvColor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvColor_CellClick);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvListData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.GridColor = System.Drawing.Color.AliceBlue;
            this.gvListData.Location = new System.Drawing.Point(16, 123);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.Name = "gvListData";
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvListData.Size = new System.Drawing.Size(1058, 281);
            this.gvListData.TabIndex = 181;
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
            this.btnClose.Location = new System.Drawing.Point(975, 418);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 182;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRepres
            // 
            this.txtRepres.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRepres.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepres.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRepres.Location = new System.Drawing.Point(348, 18);
            this.txtRepres.Margin = new System.Windows.Forms.Padding(2);
            this.txtRepres.Name = "txtRepres";
            this.txtRepres.Size = new System.Drawing.Size(151, 23);
            this.txtRepres.TabIndex = 186;
            this.txtRepres.TextChanged += new System.EventHandler(this.txtRepres_TextChanged);
            this.txtRepres.Enter += new System.EventHandler(this.txtRepres_Enter);
            this.txtRepres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepres_KeyDown);
            this.txtRepres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepres_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(584, 47);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 15);
            this.label16.TabIndex = 185;
            this.label16.Text = "Count :";
            // 
            // cmbCount
            // 
            this.cmbCount.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(634, 44);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(79, 23);
            this.cmbCount.TabIndex = 184;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(275, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 183;
            this.label4.Text = "Sales Rep. :";
            // 
            // dtGvRepres
            // 
            this.dtGvRepres.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGvRepres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvRepres.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGvRepres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtGvRepres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvRepres.EnableHeadersVisualStyles = false;
            this.dtGvRepres.Location = new System.Drawing.Point(357, 42);
            this.dtGvRepres.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvRepres.MultiSelect = false;
            this.dtGvRepres.Name = "dtGvRepres";
            this.dtGvRepres.ReadOnly = true;
            this.dtGvRepres.RowHeadersVisible = false;
            this.dtGvRepres.RowHeadersWidth = 62;
            this.dtGvRepres.RowTemplate.Height = 28;
            this.dtGvRepres.Size = new System.Drawing.Size(183, 134);
            this.dtGvRepres.TabIndex = 187;
            this.dtGvRepres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvRepres_CellClick);
            // 
            // lblTotalPack
            // 
            this.lblTotalPack.AutoSize = true;
            this.lblTotalPack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPack.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalPack.Location = new System.Drawing.Point(857, 417);
            this.lblTotalPack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPack.Name = "lblTotalPack";
            this.lblTotalPack.Size = new System.Drawing.Size(17, 19);
            this.lblTotalPack.TabIndex = 191;
            this.lblTotalPack.Text = "0";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalQty.Location = new System.Drawing.Point(685, 417);
            this.lblTotalQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(17, 19);
            this.lblTotalQty.TabIndex = 190;
            this.lblTotalQty.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(763, 417);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 19);
            this.label11.TabIndex = 189;
            this.label11.Text = "Total PKG :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(594, 417);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 188;
            this.label1.Text = "Total QTY  :";
            // 
            // dtGvCustomer
            // 
            this.dtGvCustomer.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtGvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvCustomer.EnableHeadersVisualStyles = false;
            this.dtGvCustomer.Location = new System.Drawing.Point(348, 75);
            this.dtGvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvCustomer.MultiSelect = false;
            this.dtGvCustomer.Name = "dtGvCustomer";
            this.dtGvCustomer.ReadOnly = true;
            this.dtGvCustomer.RowHeadersVisible = false;
            this.dtGvCustomer.RowHeadersWidth = 62;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtGvCustomer.RowTemplate.Height = 28;
            this.dtGvCustomer.Size = new System.Drawing.Size(201, 146);
            this.dtGvCustomer.TabIndex = 194;
            this.dtGvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvCustomer_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(277, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 193;
            this.label2.Text = "Customer :";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCustomer.Location = new System.Drawing.Point(348, 48);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(151, 23);
            this.txtCustomer.TabIndex = 192;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(544, 74);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 15);
            this.label17.TabIndex = 197;
            this.label17.Text = "Family Group :";
            // 
            // cmbFamily
            // 
            this.cmbFamily.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbFamily.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFamily.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFamily.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFamily.FormattingEnabled = true;
            this.cmbFamily.Items.AddRange(new object[] {
            "N/A"});
            this.cmbFamily.Location = new System.Drawing.Point(634, 71);
            this.cmbFamily.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFamily.Name = "cmbFamily";
            this.cmbFamily.Size = new System.Drawing.Size(79, 23);
            this.cmbFamily.TabIndex = 196;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(971, 75);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 33);
            this.btnRefresh.TabIndex = 198;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblShade_Transfer
            // 
            this.lblShade_Transfer.AutoSize = true;
            this.lblShade_Transfer.Location = new System.Drawing.Point(58, 422);
            this.lblShade_Transfer.Name = "lblShade_Transfer";
            this.lblShade_Transfer.Size = new System.Drawing.Size(35, 13);
            this.lblShade_Transfer.TabIndex = 199;
            this.lblShade_Transfer.Text = "label3";
            this.lblShade_Transfer.Visible = false;
            // 
            // lblJob_Transfer
            // 
            this.lblJob_Transfer.AutoSize = true;
            this.lblJob_Transfer.Location = new System.Drawing.Point(113, 423);
            this.lblJob_Transfer.Name = "lblJob_Transfer";
            this.lblJob_Transfer.Size = new System.Drawing.Size(35, 13);
            this.lblJob_Transfer.TabIndex = 200;
            this.lblJob_Transfer.Text = "label3";
            this.lblJob_Transfer.Visible = false;
            // 
            // frmBookingCSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1085, 464);
            this.Controls.Add(this.lblJob_Transfer);
            this.Controls.Add(this.lblShade_Transfer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtgvColor);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbFamily);
            this.Controls.Add(this.dtGvRepres);
            this.Controls.Add(this.dtGvCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblTotalPack);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRepres);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtgvJob);
            this.Controls.Add(this.dtgvShade);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtShade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBookingCSView";
            this.Text = "Schedule Balance View";
            this.Load += new System.EventHandler(this.frmBookingCSView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvJob;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgvShade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.DataGridView dtgvColor;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRepres;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtGvRepres;
        private System.Windows.Forms.Label lblTotalPack;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGvCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbFamily;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblShade_Transfer;
        private System.Windows.Forms.Label lblJob_Transfer;
    }
}