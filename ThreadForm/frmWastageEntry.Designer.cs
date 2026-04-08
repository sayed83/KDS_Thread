namespace KDS_Thread.ThreadForm
{
    partial class frmWastageEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWastageEntry));
            this.label6 = new System.Windows.Forms.Label();
            this.txtYarnCons = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoftWin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDyeing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinishing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLabDyeingTest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeviation = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(95, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "Yarn Consumption :";
            // 
            // txtYarnCons
            // 
            this.txtYarnCons.BackColor = System.Drawing.Color.GhostWhite;
            this.txtYarnCons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYarnCons.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYarnCons.Location = new System.Drawing.Point(224, 91);
            this.txtYarnCons.Margin = new System.Windows.Forms.Padding(2);
            this.txtYarnCons.Name = "txtYarnCons";
            this.txtYarnCons.Size = new System.Drawing.Size(108, 23);
            this.txtYarnCons.TabIndex = 54;
            this.txtYarnCons.Validating += new System.ComponentModel.CancelEventHandler(this.txtYarnCons_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KDS_Thread.Properties.Resources.save_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(398, 247);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(222, 48);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(110, 23);
            this.dtDate.TabIndex = 213;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(168, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 200;
            this.label2.Text = "Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(395, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 203;
            this.label1.Text = "Soft Winding :";
            // 
            // txtSoftWin
            // 
            this.txtSoftWin.BackColor = System.Drawing.Color.GhostWhite;
            this.txtSoftWin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftWin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSoftWin.Location = new System.Drawing.Point(497, 91);
            this.txtSoftWin.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoftWin.Name = "txtSoftWin";
            this.txtSoftWin.Size = new System.Drawing.Size(108, 23);
            this.txtSoftWin.TabIndex = 202;
            this.txtSoftWin.Validating += new System.ComponentModel.CancelEventHandler(this.txtSoftWin_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(156, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 205;
            this.label4.Text = "Dyeing :";
            // 
            // txtDyeing
            // 
            this.txtDyeing.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDyeing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDyeing.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDyeing.Location = new System.Drawing.Point(224, 118);
            this.txtDyeing.Margin = new System.Windows.Forms.Padding(2);
            this.txtDyeing.Name = "txtDyeing";
            this.txtDyeing.Size = new System.Drawing.Size(108, 23);
            this.txtDyeing.TabIndex = 204;
            this.txtDyeing.Validating += new System.ComponentModel.CancelEventHandler(this.txtDyeing_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(420, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 207;
            this.label5.Text = "Finishing :";
            // 
            // txtFinishing
            // 
            this.txtFinishing.BackColor = System.Drawing.Color.GhostWhite;
            this.txtFinishing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinishing.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFinishing.Location = new System.Drawing.Point(497, 118);
            this.txtFinishing.Margin = new System.Windows.Forms.Padding(2);
            this.txtFinishing.Name = "txtFinishing";
            this.txtFinishing.Size = new System.Drawing.Size(108, 23);
            this.txtFinishing.TabIndex = 206;
            this.txtFinishing.Validating += new System.ComponentModel.CancelEventHandler(this.txtFinishing_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(78, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 15);
            this.label7.TabIndex = 209;
            this.label7.Text = "Lab Dyeing & Testing :";
            this.label7.UseMnemonic = false;
            // 
            // txtLabDyeingTest
            // 
            this.txtLabDyeingTest.BackColor = System.Drawing.Color.GhostWhite;
            this.txtLabDyeingTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabDyeingTest.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLabDyeingTest.Location = new System.Drawing.Point(224, 145);
            this.txtLabDyeingTest.Margin = new System.Windows.Forms.Padding(2);
            this.txtLabDyeingTest.Name = "txtLabDyeingTest";
            this.txtLabDyeingTest.Size = new System.Drawing.Size(108, 23);
            this.txtLabDyeingTest.TabIndex = 208;
            this.txtLabDyeingTest.Validating += new System.ComponentModel.CancelEventHandler(this.txtLabDyeingTest_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(440, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 211;
            this.label8.Text = "Sales :";
            // 
            // txtSales
            // 
            this.txtSales.BackColor = System.Drawing.Color.GhostWhite;
            this.txtSales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSales.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSales.Location = new System.Drawing.Point(497, 145);
            this.txtSales.Margin = new System.Windows.Forms.Padding(2);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(108, 23);
            this.txtSales.TabIndex = 210;
            this.txtSales.Validating += new System.ComponentModel.CancelEventHandler(this.txtSales_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(141, 175);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 213;
            this.label9.Text = "Deviation :";
            // 
            // txtDeviation
            // 
            this.txtDeviation.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDeviation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeviation.Location = new System.Drawing.Point(224, 172);
            this.txtDeviation.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviation.Name = "txtDeviation";
            this.txtDeviation.Size = new System.Drawing.Size(108, 23);
            this.txtDeviation.TabIndex = 212;
            this.txtDeviation.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeviation_Validating);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(506, 247);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 214;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWastageEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(744, 330);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDeviation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLabDyeingTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFinishing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDyeing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoftWin);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtYarnCons);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWastageEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wastage Entry";
            this.Load += new System.EventHandler(this.frmWastageEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYarnCons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoftWin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDyeing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFinishing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLabDyeingTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDeviation;
        private System.Windows.Forms.Button btnClose;
    }
}