using KDS_Thread.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace KDS_Thread
{
    public partial class frmLogin : Form
    {
        private clsCommonFunctions dbConLogin = new clsCommonFunctions();
        public static string userFullName = "", userType = "", ipAddress = "",
          pList = "", LoginID = "", UserID = "", userEmail = "", EmpId = "", RoleId="", UserLocation = "", LocationID = "", Userpass = "";

      
        public static int userNo = 0;
        public static bool isLogin = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MDIMain md = new MDIMain(true);
            this.Icon = md.Icon;
            //cmbUnit.SelectedItem = "Select";

            lblVersion.Text = "Version : " + GetPublishedVersion().ToString();

            txtName.Text = Settings.Default.UserId;

            if (Get_Unit_ByUserID() == 1)
            {
                cmbUnit.SelectedItem = "Chattogram";
            }
            else if (Get_Unit_ByUserID() == 2)
            {
                cmbUnit.SelectedItem = "Dhaka";
            }
            else
            {
                cmbUnit.SelectedItem = "Select";
            }
        }
        public int Get_Unit_ByUserID()
        {
            int Unit = 0;
            SqlDataReader dr = dbConLogin.DBRetrieveFunction("SELECT [Location] AS Unit FROM dbo.UserInfo WHERE EmployeeId='" + txtName.Text.Replace("'", "").Trim() + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    Unit = Convert.ToInt32(dr["Unit"].ToString());
                }
            }

            dr.Close();
            return Unit;
        }//
        public void clear_text()
        {
            cmbUnit.SelectedItem = "Select";
            txtName.Text = "";
            txtPassword.Text = "";
        }
        public static Version GetPublishedVersion()
        {
            XmlDocument xmlDoc = new XmlDocument();
            Assembly asmCurrent = Assembly.GetExecutingAssembly();
            string executePath = new Uri(asmCurrent.GetName().CodeBase).LocalPath;

            xmlDoc.Load(executePath + ".manifest");
            string retval = string.Empty;
            if (xmlDoc.HasChildNodes)
            {
                retval = xmlDoc.ChildNodes[1].ChildNodes[0].Attributes.GetNamedItem("version").Value.ToString();
            }
            return new Version(retval);
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtName.Focus();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int Unit = 1; //-- Chattogram
            string UnitName = cmbUnit.Text.ToString().Trim();
            if (UnitName == "Dhaka")
            {
                Unit = 2;
            }
            try
            {
                if (cmbUnit.SelectedItem != "Select")
                {
                    if (!dbConLogin.CheckEmptyOrNull(txtName, "Enter User ID") &&
                   !dbConLogin.CheckEmptyOrNull(txtPassword, "Enter Password"))
                    {
                        SqlDataReader dr = dbConLogin.DBRetrieveFunction(@"EXEC T_Login_Proc '" + dbConLogin.SingleQuoteHandler(txtName) + "','" + dbConLogin.SingleQuoteHandler(txtPassword) + "','" + Unit + "'");
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                //UserID = txtName.Text.Trim();
                                LoginID = txtName.Text.Trim(); ;
                                Userpass = txtPassword.Text.Trim();
                                //LocationID = dr["Location"].ToString();
                                UserID = dr["Id"].ToString();
                                UserLocation = dr["Location"].ToString();
                                EmpId = dr["EmployeeId"].ToString();
                                userFullName = dr["UserName"].ToString();
                                RoleId = dr["RoleId"].ToString();
                                //userEmail = dr["Email"].ToString();
                                //pList = dr["PrivilegeList"].ToString();
                                isLogin = true;
                            }
                            if (isLogin)
                            {
                                Settings.Default.UserId = txtName.Text;
                                Settings.Default.Save();

                                this.Hide();
                                MDIMain frmMD = new MDIMain(isLogin);
                                frmMD.Show();
                            }
                            else
                            {
                                txtName.Text = "";
                                txtPassword.Text = "";
                                MessageBox.Show("Invalid User Name & Password..!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            txtName.Text = "";
                            txtPassword.Text = "";
                            MessageBox.Show("Invalid User Name & Password..!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Select Unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
    }
}
