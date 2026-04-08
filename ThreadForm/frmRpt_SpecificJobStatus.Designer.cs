namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_SpecificJobStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_SpecificJobStatus));
            this.dtgridJob = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgridJob
            // 
            this.dtgridJob.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgridJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgridJob.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgridJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridJob.EnableHeadersVisualStyles = false;
            this.dtgridJob.Location = new System.Drawing.Point(322, 41);
            this.dtgridJob.Margin = new System.Windows.Forms.Padding(2);
            this.dtgridJob.MultiSelect = false;
            this.dtgridJob.Name = "dtgridJob";
            this.dtgridJob.ReadOnly = true;
            this.dtgridJob.RowHeadersVisible = false;
            this.dtgridJob.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgridJob.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgridJob.RowTemplate.Height = 28;
            this.dtgridJob.Size = new System.Drawing.Size(138, 146);
            this.dtgridJob.TabIndex = 112;
            this.dtgridJob.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridJob_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(126, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 110;
            this.label4.Text = "Order ID :";
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.SystemColors.Window;
            this.txtJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJob.Location = new System.Drawing.Point(192, 41);
            this.txtJob.Margin = new System.Windows.Forms.Padding(2);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(126, 23);
            this.txtJob.TabIndex = 109;
            this.txtJob.TextChanged += new System.EventHandler(this.txtJob_TextChanged);
            this.txtJob.Enter += new System.EventHandler(this.txtJob_Enter);
            this.txtJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJob_KeyDown);
            this.txtJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJob_KeyPress);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.MintCream;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(231, 99);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 27);
            this.btnPreview.TabIndex = 111;
            this.btnPreview.Text = "   Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // frmRpt_SpecificJobStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(537, 204);
            this.Controls.Add(this.dtgridJob);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_SpecificJobStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specific Job Status Report";
            this.Load += new System.EventHandler(this.frmRpt_SpecificJobStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgridJob;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJob;
    }
}