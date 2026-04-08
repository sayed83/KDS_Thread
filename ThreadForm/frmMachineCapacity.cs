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
    public partial class frmMachineCapacity : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn checkColumn3 = new DataGridViewCheckBoxColumn();

        private int rowAdd = 0;
        public int TotalDateCount = 0;
        List<string> ScheduleDate_List = new List<string>();

        public frmMachineCapacity()
        {
            InitializeComponent();
        }

        private void frmMachineCapacity_Load(object sender, EventArgs e)
        {
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MM-yyyy";
            dtFromDate.MinDate = DateTime.Now.AddDays(1);


            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MM-yyyy";
            dtToDate.MinDate = DateTime.Now.AddDays(1);

            SkipFriday();

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'Select' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cmbUnit.SelectedValue = Unit;
            cmbSpecific.SelectedItem = "Select";
            //dbConCrUser.FillComboBox(cmbUnit, @"T_Get_UnitMachineList_Proc '1'");

            InitDataGrid();
            //Bind_DataLoad();
            InitDataGrid_Specific();
            gvData.Visible = false;
            gvSpecific.Visible = false;
        }

        public void SkipFriday()
        {
            DateTime from_date_formated = dtFromDate.Value;
            if (from_date_formated.DayOfWeek == DayOfWeek.Friday)
            {
                dtFromDate.MinDate = DateTime.Now.AddDays(2);
            }
            DateTime to_date_formated = dtToDate.Value;
            if (to_date_formated.DayOfWeek == DayOfWeek.Friday)
            {
                dtToDate.MinDate = DateTime.Now.AddDays(2);
            }
        }
        private void InitDataGrid()
        {
            try
            {
                gvData.Columns.Clear();
                gvData.Rows.Clear();

                //this.gvData.EnableHeadersVisualStyles = false;
                //this.gvData.ColumnHeadersHeight = 50;

                // this.gvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                checkColumn2.Name = "X";
                checkColumn2.HeaderText = "";
                checkColumn2.Width = 30;
                checkColumn2.ReadOnly = false;
                checkColumn2.FillWeight = 10;
                gvData.Columns.Add(checkColumn2);

                gvData.Columns.Add("machinename", "Machine");
                gvData.Columns.Add("capacity", "Capacity");
                gvData.Columns.Add("ctg_lot", "CTG");
                gvData.Columns.Add("dhk_lot", "Dhaka");
                gvData.Columns.Add("int_lot", "Internal");


                gvData.Columns["machinename"].Width = 80;
                gvData.Columns["capacity"].Width = 60;
                gvData.Columns["ctg_lot"].Width = 60;
                gvData.Columns["dhk_lot"].Width = 60;
                gvData.Columns["int_lot"].Width = 60;

                gvData.Columns["machinename"].ReadOnly = true;
                gvData.Columns["capacity"].ReadOnly = true;

                gvData.Columns.Add("machine_id", "machine_id");
                gvData.Columns["machine_id"].Visible = false;

                gvData.Columns["ctg_lot"].DefaultCellStyle.BackColor = Color.LightGreen;
                gvData.Columns["ctg_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvData.Columns["dhk_lot"].DefaultCellStyle.BackColor = Color.LightBlue;
                gvData.Columns["dhk_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvData.Columns["int_lot"].DefaultCellStyle.BackColor = Color.LightPink;
                gvData.Columns["int_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);
                //this.gvData.DefaultCellStyle.SelectionBackColor = this.gvData.DefaultCellStyle.BackColor;

                this.gvData.EnableHeadersVisualStyles = false;
                this.gvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                gvData.ColumnHeadersHeight = 40;
                gvData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                gvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }//
        public void Bind_DataLoad()
        {

            SqlDataReader dr;
            int Row = 0;

            try
            {

                gvData.Rows.Clear();
                gvData.AllowUserToAddRows = false;
                int location = 1;  // CTG
                if (cmbUnit.Text == "Dhaka")
                {
                    location = 2;
                }
                string FromDate = dtFromDate.Text;
                string ToDate = dtToDate.Text;
                // dtRdr = dbConCrUser.DBRetrieveFunction(@"SELECT rtrim(machine_name) machine_name,lot_per_day FROM thread_machine_master WHERE location_id='" + Unit + "'");
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_MachineCapacity_Datewise_Proc '" + location + "','" + FromDate + "','" + ToDate + "'");

                rowAdd = gvData.Rows.Count;
                while (dr.Read())
                {
                    gvData.Rows.Add();

                    gvData.Rows[rowAdd].Cells["machinename"].Value = dr["machine_name"].ToString();
                    gvData.Rows[rowAdd].Cells["capacity"].Value = dr["capacity"].ToString();
                    gvData.Rows[rowAdd].Cells["ctg_lot"].Value = dr["capacity_ctg"].ToString();
                    gvData.Rows[rowAdd].Cells["dhk_lot"].Value = dr["capacity_dhk"].ToString();
                    gvData.Rows[rowAdd].Cells["int_lot"].Value = dr["capacity_int"].ToString();
                    gvData.Rows[rowAdd].Cells["machine_id"].Value = dr["machine_id"].ToString();

                    rowAdd++;
                    //}
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private void InitDataGrid_Specific()
        {
            try
            {
                gvSpecific.Columns.Clear();
                gvSpecific.Rows.Clear();

                checkColumn3.Name = "X";
                checkColumn3.HeaderText = "";
                checkColumn3.Width = 30;
                checkColumn3.ReadOnly = false;
                checkColumn3.FillWeight = 10;
                gvSpecific.Columns.Add(checkColumn3);

                gvSpecific.Columns.Add("machinename", "Machine");
                gvSpecific.Columns.Add("capacity", "Capacity");
                gvSpecific.Columns.Add("ctg_lot", "CTG");
                gvSpecific.Columns.Add("dhk_lot", "Dhaka");
                gvSpecific.Columns.Add("int_lot", "Internal");
                gvSpecific.Columns.Add("UsedLot", "Used");

                gvSpecific.Columns["machinename"].Width = 80;
                gvSpecific.Columns["capacity"].Width = 60;
                gvSpecific.Columns["UsedLot"].Width = 140;
                gvSpecific.Columns["ctg_lot"].Width = 50;
                gvSpecific.Columns["dhk_lot"].Width = 50;
                gvSpecific.Columns["int_lot"].Width = 50;

                gvSpecific.Columns["machinename"].ReadOnly = true;
                gvSpecific.Columns["capacity"].ReadOnly = true;
                gvSpecific.Columns["UsedLot"].ReadOnly = true;

                gvSpecific.Columns.Add("machine_id", "machine_id");
                gvSpecific.Columns["machine_id"].Visible = false;

                gvSpecific.Columns["UsedLot"].DefaultCellStyle.ForeColor = Color.Navy;
                gvSpecific.Columns["UsedLot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvSpecific.Columns["ctg_lot"].DefaultCellStyle.BackColor = Color.LightGreen;
                gvSpecific.Columns["ctg_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvSpecific.Columns["dhk_lot"].DefaultCellStyle.BackColor = Color.LightBlue;
                gvSpecific.Columns["dhk_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvSpecific.Columns["int_lot"].DefaultCellStyle.BackColor = Color.LightPink;
                gvSpecific.Columns["int_lot"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvSpecific.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvSpecific.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);
                //this.gvSpecific.DefaultCellStyle.SelectionBackColor = this.gvSpecific.DefaultCellStyle.BackColor;

                this.gvSpecific.EnableHeadersVisualStyles = false;
                this.gvSpecific.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                gvSpecific.ColumnHeadersHeight = 40;
                gvSpecific.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                gvSpecific.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }//
        public void Bind_Specific_DataLoad()
        {

            SqlDataReader dr;
            int Row = 0;

            try
            {

                gvSpecific.Rows.Clear();
                gvSpecific.AllowUserToAddRows = false;
                int location = 1;  // CTG
                if (cmbUnit.Text == "Dhaka")
                {
                    location = 2;
                }
                DateTime SchDate = dtFromDate.Value;
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Specific_MchLotCapacity_Proc '" + location + "','" + SchDate + "'");

                rowAdd = gvSpecific.Rows.Count;
                while (dr.Read())
                {
                    gvSpecific.Rows.Add();

                    gvSpecific.Rows[rowAdd].Cells["machinename"].Value = dr["machine_name"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["capacity"].Value = dr["capacity"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["UsedLot"].Value = dr["TotalUsed"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["ctg_lot"].Value = dr["capacity_ctg"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["dhk_lot"].Value = dr["capacity_dhk"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["int_lot"].Value = dr["capacity_int"].ToString();
                    gvSpecific.Rows[rowAdd].Cells["machine_id"].Value = dr["machine_id"].ToString();

                    rowAdd++;
                    //}
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SkipFriday();

            cmbUnit.SelectedItem = "Select";
            gvData.Rows.Clear();

            cmbSpecific.SelectedItem = "Select";
            gvSpecific.Rows.Clear();
            //gvSpecific.Visible = false;
        }
        public void Inser_MachineCapacitySchDate(string schedule_date)
        {
            int location = 1;  // CTG
            if (cmbUnit.Text == "Dhaka")
            {
                location = 2;
            }
            string user = frmLogin.UserID.ToString();
            // string user = frmLogin.UserEmpCode.ToString();
            //string ip_address = frmLogin.ipAddress;

            string[] pName = { "@location", "@schedule_date", "@user" };
            string[] pVal = { location.ToString(), schedule_date, user };
            dbConCrUser.DBInsertUsingSP(@"T_Insert_MchCapacitySchDate_Proc", pName, pVal);

        }//
        public void Update_MchCapacitySchDate(int machine_id, string schedule_date, int capacity_ctg, int capacity_dhk, int capacity_int)
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

            string[] pName = { "@machine_id", "@location", "@schedule_date", "@From_date", "@To_date", "@capacity_ctg", "@capacity_dhk", "@capacity_int", "@user" };
            string[] pVal = { machine_id.ToString(), location.ToString(), schedule_date, From_date, To_date, capacity_ctg.ToString(), capacity_dhk.ToString(), capacity_int.ToString(), user };
            dbConCrUser.DBInsertUsingSP(@"T_Update_MchCapacity_SchDatewise_Proc", pName, pVal);

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
            int location = 1;  // CTG
            if (cmbUnit.Text == "Dhaka")
            {
                location = 2;
            }
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
        public int Check_IsExist_ScheduleDate(string from_date, string end_date)
        {
            int count = 0;
            int location = 1;  // CTG
            if (cmbUnit.Text == "Dhaka")
            {
                location = 2;
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.machine_capacity WHERE location_id='" + location + "' AND CONVERT(NVARCHAR(20),schedule_date,105) BETWEEN '" + from_date + "' AND '" + end_date + "'");
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
        public int Total_Mch_DeductedLotOnSchDate(int machine_id, string schedule_date)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.thread_lot WHERE machine_id='" + machine_id + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + schedule_date + "'");

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
        public int Get_AllocatedLot_Capacity(int machine_id, string schedule_date)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT ISNULL(capacity_ctg,0)+ISNULL(capacity_dhk,0)+ISNULL(capacity_internal,0) cnt FROM dbo.machine_capacity WHERE machine_id = '" + machine_id + "' AND CONVERT(NVARCHAR(20), schedule_date, 105) = '" + schedule_date + "'");

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

        private void gvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvData.SelectedCells.Count > 0)
            {
                try
                {
                    //DataGridViewRow row = gvData.Rows[e.RowIndex];
                    //DataGridViewRow selectedRow = gvData.SelectedRows[0];
                    //bool checkBoxStatus = Convert.ToBoolean(selectedRow.Cells["X"].Value);
                    //if (checkBoxStatus)
                    //{
                    //    int a = 0;
                    //}
                    if (e.ColumnIndex >= 0)
                    {
                        int machine_id = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells["machine_id"].Value);
                        int capacity = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells["capacity"].Value);
                        int ctg_lot = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells["ctg_lot"].Value);
                        int dhk_lot = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells["dhk_lot"].Value);
                        int int_lot = Convert.ToInt32(gvData.Rows[e.RowIndex].Cells["int_lot"].Value);
                        int Total_lot = ctg_lot + dhk_lot + int_lot;
                        if (Total_lot > capacity)
                        {
                            gvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            MessageBox.Show("Lot capacity exceed..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }


                        //// check deducted lot
                        if (gvData.Columns[gvData.CurrentCell.ColumnIndex].Name == "ctg_lot" || gvData.Columns[gvData.CurrentCell.ColumnIndex].Name == "dhk_lot"
                            || gvData.Columns[gvData.CurrentCell.ColumnIndex].Name == "int_lot")
                        {
                            for (int i = 0; i < TotalDateCount; i++)
                            {
                                string sch_date = ScheduleDate_List[i];
                                int DeductedLot = Total_Mch_DeductedLotOnSchDate(machine_id, sch_date);
                                if (Total_lot < DeductedLot)
                                {
                                    MessageBox.Show("This machine scheduled " + DeductedLot + " lot on " + sch_date + " . You cannot reduce lot.!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                int AllocatedLot = Get_AllocatedLot_Capacity(machine_id, sch_date);
                                int DueLot = capacity - AllocatedLot;
                                int Will_TotalLot = 0;
                                if (DueLot > 0)
                                {
                                    Will_TotalLot = Total_lot - DueLot;
                                    if (Will_TotalLot > capacity)
                                    {
                                        MessageBox.Show("Lot capacity exceed..!! This machine allocated " + AllocatedLot + " lot on " + sch_date + " . You cannot add lot, more than capacity.!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                if (DueLot == 0)
                                {
                                    //Will_TotalLot = Total_lot + DueLot;
                                    if (Total_lot > capacity)
                                    {
                                        MessageBox.Show("Lot capacity exceed..!! This machine allocated " + AllocatedLot + " lot on " + sch_date + " . You cannot add lot more than capacity.!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                //if (Total_lot > DueLot && Total_lot > capacity)
                                //{
                                //    MessageBox.Show("Lot capacity exceed..!! This machine allocated " + AllocatedLot + " lot on " + sch_date + " . You cannot add lot more than capacity.!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}
                                //if (DueLot > 0 && Total_lot > capacity)
                                //{
                                //    MessageBox.Show("Lot capacity exceed..!! This machine allocated " + AllocatedLot + " lot on " + sch_date + " . You cannot add lot more than capacity.!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}


                            }

                        }


                    }
                }
                catch { }


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
        public void Periodic_Save()
        {
            try
            {
                bool checkBoxStatus = false;
                if (MessageBox.Show("Are you sure to save this?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string from_date = dtFromDate.Text;
                    string end_date = dtToDate.Text;

                    if (Check_IsExist_ScheduleDate(from_date, end_date) > 0)
                    {
                        int gridRow = 0;
                        int count = 0;
                        if (gvData.Rows.Count > 0)
                        {
                            gridRow = gvData.Rows.Count;
                            for (int i = 0; i < gridRow; i++)
                            {
                                try
                                {
                                    if (gvData.Rows[i].Cells["X"].Value == null)
                                    {
                                        checkBoxStatus = false;
                                    }
                                    else
                                    {
                                        checkBoxStatus = Convert.ToBoolean((gvData.Rows[i].Cells["X"].Value).ToString());
                                    }

                                }
                                catch { }
                                if (checkBoxStatus)
                                {
                                    for (int d = 0; d < TotalDateCount; d++)
                                    {
                                        string sch_date = ScheduleDate_List[d];

                                        int machine_id = Convert.ToInt32(gvData.Rows[i].Cells["machine_id"].Value.ToString());
                                        int capacity_ctg = Convert.ToInt32(gvData.Rows[i].Cells["ctg_lot"].Value.ToString());
                                        int capacity_dhk = Convert.ToInt32(gvData.Rows[i].Cells["dhk_lot"].Value.ToString());
                                        int capacity_int = Convert.ToInt32(gvData.Rows[i].Cells["int_lot"].Value.ToString());

                                        Update_MchCapacitySchDate(machine_id, sch_date, capacity_ctg, capacity_dhk, capacity_int);
                                        count++;
                                    }
                                }


                            }
                        }

                        if (count > 0)
                        {
                            clearField();
                            MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch 
            {

            }
        }
        public void Specific_Save()
        {
            try
            {

                DateTime startDate = dtFromDate.Value;
                DateTime endDate = dtToDate.Value;
                int dayDiff = Convert.ToInt32((endDate - startDate).TotalDays);
                if(dayDiff > 0)
                {
                    MessageBox.Show("Select Only Specific Date..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool checkBoxStatus = false;
                if (MessageBox.Show("Are you sure to save this?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string from_date = dtFromDate.Text;
                    string end_date = dtToDate.Text;

                    if (Check_IsExist_ScheduleDate(from_date, end_date) > 0)
                    {
                        int gridRow = 0;
                        int count = 0;
                        if (gvSpecific.Rows.Count > 0)
                        {
                            gridRow = gvSpecific.Rows.Count;
                            for (int i = 0; i < gridRow; i++)
                            {
                                try
                                {
                                    if (gvSpecific.Rows[i].Cells["X"].Value == null)
                                    {
                                        checkBoxStatus = false;
                                    }
                                    else
                                    {
                                        checkBoxStatus = Convert.ToBoolean((gvSpecific.Rows[i].Cells["X"].Value).ToString());
                                    }

                                }
                                catch { }
                                if (checkBoxStatus)
                                {
                                    int machine_id = Convert.ToInt32(gvSpecific.Rows[i].Cells["machine_id"].Value.ToString());
                                    int capacity_ctg = Convert.ToInt32(gvSpecific.Rows[i].Cells["ctg_lot"].Value.ToString());
                                    int capacity_dhk = Convert.ToInt32(gvSpecific.Rows[i].Cells["dhk_lot"].Value.ToString());
                                    int capacity_int = Convert.ToInt32(gvSpecific.Rows[i].Cells["int_lot"].Value.ToString());

                                    Update_MchCapacitySchDate(machine_id, from_date, capacity_ctg, capacity_dhk, capacity_int);
                                    count++;
                                }


                            }
                        }

                        if (count > 0)
                        {
                            clearField();
                            MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch
            {

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Type = cmbSpecific.Text;

                if (Type == "Periodic")
                {
                    Periodic_Save();
                }
                else if (Type == "Specific")
                {
                    Specific_Save();
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }//

        public void calender_holidays()
        {
            //DateTime endingDate = DateTime.ParseExact("07/25/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);//TODO Insert variable from poted form 
            //int workingDays = 5;
            //List<DateTime> dates = new List<DateTime>();
            //DateTime startingDate = endingDate;
            //while (dates.Count < workingDays)
            //{
            //    if (startingDate.DayOfWeek != DayOfWeek.Sunday && startingDate.DayOfWeek != DayOfWeek.Saturday)
            //    {
            //        dates.Insert(0, startingDate);
            //    }
            //    startingDate = startingDate.AddDays(-1);
            //}

            DateTime startDate = dtFromDate.Value;
            DateTime endDate = dtToDate.Value;

            string fromDate = dtFromDate.Text;
            string toDate = dtToDate.Text;
            List<DateTime> dates = new List<DateTime>();
            DateTime startingDate = endDate;
            int dayDiff = Convert.ToInt32((endDate - startDate).TotalDays) + 1;
            int count = 0;
            while (dates.Count <= count)
            {
                if (dayDiff > count)
                {
                    if (startingDate.DayOfWeek != DayOfWeek.Friday)
                    {
                        if (startingDate > startDate || startingDate < startDate)
                        {
                            dates.Insert(0, startingDate);

                        }
                    }
                    if (startingDate > startDate)
                    {
                        startingDate = startingDate.AddDays(-1);
                    }
                    count++;
                }

            }
            int Count_InList = dates.Count;



        }//

        private void gvSpecific_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSpecific.SelectedCells.Count > 0)
            {
                try
                {
                    if (e.ColumnIndex >= 0)
                    {
                        int machine_id = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["machine_id"].Value);
                        int capacity = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["capacity"].Value);
                        //int used = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["UsedLot"].Value);
                        int ctg_lot = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["ctg_lot"].Value);
                        int dhk_lot = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["dhk_lot"].Value);
                        int int_lot = Convert.ToInt32(gvSpecific.Rows[e.RowIndex].Cells["int_lot"].Value);
                        int Total_lot = ctg_lot + dhk_lot + int_lot;
                        //int DueLot = capacity - used;
                        if (Total_lot > capacity)
                        {
                            gvSpecific.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            MessageBox.Show("Lot capacity exceed..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                catch { }


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                if (Unit == 0)
                {
                    MessageBox.Show("Select Unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string Type = cmbSpecific.Text;
                if (Type == "Select")
                {
                    MessageBox.Show("Select Type Periodic / Specific..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Type == "Periodic")
                {
                    gvData.Visible = true;
                    gvSpecific.Visible = false;
                    Bind_DataLoad();
                }
                else if (Type == "Specific")
                {
                    gvSpecific.Visible = true;
                    gvData.Visible = false;

                    Bind_Specific_DataLoad();
                }
                else
                {
                    gvSpecific.Visible = false;
                    gvData.Visible = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        ///

    }
}
