namespace KDS_Thread.ThreadForm
{
    partial class frmStockPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockPlan));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlanMachine = new System.Windows.Forms.ComboBox();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShade = new System.Windows.Forms.ComboBox();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(50, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "Plan Mch. :";
            // 
            // cmbPlanMachine
            // 
            this.cmbPlanMachine.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbPlanMachine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanMachine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPlanMachine.FormattingEnabled = true;
            this.cmbPlanMachine.Location = new System.Drawing.Point(123, 58);
            this.cmbPlanMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlanMachine.Name = "cmbPlanMachine";
            this.cmbPlanMachine.Size = new System.Drawing.Size(110, 23);
            this.cmbPlanMachine.TabIndex = 64;
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPlanDate.Location = new System.Drawing.Point(123, 31);
            this.dtPlanDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(110, 23);
            this.dtPlanDate.TabIndex = 63;
            this.dtPlanDate.ValueChanged += new System.EventHandler(this.dtPlanDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 62;
            this.label1.Text = "Plan Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(292, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 67;
            this.label2.Text = "Shade :";
            // 
            // cmbShade
            // 
            this.cmbShade.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShade.FormattingEnabled = true;
            this.cmbShade.Location = new System.Drawing.Point(346, 31);
            this.cmbShade.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShade.Name = "cmbShade";
            this.cmbShade.Size = new System.Drawing.Size(110, 23);
            this.cmbShade.TabIndex = 66;
            // 
            // txtQTY
            // 
            this.txtQTY.BackColor = System.Drawing.Color.GhostWhite;
            this.txtQTY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTY.ForeColor = System.Drawing.Color.Navy;
            this.txtQTY.Location = new System.Drawing.Point(561, 58);
            this.txtQTY.Margin = new System.Windows.Forms.Padding(2);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(111, 23);
            this.txtQTY.TabIndex = 82;
            this.txtQTY.TextChanged += new System.EventHandler(this.txtQTY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(519, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 83;
            this.label3.Text = "QTY :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(646, 147);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 30);
            this.btnRefresh.TabIndex = 85;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KDS_Thread.Properties.Resources.save_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(546, 147);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.Location = new System.Drawing.Point(53, 198);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.MultiSelect = false;
            this.gvListData.Name = "gvListData";
            this.gvListData.ReadOnly = true;
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(692, 161);
            this.gvListData.TabIndex = 86;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(293, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 15);
            this.label16.TabIndex = 88;
            this.label16.Text = "Count :";
            // 
            // cmbCount
            // 
            this.cmbCount.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(346, 58);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(110, 23);
            this.cmbCount.TabIndex = 87;
            this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.cmbCount_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(500, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 161;
            this.label8.Text = "Product :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(646, 375);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 185;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(561, 31);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(191, 23);
            this.cmbProduct.TabIndex = 186;
            // 
            // frmStockPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(775, 427);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCount);
            this.Controls.Add(this.gvListData);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQTY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbShade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlanMachine);
            this.Controls.Add(this.dtPlanDate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStockPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Planning";
            this.Load += new System.EventHandler(this.frmNonSchBlackWhitePlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlanMachine;
        private System.Windows.Forms.DateTimePicker dtPlanDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbShade;
        private System.Windows.Forms.TextBox txtQTY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbProduct;
    }
}