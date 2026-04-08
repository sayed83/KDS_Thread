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
    public partial class frmUserAdd : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();

        public frmUserAdd()
        {
            InitializeComponent();
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedItem = "Select";
        }
        public void Get_EmployeeInfo(string EmpId)
        {
            int isActive = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_EmployeeInfo_Proc '" + EmpId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtUserId.Text = dr["UserId"].ToString();
                    txtUserName.Text = dr["UserName"].ToString();
                    txtLocation.Text = dr["EmpLocation"].ToString();
                    //txtDepartment.Text = dr["DeptName"].ToString();
                    cmbStatus.SelectedItem = dr["IsActive"].ToString();

                }
            }

            dr.Close();
        }//

        public int Check_IsExist_User(string EmpId)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.UserInfo WHERE EmployeeId='" + EmpId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    count = Convert.ToInt32(dr["cnt"].ToString());
                }
            }

            dr.Close();
            return count;
        }//
        public void clearField()
        {
            txtEmpCode.Text = "";
            txtUserId.Text = "";
            txtUserName.Text = "";
            txtLocation.Text = "";
            txtLocation.Text = "";
            cmbStatus.SelectedIndex = 0;
        }
        public void Insert_Update_User()
        {
            string EntryBy = frmLogin.UserID.ToString();
            string UserId = txtUserId.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string UserPassword = "kds123";
            string Location = txtLocation.Text.Trim();
            int LocationId = 0;

            if (Location == "Chattogram")
            {
                LocationId = 1;
            }
            if (Location == "Dhaka")
            {
                LocationId = 2;
            }

            string status = cmbStatus.SelectedItem.ToString();
            int IsActive = 0;
            if (status == "Active")
            {
                IsActive = 1;
            }

            string EmpId = txtEmpCode.Text.Trim();
            int IsExist = Check_IsExist_User(EmpId);

            if (IsExist == 0)
            {
                string[] Cols = { "UserId", "UserName", "UserPassword", "EmployeeId", "Location", "IsActive", "EntryBy", "EntryDate" };
                string[] Vals = { UserId, UserName, UserPassword, EmpId, LocationId.ToString(), IsActive.ToString(), EntryBy, DateTime.UtcNow.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("UserInfo", Cols, Vals, "INSERT", null, null);

                if (sql != "")
                {
                    sql += "SELECT SCOPE_IDENTITY();";
                    dbConCrUser.DBExecuteScalarWithSQL(sql);

                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string[] Cols = { "UserId", "IsActive", "EntryBy", "EntryDate" };
                string[] Vals = { UserId, IsActive.ToString(), EntryBy, DateTime.UtcNow.ToString() };
                string[] WhCols = { "EmployeeId" };
                string[] WhVals = { EmpId };
                string sql = dbConCrUser.CreateSQLStatement("UserInfo", Cols, Vals, "UPDATE", WhCols, WhVals);

                if (sql != "")
                {
                    dbConCrUser.DBExecuteScalarWithSQL(sql);

                    MessageBox.Show("Update Successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }


        }//

        private void txtEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Get_EmployeeInfo(txtEmpCode.Text.Trim().Replace("'", ""));
                btnSave.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmpCode.Text == "")
            {
                MessageBox.Show("Enter Employee Id..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUserId.Text == "")
            {
                MessageBox.Show("Enter User Id..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStatus.Text == "Select")
            {
                MessageBox.Show("Select Status..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                if (MessageBox.Show("Are you sure to save this user?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Insert_Update_User();
                    clearField();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
    }
}
