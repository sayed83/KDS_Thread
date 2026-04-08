namespace KDS_Thread.ThreadForm
{
    partial class frmStockEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockEntry));
            this.gvListData = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShade = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).BeginInit();
            this.SuspendLayout();
            // 
            // gvListData
            // 
            this.gvListData.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.gvListData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvListData.Location = new System.Drawing.Point(43, 202);
            this.gvListData.Margin = new System.Windows.Forms.Padding(2);
            this.gvListData.MultiSelect = false;
            this.gvListData.Name = "gvListData";
            this.gvListData.ReadOnly = true;
            this.gvListData.RowHeadersVisible = false;
            this.gvListData.RowHeadersWidth = 62;
            this.gvListData.RowTemplate.Height = 28;
            this.gvListData.Size = new System.Drawing.Size(619, 147);
            this.gvListData.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(345, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "QTY :";
            // 
            // txtQTY
            // 
            this.txtQTY.BackColor = System.Drawing.Color.GhostWhite;
            this.txtQTY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTY.ForeColor = System.Drawing.Color.Navy;
            this.txtQTY.Location = new System.Drawing.Point(388, 60);
            this.txtQTY.Margin = new System.Windows.Forms.Padding(2);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(96, 23);
            this.txtQTY.TabIndex = 93;
            this.txtQTY.TextChanged += new System.EventHandler(this.txtQTY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(91, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Shade :";
            // 
            // cmbShade
            // 
            this.cmbShade.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbShade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShade.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShade.FormattingEnabled = true;
            this.cmbShade.Location = new System.Drawing.Point(145, 57);
            this.cmbShade.Margin = new System.Windows.Forms.Padding(2);
            this.cmbShade.Name = "cmbShade";
            this.cmbShade.Size = new System.Drawing.Size(113, 23);
            this.cmbShade.TabIndex = 91;
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(145, 30);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(113, 23);
            this.dtDate.TabIndex = 88;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(66, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Prod. Date :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(481, 127);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 36);
            this.btnRefresh.TabIndex = 96;
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
            this.btnSave.Location = new System.Drawing.Point(374, 127);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(92, 86);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 15);
            this.label16.TabIndex = 99;
            this.label16.Text = "Count :";
            // 
            // cmbCount
            // 
            this.cmbCount.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(145, 84);
            this.cmbCount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(113, 23);
            this.cmbCount.TabIndex = 98;
            this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.cmbCount_SelectedIndexChanged);
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(388, 33);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(191, 23);
            this.cmbProduct.TabIndex = 188;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(327, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 187;
            this.label8.Text = "Product :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KDS_Thread.Properties.Resources.application_exit_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(563, 362);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStockEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(691, 410);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbProduct);
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
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStockEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Entry";
            this.Load += new System.EventHandler(this.frmStockEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvListData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQTY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbShade;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
    }
}