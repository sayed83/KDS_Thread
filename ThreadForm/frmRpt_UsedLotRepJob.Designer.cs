namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_UsedLotRepJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_UsedLotRepJob));
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gridRep = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRep = new System.Windows.Forms.TextBox();
            this.gridJob = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(408, 184);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(97, 32);
            this.btnPreview.TabIndex = 138;
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
            this.cmbUnit.Location = new System.Drawing.Point(113, 104);
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
            this.label5.Location = new System.Drawing.Point(71, 106);
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
            this.dtToDate.Location = new System.Drawing.Point(113, 77);
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
            this.label1.Location = new System.Drawing.Point(53, 77);
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
            this.dtFromDate.Location = new System.Drawing.Point(113, 50);
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
            this.label2.Location = new System.Drawing.Point(37, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 133;
            this.label2.Text = "From Date :";
            // 
            // gridRep
            // 
            this.gridRep.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.gridRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridRep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRep.EnableHeadersVisualStyles = false;
            this.gridRep.Location = new System.Drawing.Point(451, 80);
            this.gridRep.Margin = new System.Windows.Forms.Padding(2);
            this.gridRep.MultiSelect = false;
            this.gridRep.Name = "gridRep";
            this.gridRep.ReadOnly = true;
            this.gridRep.RowHeadersVisible = false;
            this.gridRep.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gridRep.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRep.RowTemplate.Height = 28;
            this.gridRep.Size = new System.Drawing.Size(198, 157);
            this.gridRep.TabIndex = 153;
            this.gridRep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRep_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(280, 56);
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
            this.txtRep.Location = new System.Drawing.Point(353, 53);
            this.txtRep.Margin = new System.Windows.Forms.Padding(2);
            this.txtRep.Name = "txtRep";
            this.txtRep.Size = new System.Drawing.Size(152, 23);
            this.txtRep.TabIndex = 151;
            this.txtRep.TextChanged += new System.EventHandler(this.txtRep_TextChanged);
            this.txtRep.Enter += new System.EventHandler(this.txtRep_Enter);
            this.txtRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRep_KeyDown);
            this.txtRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRep_KeyPress);
            // 
            // gridJob
            // 
            this.gridJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridJob.EnableHeadersVisualStyles = false;
            this.gridJob.Location = new System.Drawing.Point(451, 107);
            this.gridJob.Margin = new System.Windows.Forms.Padding(2);
            this.gridJob.MultiSelect = false;
            this.gridJob.Name = "gridJob";
            this.gridJob.ReadOnly = true;
            this.gridJob.RowHeadersVisible = false;
            this.gridJob.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.gridJob.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridJob.RowTemplate.Height = 28;
            this.gridJob.Size = new System.Drawing.Size(138, 146);
            this.gridJob.TabIndex = 156;
            this.gridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridJob_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(295, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 155;
            this.label4.Text = "Job No. :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.GhostWhite;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(353, 80);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(126, 23);
            this.txtJob.TabIndex = 154;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // frmRpt_UsedLotRepJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(660, 276);
            this.Controls.Add(this.gridRep);
            this.Controls.Add(this.gridJob);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRep);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_UsedLotRepJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Used Lot Status Report";
            this.Load += new System.EventHandler(this.frmRpt_UsedLotRepJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridJob)).EndInit();
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
        private System.Windows.Forms.DataGridView gridRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRep;
        private System.Windows.Forms.DataGridView gridJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJob;
    }
}