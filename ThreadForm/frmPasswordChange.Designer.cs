namespace KDS_Thread.ThreadForm
{
    partial class frmPasswordChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswordChange));
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmPassw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPassw = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(47, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 72;
            this.label4.Text = "Confirm Password :";
            // 
            // txtConfirmPassw
            // 
            this.txtConfirmPassw.BackColor = System.Drawing.Color.GhostWhite;
            this.txtConfirmPassw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConfirmPassw.Location = new System.Drawing.Point(168, 65);
            this.txtConfirmPassw.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassw.Name = "txtConfirmPassw";
            this.txtConfirmPassw.PasswordChar = '*';
            this.txtConfirmPassw.Size = new System.Drawing.Size(114, 23);
            this.txtConfirmPassw.TabIndex = 74;
            this.txtConfirmPassw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassw_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(67, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 75;
            this.label1.Text = "New Password :";
            // 
            // txtNewPassw
            // 
            this.txtNewPassw.BackColor = System.Drawing.Color.GhostWhite;
            this.txtNewPassw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNewPassw.Location = new System.Drawing.Point(168, 38);
            this.txtNewPassw.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPassw.Name = "txtNewPassw";
            this.txtNewPassw.PasswordChar = '*';
            this.txtNewPassw.Size = new System.Drawing.Size(114, 23);
            this.txtNewPassw.TabIndex = 71;
            this.txtNewPassw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassw_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KDS_Thread.Properties.Resources.check_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(194, 106);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "Change";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(371, 168);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPassw);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConfirmPassw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasswordChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Password Change";
            this.Load += new System.EventHandler(this.frmPasswordChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmPassw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPassw;
    }
}