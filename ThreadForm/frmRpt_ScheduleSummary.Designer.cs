namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_ScheduleSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ScheduleSummary));
            this.dtGvCustomer = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRep = new System.Windows.Forms.TextBox();
            this.dtGvRepresentative = new System.Windows.Forms.DataGridView();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gridShade = new System.Windows.Forms.DataGridView();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.dtgvCount = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGvCustomer
            // 
            this.dtGvCustomer.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtGvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvCustomer.EnableHeadersVisualStyles = false;
            this.dtGvCustomer.Location = new System.Drawing.Point(576, 102);
            this.dtGvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvCustomer.MultiSelect = false;
            this.dtGvCustomer.Name = "dtGvCustomer";
            this.dtGvCustomer.ReadOnly = true;
            this.dtGvCustomer.RowHeadersVisible = false;
            this.dtGvCustomer.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGvCustomer.RowTemplate.Height = 28;
            this.dtGvCustomer.Size = new System.Drawing.Size(178, 146);
            this.dtGvCustomer.TabIndex = 116;
            this.dtGvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvCustomer_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(351, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 114;
            this.label4.Text = "Customer :";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCustomer.Location = new System.Drawing.Point(422, 97);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(150, 23);
            this.txtCustomer.TabIndex = 113;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(143, 77);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 120;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(83, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 119;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(143, 50);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 118;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(67, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 117;
            this.label2.Text = "From Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(349, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 122;
            this.label3.Text = "Sales Rep. :";
            // 
            // txtRep
            // 
            this.txtRep.BackColor = System.Drawing.Color.GhostWhite;
            this.txtRep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRep.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRep.Location = new System.Drawing.Point(422, 123);
            this.txtRep.Margin = new System.Windows.Forms.Padding(2);
            this.txtRep.Name = "txtRep";
            this.txtRep.Size = new System.Drawing.Size(150, 23);
            this.txtRep.TabIndex = 121;
            this.txtRep.TextChanged += new System.EventHandler(this.txtRep_TextChanged);
            this.txtRep.Enter += new System.EventHandler(this.txtRep_Enter);
            this.txtRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRep_KeyDown);
            this.txtRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRep_KeyPress);
            // 
            // dtGvRepresentative
            // 
            this.dtGvRepresentative.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtGvRepresentative.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGvRepresentative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGvRepresentative.EnableHeadersVisualStyles = false;
            this.dtGvRepresentative.Location = new System.Drawing.Point(590, 123);
            this.dtGvRepresentative.Margin = new System.Windows.Forms.Padding(2);
            this.dtGvRepresentative.MultiSelect = false;
            this.dtGvRepresentative.Name = "dtGvRepresentative";
            this.dtGvRepresentative.ReadOnly = true;
            this.dtGvRepresentative.RowHeadersVisible = false;
            this.dtGvRepresentative.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtGvRepresentative.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGvRepresentative.RowTemplate.Height = 28;
            this.dtGvRepresentative.Size = new System.Drawing.Size(178, 146);
            this.dtGvRepresentative.TabIndex = 123;
            this.dtGvRepresentative.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGvRepresentative_CellClick);
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(143, 104);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 113;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(101, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 124;
            this.label5.Text = "Unit :";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(143, 131);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(125, 23);
            this.cmbZone.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(98, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 126;
            this.label6.Text = "Zone :";
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
            "Shade"});
            this.cmbSortBy.Location = new System.Drawing.Point(143, 158);
            this.cmbSortBy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(125, 23);
            this.cmbSortBy.TabIndex = 129;
            this.cmbSortBy.SelectedValueChanged += new System.EventHandler(this.cmbSortBy_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(85, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 128;
            this.label7.Text = "Sort By :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(371, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 133;
            this.label8.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(422, 71);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(150, 23);
            this.txtShade.TabIndex = 132;
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
            this.label9.Location = new System.Drawing.Point(361, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 131;
            this.label9.Text = "Product :";
            // 
            // gridShade
            // 
            this.gridShade.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShade.EnableHeadersVisualStyles = false;
            this.gridShade.Location = new System.Drawing.Point(576, 77);
            this.gridShade.Margin = new System.Windows.Forms.Padding(2);
            this.gridShade.MultiSelect = false;
            this.gridShade.Name = "gridShade";
            this.gridShade.ReadOnly = true;
            this.gridShade.RowHeadersVisible = false;
            this.gridShade.RowHeadersWidth = 62;
            this.gridShade.RowTemplate.Height = 28;
            this.gridShade.Size = new System.Drawing.Size(119, 141);
            this.gridShade.TabIndex = 135;
            this.gridShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShade_CellClick);
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCount.Location = new System.Drawing.Point(422, 45);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(150, 23);
            this.txtCount.TabIndex = 137;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            this.txtCount.Enter += new System.EventHandler(this.txtCount_Enter);
            this.txtCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCount_KeyDown);
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // dtgvCount
            // 
            this.dtgvCount.BackgroundColor = System.Drawing.Color.Beige;
            this.dtgvCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCount.EnableHeadersVisualStyles = false;
            this.dtgvCount.Location = new System.Drawing.Point(576, 46);
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
            this.dtgvCount.TabIndex = 138;
            this.dtgvCount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCount_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(465, 270);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 37);
            this.btnRefresh.TabIndex = 136;
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
            this.btnPreview.Location = new System.Drawing.Point(343, 271);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(107, 36);
            this.btnPreview.TabIndex = 115;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // frmRpt_ScheduleSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(792, 352);
            this.Controls.Add(this.dtGvRepresentative);
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
            this.Name = "frmRpt_ScheduleSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Summary Report";
            this.Load += new System.EventHandler(this.frmRpt_ScheduleSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGvRepresentative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGvCustomer;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRep;
        private System.Windows.Forms.DataGridView dtGvRepresentative;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gridShade;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.DataGridView dtgvCount;
    }
}