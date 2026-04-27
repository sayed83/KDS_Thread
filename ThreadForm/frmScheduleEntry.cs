using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization.Configuration;

namespace KDS_Thread.ThreadForm
{
    public partial class frmScheduleEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkEmergencyClm = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        //GridDateControl SchDate = new GridDateControl();
        DataGridViewImageColumn removeBtn = new DataGridViewImageColumn();

        public frmScheduleEntry()
        {
            InitializeComponent();
        }
        public string strDay = "";
        private int flgEventCheck = 1, totDateCol = 0;
        public int searchId = 0;
        public string nameValue = "";
        public string CountGroup_glb = "";
        private int rowAdd = 0;
        private void frmScheduleEntry_Load(object sender, EventArgs e)
        {
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.TopMost = true;
            chkUnitCTG.Checked = false;
            chkUnitDhaka.Checked = false;
            cmbFamily.SelectedItem = "N/A";
            cmbFamily.Enabled = false;
            int UnitId = Convert.ToInt32(frmLogin.UserLocation.ToString());
            if (UnitId == 1) // 1= CTG, 2=Dhaka
            {
                chkUnitCTG.Checked = true;
                chkUnitDhaka.Checked = false;
            }
            else
            {
                chkUnitCTG.Checked = false;
                chkUnitDhaka.Checked = true;
            }

            dataGridViewShade.Visible = false;
            dgvSearchResult.Visible = false;
            dtgvColor.Visible = false;


            InitDataGrid();
            dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '0'");

            dbConCrUser.FillDataGridView(dataGridViewShade, @"EXEC proc_get_shade '" + UnitId + "'");
            dbConCrUser.FillDataGridView(dgvSearchResult, @"EXEC proc_get_booking_no '" + UnitId + "'");
            //dbConCrUser.FillDataGridView(dgvSearchResult, @"EXEC T_Get_Job_ByShade_Proc '" + UnitId + "','" + txtShade.Text.Trim() + "'");
            dbConCrUser.FillDataGridView(dtgvColor, @"EXEC T_Get_Color_Proc '" + UnitId + "','" + txtJob.Text.Trim() + "'");

            //dbConCrUser.FillComboBox(cmbCount, @"SELECT * FROM vw_count ORDER BY id");
            dbConCrUser.FillComboBox(cmbCount, @"T_Get_Count_Proc");
            dbConCrUser.FillComboBox(cmbBrand, @"EXEC T_Get_BrandList_Proc");
            dbConCrUser.FillComboBox(cmbOrdLocation, @"EXEC T_Get_LocationList_Proc");


            //cmbCustomer.DataSource = ds.Tables[1];
            //cmbCustomer.DisplayMember = "TypeName";
            //cmbCustomer.ValueMember = "TypeID";



            cmbOrdLocation.SelectedValue = UnitId;
            //cmbOrdLocation.SelectedItem = "Select";

            dtSchDate.Format = DateTimePickerFormat.Custom;
            dtSchDate.CustomFormat = "dd-MMM-yyyy";
            dtSchDate.Value = DateTime.Now.AddDays(1);
            dtSchDate.MinDate = DateTime.Now.AddDays(1);

            //this.gvListData.DefaultCellStyle.SelectionBackColor = this.gvListData.DefaultCellStyle.BackColor;
            //cmbSearch.SelectedValue = 4; // Shade
            //lblSearchFilter.Text = "Search";


            //Generate_UsedLotDataGrid();
            ///Get_Lot_Capacity_UsedDataLoad();

            //Generate_ScheduledQTY_DataGrid();
            //Get_ScheduledQTY_Data();

            if (chkUnitCTG.Checked == true)
            {
                dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '1'");
            }
            if (chkUnitDhaka.Checked == true)
            {
                dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '2'");
            }

            if(Is_NotSamePage == 1)
            {
                string Brand = Select_BrandByShade();
                cmbBrand.SelectedValue = Get_BrandId(Brand);
                txtShade.Enabled = false;
                txtJob.Enabled = false;
            }

        }//
        private void InitDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                //gvListData.Rows.Clear();
                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;

                //================================= Second DataGrid View ===========================
                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeight = 50;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                //removeBtn.Image = Properties.Resources.delete;
                //removeBtn.HeaderText = "Remove";
                //removeBtn.Name = "remove";
                //gvListData.Columns.Add(removeBtn);
                //gvListData.Columns["remove"].Width = 50;

                checkColumn2.Name = "X";
                checkColumn2.HeaderText = "";
                checkColumn2.Width = 30;
                checkColumn2.ReadOnly = false;
                checkColumn2.FillWeight = 10;
                gvListData.Columns.Add(checkColumn2);

                gvListData.Columns.Add("BookingNo", "Booking No");
                gvListData.Columns.Add("Customer", "Customer");

                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("ConePerPack", "Cone Pack");
                gvListData.Columns.Add("PerLotCone", "PerLot Qty");
                gvListData.Columns.Add("BookingQty", "Booking Qty");
                //gvListData.Columns.Add("ScheduledQty", "Sch. Qty");
                gvListData.Columns.Add("BalQty", "Balance Qty");
                gvListData.Columns.Add("PKG", "PKG");
                gvListData.Columns.Add("QTY", "QTY");
                //gvListData.Columns.Add("NetWeightKG", "QTY. KG");
                checkEmergencyClm.Name = "chkUrgent";
                checkEmergencyClm.HeaderText = "Urgent";
                checkEmergencyClm.Width = 50;
                checkEmergencyClm.ReadOnly = true;
                checkEmergencyClm.FillWeight = 10;
                gvListData.Columns.Add(checkEmergencyClm);

                //gvListData.Columns.Add("RemainingPack", "Pack Bal.");
                //gvListData.Columns.Add("SchQty", "Schedule Qty.");

                gvListData.Columns["BookingNo"].Width = 120;
                gvListData.Columns["Customer"].Width = 120;
                gvListData.Columns["ProductName"].Width = 180;
                gvListData.Columns["Color"].Width = 100;
               // gvListData.Columns["Shade"].Width = 80;
                gvListData.Columns["ConePerPack"].Width = 50;
                gvListData.Columns["PerLotCone"].Width = 50;
                gvListData.Columns["BookingQty"].Width = 70;
                //gvListData.Columns["ScheduledQty"].Width = 50;
                gvListData.Columns["BalQty"].Width = 70;
                gvListData.Columns["PKG"].Width = 50;
                gvListData.Columns["QTY"].Width = 70;

                // gvListData.Columns["Rep"].Width = 140;

                //gvListData.Columns["SchQty"].Width = 50;


