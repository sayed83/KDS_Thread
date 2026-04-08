namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_ExcessProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ExcessProduction));
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.gridShade = new System.Windows.Forms.DataGridView();
            this.dtgvCount = new System.Windows.Forms.DataGridView();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(131, 80);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 132;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(89, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 137;
            this.label5.Text = "Unit :";
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(131, 53);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 136;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(71, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 135;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(131, 26);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 134;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(55, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 133;
            this.label2.Text = "From Date :";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(259, 193);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(97, 32);
            this.btnPreview.TabIndex = 138;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // gridShade
            // 
            this.gridShade.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridShade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShade.EnableHeadersVisualStyles = false;
            this.gridShade.Location = new System.Drawing.Point(412, 53);
            this.gridShade.Margin = new System.Windows.Forms.Padding(2);
            this.gridShade.MultiSelect = false;
            this.gridShade.Name = "gridShade";
            this.gridShade.ReadOnly = true;
            this.gridShade.RowHeadersVisible = false;
            this.gridShade.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gridShade.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridShade.RowTemplate.Height = 28;
            this.gridShade.Size = new System.Drawing.Size(126, 121);
            this.gridShade.TabIndex = 142;
            this.gridShade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShade_CellClick);
            // 
            // dtgvCount
            // 
            this.dtgvCount.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCount.EnableHeadersVisualStyles = false;
            this.dtgvCount.Location = new System.Drawing.Point(391, 80);
            this.dtgvCount.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvCount.MultiSelect = false;
            this.dtgvCount.Name = "dtgvCount";
            this.dtgvCount.ReadOnly = true;
            this.dtgvCount.RowHeadersVisible = false;
            this.dtgvCount.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvCount.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvCount.RowTemplate.Height = 28;
            this.dtgvCount.Size = new System.Drawing.Size(178, 128);
            this.dtgvCount.TabIndex = 144;
            this.dtgvCount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCount_CellClick);
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.GhostWhite;
            this.txtCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCount.Location = new System.Drawing.Point(360, 53);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(126, 23);
            this.txtCount.TabIndex = 143;
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
            this.label8.Location = new System.Drawing.Point(309, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 141;
            this.label8.Text = "Shade :";
            // 
            // txtShade
            // 
            this.txtShade.BackColor = System.Drawing.Color.GhostWhite;
            this.txtShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShade.Location = new System.Drawing.Point(360, 26);
            this.txtShade.Margin = new System.Windows.Forms.Padding(2);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(126, 23);
            this.txtShade.TabIndex = 140;
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
            this.label9.Location = new System.Drawing.Point(309, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 139;
            this.label9.Text = "Count :";
            // 
            // frmRpt_ExcessProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(580, 266);
            this.Controls.Add(this.gridShade);
            this.Controls.Add(this.dtgvCount);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtShade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRpt_ExcessProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excess Production Report";
            this.Load += new System.EventHandler(this.frmRpt_ExcessProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridShade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCount)).EndInit();
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
        private System.Windows.Forms.DataGridView gridShade;
        private System.Windows.Forms.DataGridView dtgvCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Label label9;
    }
}