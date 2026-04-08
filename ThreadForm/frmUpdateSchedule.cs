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
    public partial class frmUpdateSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;
        public int allocated_machine_id = 0;
        public frmUpdateSchedule()
        {
            InitializeComponent();
        }

        private void frmUpdateSchedule_Load(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());

            dtTransferDate.Format = DateTimePickerFormat.Custom;
            dtTransferDate.CustomFormat = "dd-MM-yyyy";
            dtTransferDate.Value = DateTime.Now.AddDays(1);
            dtTransferDate.MinDate = DateTime.Now.AddDays(1);

            dtgridJob.Rows.Clear();
            dtgridJob.Visible = false;
            chkAll.Visible = false;
            txtJobNo.Focus();
            InitialDataGrid();
            dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND ISNULL(IsPlan,0)=0 GROUP BY OrderId");
            //dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '0'");

            dbConCrUser.FillComboBox_SingleColumn(cmbShade, @"SELECT DISTINCT shade FROM dbo.thread_schedule WHERE OrderId='" + txtJobNo.Text.Trim() + "' AND ISNULL(IsPlan,0)=0");

        }

        private void InitialDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;
                //this.gvData.EnableHeadersVisualStyles = false;
                //this.gvData.ColumnHeadersHeight = 50;

                // this.gvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                checkColumn2.Name = "X";
                checkColumn2.HeaderText = "";
                checkColumn2.Width = 30;
                checkColumn2.ReadOnly = false;
                checkColumn2.FillWeight = 10;
                gvListData.Columns.Add(checkColumn2);

                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("shade", "Shade");
                gvListData.Columns.Add("machine_name", "Machine");
                gvListData.Columns.Add("schedule_date", "Date");
                gvListData.Columns.Add("schedule_qty", "QTY");

                gvListData.Columns["ProductName"].Width = 180;
                gvListData.Columns["machine_name"].Width = 80;
                //gvListData.Columns["shade"].Width = 100;
                gvListData.Columns["schedule_date"].Width = 100;
                gvListData.Columns["schedule_qty"].Width = 100;


                gvListData.Columns["machine_name"].ReadOnly = true;
                gvListData.Columns["shade"].ReadOnly = true;
                gvListData.Columns["ProductName"].ReadOnly = true;
                gvListData.Columns["schedule_date"].ReadOnly = true;
                gvListData.Columns["schedule_qty"].ReadOnly = true;

                gvListData.Columns.Add("Schedule_Id", "Schedule_Id");
                gvListData.Columns.Add("product_id", "product_id");
                //gvListData.Columns.Add("booking_id", "booking_id");
                gvListData.Columns.Add("booking_sub_id", "booking_sub_id");
                gvListData.Columns.Add("machine_id", "machine_id");
                gvListData.Columns.Add("per_lot_cone", "per_lot_cone");
                gvListData.Columns.Add("cone_per_pack", "cone_per_pack");

                gvListData.Columns["Schedule_Id"].Visible = false;
                gvListData.Columns["product_id"].Visible = false;
                //gvListData.Columns["booking_id"].Visible = false;
                gvListData.Columns["booking_sub_id"].Visible = false;
                gvListData.Columns["machine_id"].Visible = false;
                gvListData.Columns["cone_per_pack"].Visible = false;
                gvListData.Columns["per_lot_cone"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);
                //this.gvData.DefaultCellStyle.SelectionBackColor = this.gvData.DefaultCellStyle.BackColor;

                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                gvListData.ColumnHeadersHeight = 40;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        public void Bind_DataLoad()
        {
            SqlDataReader dr;
            try
            {

                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;
                string OrderId = txtJobNo.Text.Trim();
                string SchDate = cmbSchDate.SelectedValue.ToString();
                string Shade = cmbShade.Text.ToString();
                int machine_id = Convert.ToInt32(cmbMachine.SelectedValue.ToString());

                if (OrderId == "")
                {
                    MessageBox.Show("Enter Job..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Shade == "")
                {
                    MessageBox.Show("Select Shade..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Job_SchUpdateGV_Proc '" + OrderId + "','" + SchDate + "','"+ Shade + "','" + machine_id + "'");

                chkAll.Visible = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
                    gvListData.Rows[rowAdd].Cells["shade"].Value = dr["shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = dr["schedule_qty"].ToString();

                    gvListData.Rows[rowAdd].Cells["Schedule_Id"].Value = dr["Schedule_Id"].ToString();
                    gvListData.Rows[rowAdd].Cells["product_id"].Value = dr["product_id"].ToString();
                    //gvListData.Rows[rowAdd].Cells["booking_id"].Value = dr["booking_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["booking_sub_id"].Value = dr["booking_sub_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine_id"].Value = dr["machine_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["cone_per_pack"].Value = dr["cone_per_pack"].ToString();
                    gvListData.Rows[rowAdd].Cells["per_lot_cone"].Value = dr["per_lot_cone"].ToString();

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
        public int Get_JobSchedule_Location(string OrderId)
        {
            int id = 0;
            string Shade = cmbShade.Text.Trim();
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 location_id FROM dbo.thread_schedule WHERE OrderId='" + OrderId + "' AND ISNULL(IsPlan,0)=0  AND shade='" + Shade + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    id = Convert.ToInt32(dr["location_id"].ToString());
                }
            }

            dr.Close();
            return id;
        }//
        public int Get_Job_MachineId(string OrderId, string Shade)
        {
            int id = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 machine_id FROM dbo.thread_schedule WHERE OrderId='" + OrderId + "' AND ISNULL(IsPlan,0)=0 AND shade='" + Shade + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    id = Convert.ToInt32(dr["machine_id"].ToString());
                }
            }

            dr.Close();
            return id;
        }//
        public decimal Get_machine_capacityKG(int machine_id)
        {
            decimal max_KG = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT per_lot_pack FROM dbo.thread_machine_master WHERE id='" + machine_id + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    max_KG = Convert.ToDecimal(dr["per_lot_pack"].ToString());
                }
            }

            dr.Close();
            return max_KG;
        }//
        public int Get_Assigned_MchLot_OnSchDate(int machine_id, DateTime SchDate)
        {
            int count = 0;
            int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_AssignedMchLot_OnSchDate_Proc '" + machine_id + "' ,'" + location_id + "','" + SchDate + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    count = Convert.ToInt32(dr["lot_capacity"].ToString());
                }
            }
            dr.Close();
            return count;
        }//
        public int Get_Lot_scheduleId(string lot_no)
        {
            int id = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 s.id FROM dbo.thread_schedule s 
                                LEFT JOIN dbo.thread_lot l ON s.process_id=l.process_id 
                                WHERE  l.lot_no='" + lot_no + "' AND s.schedule_qty < s.per_lot_cone");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    id = Convert.ToInt32(dr["id"].ToString());
                }
            }

            dr.Close();
            return id;
        }//

        public decimal Get_ConePer_Pack(string OrderId, string Shade)
        {
            decimal ConePer_pack = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 cone_per_pack FROM dbo.thread_schedule WHERE OrderId='" + OrderId + "' AND shade='" + Shade + "' AND ISNULL(IsPlan,0)=0");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    ConePer_pack = Convert.ToInt32(dr["cone_per_pack"].ToString());
                }
            }

            dr.Close();
            return ConePer_pack;
        }//
        public int Check_IsSelected()
        {
            int count = 0;
            bool checkBoxStatus = false;
            try
            {

                for (int i = 0; i <= gvListData.Rows.Count; i++)
                {
                    if (gvListData.Rows[i].Cells["X"].Value == null)
                    {
                        checkBoxStatus = false;
                    }
                    else
                    {
                        checkBoxStatus = Convert.ToBoolean((gvListData.Rows[i].Cells["X"].Value).ToString());
                    }

                    if (checkBoxStatus)
                    {
                        count++;
                    }
                }//for
            }
            catch { }

            return count;
        }//

        private void txtJobNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgridJob.Focus();
            }
        }

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dtgridJob.Visible = false;
            }
        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJobNo.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgridJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgridJob.Visible = true;
                        dataView.RowFilter = "[" + dtgridJob.Columns[0].Name + "] LIKE '%" + txtJobNo.Text.Trim() + "%'";

                    }

                    foreach (DataGridViewColumn column in dtgridJob.Columns)
                    {
                        if (column.Name != "OrderId")
                            column.Visible = false;
                    }


                    dtgridJob.RowHeadersVisible = false;

                    dtgridJob.Columns["OrderId"].Visible = true;

                    //// Set the column header text
                    dtgridJob.Columns["OrderId"].HeaderText = " Job No.";
                    //dtgridJob.Columns["OrderId"].ReadOnly = true;
                    dtgridJob.Columns["OrderId"].Width = 200;
                    dtgridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    dtgridJob.ColumnHeadersHeight = 60;
                    dtgridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                    //int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
                    //dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '" + location_id + "'");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        private void txtJobNo_Enter(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                string OrderNo = txtJobNo.Text.Trim();
                if (OrderNo != "")
                {
                    //Bind_DataLoad();
                    dbConCrUser.FillComboBox_SingleColumn(cmbSchDate, @"SELECT 'Select' AS schedule_date 
                                                           UNION ALL
                                                           SELECT DISTINCT CONVERT(NVARCHAR(20),schedule_date,105) schedule_date
                                                           FROM dbo.thread_schedule WHERE OrderId='" + OrderNo + "' AND  ISNULL(IsPlan,0)=0 AND Unit='" + Unit + "'");


                    dtgridJob.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Select_JobGrid_ToTextfield()
        {
            if (dtgridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgridJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJobNo.Text = cellValue.ToString();
                    dtgridJob.Visible = false;
                }
                txtJobNo.Focus();

                dbConCrUser.FillComboBox_SingleColumn(cmbShade, @"SELECT DISTINCT shade FROM dbo.thread_schedule WHERE OrderId='" + txtJobNo.Text.Trim() + "' AND ISNULL(IsPlan,0)=0");
                //int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
                //dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '" + location_id + "'");

            }
        }//

        private void dtgridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextfield();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                //int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
                //dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '" + location_id + "'");

                Bind_DataLoad();

                // int machine_id = Get_Job_MachineId(txtJobNo.Text.Trim(), txtShade.Text.Trim());
                //cmbMachine.SelectedValue = machine_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void clearfield()
        {

            dtTransferDate.Format = DateTimePickerFormat.Custom;
            dtTransferDate.CustomFormat = "dd-MM-yyyy";
            dtTransferDate.Value = DateTime.Now.AddDays(1);
            dtTransferDate.MinDate = DateTime.Now.AddDays(1);

            txtJobNo.Text = "";
            cmbSchDate.SelectedIndex = 0;
            cmbMachine.SelectedIndex = 0;
            cmbShade.DataSource= null;
            gvListData.Rows.Clear();
            dtgridJob.Visible = false;
            chkAll.Visible = false;
        }//

        public int Get_ScheduleDate_OnOff(string SchDate)
        {
            int count = 0;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.Schedule_OnOff WHERE Unit='"+ Unit + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + SchDate + "' AND sch_status='OFF'");
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
        public int Check_IsAssigned_MchLot_OnSchDate(int machine_id, string schedule_date)
        {
            int count = 0;
            int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.machine_capacity WHERE machine_id='" + machine_id + "' AND schedule_date='" + schedule_date + "' AND location_id='" + location_id + "'");

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
        public int Get_Assigned_MchLot_OnSchDate(string SchDate)
        {
            int count = 0;
            SqlDataReader dr;
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
            int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
            if (location_id == 1) // CTG
            {
                dr = dbConCrUser.DBRetrieveFunction("SELECT capacity_ctg AS lot_capacity FROM dbo.machine_capacity WHERE machine_id='" + machine_id + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + SchDate + "' AND location_id=1");
            }
            if(location_id == 2)// Dhaka
            {
                dr = dbConCrUser.DBRetrieveFunction("SELECT capacity_dhk AS lot_capacity FROM dbo.machine_capacity WHERE machine_id='" + machine_id + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + SchDate + "' AND location_id=2");
            }
            else // Internal
            {
                dr = dbConCrUser.DBRetrieveFunction("SELECT capacity_internal AS lot_capacity FROM dbo.machine_capacity WHERE machine_id='" + machine_id + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + SchDate + "' AND location_id=3");
            }

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    count = Convert.ToInt32(dr["lot_capacity"].ToString());
                }
            }
            dr.Close();
            return count;
        }//
        public int Check_Machine_LotExceed(string Shade, decimal mch_maxKG, string SchDate, decimal sumQTY_fullday)
        {
            int count = 0;
            int UsedLot = 0;
            int mch_lot = 0;
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
            int location_id = Get_JobSchedule_Location(txtJobNo.Text.Trim());
            string OrderId = txtJobNo.Text.Trim();

            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT ISNULL(count(lot_no),0) used_lot FROM dbo.thread_lot WHERE machine_id = '" + machine_id + "' AND  CONVERT(NVARCHAR(20),schedule_date,105) = '" + SchDate + "' AND location_id='" + location_id + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    UsedLot = Convert.ToInt32(dr["used_lot"].ToString());
                }
            }
            dr.Close();

            mch_lot = Get_Assigned_MchLot_OnSchDate(SchDate);
            decimal conePerPack = Get_ConePer_Pack(OrderId, Shade);


            int DueLot = mch_lot - UsedLot;
            decimal ConeCapacity_PerLot = Math.Round(mch_maxKG * conePerPack); // suppose 20kg * 10 cone = 200 cone
            decimal TotalConeCapacity_FullDay = ConeCapacity_PerLot * DueLot; // suppose due 5 lot. 200*5=1000 cone
            if (sumQTY_fullday > TotalConeCapacity_FullDay) // 200>400
            {
                count = 1;
            }
            return count;
        }//

        public int Check_IsBlock_Machine()
        {
            int count = 0;
            int MachineId = 0;
            if (cmbMachine.Text != "Select" || cmbMachine.Text != "")
            {
                try
                {
                    MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                }
                catch { }

            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.block_machine WHERE machine_id='" + MachineId + "'");

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
        public decimal Get_MachineCapacity_KG(int MachineId)
        {
            decimal mch_kg = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT per_lot_pack FROM thread_machine_master WHERE machine_type = 'DY' AND is_active = 1 AND id='" + MachineId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    mch_kg = Convert.ToDecimal(dr["per_lot_pack"].ToString());
                }
            }

            dr.Close();
            return mch_kg;
        }//
        public decimal Check_Sum_TotalSchQTY()
        {
            decimal Total_Sum = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                bool checkBoxStatus = false;
                if (c >= 0)
                {
                    try
                    {
                        if (gvListData.Rows[c].Cells["X"].Value == null)
                        {
                            checkBoxStatus = false;
                        }
                        else
                        {
                            checkBoxStatus = Convert.ToBoolean((gvListData.Rows[c].Cells["X"].Value).ToString());
                        }

                    }
                    catch { }
                    if (checkBoxStatus)
                    {
                        decimal SchQTY = Convert.ToDecimal(gvListData.Rows[c].Cells["used_cone"].Value.ToString());
                        Total_Sum += SchQTY;
                    }

                }

            }// for
            return Total_Sum;
        }//
        public decimal Sum_Total_Pack()
        {
            decimal Total_PackKG = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                bool checkBoxStatus = false;
                if (c >= 0)
                {
                    try
                    {
                        if (gvListData.Rows[c].Cells["X"].Value == null)
                        {
                            checkBoxStatus = false;
                        }
                        else
                        {
                            checkBoxStatus = Convert.ToBoolean((gvListData.Rows[c].Cells["X"].Value).ToString());
                        }

                    }
                    catch { }
                    if (checkBoxStatus)
                    {
                        decimal cone_per_pack = Convert.ToDecimal(gvListData.Rows[c].Cells["cone_per_pack"].Value.ToString());
                        decimal SchQTY = Convert.ToDecimal(gvListData.Rows[c].Cells["schedule_qty"].Value.ToString());
                        Total_PackKG += decimal.Round(SchQTY / cone_per_pack, 2);
                    }

                }

            }// for
            return Total_PackKG;
        }//
        public string Get_ScheduleNo(string SchDate)
        {
            string SCNO = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Generate_ScheduleNo_Proc '" + SchDate + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    SCNO = dr["SCNO"].ToString();
                }
            }

            dr.Close();
            return SCNO;
        }//
        public string Get_LotNo(string SchDate, int machineId)
        {
            string LOTNO = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Generate_LotNo_Proc '" + SchDate + "','" + machineId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    LOTNO = dr["LOTNO"].ToString();
                }
            }

            dr.Close();
            return LOTNO;
        }//


        public int Get_UsedLot(string ScheduleDate)
        {
            int UsedLot = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) used_lot FROM dbo.thread_lot WHERE machine_id = '" + cmbMachine.SelectedValue + "' AND  schedule_date = '" + ScheduleDate + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    UsedLot = Convert.ToInt32(dr["used_lot"].ToString());
                }
            }

            dr.Close();
            return UsedLot;
        }//
        public int Check_IsLotExist_ForSchedule(int schedule_id)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT COUNT(*) cnt FROM dbo.thread_lot WHERE schedule_id='" + schedule_id + "'");

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
        public void Transfer_Schedule()
        {
            try
            {
                string EntryBy = frmLogin.UserID.ToString();
                //string EntryBy = "arif";

                string OrderId = txtJobNo.Text.Trim();
                string transfer_date = dtTransferDate.Value.ToString();
                DateTime sch_date_formated = dtTransferDate.Value;

                bool checkBoxStatus = false;
                //DateTime sch_date_formated = dtTransferDate.Value;
                int gridRow = 0;
                int count = 0;
                gridRow = gvListData.Rows.Count;
                for (int i = 0; i < gridRow; i++)
                {
                    try
                    {
                        if (gvListData.Rows[i].Cells["X"].Value == null)
                        {
                            checkBoxStatus = false;
                        }
                        else
                        {
                            checkBoxStatus = Convert.ToBoolean((gvListData.Rows[i].Cells["X"].Value).ToString());
                        }

                    }
                    catch { }
                    if (checkBoxStatus)
                    {
                        int schedule_id = Convert.ToInt32(gvListData.Rows[i].Cells["Schedule_Id"].Value.ToString());
                        int machine_id = Convert.ToInt32(gvListData.Rows[i].Cells["machine_id"].Value.ToString());

                        // schedule table update
                        string[] Cols = { "schedule_date", "entry_by", "entry_date" };
                        string[] Vals = { sch_date_formated.ToString(), EntryBy, DateTime.UtcNow.ToString() };
                        string[] WhCols = { "id" };
                        string[] WhVals = { schedule_id.ToString() };
                        string sql_schedule = dbConCrUser.CreateSQLStatement("thread_schedule", Cols, Vals, "UPDATE", WhCols, WhVals);
                        dbConCrUser.DBExecuteScalarWithSQL(sql_schedule);

                        ////// lot create --- 
                        //string[] pName = { "@machine_id", "@schedule_id", "@sch_date" };
                        //string[] pVal = { machine_id.ToString(), schedule_id.ToString(), sch_date_formated.ToString() };
                        //dbConCrUser.DBInsertUsingSP(@"T_Transfer_JobSchedule_Proc", pName, pVal);
                        dbConCrUser.DBExecuteScalarWithSQL(@"EXEC T_Transfer_JobSchedule_Proc '" + machine_id + "','" + schedule_id + "','" + sch_date_formated + "'");

                        count++;

                    }
                }// for

                if(count > 0)
                {
                    clearfield();
                    //Bind_DataLoad();
                    MessageBox.Show("Transfer Successfully.", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            
            try
            {
                int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
                if (Check_IsSelected() == 0)
                {
                    MessageBox.Show("Select minimum one..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (machine_id == 0)
                {
                    MessageBox.Show("Select machine..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal mch_kg = Get_MachineCapacity_KG(machine_id);
                string transfer_date = dtTransferDate.Value.ToString();
                DateTime sch_date_formated = dtTransferDate.Value;

                if (Get_ScheduleDate_OnOff(transfer_date) > 0)
                {
                    MessageBox.Show("Schedule day off on " + dtTransferDate.Text + " date..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Check_IsAssigned_MchLot_OnSchDate(machine_id, transfer_date) == 0)
                {
                    MessageBox.Show(" '" + cmbMachine.Text + "' machine lot capacity not allocated for this [" + dtTransferDate.Text + "] date..!! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal TotalPack = Sum_Total_Pack();
                decimal Assign_Lot = Get_Assigned_MchLot_OnSchDate(machine_id, sch_date_formated);
                decimal max_kg_produce = Assign_Lot * mch_kg; // 8*5=40kg
                if (TotalPack > max_kg_produce) // 25>40
                {
                    MessageBox.Show(" '" + cmbMachine.Text + "' machine capacity exceed..!! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure to transfer.??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Transfer_Schedule();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void chkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvListData.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["X"] as DataGridViewCheckBoxCell);
                checkBox.Value = chkAll.Checked;
            }
        }

        private void cmbSchDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = txtJobNo.Text.Trim();
            string Schedule_Date = cmbSchDate.SelectedValue.ToString();
            if (OrderNo != "" && Schedule_Date != "")
            {
                dbConCrUser.FillComboBox(cmbMachine, @"SELECT 0 AS machine_id,'Select' machine_name 
                                                        UNION ALL
                                                        SELECT DISTINCT machine_id,RTRIM(m.machine_name) machine_name
                                                        FROM dbo.thread_schedule s
                                                        LEFT JOIN dbo.thread_machine_master m ON s.machine_id=m.id
                                                        WHERE OrderId='" + OrderNo + "' AND CONVERT(NVARCHAR(20),schedule_date,105)='" + Schedule_Date + "' AND  ISNULL(IsPlan,0)=0");

            }
        }//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearfield();
        }

      
    }
}