                gvListData.Columns["BookingNo"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["ProductName"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["Shade"].Visible = false;
                gvListData.Columns["ConePerPack"].ReadOnly = true;
                gvListData.Columns["PerLotCone"].ReadOnly = true;
                gvListData.Columns["BookingQty"].ReadOnly = true;
                //gvListData.Columns["ScheduledQty"].ReadOnly = true;
                gvListData.Columns["BalQty"].ReadOnly = true;
                gvListData.Columns["PKG"].ReadOnly = true;
                //gvListData.Columns["NetWeightKG"].ReadOnly = true;

                // gvListData.Columns["SchQty"].ReadOnly = false;




                //gvListData.Columns["BookingQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //gvListData.Columns["ScheduledQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //gvListData.Columns["BalQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                ///===================== Invisible columns ======================\\\\\\\\
                gvListData.Columns.Add("BookingId", "BookingId");
                gvListData.Columns["BookingId"].Visible = false;

                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false;

                gvListData.Columns.Add("ProductId", "ProductId");
                gvListData.Columns["ProductId"].Visible = false;

                gvListData.Columns.Add("CountGroup", "CountGroup");
                gvListData.Columns["CountGroup"].Visible = false;

                gvListData.Columns.Add("RepID", "RepID");
                gvListData.Columns["RepID"].Visible = false;

                gvListData.Columns.Add("CusID", "CusID");
                gvListData.Columns["CusID"].Visible = false;


                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);

                //gvListData.Columns["QTY"].DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                //gvListData.Columns["QTY"].DefaultCellStyle.BackColor = Color.HotPink;
                //gvListData.Columns["QTY"].ReadOnly = false;
                //gvListData.Columns["chkUrgent"].ReadOnly = false;


                ////============================= End Grid =========================\\\\\

                //prcSetDateColumn();
                //Generate_DayForDataListGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        private void Get_GridDataLoad()
        {
            SqlDataReader dr;
            try
            {
                
                int MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                //int LocationId = 0;
                int OrdLocation_Id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                //if (chkUnitCTG.Checked == true) { LocationId = 1; }
                //if (chkUnitDhaka.Checked == true) { LocationId = 2; }

                string Shade = txtShade.Text.Trim();
                string color = txtColor.Text.Trim();
                string OrderNo = txtJob.Text.Trim();
                string Count = cmbCount.Text.Trim();
                string Brand = cmbBrand.Text.Trim();
                string FamilyGroup = cmbFamily.Text.Trim();
                //string OrderLocation = cmbOrdLocation.Text.Trim();


                int CommId = 1;
                int IsFamily = 0;
                if (chkFamily.Checked == true)
                {
                    IsFamily = 1;
                    CommId = 2;
                }



                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_ScheduleDataLoad_Proc '" + MachineId + "','" + OrdLocation_Id + "','" + Shade + "' ,'" + OrderNo + "','" + Count + "','" + FamilyGroup + "','" + Brand + "','" + color + "','" + CommId + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();


                    gvListData.Rows[rowAdd].Cells["BookingNo"].Value = dr["BookingNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();

                    gvListData.Rows[rowAdd].Cells["BookingQty"].Value = Convert.ToInt32(dr["BookingQty"]);
                    gvListData.Rows[rowAdd].Cells["BalQty"].Value = Convert.ToInt32(dr["BalQty"]);
                    gvListData.Rows[rowAdd].Cells["ConePerPack"].Value = dr["ConePerPack"].ToString();
                    gvListData.Rows[rowAdd].Cells["PerLotCone"].Value = dr["PerLotCone"].ToString();
                    
                    gvListData.Rows[rowAdd].Cells["PKG"].Value = dr["PKG"].ToString();

                    // visible false
                    gvListData.Rows[rowAdd].Cells["BookingId"].Value = dr["BookingId"].ToString();
                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    gvListData.Rows[rowAdd].Cells["CountGroup"].Value = dr["CountGroup"].ToString();
                    gvListData.Rows[rowAdd].Cells["RepID"].Value = dr["RepID"].ToString();
                    gvListData.Rows[rowAdd].Cells["CusID"].Value = dr["CusID"].ToString();


                    rowAdd++;

                    //gvListData.Rows[rowAdd].Cells["QTY"].Style.BackColor = Color.LightGreen;
                    //gvListData.Rows[rowAdd].Cells["QTY"].Style.Font = new Font("Calibri", 9F, FontStyle.Bold);
                    //foreach (DataGridViewColumn c in gvListData.Columns)
                    //{
                    //    c.DefaultCellStyle.Font = new Font("Arial", 8.5F, GraphicsUnit.Pixel);
                    //}


                }
                //prcSetDateColumn();
                dr.Close();

                //gvListData.Rows.Add(1);
                //gvListData[8, gvListData.Rows.Count - 1].Value = "Total";
                //gvListData[8, gvListData.Rows.Count - 1].Style.ForeColor = Color.Blue;
                //if (gvListData[8, gvListData.Rows.Count - 1].Value == "Total")
                //{
                //    gvListData[0, gvListData.Rows.Count - 1].ReadOnly = true;
                //}

                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public int Get_ScheduleDate_OnOff(string SchDate)
        {
            int count = 0;
            int Unit = 1;
            if(chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.Schedule_OnOff WHERE Unit='"+ Unit + "' AND schedule_date='" + SchDate + "' AND sch_status='OFF'");
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

        //------------ Start Lot capacity & Used lot grid data
        private void Generate_UsedLotDataGrid()
        {
            try
            {

                dgvLotCapacityDetails.Rows.Clear();
                dgvLotCapacityDetails.Columns.Clear();
                dgvLotCapacityDetails.AutoGenerateColumns = false;
                dgvLotCapacityDetails.Columns.Add("machine_name", "Machine");
                dgvLotCapacityDetails.Columns.Add("lot_capacity", "Capacity");
                dgvLotCapacityDetails.Columns.Add("used_lot", "Used");

                dgvLotCapacityDetails.Columns["machine_name"].Width = 100;
                dgvLotCapacityDetails.Columns["lot_capacity"].Width = 80;
                dgvLotCapacityDetails.Columns["used_lot"].Width = 80;
                DateTime SchDate = dtSchDate.Value;

                //string displayName = SchDate.ToString("dd-MMM");
                string columnName = SchDate.ToString("yyyy-MM-dd");
                //dgvLotCapacityDetails.Columns.Add(columnName, displayName);

                if (Get_ScheduleDate_OnOff(columnName) > 0)
                {
                    MessageBox.Show("Schedule off on this " + columnName + " day..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvLotCapacityDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvLotCapacityDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Get_Lot_Capacity_UsedDataLoad()
        {
            SqlDataReader dr;
            try
            {

                dgvLotCapacityDetails.Rows.Clear();
                dgvLotCapacityDetails.AllowUserToAddRows = false;

                DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
                int UnitId = 0;
                if (chkUnitCTG.Checked == true) { UnitId = 1; }
                if (chkUnitDhaka.Checked == true) { UnitId = 2; }

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_UnitMachine_UsedLotGv_Proc '" + UnitId + "','" + SchDate + "'");

                rowAdd = dgvLotCapacityDetails.Rows.Count;
                while (dr.Read())
                {
                    dgvLotCapacityDetails.Rows.Add();

                    dgvLotCapacityDetails.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
                    dgvLotCapacityDetails.Rows[rowAdd].Cells["lot_capacity"].Value = dr["lot_capacity"].ToString();
                    dgvLotCapacityDetails.Rows[rowAdd].Cells["used_lot"].Value = dr["used_lot"].ToString();

                    rowAdd++;
                }
                for (int i = 0; i < dgvLotCapacityDetails.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        dgvLotCapacityDetails.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    }

                }
               
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        //private void Get_Lot_Capacity_UsedDataLoad()
        //{
        //    SqlDataReader dr;
        //    dgvLotCapacityDetails.Rows.Clear();
        //    try
        //    {
        //        DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
        //        //string columnName = SchDate.ToString("yyyy-MM-dd");

        //        //int MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
        //        //DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
        //        int UnitId = 0;
        //        if (chkUnitCTG.Checked == true) { UnitId = 1; }
        //        if (chkUnitDhaka.Checked == true) { UnitId = 2; }

        //        dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_UnitMachine_UsedLotGv_Proc '" + UnitId + "','" + SchDate + "'");
        //        rowAdd = dgvLotCapacityDetails.Rows.Count;
        //        while (dr.Read())
        //        {
        //            dgvLotCapacityDetails.Rows.Add();
        //            dgvLotCapacityDetails.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
        //            dgvLotCapacityDetails.Rows[rowAdd].Cells["lot_capacity"].Value = dr["lot_capacity"].ToString();
        //            dgvLotCapacityDetails.Rows[rowAdd].Cells["used_lot"].Value = dr["used_lot"].ToString();

        //            rowAdd++;
        //        }
        //        for (int i = 0; i < dgvLotCapacityDetails.Rows.Count; i++)
        //        {
        //            if (i % 2 == 0)
        //            {
        //                dgvLotCapacityDetails.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
        //            }

        //        }
        //        dr.Close();
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}//
        private void dgvLotCapacityDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvLotCapacityDetails.ClearSelection();
        }

        public void Get_Machine_Lot_KG()
        {
            SqlDataReader dtRdr;
            int MachineId = 0;
            try
            {
                if (cmbMachine.Text != "Select" || cmbMachine.Text != "")
                {
                    try
                    {
                        MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                    }
                    catch { }

                }

                SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Machine_Lot_KG_Proc '" + MachineId + "' ");

                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        //txtMchLotC.Text = dr["lot_per_day"].ToString();
                        txtMchKG.Text = dr["per_lot_pack"].ToString();
                        //txtMinKG.Text = dr["minimum_pack"].ToString();
                        txtMinKG.Text = "0.1";
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        //private void Generate_ScheduledQTY_DataGrid()
        //{
        //    try
        //    {

        //        gvListDayLotQty.Columns.Clear();
        //        gvListDayLotQty.Rows.Clear();
        //        gvListDayLotQty.AutoGenerateColumns = false;

        //        //this.gvListData.EnableHeadersVisualStyles = false;
        //        //this.gvListData.ColumnHeadersHeight = 30;
        //        //gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

        //        gvListDayLotQty.Columns.Add("SchQTY", "Scheduled QTY");

        //        gvListDayLotQty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //        this.gvListDayLotQty.EnableHeadersVisualStyles = false;
        //        this.gvListDayLotQty.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //        gvListDayLotQty.ColumnHeadersHeight = 30;
        //        gvListDayLotQty.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}//
        //private void Get_ScheduledQTY_Data()
        //{
        //    SqlDataReader dr;
        //    gvListDayLotQty.Rows.Clear();
        //    try
        //    {
        //        DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
        //        int UnitId = 0;
        //        if (chkUnitCTG.Checked == true) { UnitId = 1; }
        //        if (chkUnitDhaka.Checked == true) { UnitId = 2; }

        //        dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Unit_ScheduledQTY_Proc '" + UnitId + "','" + SchDate + "'");
        //        rowAdd = gvListDayLotQty.Rows.Count;
        //        while (dr.Read())
        //        {
        //            gvListDayLotQty.Rows.Add();
        //            gvListDayLotQty.Rows[rowAdd].Cells["SchQTY"].Value = dr["SchQTY"].ToString();

        //            rowAdd++;
        //        }
        //        dr.Close();


        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void Get_ScheduledQTY_Data()
        {
            SqlDataReader dr;
            try
            {
                DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
                int UnitId = 0;
                if (chkUnitCTG.Checked == true) { UnitId = 1; }
                if (chkUnitDhaka.Checked == true) { UnitId = 2; }

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Unit_ScheduledQTY_Proc '" + UnitId + "','" + SchDate + "'");
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["SchQTY"].ToString()))
                    {
                        lblScheduledQty.Text = dr["SchQTY"].ToString();
                    }
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private int GetLotMaxCapacity(int? machineId)
        {
            decimal lotCapacity = 0;
            if (machineId.HasValue)
            {
                SqlDataReader dr;
                try
                {
                    dr = dbConCrUser.DBRetrieveFunction(@"EXEC proc_CheckPackLimit @machineId = '" + machineId + "'");
                    while (dr.Read())
                    {

                        if (!string.IsNullOrEmpty(dr["max_pack"].ToString()))
                        {
                            lotCapacity = Convert.ToDecimal(dr["max_pack"].ToString());
                        }
                    }

                    dr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Convert.ToInt32(lotCapacity);
        }//
        private int GetLotMinCapacity(int? machineId)
        {
            decimal lotCapacity = 0;
            if (machineId.HasValue)
            {
                SqlDataReader dr;
                try
                {
                    dr = dbConCrUser.DBRetrieveFunction(@"EXEC proc_CheckPackLimit @machineId = '" + machineId + "'");
                    while (dr.Read())
                    {

                        if (!string.IsNullOrEmpty(dr["min_pack"].ToString()))
                        {
                            lotCapacity = Convert.ToDecimal(dr["min_pack"].ToString());
                        }
                    }

                    dr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Convert.ToInt32(lotCapacity);
        }//

      

        //private void SetHolidayDate(string fromDate, string toDate)
        //{
        //    DataTable dataTable = new DataTable();
        //    fromDate = Convert.ToDateTime(dtFromDate.Value).ToString("yyyy-MM-dd");
        //    toDate = Convert.ToDateTime(dtToDate.Value).ToString("yyyy-MM-dd");
        //    drtHoly = dbConCrUser.DBRetrieveFunction(@"Exec prcCheckHR_Holiday '" + fromDate.ToString() + "','" + toDate.ToString() + "'");
        //    dataTable.Load(drtHoly);
        //}
        private void CheckLotCapacityByDate(int machineId, string date, decimal currentPack, out string machineName, out bool isAvailable, out string lotMessage, out string minimumPackMsg)
        {
            lotMessage = "";
            minimumPackMsg = "";
            machineName = "";
            isAvailable = false;
            decimal lotCapacity = 0;
            decimal usedLot = 0;
            decimal minimumPack = 0;
            decimal maximumPack = 0;
            int currentLot = 0;
            SqlDataReader dr;

            try
            {
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC proc_GetThreadLotStats @machineId = '" + machineId + "', @scheduleDate = '" + date + "'");
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["machine_name"].ToString()))
                    {
                        machineName = dr["machine_name"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dr["lot_per_day"].ToString()))
                    {
                        lotCapacity = Convert.ToDecimal(dr["lot_per_day"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["used_lot"].ToString()))
                    {
                        usedLot = Convert.ToDecimal(dr["used_lot"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["min_pack"].ToString()))
                    {
                        minimumPack = Convert.ToDecimal(dr["min_pack"].ToString());
                    }

                    //if (minimumPack > currentPack && cbFixedDate.Checked == false)
                    if (minimumPack > currentPack)
                    {
                        minimumPackMsg = "Current pack is less then minimum pack Qty." + machineName + ",minimum pack is: " + minimumPack;
                    }

                    if (!string.IsNullOrEmpty(dr["max_pack"].ToString()))
                    {
                        maximumPack = Convert.ToDecimal(dr["max_pack"].ToString());
                    }

                    if (!string.IsNullOrEmpty(currentPack.ToString()))
                    {
                        currentLot = (int)Math.Ceiling(currentPack / maximumPack);
                    }

                    var totalLot = currentLot + usedLot;
                    if (currentPack > minimumPack && totalLot <= lotCapacity)
                    {
                        isAvailable = true;
                    }
                    string dateString = date; // Replace this with your actual date string
                    DateTime dateValue = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string formattedDate = dateValue.ToString("dd/MM/yyyy");

                    //if (currentPack > 0 && cbFixedDate.Checked == false)
                    if (currentPack > 0)
                    {
                        lotMessage = "" + machineName + ", can produce " + lotCapacity + " lots/day with maximum package Qty: " + maximumPack + " and Minimum package Qty: " + minimumPack + " " +
                    ", " + usedLot + " lot  already scheduled for " + formattedDate + ", Your current package: " + Math.Round(currentPack, 2) + " and lot is " + Convert.ToInt32(currentLot) + "";
                    }

                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//

        private void dtSchDate_ValueChanged(object sender, EventArgs e)
        {

            //Generate_UsedLotDataGrid();
            Get_Lot_Capacity_UsedDataLoad();

            //Generate_ScheduledQTY_DataGrid();
            Get_ScheduledQTY_Data();
        }

        private void chkUnitCTG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnitCTG.Checked == true)
            {
                chkUnitDhaka.Checked = false;
                dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '1'");

                Generate_UsedLotDataGrid();
                Get_Lot_Capacity_UsedDataLoad();

                //Generate_ScheduledQTY_DataGrid();
                Get_ScheduledQTY_Data();
            }
        }//
        private void chkUnitDhaka_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnitDhaka.Checked == true)
            {
                chkUnitCTG.Checked = false;
                dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '2'");

                Generate_UsedLotDataGrid();
                Get_Lot_Capacity_UsedDataLoad();

                //Generate_ScheduledQTY_DataGrid();
                Get_ScheduledQTY_Data();
            }
        }//

        private void cmbOrdLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrdLocName = cmbOrdLocation.Text.Trim();
            if (OrdLocName != "Select" && OrdLocName.Length > 4 && OrdLocName.Length < 12)
            {
                int Order_Location = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                dbConCrUser.FillDataGridView(dgvSearchResult, @"proc_get_booking_no '" + Order_Location + "'");
                //dbConCrUser.FillDataGridView(dgvSearchResult, @"EXEC T_Get_Job_ByShade_Proc '" + Order_Location + "','" + txtShade.Text.Trim() + "'");
                dbConCrUser.FillDataGridView(dataGridViewShade, @"EXEC proc_get_shade '" + Order_Location + "'");

            }
        }//
        private void txtShade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridViewShade.Focus();
            }
        }
        private void txtShade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dataGridViewShade.Visible = false;
            }
        }
        private void txtShade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtShade.Text.Trim() != "")
                {
                    if(Is_NotSamePage != 1)
                    {
                        //dgvSearchResult.Visible = false;
                        dgvSearchResult.Visible = false;
                        dtgvColor.Visible = false;

                        var dataTable = (DataTable)dataGridViewShade.DataSource;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            dataGridViewShade.Visible = true;
                            dataView.RowFilter = "[" + dataGridViewShade.Columns[1].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";

                            //for (int i = 0; i < dataGridViewShade.Rows.Count; i++)
                            //{
                            //    if (i % 2 == 0)
                            //    {
                            //        dataGridViewShade.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                            //    }

                            //}
                        }
                        foreach (DataGridViewColumn column in dataGridViewShade.Columns)
                        {
                            //column.Visible = false;
                            if (column.Name != "shade_name")
                                column.Visible = false;
                        }

                        //Hide row header
                        dataGridViewShade.RowHeadersVisible = false;
                        // Show the "shade_name" column
                        dataGridViewShade.Columns["shade_name"].Visible = true;

                        // Set the column header text
                        dataGridViewShade.Columns["shade_name"].HeaderText = " Shade";
                        //dataGridViewShade.Columns["shade_name"].ReadOnly = true;
                        dataGridViewShade.Columns["shade_name"].Width = 200;
                        dataGridViewShade.Columns["shade_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridViewShade.Columns["shade_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        dataGridViewShade.ColumnHeadersHeight = 60;
                        dataGridViewShade.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        dataGridViewShade.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    }
                    //else
                    //{
                    //    dbConCrUser.FillComboBox(cmbBrand, @"EXEC T_Get_BrandList_Proc");
                    //    string Brand = Select_BrandByShade();
                    //    cmbBrand.SelectedValue = Get_BrandId(Brand);

                    //    txtShade.Enabled = false;
                    //}

                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public string Select_BrandByShade()
        {
            string Brand = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT CountType AS Brand FROM SalesCube.dbo.Shade WHERE SubTypeId = '" + txtShade.Text.Trim() + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    Brand = dr["Brand"].ToString();
                }
            }

            dr.Close();
            return Brand;
        }//
        public int Get_BrandId(string Brand)
        {
            int Id = 0;
            if (Brand == "LION")
            {
                Id = 1;
            }
            else if (Brand == "GREEN SPUN")
            {
                Id = 2;
            }
            else if (Brand == "ULTRA CORE")
            {
                Id = 3;
            }
            else if (Brand == "ULTRA TEX")
            {
                Id = 4;
            }
            else if (Brand == "GREEN TEX")
            {
                Id = 5;
            }
            else if (Brand == "NEEDLECRAFT")
            {
                Id = 6;
            }
            else if (Brand == "WST")
            {
                Id = 8;
            }
            else if (Brand == "Nylon")
            {
                Id = 9;
            }
            else
            {
                Id = 7; //Filament
            }
            return Id;
        }

        public void Select_ShadeGrid_ToTextfield()
        {
            if (dataGridViewShade.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dataGridViewShade.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtShade.Text = cellValue.ToString();
                    dataGridViewShade.Visible = false;
                }
                txtShade.Focus();

                string Brand = Select_BrandByShade();
                cmbBrand.SelectedValue = Get_BrandId(Brand);


            }
        }//

        private void txtShade_Enter(object sender, EventArgs e)
        {
            if (txtShade.Text.Trim() != "")
            {
                Select_ShadeGrid_ToTextfield();
            }
            dtgvColor.Visible = false;
            dgvSearchResult.Visible = false;
        }
        private void dataGridViewShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
        }
        private void dataGridViewShade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_ShadeGrid_ToTextfield();
            }
        }

        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvSearchResult.Focus();
                //gvListData.Rows[0].Cells[1].Selected = true;
            }
        }
        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dgvSearchResult.Visible = false;
            }
        }
        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() != "")
                {
                    if (Is_NotSamePage != 1)
                    {
                        dataGridViewShade.Visible = false;
                        dtgvColor.Visible = false;

                        var dataTable = (DataTable)dgvSearchResult.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            dgvSearchResult.Visible = true;
                            dataView.RowFilter = "[" + dgvSearchResult.Columns[1].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";

                            //for (int i = 0; i < dgvSearchResult.Rows.Count; i++)
                            //{
                            //    if (i % 2 == 0)
                            //    {
                            //        dgvSearchResult.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                            //    }

                            //}
                        }

                        dgvSearchResult.RowHeadersVisible = false;
                        //// Show the "shade_name" column
                        dgvSearchResult.Columns["name_value"].Visible = true;
                        dgvSearchResult.Columns["id"].Visible = false;

                        //// Set the column header text
                        dgvSearchResult.Columns["name_value"].HeaderText = " Order ID";
                        //dgvSearchResult.Columns["name_value"].ReadOnly = true;
                        dgvSearchResult.Columns["name_value"].Width = 300;
                        dgvSearchResult.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvSearchResult.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        dgvSearchResult.ColumnHeadersHeight = 60;
                        dgvSearchResult.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        dgvSearchResult.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    }
                    //else
                    //{
                    //    txtJob.Enabled = false;
                    //}

                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public void Select_JobGrid_ToTextfield()
        {
            if (dgvSearchResult.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dgvSearchResult.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    dgvSearchResult.Visible = false;
                }
                txtJob.Focus();


                int Unit = 0;
                if (chkUnitCTG.Checked == true)
                { Unit = 1; }
                else if (chkUnitDhaka.Checked == true)
                { Unit = 2; }
                dbConCrUser.FillDataGridView(dtgvColor, @"EXEC T_Get_Color_Proc '" + Unit + "','" + txtJob.Text.Trim() + "'");
            }
        }//

        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextfield();
            }
            dtgvColor.Visible = false;
            dataGridViewShade.Visible = false;
        }
        private void dgvSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextfield();
        }
        private void dgvSearchResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_JobGrid_ToTextfield();
            }
        }
        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvColor.Focus();
            }
        }
        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvColor.Visible = false;
            }
        }
        public void Select_ColorGrid_ToTextfield()
        {
            if (dtgvColor.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvColor.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtColor.Text = cellValue.ToString();
                    dtgvColor.Visible = false;
                }
                txtColor.Focus();
            }
        }//
        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtColor.Text.Trim() != "")
                {
                    dataGridViewShade.Visible = false;
                    dgvSearchResult.Visible = false;

                    var dataTable = (DataTable)dtgvColor.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvColor.Visible = true;
                        dataView.RowFilter = "[" + dtgvColor.Columns[0].Name + "] LIKE '%" + txtColor.Text.Trim() + "%'";

                        for (int i = 0; i < dtgvColor.Rows.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                dtgvColor.Rows[i].DefaultCellStyle.BackColor = Color.Snow;
                            }

                        }
                    }

                    dtgvColor.RowHeadersVisible = false;

                    dtgvColor.Columns["Color"].Visible = true;

                    //// Set the column header text
                    dtgvColor.Columns["Color"].HeaderText = " Color";
                    //dtgvColor.Columns["Color"].ReadOnly = true;
                    dtgvColor.Columns["Color"].Width = 300;
                    dtgvColor.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvColor.Columns["Color"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvColor.ColumnHeadersHeight = 60;
                    dtgvColor.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvColor.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        private void txtColor_Enter(object sender, EventArgs e)
        {
            if(txtColor.Text.Trim() !="")
            {
                Select_ColorGrid_ToTextfield();
            }
            dataGridViewShade.Visible = false;
            dgvSearchResult.Visible = false;
        }

        private void dtgvColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ColorGrid_ToTextfield();
        }
        private void dtgvColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_ColorGrid_ToTextfield();
            }
        }
        private void chkFamily_CheckedChanged(object sender, EventArgs e)
        {
            if (txtShade.Text.Trim() != "")
            {
                if (chkFamily.Checked == true)
                {
                    cmbCount.SelectedItem = "Select";
                    cmbCount.Enabled = false;
                    cmbFamily.Enabled = true;

                    string Brand = cmbBrand.Text.ToString();
                    dbConCrUser.FillComboBox_SingleColumn
                        (cmbFamily, @"SELECT 'N/A' GroupName
                            UNION ALL
                            SELECT DISTINCT GroupName FROM dbo.Family_Count WHERE Brand='" + Brand + "'"
                         );
                }
                else
                {
                    cmbCount.Enabled = true;
                    cmbFamily.SelectedItem = "N/A";
                    cmbFamily.Enabled = false;
                }
            }
            else if(txtShade.Text.Trim() == "" && chkFamily.Checked == true)
            {
                chkFamily.Checked = false;
                MessageBox.Show("Enter Shade..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            { }
           
        }//

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblDayTotal.Text = "0";
                lblDayTotalLot.Text = "0";
                lblTotalPack.Text = "0";

                int isFamily = 0;
                if (cmbOrdLocation.Text.Trim() == "Select")
                {
                    MessageBox.Show("Select Order Location!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtShade.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Valid Shade!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(cmbMachine.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Machine!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (chkFamily.Checked == true)
                {
                    isFamily = 1;
                    if (cmbFamily.Text == "N/A")
                    {
                        MessageBox.Show("Select Family Group..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (cmbBrand.Text == "Select" && isFamily == 0)
                {
                    MessageBox.Show("Select Brand!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (chkFamily.Checked == false)
                //{
                //    if (cmbCount.Text == "Select")
                //    {
                //        MessageBox.Show("Select Count..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}



                InitDataGrid();
                //Generate_DayForDataListGrid();

                Get_GridDataLoad();
                //Block_Machine();


                //txtShade.Enabled = false;
               // txtJob.Enabled = false;
                //txtColor.Enabled = false;
                //chkFamily.Enabled = false;
                //cmbCount.Enabled = false;
                cmbBrand.Enabled = false;
                cmbMachine.Enabled = false;
                //cmbOrdLocation.Enabled = false;
                //btnSearch.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

      
        public void Clear_Refresh()
        {
            dtSchDate.Text = "";
            CountGroup_glb = "";
            dtSchDate.Format = DateTimePickerFormat.Custom;
            dtSchDate.CustomFormat = "dd-MMM-yyyy";
            dtSchDate.MinDate = DateTime.Now.AddDays(1);

            //txtShade.Enabled = true;
            txtJob.Enabled = true;

            txtColor.Enabled = true;
            chkFamily.Enabled = true;
            cmbCount.Enabled = true;
            //cmbBrand.Enabled = false;
            cmbMachine.Enabled = true;
            cmbOrdLocation.Enabled = true;

            txtShade.Text = "";
            txtJob.Text = "";
            txtColor.Text = "";

            //txtMchLotC.Text = "0";
            txtMchKG.Text = "0";
            txtMinKG.Text = "0";
            lblDayTotal.Text = "0";
            lblDayTotalLot.Text = "0";
            lblTotalPack.Text = "0";
            //lotExcedCount = 0;

            //sumQTY_DayWise = 0;

            chkFamily.Checked = false;
            //chkUnitCTG.Checked = false;
            //chkUnitDhaka.Checked = false;
            cmbCount.SelectedValue = 0;
            btnSearch.Enabled = true;

            //gvListData.Rows.Clear();
            InitDataGrid();
            //Delete_Block_Machine();
            cmbMachine.SelectedValue = 0;
            //cmbOrdLocation.SelectedIndex = 0;
            cmbBrand.SelectedIndex = 0;
            cmbFamily.SelectedItem = "N/A";

            dataGridViewShade.Visible = false;
            dgvSearchResult.Visible = false;
            dtgvColor.Visible = false;

            Get_Lot_Capacity_UsedDataLoad();
            lblScheduledQty.Text = "0";
            Get_ScheduledQTY_Data();

            Is_NotSamePage = 0;
            txtShade.Enabled = true;
        }//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear_Refresh();
            }
            catch 
            {
            }
          
        }

        public int Check_IsAssigned_MchLot_OnSchDate(string schedule_date)
        {
            int count = 0;
            int location_id = 1;
            if (chkUnitDhaka.Checked == true)
            {
                location_id = 2;
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.machine_capacity WHERE machine_id='" + cmbMachine.SelectedValue + "' AND schedule_date='" + schedule_date + "' AND location_id='" + location_id + "'");

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

        private void cmbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Generate_UsedLotDataGrid();

            string machine_name = cmbMachine.Text.Trim();
            if (machine_name != "Select" && machine_name.Length > 1 && machine_name.Length < 10)
            {

                string sch_date = dtSchDate.Text;
                if (Check_IsAssigned_MchLot_OnSchDate(sch_date) == 0)
                {
                    Clear_Refresh();
                    MessageBox.Show(" '" + cmbMachine.Text + "' lot capacity not allocated on this [" + sch_date + "] date..!! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Get_ScheduleDate_OnOff(sch_date) > 0)
                {
                    MessageBox.Show("Schedule off on this " + sch_date + " date..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Get_Machine_Lot_KG();
                //if (Check_IsBlock_Machine() == 0)
                //{
                //    Get_Machine_Lot_KG();
                //}
                //else
                //{
                //    cmbMachine.SelectedIndex = 0;
                //    MessageBox.Show("At this moment '" + machine_name + "' is blocked by someone..!! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


            }
            else
            {
                //txtMchLotC.Text = "0";
                txtMchKG.Text = "0";
                txtMinKG.Text = "0.1";
            }
        }//

        public void Block_Machine()
        {
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
             string user = frmLogin.LoginID.ToString();
            //string ip_address = frmLogin.ipAddress;
            //string user = "arif";
            string ip_address = "";
            string[] Cols = { "machine_id", "user_id", "ip_address" };
            string[] Vals = { machine_id.ToString(), user, ip_address };
            string sql = dbConCrUser.CreateSQLStatement("block_machine", Cols, Vals, "INSERT", null, null);

            if (sql != "")
            {
                sql += "SELECT SCOPE_IDENTITY();";
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }
        }//
        public void Delete_Block_Machine()
        {
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
            string user = frmLogin.LoginID.ToString();
            //string ip_address = frmLogin.ipAddress;
            //string user = "arif";
            //string ip_address = "";
            string sql = "DELETE FROM dbo.block_machine WHERE machine_id = '" + machine_id + "' AND user_id='"+ user + "' ";
            if (sql != "")
            {
                //dbConCrUser.DBExecuteScalarWithSQL(sql);
                dbConCrUser.DBInsertUpdateDeleteFunction(sql);
            }
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
        public void Machine_Pack_Calculation(int machineId, decimal ConePerPack, decimal schBal)
        {

            decimal maxPack = GetLotMaxCapacity(machineId);
            decimal minPack = GetLotMinCapacity(machineId);
            decimal totalSchQty = maxPack * ConePerPack; // can produce QTY

            decimal schPack = schBal / ConePerPack; // need KG

            //string schQtyColumnName = gvListData.Columns[e.ColumnIndex].Name;

            //if (schBal > totalSchQty)
            //{
            //    decimal roundedTotalSchQty = Math.Round(totalSchQty, 2);
            //    gvListData.Rows[e.RowIndex].Cells[schQtyColumnName].Value = roundedTotalSchQty;
            //}
            //else if (schPack > minPack)
            //{
            //    gvListData.Rows[e.RowIndex].Cells[schQtyColumnName].Value = schBal;
            //}
            //else
            //{
            //    gvListData.Rows[e.RowIndex].Cells[schQtyColumnName].Value = 0;
            //}

        }//
        public int Get_Assigned_MchLot_OnSchDate(string SchDate)
        {
            int count = 0;
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
            //int location_id = 1;
            //if (chkUnitDhaka.Checked == true)
            //{
            //    location_id = 2;
            //}
            int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
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
        public decimal Get_UsedPackInMachineLot_OnSchDate(int machine_id, int location_id, string SchDate)
        {
            decimal pack = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_UsedPackInMchLot_OnSchDate_Proc '" + machine_id + "' ,'" + location_id + "','" + SchDate + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    pack = Convert.ToDecimal(dr["used_pack"].ToString());
                }
            }
            dr.Close();
            return pack;
        }//

        public int Check_Machine_LotExceed(decimal conePerPack, decimal sumQTY_DayWise)
        {
            int count = 0;
            int UsedLot = 0;
            int mch_lot = 0;
            int machine_id = Convert.ToInt32(cmbMachine.SelectedValue);
            decimal Mch_KG = Convert.ToDecimal(txtMchKG.Text);
            int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
            DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
            string ScheduleDate = SchDate.ToString("yyyy-MM-dd");

            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("T_Get_Count_UsedLot_Proc '" + machine_id + "' , '" + ScheduleDate + "' ,'" + location_id + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    UsedLot = Convert.ToInt32(dr["cnt"].ToString());
                }
            }
            dr.Close();

            mch_lot = Get_Assigned_MchLot_OnSchDate(ScheduleDate);

            decimal assignLot_KG = mch_lot * Mch_KG; // 4*5=20kg
            decimal UsedPack = Math.Ceiling(Get_UsedPackInMachineLot_OnSchDate(machine_id, location_id, ScheduleDate));
            decimal DueKG = assignLot_KG - UsedPack;

            //int mch_lot = Convert.ToInt32(txtMchLotC.Text);
            int DueLot = mch_lot - UsedLot;
            decimal ConeCapacity_PerLot = Math.Round(Mch_KG * conePerPack); // suppose 40kg * 10 cone = 400 cone
            decimal TotalConeCapacity_FullDay = ConeCapacity_PerLot * DueLot;
            decimal curren_SchQTY_PackKG = sumQTY_DayWise / conePerPack;
            if (sumQTY_DayWise > TotalConeCapacity_FullDay)
            {
                if (DueKG <= 0) // 2.56<=0
                {
                    count = 1;
                }
                if (curren_SchQTY_PackKG > DueKG)
                {
                    count = 1;
                }
            }
            return count;
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
        public int Check_IsExist_RemainingPack_Lot(int MachineId, string Shade,string familyCount, string ScheduleDate, int Location)
        {
            int count = 0;
            int CommId = 1;
            int Brand = Convert.ToInt32(cmbBrand.SelectedValue.ToString());
            //string familyCount = cmbCount.Text;
            string FamilyGroup = "";
            if (chkFamily.Checked == true)
            {
                FamilyGroup = cmbFamily.SelectedValue.ToString();
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + Location + "','" + Brand + "','" + FamilyGroup + "','" + familyCount + "','" + CommId + "'");

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
        public string Bind_RemainingPack_LotNo(int MachineId, string Shade, string ScheduleDate)
        {
            string LotNo = "";
            int CommId = 2;
            int location = Convert.ToInt32(cmbOrdLocation.SelectedValue);
            int Brand = Convert.ToInt32(cmbBrand.SelectedValue.ToString());
            string familyCount = cmbCount.Text;
            string FamilyGroup = "";
            if (chkFamily.Checked == true)
            {
                FamilyGroup = cmbFamily.SelectedValue.ToString();
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + location + "','" + Brand + "','" + FamilyGroup + "','" + familyCount + "','" + CommId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    LotNo = dr["lot_no"].ToString();
                }
            }

            dr.Close();
            return LotNo;
        }//
        public decimal Bind_LotUsedPack_KG(string LotNo, int MachineId)
        {
            decimal used_pack = 0;
            int CommId = 1;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_LotUsedPack_Proc '" + LotNo + "','" + MachineId + "','" + CommId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    used_pack = Convert.ToDecimal(dr["used_pack"].ToString());
                }
            }

            dr.Close();
            return used_pack;
        }//
        public decimal Bind_UsedPack_KG_GroupByLot(int MachineId, string Shade, string ScheduleDate, string familyCount)
        {
            decimal used_pack = 0;
            int CommId = 3;
            int location = Convert.ToInt32(cmbOrdLocation.SelectedValue);
            int Brand = Convert.ToInt32(cmbBrand.SelectedValue.ToString());
            ///string familyCount = cmbCount.Text;
            string FamilyGroup = "";
            if (chkFamily.Checked == true)
            {
                FamilyGroup = cmbFamily.SelectedValue.ToString();
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + location + "','" + Brand + "','" + FamilyGroup + "','" + familyCount + "','" + CommId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    used_pack = Convert.ToDecimal(dr["used_pack"].ToString());
                }
            }

            dr.Close();
            return used_pack;
        }//
        public decimal Bind_Machine_UsedPackOnDate_KG(DateTime SchDate, int MachineId, int locationId)
        {
            decimal used_pack = 0;
            int CommId = 1; // CS Schedule
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Machine_UsedPackOnDate_Proc '" + SchDate + "','" + MachineId + "','" + locationId + "','" + CommId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    used_pack = Convert.ToDecimal(dr["used_pack"].ToString());
                }
            }

            dr.Close();
            return used_pack;
        }//
        public int Bind_MAX_LotId()
        {
            int id = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT MAX(id)+1 AS id FROM dbo.thread_lot_details");

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
        public void Sum_TotalSchQTY_KG()
        {
            decimal sumQTY = 0;
            decimal SumPack_KG = 0;
            decimal SumLot = 0;
            int count = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                if (c >= 0)
                {
                    try
                    {
                        //DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                        //bool checkBoxStatus = Convert.ToBoolean(selectedRow.Cells["X"].Value);
                        bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[c].Cells["X"].Value);
                        if (checkBoxStatus)
                        {
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value) > 0)
                            {
                                count++;

                                decimal QTY = Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value.ToString());
                                sumQTY += QTY;
                                lblDayTotal.Text = sumQTY.ToString();

                                decimal conePack = Convert.ToDecimal(gvListData.Rows[c].Cells["ConePerPack"].Value);
                                SumPack_KG += decimal.Round(QTY / conePack, 2); // 40/8=5kg
                                lblTotalPack.Text = SumPack_KG.ToString();

                                SumLot = Math.Ceiling(SumPack_KG / Convert.ToDecimal(txtMchKG.Text));
                                lblDayTotalLot.Text = SumLot.ToString();
                            }
                        }

                        if(count == 0)
                        {
                            lblDayTotal.Text = "0";
                            lblDayTotalLot.Text = "0";
                            lblTotalPack.Text = "0";
                        }


                    }
                    catch { }
                }

            }// for
        }//
        public int Get_Assigned_MchLot_OnSchDate(int machine_id, DateTime SchDate)
        {
            int count = 0;
            int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
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
        public int Get_UsedLot(int machine_id, DateTime SchDate)
        {
            int count = 0;
            int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(lot_no) cnt FROM dbo.thread_lot WHERE location_id='" + location_id + "' AND machine_id= '" + machine_id + "' AND schedule_date='" + SchDate + "'");
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
        public int Check_IsSchedule_Locked(int CusId, int ReprsId)
        {
            int IsLocked = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt  FROM SalesCube.dbo.CustomerRepInfo WHERE IsScheduleLock=1 AND CustomerId='" + CusId + "' AND RepresentativeId='" + ReprsId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    IsLocked = Convert.ToInt32(dr["cnt"].ToString());
                }
            }

            dr.Close();
            return IsLocked;
        }//
        private void gvListData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gvListData.BeginEdit(true);
                if (e.ColumnIndex == 0)
                {
                    gvListData.EndEdit();

                    // DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    // Get the value of the checkbox cell in the selected row
                    //bool checkBoxStatus = Convert.ToBoolean(selectedRow.Cells["X"].Value);
                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    //bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[e.RowIndex].Cells[0].EditedFormattedValue);
                    if (checkBoxStatus)
                    {
                        //--------- Check Is Schedule Locked
                        int CusID = Convert.ToInt32(row.Cells["CusID"].Value.ToString());
                        int RepID = Convert.ToInt32(row.Cells["RepID"].Value.ToString());
                        if(Check_IsSchedule_Locked(CusID, RepID) > 0)
                        {
                            MessageBox.Show("Schedule is locked..! Contact With CM.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        row.Cells["QTY"].Style.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        row.Cells["QTY"].Style.BackColor = Color.HotPink;
                        row.Cells["QTY"].ReadOnly = false;
                        row.Cells["chkUrgent"].ReadOnly = false;
                        /// for cell color & enable 
                        //gvListData.Rows[e.RowIndex].Cells["QTY"].Style.Font = new Font("Calibri", 9F, FontStyle.Bold);
                        //gvListData.Rows[e.RowIndex].Cells["QTY"].Style.BackColor = Color.HotPink;
                        //gvListData.Rows[e.RowIndex].Cells["QTY"].ReadOnly = false;
                        //gvListData.Rows[e.RowIndex].Cells["chkUrgent"].ReadOnly = false;

                        decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);
                        decimal TotalPack = Convert.ToDecimal(lblTotalPack.Text);

                        decimal BalQty = Convert.ToDecimal(row.Cells["BalQty"].Value);
                        decimal PerLotCone = Convert.ToInt32(row.Cells["PerLotCone"].Value.ToString());
                        decimal ConePerPack = Convert.ToDecimal(row.Cells["ConePerPack"].Value);
                        
                        decimal due_kg = mch_maxKg - TotalPack; // 10kg - 8kg=2kg
                        //decimal req_qty =Math.Ceiling(ConePerPack * due_kg); // 10*2kg=20
                        decimal req_qty =Math.Floor(ConePerPack * due_kg); // 10*2kg=20
                        if (BalQty >= PerLotCone && req_qty > 0) //100>=40
                        {
                            row.Cells["QTY"].Value = req_qty;
                        }
                        else
                        {
                            if (req_qty > BalQty) // 20 > 5
                            {
                                row.Cells["QTY"].Value = BalQty;
                            }
                            else // 5 > 20
                            {
                                row.Cells["QTY"].Value = req_qty;
                            }

                        }
                    }// if checkbox
                    else
                    {

                        row.Cells["QTY"].Style.BackColor = Color.White;
                        row.Cells["QTY"].ReadOnly = true;
                        row.Cells["QTY"].Value = "0";

                        Sum_TotalSchQTY_KG();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (gvListData.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    string isUrgentColumn = gvListData.Columns[e.ColumnIndex].Name;
                    int QtyVal =Convert.ToInt32(row.Cells["QTY"].Value);
                    if (isUrgentColumn != "chkUrgent" && QtyVal > 0)
                    {
                       
                        //DataGridViewRow selectedRow = gvListData.SelectedRows[0];

                        // Get the value of the checkbox cell in the selected row
                        //bool checkBoxStatus = Convert.ToBoolean(selectedRow.Cells["X"].Value);
                        //bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[e.RowIndex].Cells["X"].Value);
                        bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);

                        decimal TotalSchQTY = 0;
                        decimal SchQTY = 0;
                        //decimal sumQTY_DayWise = 0;
                        if (checkBoxStatus)
                        {
                            //row.Cells["QTY"].Style.Font = new Font("Calibri", 9F, FontStyle.Bold);
                            //row.Cells["QTY"].Style.BackColor = Color.HotPink;
                            //row.Cells["QTY"].ReadOnly = false;
                            //row.Cells["chkUrgent"].ReadOnly = false;
                            // Check if the edited cell belongs to the Machine column
                            if (e.ColumnIndex >= 0)
                            {

                                decimal BalQty = Convert.ToDecimal(row.Cells["BalQty"].Value);
                                decimal PerLotCone = Convert.ToInt32(row.Cells["PerLotCone"].Value.ToString());
                                decimal ConePerPack = Convert.ToDecimal(row.Cells["ConePerPack"].Value);
                                string CountGroup = row.Cells["CountGroup"].Value.ToString();
                                CountGroup_glb = CountGroup;
                                string Shade = txtShade.Text.Trim();
                                try
                                {

                                    SchQTY = Convert.ToDecimal(row.Cells["QTY"].Value);
                                    TotalSchQTY = TotalSchQTY + SchQTY;
                                }
                                catch { }
                                //// Total all date QTY SUM

                                //TotalSchQTY = Convert.ToDecimal(lblDayTotal.Text);
                                if (SchQTY > 0)
                                {
                                    if (TotalSchQTY > BalQty)
                                    {
                                        row.Cells[e.ColumnIndex].Value = 0;
                                        MessageBox.Show("Schedule QTY is more than balance QTY..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        Sum_TotalSchQTY_KG();
                                        int TotalQTY = Convert.ToInt32(lblDayTotal.Text);
                                        //if (Check_Machine_LotExceed("QTY", ConePerPack, sumQTY_DayWise) > 0)
                                        if (Check_Machine_LotExceed(ConePerPack, TotalQTY) > 0)
                                        {
                                            //IsExceedQty = 1;
                                            row.Cells["QTY"].Value = 0;
                                            MessageBox.Show(cmbMachine.Text + " machine due lot QTY limit exceed..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        /// new added validation for only 1 lot
                                        decimal TotalPack_KG = Convert.ToDecimal(lblTotalPack.Text);
                                        decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);
                                        if (TotalPack_KG > mch_maxKg)
                                        {
                                            row.Cells["QTY"].Value = 0;
                                            //lblTotalPack.Text = "0";
                                            //lblDayTotalLot.Text = "0";
                                            //lblDayTotal.Text = "0";
                                            //Sum_TotalSchQTY_KG();
                                            MessageBox.Show("Lot capacity(" + mch_maxKg + " KG) exceed..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }//


                                        ///----- Exceed lot capacity validation
                                        string ScheduleDate = dtSchDate.Text;
                                        DateTime sch_date_formated = dtSchDate.Value;
                                        int MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                                        int Assigned_MchLot = Get_Assigned_MchLot_OnSchDate(MachineId, sch_date_formated);
                                        int UsedLot = Get_UsedLot(MachineId, sch_date_formated);
                                        int NetLot = UsedLot + 1;
                                        if (NetLot > Assigned_MchLot)
                                        {
                                            int LocationId = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                                            int Is_RemainingLot = Check_IsExist_RemainingPack_Lot(MachineId, Shade, CountGroup, ScheduleDate, LocationId);
                                            if (Is_RemainingLot == 0)
                                            {
                                                row.Cells["QTY"].Value = 0;
                                                Sum_TotalSchQTY_KG();

                                                MessageBox.Show("Machine lot capacity exceed.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                            else if (Is_RemainingLot > 0)
                                            {
                                                decimal UsedPack_KG = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, ScheduleDate, CountGroup);
                                                decimal DuePack_KG= mch_maxKg - UsedPack_KG; // 10-8=2
                                                if (TotalPack_KG > DuePack_KG) // 4>2
                                                {
                                                    row.Cells["QTY"].Value = 0;
                                                    Sum_TotalSchQTY_KG();

                                                    MessageBox.Show("Machine lot capacity exceed.! Reduce QTY.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    return;
                                                }

                                            }
                                            else
                                            {
                                                row.Cells["QTY"].Value = 0;
                                                Sum_TotalSchQTY_KG();

                                                MessageBox.Show("Machine lot capacity exceed.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }// lot exceed

                                    }

                                }// if schqty>0

                            }

                        }
                        //else
                        //{
                        //    gvListData.Rows[e.RowIndex].Cells["QTY"].Style.BackColor = Color.White;
                        //    gvListData.Rows[e.RowIndex].Cells["QTY"].ReadOnly = true;
                        //    gvListData.Rows[e.RowIndex].Cells["QTY"].Value = "0";
                        //}
                    }// if chkUrgent checkbox

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private decimal CalculateLot(int machineId, decimal currentPack)
        {
            decimal lot = 0;
            decimal maximumPack = 0;
            decimal lotPerDay = 0;
            string machineName = "";
            decimal minimumPack = 0;

            SqlDataReader dr;

            try
            {
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC proc_CheckPackLimit @machineId = '" + machineId + "'");
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["max_pack"].ToString()))
                    {
                        maximumPack = Convert.ToDecimal(dr["max_pack"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["lot_per_day"].ToString()))
                    {
                        lotPerDay = Convert.ToDecimal(dr["lot_per_day"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["min_pack"].ToString()))
                    {
                        minimumPack = Convert.ToDecimal(dr["min_pack"].ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["machine_name"].ToString()))
                    {
                        machineName = dr["machine_name"].ToString();
                    }

                    if (currentPack >= minimumPack)
                    {
                        lot = (currentPack / maximumPack);
                        if (lot > lotPerDay)
                        {
                            MessageBox.Show("Current lot exceed lot limit of '" + machineName + "' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return 0;
                        }
                    }
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lot;
        }//
        public decimal Check_Sum_TotalSchQTY()
        {
            decimal Total_Sum = 0;
            bool checkBoxStatus = false;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                if (c >= 0)
                {
                    try
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
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value) > 0)
                            {
                                decimal FoTY = Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value.ToString());
                                Total_Sum += FoTY;
                            }
                        }


                    }
                    catch { }
                }

            }// for
            return Total_Sum;
        }//
        public string Get_ScheduleNo(string SchDate)
        {
            string SCNO = "";
            //int location = cmbOrdLocation.SelectedValue;
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
        public decimal Sum_Total_Pack(string SchDate)
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
                        if (Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value) > 0)
                        {
                            decimal cone_per_pack = Convert.ToDecimal(gvListData.Rows[c].Cells["ConePerPack"].Value.ToString());
                            decimal SchQTY = Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value.ToString());
                            Total_PackKG += decimal.Round(SchQTY / cone_per_pack, 2);
                        }

                    }

                }

            }// for
            return Total_PackKG;
        }//
        public int Bind_Unit_ScheduleQTY_Capacity()
        {
            int Unit = 0;
            int QTY = 0;
            if (chkUnitCTG.Checked == true)
            { Unit = 1; }
            else if (chkUnitDhaka.Checked == true)
            { Unit = 2; }
            else { }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT CapacityQty FROM dbo.Unit_Capacity WHERE Unit='" + Unit + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    QTY = Convert.ToInt32(dr["CapacityQty"].ToString());
                }
            }

            dr.Close();
            return QTY;
        }//
        public int Bind_Unit_ScheduledQTY_OnDate()
        {
            int Unit = 0;
            int QTY = 0;
            DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
            if (chkUnitCTG.Checked == true) { Unit = 1; }
            if (chkUnitDhaka.Checked == true) { Unit = 2; }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(" EXEC T_Get_Unit_ScheduledQTY_Proc '" + Unit + "','" + SchDate + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    QTY = Convert.ToInt32(dr["SchQTY"].ToString());
                }
            }

            dr.Close();
            return QTY;
        }//
        public void Confirm_Schedule()
        {
            string sql_master = "";
            string sql_details = "";
            string sql_details_2 = "";
            string sql_lot = "";
            int schedule_id = 0;
            string LotNo = "";

            int gridRow = 0;
            //string processId = "";

            int Lot = 0;

            int MachineId = 0;
            int BookingId = 0;
            int BookingSubId = 0;
            int ProductId = 0;
            int Unit = 0;
            string FamilyGroup = "";

            string BookingNo = "";
            string Shade = "";
            string Color = "";
            string PrdCount = "";
            decimal ConePerPack = 0;
            int PerLotCone = 0;
            decimal BalanceQty = 0;
            string ScheduleDate = "";
            decimal DueQTY = 0;
            decimal TotalPack = 0;
            decimal SchDayQTY = 0;
            decimal TotalScheduleQTY = 0;

            bool checkUrgent = false;
            bool checkBoxStatus = false;
            int insertCount = 0;

            try
            {
                string EntryBy = frmLogin.UserID.ToString();
                //string EntryBy = "arif";

                MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                decimal machine_capacity = Convert.ToDecimal(txtMchKG.Text);
                int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                int BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
                if (BrandId == 2) // Lion & Green spun is same as per CS requirement.
                {
                    BrandId = 1;
                }
                //ScheduleDate = dtSchDate.Text;
                DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
                ScheduleDate = SchDate.ToString("yyyy-MM-dd");

                if (chkUnitCTG.Checked == true)
                { Unit = 1; }
                else if (chkUnitDhaka.Checked == true)
                { Unit = 2; }
                else { }

                if (chkFamily.Checked == true)
                {
                    FamilyGroup = cmbFamily.Text.Trim();
                }


                if (gvListData.Rows.Count > 0)
                {
                    gridRow = gvListData.Rows.Count;

                    DateTime date = DateTime.UtcNow;

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
                            string uniqueNumber = "";
                            DateTime now = DateTime.Now;
                            //uniqueNumber = now.ToString("yyyyMMddHHmmssfff");
                            int IsUrgent = 0;
                            try
                            {
                                BookingNo = gvListData.Rows[i].Cells["BookingNo"].Value.ToString();
                                Shade = gvListData.Rows[i].Cells["Shade"].Value.ToString();
                                Color = gvListData.Rows[i].Cells["Color"].Value.ToString();
                                ConePerPack = Convert.ToDecimal(gvListData.Rows[i].Cells["ConePerPack"].Value.ToString());
                                PerLotCone = Convert.ToInt32(gvListData.Rows[i].Cells["PerLotCone"].Value.ToString());
                                BalanceQty = Convert.ToDecimal(gvListData.Rows[i].Cells["BalQty"].Value.ToString());
                                PrdCount = gvListData.Rows[i].Cells["CountGroup"].Value.ToString();

                                if (gvListData.Rows[i].Cells["chkUrgent"].Value == null)
                                {
                                    checkUrgent = false;
                                }
                                else
                                {
                                    checkUrgent = Convert.ToBoolean((gvListData.Rows[i].Cells["chkUrgent"].Value).ToString());
                                }
                                if (checkUrgent)
                                {
                                    IsUrgent = 1;
                                }

                                if (gvListData.Rows[i].Cells["QTY"].Value != null)
                                {
                                    SchDayQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value.ToString());
                                }
                                DueQTY = BalanceQty - SchDayQTY;
                            }
                            catch { }

                            //// int Id
                            BookingId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingId"].Value.ToString());
                            BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingSubId"].Value.ToString());
                            ProductId = Convert.ToInt32(gvListData.Rows[i].Cells["ProductId"].Value.ToString());
                            string RepID = gvListData.Rows[i].Cells["RepID"].Value.ToString();
                            string CusID = gvListData.Rows[i].Cells["CusID"].Value.ToString();

                            /// schedule date & qty details save
                            //ScheduleDate = ScheduleDate_List[d];
                            //processId = Get_ScheduleNo(ScheduleDate);
                            //SchDayQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value);
                            decimal Total_SumDayQTY = Check_Sum_TotalSchQTY();

                            //----------- Used & Due Lot Part
                            int UsedLot = Get_UsedLot(ScheduleDate);
                            int Lot_PerDay = Get_Assigned_MchLot_OnSchDate(ScheduleDate);
                            int DueLot = Lot_PerDay - UsedLot;

                            decimal FullDay_MachineKG = DueLot * machine_capacity;
                            decimal assignLot_KG = Lot_PerDay * machine_capacity; // 4*10=40kg
                            decimal UsedPack_InAssignLot = Math.Ceiling(Get_UsedPackInMachineLot_OnSchDate(MachineId, location_id, ScheduleDate));
                            decimal DueKG = assignLot_KG - UsedPack_InAssignLot; // 40kg-10kg=30kg

                            //--------------- Date wise pack check
                            TotalPack = Sum_Total_Pack(ScheduleDate); // total pack kg                                   
                            Lot = (int)Math.Ceiling(CalculateLot(MachineId, TotalPack)); //lot exceed check
                            if (TotalPack > FullDay_MachineKG)
                            {
                                if (DueKG <= 0)
                                {
                                    throw new Exception("" + cmbMachine.Text + " machine capacity exceed on this " + ScheduleDate + " date!!. ");
                                }
                            }

                            // check current lot exceed due lot
                            decimal MaximumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMchKG.Text));
                            decimal MinimumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMinKG.Text));

                            decimal TotalLot = Math.Ceiling(TotalPack / machine_capacity); // (27/5=6) day kg/mchKg to lot 
                            decimal TotalLot_lineWise = Math.Ceiling(SchDayQTY / PerLotCone); // day Qty to lot 
                            decimal TotalPack_lineWise = Math.Ceiling(SchDayQTY / ConePerPack);

                            if (TotalPack < Convert.ToDecimal(txtMinKG.Text)) //-- 7<1
                            {
                                // checking if exists lot has enough pack for this QTY
                                if (Convert.ToDecimal(txtMchKG.Text) > 1)
                                {
                                    if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, PrdCount, ScheduleDate, location_id) == 0)
                                    {
                                        throw new Exception("Enter minimum capacity QTY for one lot.!! ");
                                    }
                                }


                            }
                            //------------ exceed qty calculation
                            decimal Exceed_DueQTY = 0;
                            if (TotalLot_lineWise > 0)
                            {
                                //Exceed_DueQTY = Math.Ceiling(SchDayQTY - (TotalLot * PerLotCone)); // due qty after lot deduct
                                //Exceed_DueQTY = Math.Ceiling(SchDayQTY - (TotalLot_lineWise * PerLotCone)); // due qty after lot deduct
                                //if (Exceed_DueQTY < 0)
                                //{
                                //    decimal ExactQty = TotalLot_lineWise * PerLotCone;
                                //    Exceed_DueQTY = Math.Ceiling(SchDayQTY - ExactQty);
                                //}

                                if (TotalLot_lineWise == 1 && SchDayQTY > PerLotCone) // 90>80
                                {
                                    Exceed_DueQTY = SchDayQTY - PerLotCone; // exceed=10
                                }
                                if (TotalLot_lineWise > 1 && SchDayQTY > PerLotCone) // 240>200
                                {
                                    Exceed_DueQTY = SchDayQTY % PerLotCone; //200%80=40
                                }

                                //if (TotalLot_lineWise > 1)
                                //{
                                //    Exceed_DueQTY = Math.Ceiling((TotalLot_lineWise * PerLotCone) - SchDayQTY);
                                //}
                                //if(Exceed_DueQTY >= 0)
                                //{

                                //}
                                //else
                                //{
                                //    decimal exact_lot_qty = TotalLot_lineWise * PerLotCone;
                                //    if (exact_lot_qty > SchDayQTY)
                                //    {
                                //        Exceed_DueQTY = (SchDayQTY - PerLotCone);
                                //    }
                                //    if (Exceed_DueQTY < 0)
                                //    {
                                //        Exceed_DueQTY = 0;
                                //    }
                                //}



                            }

                            //---------- Net scheduleQTY & due pack calculation
                            decimal NetSchQTY = 0;
                            //if (TotalLot_lineWise > 1)
                            //{
                            //    NetSchQTY = SchDayQTY;
                            //}
                            //else
                            //{
                            //    NetSchQTY = Math.Ceiling(SchDayQTY - Exceed_DueQTY); // 120-40=80
                            //}
                            NetSchQTY = SchDayQTY;
                            //decimal SchQTY_LotKg = SchDayQTY / ConePerPack;
                            decimal SchQTY_LotKg = NetSchQTY / ConePerPack;
                            decimal Exceed_DueQTY_KG = Exceed_DueQTY / ConePerPack; // 40/8=5kg
                            decimal UsedPackKg = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, ScheduleDate, PrdCount);
                            decimal DuePack_Exceed = 0;
                            if (UsedPackKg > 0)
                            {
                                //if (Exceed_DueQTY_KG > UsedPackKg) // 2>1
                                //{
                                //    DuePack_Exceed = Exceed_DueQTY_KG - UsedPackKg;
                                //}
                                //else
                                //{
                                //    DuePack_Exceed = UsedPackKg - Exceed_DueQTY_KG; // 2-3=-1kg
                                //}
                                DuePack_Exceed = machine_capacity - UsedPackKg;
                                //DuePack_Exceed = UsedPackKg - Exceed_DueQTY_KG;
                            }

                            decimal DuePack = Convert.ToDecimal(txtMchKG.Text) - UsedPackKg; // 5-2=3kg

                            // minimum kg part
                            string OldLotNo = "";
                            string IsEmptyLot = "NO";
                            //string IsExtraLot = "YES";
                            string IsExtraLot = "NO";
                            //if (Exceed_DueQTY > MinimumSchQty)
                            //{
                            //    Exceed_DueQTY = MinimumSchQty;
                            //}
                            //------------- exceed qty lot check or creat new lot

                            decimal Lot_lineWise_Floor = Math.Floor(SchDayQTY / PerLotCone);
                            decimal QTY_withoutExceed = Lot_lineWise_Floor * PerLotCone; // 3*35=105

                            if (Exceed_DueQTY >= MinimumSchQty && Exceed_DueQTY <= MaximumSchQty)// 40>=32 & 40<=80
                            {
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, PrdCount, ScheduleDate, location_id) == 0)
                                {
                                    //TotalLot = TotalLot + 1;
                                    IsExtraLot = "YES";
                                    //NetSchQTY = NetSchQTY + MinimumSchQty; // 80+32=112
                                    //NetSchQTY = PerLotCone + MinimumSchQty; // 80+32=112
                                    //Exceed_DueQTY = Exceed_DueQTY - MinimumSchQty;

                                    if (Exceed_DueQTY == MinimumSchQty)
                                    {
                                        Exceed_DueQTY = MinimumSchQty;
                                    }

                                    if (Exceed_DueQTY < MinimumSchQty) // 10<15
                                    {
                                        NetSchQTY = QTY_withoutExceed;
                                        TotalLot_lineWise = Math.Floor(NetSchQTY / PerLotCone);
                                    }
                                    else
                                    {
                                        NetSchQTY = QTY_withoutExceed + Exceed_DueQTY; // 105+15
                                    }


                                }
                                else
                                {

                                    if (Exceed_DueQTY_KG <= DuePack_Exceed) // 2<=3
                                    {
                                        //-------- if exceed qty found enough space in exist lot
                                        OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate);
                                        decimal Lot_usedPack = Bind_LotUsedPack_KG(OldLotNo, MachineId);
                                        decimal Lot_duePack = Convert.ToDecimal(txtMchKG.Text) - Lot_usedPack;
                                        if (TotalPack_lineWise <= Lot_duePack)
                                        {
                                            IsEmptyLot = "YES";
                                            //TotalLot = TotalLot - 1;
                                        }
                                    }
                                    else if (OldLotNo != "" && DuePack_Exceed > 0 && Exceed_DueQTY_KG > DuePack_Exceed) //2>0 & 2>3
                                    {
                                        if (MessageBox.Show("Are you want to create a new lot? One existing lot has capacity " + DuePack_Exceed + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            //TotalLot = TotalLot + 1;
                                            //IsExtraLot = "YES";
                                            //NetSchQTY = NetSchQTY + Exceed_DueQTY;
                                        }
                                        else
                                        {
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        //TotalLot = TotalLot + 1;
                                        IsExtraLot = "YES";
                                        //NetSchQTY = NetSchQTY + Exceed_DueQTY;

                                    }


                                }

                            }
                            //if (Exceed_DueQTY <= MinimumSchQty && Exceed_DueQTY > 0) // 130 .. 100-30=30
                            if (Exceed_DueQTY > 0 && PerLotCone > Exceed_DueQTY) // 130 .. 100-30=30
                            {
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, PrdCount, ScheduleDate, location_id) > 0)
                                {
                                    OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate);
                                    if (Exceed_DueQTY_KG <= DuePack_Exceed)
                                    {
                                        if (OldLotNo != "")
                                        {
                                            decimal Lot_usedPack = Bind_LotUsedPack_KG(OldLotNo, MachineId);
                                            decimal Lot_duePack = Convert.ToDecimal(txtMchKG.Text) - Lot_usedPack;
                                            //decimal PackExceedQTY = Exceed_DueQTY / ConePerPack;
                                            if (Exceed_DueQTY_KG <= Lot_duePack)
                                            {
                                                IsEmptyLot = "YES";
                                                //TotalLot = TotalLot - 1;
                                                //NetSchQTY = NetSchQTY + Exceed_DueQTY;
                                            }
                                        }
                                    }
                                    else if (OldLotNo != "" && DuePack_Exceed > 0 && Exceed_DueQTY_KG > DuePack_Exceed)
                                    {
                                        if (MessageBox.Show("Are you want to create a new lot? One Existing lot has due capacity " + DuePack_Exceed + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            //TotalLot = TotalLot + 1;
                                            //IsExtraLot = "YES";
                                        }
                                        else
                                        {
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        //TotalLot = TotalLot + 1;
                                    }


                                }
                                else
                                {
                                    if (Exceed_DueQTY < MinimumSchQty) // 10<15
                                    {
                                        NetSchQTY = QTY_withoutExceed;
                                        TotalLot_lineWise = Math.Floor(NetSchQTY / PerLotCone);
                                    }
                                }



                            }
                            //if (SchDayQTY < PerLotCone && TotalLot <= 1 && Exceed_DueQTY == 0)
                            //{
                            //    if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, location_id) > 0)
                            //    {
                            //        if (SchQTY_LotKg <= DuePack)
                            //        {
                            //            IsEmptyLot = "YES";
                            //            OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate);
                            //        }
                            //        else
                            //        {
                            //            if (MessageBox.Show("Do you want to create a new lot? One existing lot has due capacity " + DuePack + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            //            {
                            //                //TotalLot = TotalLot + 1;
                            //            }
                            //            else
                            //            {
                            //                return;
                            //            }

                            //        }
                            //    }
                            //}
                            if (SchDayQTY < PerLotCone && TotalLot_lineWise <= 1 && Exceed_DueQTY == 0)
                            {
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, PrdCount, ScheduleDate, location_id) > 0)
                                {
                                    if (SchQTY_LotKg <= DuePack && UsedPackKg > 0)
                                    {
                                        IsEmptyLot = "YES";
                                        OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate);
                                    }
                                    else
                                    {
                                        //if (MessageBox.Show("Do you want to create a new lot? One existing lot has due capacity " + DuePack + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        //{
                                        //    //TotalLot = TotalLot + 1;
                                        //}
                                        //else
                                        //{
                                        //    return;
                                        //}

                                    }
                                }
                            }
                            //TotalPack = NetSchQTY / Convert.ToDecimal(txtMchKG.Text); // total kg
                            //if (TotalLot > DueLot)
                            //{
                            //    //MessageBox.Show("Current lot exceed lot limit (Due Lot =" + DueLot + ") of '" + cmbMachine.Text + "' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    //return;

                            //    throw new Exception("Current lot exceed lot limit (Due Lot =" + DueLot + ") of '" + cmbMachine.Text + "' ");
                            //}



                            //-------------------- Start Save part
                            if (IsEmptyLot == "YES" && TotalLot <= 1) // SchDayQTY < PerLotCone multiple row into a lot function 
                            {
                                // thread schedule main table data save
                                string[] Cols5 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                                string[] Vals5 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepID, CusID, location_id.ToString(), MachineId.ToString(), Shade, IsUrgent.ToString(), ScheduleDate, SchDayQTY.ToString(), "0", BrandId.ToString(), FamilyGroup, PrdCount,"0", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols5, Vals5, "INSERT", null, null);

                                //if (sql_master != "" && SchDayQTY > 0)
                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                    insertCount++;
                                }

                                // lot details table data save
                                string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                string[] Vals4 = { OldLotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }
                            }
                            else if (IsEmptyLot == "NO" && TotalLot > 0 & SchDayQTY < PerLotCone) // multiple row into a lot function 
                            {
                                uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
                                string Generate_LotNo = Get_LotNo(ScheduleDate, MachineId);
                                //LotNo = cmbMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
                                LotNo = Generate_LotNo;
                                // thread schedule main table data save
                                string[] Cols1 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                                string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepID, CusID, location_id.ToString(), MachineId.ToString(), Shade, IsUrgent.ToString(), ScheduleDate, NetSchQTY.ToString(), "0", BrandId.ToString(), FamilyGroup, PrdCount,"0", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols1, Vals1, "INSERT", null, null);
                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                }


                                //  lot table data save
                                string[] Cols2 = { "lot_no", "schedule_id", "shade", "machine_id", "schedule_date", "location_id" };
                                string[] Vals2 = { LotNo, schedule_id.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), location_id.ToString() };
                                sql_lot = dbConCrUser.CreateSQLStatement("thread_lot", Cols2, Vals2, "INSERT", null, null);

                                if (sql_lot != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                    insertCount++;
                                }

                                // lot details table data save
                                string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                string[] Vals4 = { LotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY == 0) // multiple row into a lot function 
                            {
                                // thread schedule main table data save
                                string[] Cols1 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                                string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepID, CusID, location_id.ToString(), MachineId.ToString(), Shade, IsUrgent.ToString(), ScheduleDate, NetSchQTY.ToString(), "0", BrandId.ToString(), FamilyGroup, PrdCount,"0", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                }

                                // lot details table data save
                                string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                string[] Vals4 = { OldLotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else if (IsEmptyLot == "YES" && TotalLot > 0 && SchDayQTY < PerLotCone) // multiple row into a lot function 
                            {
                                // thread schedule main table data save
                                string[] Cols1 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                                string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepID, CusID, location_id.ToString(), MachineId.ToString(), Shade, IsUrgent.ToString(), ScheduleDate, NetSchQTY.ToString(), "0", BrandId.ToString(), FamilyGroup, PrdCount,"0", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                }

                                // lot details table data save
                                string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                string[] Vals4 = { OldLotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else // single row or large qty into a lot function
                            {
                                // thread schedule main table data save
                                string[] Cols1 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                                string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepID, CusID, location_id.ToString(), MachineId.ToString(), Shade, IsUrgent.ToString(), ScheduleDate, NetSchQTY.ToString(), "0", BrandId.ToString(), FamilyGroup, PrdCount,"0", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                }


                                // Lot details save
                                uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
                                decimal PerLotSchQty = 0;
                                decimal DueLotSchQty = 0;
                                //for (int l = 0; l < TotalLot; l++)
                                for (int l = 0; l < TotalLot_lineWise; l++)
                                {
                                    string Generate_LotNo = Get_LotNo(ScheduleDate, MachineId);
                                    //LotNo = cmbMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
                                    LotNo = Generate_LotNo;
                                    //decimal PerLotSchQty = 0;
                                    if (l == 0)
                                    {
                                        DueLotSchQty = Math.Ceiling(NetSchQTY - PerLotCone);
                                        PerLotSchQty = Math.Ceiling(NetSchQTY - DueLotSchQty);
                                    }
                                    else
                                    {
                                        DueLotSchQty = DueLotSchQty - PerLotCone;
                                        PerLotSchQty = PerLotCone;
                                    }

                                    if (DueLotSchQty < 0)
                                    {
                                        //PerLotSchQty = PerLotCone + DueLotSchQty; 
                                        PerLotSchQty = NetSchQTY - PerLotSchQty;
                                    }
                                    decimal Used_PerLotKg = PerLotSchQty / ConePerPack;
                                    if (PerLotSchQty == PerLotCone)
                                    {
                                        //  lot table data save
                                        string[] Cols2 = { "lot_no", "schedule_id", "shade", "machine_id", "schedule_date", "location_id" };
                                        string[] Vals2 = { LotNo, schedule_id.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), location_id.ToString() };
                                        sql_lot = dbConCrUser.CreateSQLStatement("thread_lot", Cols2, Vals2, "INSERT", null, null);

                                        if (sql_lot != "")
                                        {
                                            dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                            insertCount++;
                                        }

                                        // lot details table data save
                                        string[] Cols3 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                        string[] Vals3 = { LotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), Used_PerLotKg.ToString(), PerLotSchQty.ToString() };
                                        sql_details = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols3, Vals3, "INSERT", null, null);
                                        if (sql_details != "")
                                        {
                                            dbConCrUser.DBExecuteScalarWithSQL(sql_details);
                                        }


                                    }

                                    // add under remaining lot
                                    if (l > 0)
                                    {
                                        if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY >= MinimumSchQty)
                                        {
                                            decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                            // lot details table data save
                                            string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                            string[] Vals4 = { OldLotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                            sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                            if (sql_details_2 != "")
                                            {
                                                dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                            }
                                        }
                                    }



                                }

                                if (IsEmptyLot == "YES" && Exceed_DueQTY <= MinimumSchQty)
                                {

                                    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                     // lot details table data save
                                    string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                    string[] Vals4 = { OldLotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                    sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                    if (sql_details_2 != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                        insertCount++;
                                    }
                                }
                                if (IsExtraLot == "YES" && IsEmptyLot == "NO" && Exceed_DueQTY >= MinimumSchQty)
                                {
                                    string Generate_LotNo = Get_LotNo(ScheduleDate, MachineId);
                                    //LotNo = cmbMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
                                    LotNo = Generate_LotNo;
                                    //  lot table data save
                                    string[] Cols2 = { "lot_no", "schedule_id", "shade", "machine_id", "schedule_date", "location_id" };
                                    string[] Vals2 = { LotNo, schedule_id.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), location_id.ToString() };
                                    sql_lot = dbConCrUser.CreateSQLStatement("thread_lot", Cols2, Vals2, "INSERT", null, null);

                                    if (sql_lot != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                        insertCount++;
                                    }

                                    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                   // lot details table data save
                                    string[] Cols4 = { "lot_no", "sub_booking_id", "shade", "machine_id", "schedule_id", "schedule_date", "used_pack", "used_cone" };
                                    string[] Vals4 = { LotNo, BookingSubId.ToString(), Shade, MachineId.ToString(), schedule_id.ToString(), ScheduleDate, Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                    sql_details_2 = dbConCrUser.CreateSQLStatement("thread_lot_details", Cols4, Vals4, "INSERT", null, null);
                                    if (sql_details_2 != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                        insertCount++;
                                    }
                                }

                            }
                        }

                    }//for grid row
                    if (insertCount > 0)
                    {
                        //Clear_Refresh();

                        lblDayTotal.Text = "0";
                        lblDayTotalLot.Text = "0";
                        lblTotalPack.Text = "0";
                        lblScheduledQty.Text = "0";
                        cmbMachine.Enabled = false;

                        Get_Lot_Capacity_UsedDataLoad();
                        Get_ScheduledQTY_Data();
                        gvListData.Rows.Clear();
                        Get_GridDataLoad();

                        Is_NotSamePage = 0;

                        MessageBox.Show("Confirm Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
      
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // unit schedule qty capacity check
                int Capacity_Qty = Bind_Unit_ScheduleQTY_Capacity();
                int Scheduled_Qty = Bind_Unit_ScheduledQTY_OnDate();
                int CurrentQTY = Convert.ToInt32(lblDayTotal.Text);
                int TotalQTY = Scheduled_Qty + CurrentQTY;
                if (TotalQTY > Capacity_Qty)
                {
                    int ExceedQty = TotalQTY - Capacity_Qty;
                    MessageBox.Show("Schedule QTY is more than unit capacity QTY.! Reduce " + ExceedQty + " QTY.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int Total_Lot = Convert.ToInt32(lblDayTotalLot.Text);
                if(Total_Lot > 1)
                {
                    MessageBox.Show("Lot (1) Exceed.! Reduce QTY.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                ///----- Exceed lot capacity validation
                string ScheduleDate = dtSchDate.Text;
                string Shade = txtShade.Text.Trim();
                string CountGroup = CountGroup_glb;
                DateTime sch_date_formated = dtSchDate.Value;
                int MachineId = Convert.ToInt32(cmbMachine.SelectedValue);
                int Assigned_MchLot = Get_Assigned_MchLot_OnSchDate(MachineId, sch_date_formated);
                int UsedLot = Get_UsedLot(MachineId, sch_date_formated);
                int NetLot = UsedLot + 1;
                if (NetLot > Assigned_MchLot)
                {
                    int LocationId = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                    int Is_RemainingLot = Check_IsExist_RemainingPack_Lot(MachineId, Shade, CountGroup, ScheduleDate, LocationId);
                    if (Is_RemainingLot == 0)
                    {
                        MessageBox.Show("Machine lot capacity exceed.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (Is_RemainingLot > 0)
                    {
                        decimal TotalPack_KG = Convert.ToDecimal(lblTotalPack.Text);
                        decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);

                        decimal UsedPack_KG = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, ScheduleDate, CountGroup);
                        decimal DuePack_KG = mch_maxKg - UsedPack_KG; // 10-8=2
                        if (TotalPack_KG > DuePack_KG) // 4>2
                        {
                            MessageBox.Show("Machine lot capacity exceed.! Reduce QTY.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Machine lot capacity exceed.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }// lot exceed


                // confirm/save part
                if (MessageBox.Show("Are you sure to save this schedule?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Confirm_Schedule();

                    //Delete_Block_Machine();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//

        private void btnViewSchBalance_Click(object sender, EventArgs e)
        {
            frmBookingCSView frm = new frmBookingCSView();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Delete_Block_Machine();
            this.Close();
        }
        public int Is_NotSamePage;
        public string _set_OrderId
        {
            //set { string job = value; }
            set { txtJob.Text = value; }
        }
        public string _set_Shade
        {
            //set { string shade = value; }
            set { txtShade.Text = value; }
        }
        public int _set_Is_NotSamePage
        {
            set { Is_NotSamePage = value; }
        }

    }
}
