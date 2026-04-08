using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmPasswordChange : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();

        public frmPasswordChange()
        {
            InitializeComponent();
        }

        private void frmPasswordChange_Load(object sender, EventArgs e)
        {

        }
        public void clearField()
        {
            txtNewPassw.Text = "";
            txtConfirmPassw.Text = "";
        }

        private void txtNewPassw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtConfirmPassw.Focus();
            }
        }

        private void txtConfirmPassw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        public string Check_Valid_User(string EmpId)
        {
            string EmployeeId = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT EmployeeId FROM dbo.UserInfo WHERE EmployeeId='" + EmpId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    EmployeeId = dr["EmployeeId"].ToString();
                }
            }

            dr.Close();
            return EmployeeId;
        }//
        public void ChangePassword()
        {
            string EntryBy = frmLogin.UserID.ToString();
            string EmpId = frmLogin.EmpId.ToString();
            string New_Password = txtNewPassw.Text.Trim();
            string Confimr_Password = txtConfirmPassw.Text.Trim();

            string Exist_EmpId = Check_Valid_User(EmpId);
            if (Exist_EmpId != EmpId)
            {
                MessageBox.Show("Invalid User..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (New_Password != Confimr_Password)
            {
                MessageBox.Show("Password not match..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] Cols = { "UserPassword", "EntryBy", "EntryDate" };
            string[] Vals = { New_Password, EntryBy, DateTime.UtcNow.ToString() };
            string[] WhCols = { "EmployeeId" };
            string[] WhVals = { EmpId };
            string sql = dbConCrUser.CreateSQLStatement("UserInfo", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
                MessageBox.Show("Password Change Successfully.", "Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearField();
            }


        }//

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to change your password?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ChangePassword();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
    }
}
