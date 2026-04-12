namespace KDS_Thread.ThreadForm
{
    partial class frmRpt_BookingReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.btn_booking_preview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date:";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(252, 39);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 1;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(254, 70);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(198, 22);
            this.dtTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unit:";
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(252, 102);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(200, 24);
            this.cbUnit.TabIndex = 5;
            // 
            // btn_booking_preview
            // 
            this.btn_booking_preview.BackColor = System.Drawing.SystemColors.Info;
            this.btn_booking_preview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_booking_preview.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_booking_preview.Image = global::KDS_Thread.Properties.Resources.print;
            this.btn_booking_preview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_booking_preview.Location = new System.Drawing.Point(254, 159);
            this.btn_booking_preview.Name = "btn_booking_preview";
            this.btn_booking_preview.Size = new System.Drawing.Size(198, 36);
            this.btn_booking_preview.TabIndex = 6;
            this.btn_booking_preview.Text = "Preview";
            this.btn_booking_preview.UseVisualStyleBackColor = false;
            this.btn_booking_preview.Click += new System.EventHandler(this.btn_booking_preview_Click);
            // 
            // frmRpt_BookingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 253);
            this.Controls.Add(this.btn_booking_preview);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label1);
            this.Name = "frmRpt_BookingReport";
            this.Text = "Booking Report Form";
            this.Load += new System.EventHandler(this.frmRpt_BookingReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Button btn_booking_preview;
    }
}