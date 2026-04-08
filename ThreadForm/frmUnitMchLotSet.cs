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
    public partial class frmUnitMchLotSet : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();

        private int rowAdd = 0;
        public int TotalDateCount = 0;
        List<string> ScheduleDate_List = new List<string>();

        public frmUnitMchLotSet()
        {
            InitializeComponent();
        }

        private void frmUnitMchLotSet_Load(object sender, EventArgs e)
        {
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MM-yyyy";
            dtFromDate.MinDate = DateTime.Now.AddDays(1);


            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MM-yyyy";
            dtToDate.MinDate = DateTime.Now.AddDays(1);

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'Select' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            cmbUnit.SelectedItem = "Select";

            dbConCrUser.FillComboBox(cmbDyeMachine, @"SELECT 0 id ,'All' machine_name
                                    UNION ALL
                                    SELECT id ,LTRIM(RTRIM(machine_name)) machine_name FROM thread_machine_master 
                                    WHERE machine_type = 'DY' AND is_active = 1 AND location_id='"+Convert.ToInt32(cmbUnit.SelectedValue)+"' ORDER BY id ASC");

            cmbDyeMachine.SelectedValue = 0;
            txtCTG.Text = "0";
            textDhk.Text = "0";
            textIntr.Text = "0";
            txtTotalLot.Text = "0";

        }

        private void txtCTG_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCTG.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtCTG.Text = txtCTG.Text.Remove(txtCTG.Text.Length - 1);
            }
            if (txtCTG.TextLength > 2)
            {
                MessageBox.Show("Allow only 2 digit!");
                txtCTG.Text = txtCTG.Text.Remove(txtCTG.Text.Length - 1);
            }
        }

        private void textDhk_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textDhk.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textDhk.Text = textDhk.Text.Remove(textDhk.Text.Length - 1);
            }
            if (textDhk.TextLength > 2)
            {
                MessageBox.Show("Allow only 2 digit!");
                textDhk.Text = textDhk.Text.Remove(textDhk.Text.Length - 1);
            }
        }//

        private void textIntr_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textIntr.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textIntr.Text = textIntr.Text.Remove(textIntr.Text.Length - 1);
            }
            if (textIntr.TextLength > 2)
            {
                MessageBox.Show("Allow only 2 digit!");
                textIntr.Text = textIntr.Text.Remove(textIntr.Text.Length - 1);
            }
        }//

        private void txtTotalLot_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTotalLot.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtTotalLot.Text = txtTotalLot.Text.Remove(txtTotalLot.Text.Length - 1);
            }
            if (txtTotalLot.TextLength > 2)
            {
                MessageBox.Show("Allow only 2 digit!");
                txtTotalLot.Text = textIntr.Text.Remove(txtTotalLot.Text.Length - 1);
            }
        }//
        public void clearField()
        {
            dtFromDate.Text = "";
            dtToDate.Text = "";

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MM-yyyy";
            dtFromDate.MinDate = DateTime.Now.AddDays(1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MM-yyyy";
            dtToDate.MinDate = DateTime.Now.AddDays(1);

            cmbUnit.SelectedIndex = 0;
            cmbDyeMachine.SelectedIndex = 0;
            cmbDyeMachine.SelectedValue = 0;
            txtCTG.Text = "0";
            textDhk.Text = "0";
            textIntr.Text = "0";
            txtTotalLot.Text = "0";
        }//
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }//

        private void Generate_ScheduleDateList()
        {
            try
            {
                ScheduleDate_List.Clear();
                TotalDateCount = 0;
                DateTime startDate = dtFromDate.Value;
                DateTime endDate = dtToDate.Value;

                DateTime to_date_formated = dtToDate.Value;
                if (to_date_formated.DayOfWeek == DayOfWeek.Friday)
                {
                    dtToDate.MinDate = DateTime.Now.AddDays(2);
                }

                int dayDiff = Convert.ToInt32((endDate - startDate).TotalDays) + 1;
                for (int i = 0; i < dayDiff; i++)
                {
                    DateTime currentDate = startDate.AddDays(i);
                    string sch_date = currentDate.ToString("dd-MM-yyyy");
                    ScheduleDate_List.Add(sch_date);
                    TotalDateCount++;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public int Check_IsExist_CapacityOnScheduleDate(string schedule_date)
        {
            int count = 0;
            //int location = 1;  // CTG
            //if (cmbUnit.Text == "Dhaka")
            //{
            //    location = 2;
            //}
            int location = Convert.ToInt32(cmbUnit.SelectedValue);
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.machine_capacity WHERE location_id='" + location + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + schedule_date + "'");
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
        public void Update_MachineCapacity(int location, int Capacity, int Ctg_Lot, int Dhk_Lot, int Int_Lot, string EntryBy)
        {
            string From_date = dtFromDate.Text;
            string To_date = dtToDate.Text;

            string[] pName = { "@location", "@From_date", "@To_date", "@Capacity", "@Ctg_Lot", "@Dhk_Lot", "@Int_Lot", "@User" };
            string[] pVal = { location.ToString(), From_date, To_date, Capacity.ToString(), Ctg_Lot.ToString(), Dhk_Lot.ToString(), Int_Lot.ToString(), EntryBy };
            dbConCrUser.DBInsertUsingSP(@"T_Update_UnitMachineLot_Proc", pName, pVal);

        }//
        public void Update_Individual_MchCapacity(int machine_id, int capacity, int capacity_ctg, int capacity_dhk, int capacity_int)
        {
            int location = 1;  // CTG
            string From_date = dtFromDate.Text;
            string To_date = dtToDate.Text;
            if (cmbUnit.Text == "Dhaka")
            {
                location = 2;
            }
            string user = frmLogin.UserID.ToString();
            // string user = frmLogin.UserEmpCode.ToString();
            //string ip_address = frmLogin.ipAddress;

            string[] pName = { "@machine_id", "@location", "@From_date", "@To_date", "@capacity", "@capacity_ctg", "@capacity_dhk", "@capacity_int", "@user" };
            string[] pVal = { machine_id.ToString(), location.ToString(), From_date, To_date, capacity.ToString(), capacity_ctg.ToString(), capacity_dhk.ToString(), capacity_int.ToString(), user };
            dbConCrUser.DBInsertUsingSP(@"T_Update_MchCapacity_Individual_Proc", pName, pVal);

        }//
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string EntryBy = frmLogin.UserID.ToString();
                //string EntryBy = "arif";
                if (cmbUnit.Text == "Select")
                {
                    MessageBox.Show("Select Unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //int location = 1;  // CTG
                //if (cmbUnit.Text == "Dhaka")
                //{
                //    location = 2;
                //}
                int location = Convert.ToInt32(cmbUnit.SelectedValue);
                int CTG_LOT = Convert.ToInt32(txtCTG.Text.Trim());
                int DHK_LOT = Convert.ToInt32(textDhk.Text.Trim());
                int INT_LOT = Convert.ToInt32(textIntr.Text.Trim());
                int Capacity = Convert.ToInt32(txtTotalLot.Text.Trim());
                int count = 0;
                if (location == 1) // ctg
                {
                    if (txtCTG.Text == "" || CTG_LOT == 0)
                    {
                        MessageBox.Show("Enter Lot for selected unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (location == 2) // dhaka
                {
                    if (textDhk.Text == "" || DHK_LOT == 0)
                    {
                        MessageBox.Show("Enter Lot for selected unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (txtTotalLot.Text == "" || Capacity == 0)
                {
                    MessageBox.Show("Enter total lot capacity..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure to save this schedule.?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        DateTime startDate = dtFromDate.Value;
                        DateTime endDate = dtToDate.Value;
                        //int dayDiff = Convert.ToInt32((endDate - startDate).TotalDays) + 1;
                        if (startDate > endDate)
                        {
                            cmbUnit.SelectedItem = "Select";
                            MessageBox.Show("End date less than start date not allowed..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ////---- Individual machine capacity lot
                        int MachineId = Convert.ToInt32(cmbDyeMachine.SelectedValue);
                        if(MachineId != 0) 
                        {
                            Update_Individual_MchCapacity(MachineId, Capacity, CTG_LOT, DHK_LOT, INT_LOT);
                            count = 1;
                        }

                        else ////---- location all machine capacity lot
                        {
                            //-------- save unit machine lot
                            string[] Cols = { "Unit_Loc", "Capacity", "Ctg_Lot", "Dhk_Lot", "Int_Lot", "FromDate", "ToDate", "EntryBy", "EntryDate", };
                            string[] Vals = { location.ToString(), Capacity.ToString(), CTG_LOT.ToString(), DHK_LOT.ToString(), INT_LOT.ToString(), startDate.ToString(), endDate.ToString(), EntryBy, DateTime.Now.ToString() };
                            string sql = dbConCrUser.CreateSQLStatement("UnitMachineLot", Cols, Vals, "INSERT", null, null);
                            if (sql != "")
                            {
                                dbConCrUser.DBExecuteScalarWithSQL(sql);
                            }

                            Update_MachineCapacity(location, Capacity, CTG_LOT, DHK_LOT, INT_LOT, EntryBy);
                            count = 1;
                        }



                        if (count > 0)
                        {
                            clearField();
                            MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Generate_ScheduleDateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string UnitText = cmbUnit.Text.Trim();
                if (UnitText != "0" && UnitText.Length < 12)
                {
                    int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    dbConCrUser.FillComboBox(cmbDyeMachine, @"SELECT 0 id ,'All' machine_name
                                    UNION ALL
                                    SELECT id ,LTRIM(RTRIM(machine_name)) machine_name FROM thread_machine_master 
                                    WHERE machine_type = 'DY' AND is_active = 1 AND location_id='" + Convert.ToInt32(cmbUnit.SelectedValue) + "' ORDER BY id ASC");

                }

            }
            catch 
            {
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
