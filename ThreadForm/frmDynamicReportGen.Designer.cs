namespace KDS_Thread.ThreadForm
{
    partial class frmDynamicReportGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDynamicReportGen));
            this.lblReport = new System.Windows.Forms.Label();
            this.cmbReportList = new System.Windows.Forms.ComboBox();
            this.pnlHost = new System.Windows.Forms.Panel();
            this.pnlParams = new System.Windows.Forms.TableLayoutPanel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlHost.SuspendLayout();
            this.SuspendLayout();
            //
            // lblReport
            //
            this.lblReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReport.Location = new System.Drawing.Point(40, 34);
            this.lblReport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(130, 23);
            this.lblReport.TabIndex = 0;
            this.lblReport.Text = "Report :";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // cmbReportList
            //
            this.cmbReportList.BackColor = System.Drawing.Color.GhostWhite;
            this.cmbReportList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbReportList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbReportList.FormattingEnabled = true;
            this.cmbReportList.Location = new System.Drawing.Point(175, 34);
            this.cmbReportList.Margin = new System.Windows.Forms.Padding(2);
            this.cmbReportList.Name = "cmbReportList";
            this.cmbReportList.Size = new System.Drawing.Size(555, 23);
            this.cmbReportList.TabIndex = 1;
            this.cmbReportList.SelectedIndexChanged += new System.EventHandler(this.cmbReportList_SelectedIndexChanged);
            //
            // pnlHost
            //
            this.pnlHost.AutoScroll = true;
            this.pnlHost.Controls.Add(this.pnlParams);
            this.pnlHost.Location = new System.Drawing.Point(40, 72);
            this.pnlHost.Name = "pnlHost";
            this.pnlHost.Size = new System.Drawing.Size(730, 140);
            this.pnlHost.TabIndex = 2;
            //
            // pnlParams
            //
            this.pnlParams.AutoSize = true;
            this.pnlParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlParams.ColumnCount = 4;
            this.pnlParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.pnlParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.pnlParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.pnlParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.pnlParams.Location = new System.Drawing.Point(0, 0);
            this.pnlParams.Margin = new System.Windows.Forms.Padding(0);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.RowCount = 1;
            this.pnlParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.pnlParams.Size = new System.Drawing.Size(700, 0);
            this.pnlParams.TabIndex = 0;
            //
            // btnPreview
            //
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(340, 231);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(107, 36);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::KDS_Thread.Properties.Resources.refresh_icon;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(462, 230);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 37);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = " Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // frmDynamicReportGen
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(808, 326);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pnlHost);
            this.Controls.Add(this.cmbReportList);
            this.Controls.Add(this.lblReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDynamicReportGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Reports";
            this.Load += new System.EventHandler(this.frmDynamicReportGen_Load);
            this.pnlHost.ResumeLayout(false);
            this.pnlHost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.ComboBox cmbReportList;
        private System.Windows.Forms.Panel pnlHost;
        private System.Windows.Forms.TableLayoutPanel pnlParams;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnRefresh;
    }
}
