namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_PrintDyelotCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_PrintDyelotCard));
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDyeMachine = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(243, 71);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(118, 23);
            this.dtDate.TabIndex = 140;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(135, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 139;
            this.label2.Text = "Production Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(154, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 157;
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
            this.cmbDyeMachine.Location = new System.Drawing.Point(243, 98);
            this.cmbDyeMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDyeMachine.Name = "cmbDyeMachine";
            this.cmbDyeMachine.Size = new System.Drawing.Size(118, 23);
            this.cmbDyeMachine.TabIndex = 156;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(268, 171);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 32);
            this.btnPreview.TabIndex = 144;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(201, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 143;
            this.label5.Text = "Unit :";
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(243, 44);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(118, 23);
            this.cmbUnit.TabIndex = 138;
            // 
            // frmRpt_PrintDyelotCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(512, 260);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDyeMachine);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_PrintDyelotCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Dyelot Tag Report";
            this.Load += new System.EventHandler(this.frmPrintTravelCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDyeMachine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUnit;
    }
}