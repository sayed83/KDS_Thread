using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmMachineBreakdown : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmMachineBreakdown()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmMachineBreakdown_Load(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MMM-yyyy";
            dtDate.Value = DateTime.Now;
            dtDate.MinDate = DateTime.Now.AddDays(-3);

            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            cmbMchType.SelectedItem = "Select";
            dbConCrUser.FillComboBox_SingleColumn(cmbMachine, @"SELECT LTRIM(RTRIM(MchName)) FROM ProductionCube..ThreadMachines 
                        WHERE MchType='"+cmbMchType.Text.Trim()+"' AND IsActive=1 AND UnitId='" + Unit + "'");

            dbConCrUser.FillComboBox(cmbShift, @"SELECT 0 Id,'Select' ShiftName
                                                UNION ALL
                                                SELECT Id,ShiftName FROM dbo.ShiftInfo");
            cmbShift.SelectedValue = 0;

            InitialDataGrid();
            Get_GridDataLoad();
        }
        private void InitialDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;


                //================================= Second DataGrid View ===========================
                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeight = 50;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;


                gvListData.Columns.Add("RunningHr", "Running (Hour)");
                gvListData.Columns.Add("MaintenanceHr", "Maintenance (Hour)");
                gvListData.Columns.Add("RMHr", "RM Short (Hour)");
                gvListData.Columns.Add("LDSheddingHr", "Load Shedding (Hour)");
                gvListData.Columns.Add("NoOrderHr", "No Orders (Hour)");
                gvListData.Columns.Add("OtherHr", "Others (Hour)");


                gvListData.Columns["RunningHr"].Width = 90;
                gvListData.Columns["MaintenanceHr"].Width = 90;
                gvListData.Columns["RMHr"].Width = 90;
                gvListData.Columns["LDSheddingHr"].Width = 110;
                gvListData.Columns["NoOrderHr"].Width = 90;
                gvListData.Columns["OtherHr"].Width = 90;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);

                ////============================= End Grid =========================\\\\\



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//

        private void Get_GridDataLoad()
        {
            gvListData.Rows.Add();
            gvListData.RowsDefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);
            gvListData.RowsDefaultCellStyle.ForeColor= Color.Blue;
            //gvListData.RowsDefaultCellStyle.BackColor = Color.DeepPink;
            try
            {
                gvListData.Rows[0].Cells["RunningHr"].Value = 0;
                gvListData.Rows[0].Cells["MaintenanceHr"].Value = 0;
                gvListData.Rows[0].Cells["RMHr"].Value = 0;
                gvListData.Rows[0].Cells["LDSheddingHr"].Value = 0;
                gvListData.Rows[0].Cells["NoOrderHr"].Value = 0;
                gvListData.Rows[0].Cells["OtherHr"].Value = 0;

                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void clearField()
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MMM-yyyy";
            dtDate.Value = DateTime.Now;
            dtDate.MinDate = DateTime.Now.AddDays(-3);

            cmbMchType.SelectedIndex = 0;
            cmbMachine.DataSource = null;
            cmbShift.SelectedIndex = 0;
            txtRemark.Text = "";
            gvListData.Rows.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }
        public int IsExist()
        {
            SqlDataReader dtRdr;
            int count = 0;
            try
            {
                DateTime BreakdownDate = Convert.ToDateTime(dtDate.Text);
                int ShiftId = Convert.ToInt32(cmbShift.SelectedValue);
                string Machine = cmbMachine.Text.Trim();

                dtRdr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.MachineBreakdown WHERE BrkDownDate ='" + BreakdownDate + "' AND ShiftId='" + ShiftId + "' AND Machine='" + Machine + "' ");
                while (dtRdr.Read())
                {
                    count = Convert.ToInt32(dtRdr["cnt"].ToString());
                }

                dtRdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(cmbShift.Text))
                {
                    MessageBox.Show("Select Shift..!!");
                    return;
                }
                if (string.IsNullOrEmpty(cmbMachine.Text))
                {
                    MessageBox.Show("Select Machine..!!");
                    return;
                }
                if (cmbMchType.Text.Trim() == "Select")
                {
                    MessageBox.Show("Select Machine Type..!!");
                    return;
                }

                DateTime BreakdownDate = Convert.ToDateTime(dtDate.Value);
                int ShiftId = Convert.ToInt32(cmbShift.SelectedValue);
                string MchType = cmbMchType.Text.Trim();
                string Machine = cmbMachine.Text.Trim();
                string Remarks = txtRemark.Text.Trim().Replace("'", "");
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //string UserId = frmLogin.UserEmpCode.ToString();

                if (IsExist() > 0)
                {
                    MessageBox.Show("This machine already exists on this selected day!.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "";
                string User = frmLogin.UserID.ToString();
                //string User = "arif";
                decimal RunningHr = 0;
                decimal MaintenanceHr = 0;
                decimal RMHr = 0;
                decimal LDSheddingHr = 0;
                decimal NoOrderHr = 0;
                decimal OtherHr = 0;
                if (gvListData.Rows.Count > 0)
                {
                    RunningHr = Convert.ToDecimal(gvListData.Rows[0].Cells["RunningHr"].Value);
                    MaintenanceHr = Convert.ToDecimal(gvListData.Rows[0].Cells["MaintenanceHr"].Value);
                    RMHr = Convert.ToDecimal(gvListData.Rows[0].Cells["RMHr"].Value);
                    LDSheddingHr = Convert.ToDecimal(gvListData.Rows[0].Cells["LDSheddingHr"].Value);
                    NoOrderHr = Convert.ToDecimal(gvListData.Rows[0].Cells["NoOrderHr"].Value);
                    OtherHr = Convert.ToDecimal(gvListData.Rows[0].Cells["OtherHr"].Value);

                }

                if (RunningHr == 0)
                {
                    MessageBox.Show("Enter machine idle hour..!.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                string[] Cols = { "BrkDownDate", "ShiftId", "MchType", "Machine", "RunningHrs", "MaintHrs", "RMShortHrs", "LDSheddingHrs", "NoOrderHrs", "OtherHrs", "Remarks", "Unit", "EntryBy", "EntryDate" };
                string[] Vals = { BreakdownDate.ToString(), ShiftId.ToString(), MchType, Machine, RunningHr.ToString(), MaintenanceHr.ToString(), RMHr.ToString(), LDSheddingHr.ToString(), NoOrderHr.ToString(), OtherHr.ToString(), Remarks, Unit.ToString(), User, DateTime.Now.ToString() };

                sql += dbConCrUser.CreateSQLStatement("MachineBreakdown", Cols, Vals, "INSERT", null, null);

                if (sql != "" && dbConCrUser.DBInsertUpdateDeleteFunction(sql))
                {
                    clearField();
                    MessageBox.Show("Save Successfully.", "Save",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvListData.BeginEdit(true);
        }

        private void cmbMchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int Unit = frmLogin.UserLocation.ToString();
            //int Unit = 1;
            string MchType = cmbMchType.Text.Trim();
            if(MchType == "DY" || MchType == "SW" || MchType == "WI")
            {
                dbConCrUser.FillComboBox_SingleColumn(cmbMachine, @"SELECT LTRIM(RTRIM(MchName)) FROM ProductionCube..ThreadMachines 
                        WHERE MchType='" + cmbMchType.Text.Trim() + "' AND IsActive=1 AND UnitId='" + Unit + "'");
            }


        }
    }
}
