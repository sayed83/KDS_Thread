using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KDS_Thread.ThreadForm
{
    public partial class frmOTEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        int Unit = 0;
        public frmOTEntry()
        {
            InitializeComponent();
        }

        private void frmOTEntry_Load(object sender, EventArgs e)
        {
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            dbConCrUser.FillComboBox(cmbShift, @"SELECT 0 Id,'Select' ShiftName
                                                UNION ALL
                                                SELECT Id,ShiftName FROM dbo.ShiftInfo");

            dbConCrUser.FillComboBox(cmbWinMachine, @"SELECT '0' Id,'Select' ShortNam
                                    UNION ALL
                                    SELECT Id,ShortNam FROM dbo.WindingMachine WHERE Unit='" + Unit + "'");
            
            dbConCrUser.FillComboBox(cmbCount, @"T_Get_OT_CountList_Proc '" + Unit + "'");

            cmbWinMachine.SelectedItem = "Select";
            cmbShift.SelectedValue = 1;
            txtQty.Text = "0";

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MM-yyyy";
            dtDate.Value = DateTime.Now;
            dtDate.MinDate = DateTime.Now.AddDays(-3);
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQty.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQty.Text = txtQty.Text.Remove(txtQty.Text.Length - 1);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                int ProdId = Convert.ToInt32(cmbCount.SelectedValue);
                int WinQTY = Convert.ToInt32(txtQty.Text.Trim());
                int MchId = Convert.ToInt32(cmbWinMachine.SelectedValue);
                int Shift = Convert.ToInt32(cmbShift.SelectedValue);
                DateTime win_date = dtDate.Value;
                string user = frmLogin.UserID.ToString();

                if (Shift == 0)
                {
                    MessageBox.Show("Select Shift.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtQty.Text == "" || WinQTY == 0)
                {
                    MessageBox.Show("Enter Winding Quantity.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string[] Cols = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "DyeQty", "WinQty", "MchId", "Shift", "WinDate", "PlanSchId", "IsPack", "UnitId", "EntryBy", "EntryDate" };
                string[] Vals = { "OT", "OT", "0", ProdId.ToString(), "WHITE", "0", WinQTY.ToString(), MchId.ToString(), Shift.ToString(), win_date.ToString(), "0", "0", Unit.ToString(), user, DateTime.Now.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("ThreadWIN", Cols, Vals, "INSERT", null, null);

                if (sql != "")
                {
                    sql += "SELECT SCOPE_IDENTITY();";
                    dbConCrUser.DBExecuteScalarWithSQL(sql);
                    count++;
                }
                if (count > 0)
                {
                    cmbWinMachine.SelectedIndex = 0;
                    txtQty.Text = "0";
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
