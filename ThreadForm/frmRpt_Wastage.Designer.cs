namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_Wastage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_Wastage));
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(214, 164);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(97, 32);
            this.btnPreview.TabIndex = 212;
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
            this.cmbUnit.Location = new System.Drawing.Point(186, 43);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(125, 23);
            this.cmbUnit.TabIndex = 210;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(144, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 211;
            this.label5.Text = "Unit :";
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(186, 98);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 23);
            this.dtToDate.TabIndex = 216;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(126, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 215;
            this.label1.Text = "To Date :";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(186, 71);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtFromDate.TabIndex = 214;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(110, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 213;
            this.label2.Text = "From Date :";
            // 
            // frmRpt_Wastage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(450, 237);
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
            this.MinimizeBox = false;
            this.Name = "frmRpt_Wastage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wastage Report";
            this.Load += new System.EventHandler(this.frmRpt_Wastage_Load);
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
    }
}