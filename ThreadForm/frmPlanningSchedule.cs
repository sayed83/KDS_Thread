using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KDS_Thread.ThreadForm
{
    public partial class frmPlanningSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkEmergencyClm = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;

        public frmPlanningSchedule()
        {
            InitializeComponent();
        }

        private void frmPlanningSchedule_Load(object sender, EventArgs e)
        {
            gridJob.Visible = false;
            gridShade.Visible = false;
            //txtJob.Enabled = false;
            //txtShade.Enabled = false;
            //cmbSchMachine.Enabled = false;

            //cmbSearchType.SelectedItem = "Select";
            //cmbSchDate.Text = "Select";



            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(1);
            //dtFromDate.MinDate = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);
            //dtToDate.MinDate = DateTime.Now.AddDays(-1);

            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;

            dbConCrUser.FillComboBox(cmbOrdLocation, @"SELECT id,location_name FROM [dbo].[location] WHERE id IN (1,2,3)");

            chkUnitCTG.Checked = false;
            chkUnitDhaka.Checked = false;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            if (Unit == 1) // 1= CTG, 2=Dhaka
            {
                chkUnitCTG.Checked = true;
                chkUnitDhaka.Checked = false;

                cmbOrdLocation.SelectedValue = 1;
            }
            else
            {
                chkUnitCTG.Checked = false;
                chkUnitDhaka.Checked = true;

                cmbOrdLocation.SelectedValue = 2;
            }
            //int Unit = frmLogin.UserLocation.ToString();
            //int Unit = 1;
            //dbConCrUser.FillDataGridView(gridShade, @"SELECT DISTINCT shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND IsPlan=0 AND schedule_date='" + dtSchDate.Text + "'");

            dbConCrUser.FillComboBox(cmbPlanMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");
            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");
            Get_Shade_ByDateAndMachine();
            dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");

            cmbPlanMachine.SelectedItem = "Select";
            cmbSchMachine.SelectedItem = "Select";
            cmbProduct.SelectedValue = 0;

            Get_CountGroup_ByShadeJob();
            cmbCount.SelectedItem = "Select";

            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MMM-yyyy";
            dtPlanDate.Value = DateTime.Now.AddDays(1);
            dtPlanDate.MinDate = DateTime.Now;

            dbConCrUser.FillComboBox(cmbProduct, @"T_Get_WhiteProductByCount_Proc '" + cmbCount.Text.Trim() + "'");


            InitialDataGrid();
            Initial_UsedLotQty_DataGrid();


            if (Is_NotSamePage == 1)
            {
                txtShade.Enabled = false;
                txtJob.Enabled = false;
            }
        }//

       
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

                checkColumn2.Name = "X";
                checkColumn2.HeaderText = "";
                checkColumn2.Width = 30;
                checkColumn2.ReadOnly = false;
                checkColumn2.FillWeight = 10;
                gvListData.Columns.Add(checkColumn2);

                gvListData.Columns.Add("schedule_date", "Sch. Date");
                gvListData.Columns.Add("OrderId", "Booking No");
                gvListData.Columns.Add("Product", "Product");

                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("Machine", "Machine");
                gvListData.Columns.Add("cone_per_pack", "Cone Pack");
                //gvListData.Columns.Add("per_lot_cone", "Lot Cone");
                gvListData.Columns.Add("IsUrgent", "Priority");
                gvListData.Columns.Add("schedule_qty", "Schedule QTY");
                gvListData.Columns.Add("SchPKG", "KG");
                gvListData.Columns.Add("OrderQty", "Ord QTY");
                gvListData.Columns.Add("PlanQty", "Plan QTY");
                gvListData.Columns.Add("BalQty", "Balance QTY");
                gvListData.Columns.Add("FromStock", "From Stock");
                gvListData.Columns.Add("QTY", "QTY");
                gvListData.Columns.Add("PKG", "KG");
                

                gvListData.Columns["schedule_date"].Width = 80;
                gvListData.Columns["OrderId"].Width = 120;
                gvListData.Columns["Product"].Width = 160;
                gvListData.Columns["Color"].Width = 90;
                gvListData.Columns["Shade"].Width = 90;
                gvListData.Columns["Machine"].Width = 60;
                gvListData.Columns["cone_per_pack"].Width = 50;
                //gvListData.Columns["per_lot_cone"].Width = 70;
                gvListData.Columns["IsUrgent"].Width = 60;
                gvListData.Columns["schedule_qty"].Width = 60;
                gvListData.Columns["SchPKG"].Width = 50;
                //gvListData.Columns["StockQty"].Width = 50;
                gvListData.Columns["OrderQty"].Width = 50;
                gvListData.Columns["PlanQty"].Width = 60;
                gvListData.Columns["BalQty"].Width = 50;
                gvListData.Columns["FromStock"].Width = 50;
                gvListData.Columns["QTY"].Width = 60;
                gvListData.Columns["PKG"].Width = 60;

                gvListData.Columns["schedule_date"].ReadOnly = true;
                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Machine"].ReadOnly = true;
                gvListData.Columns["IsUrgent"].ReadOnly = true;
                gvListData.Columns["schedule_qty"].ReadOnly = true;
                gvListData.Columns["SchPKG"].ReadOnly = true;
                //gvListData.Columns["StockQty"].ReadOnly = true;
                gvListData.Columns["OrderQty"].ReadOnly = true;
                gvListData.Columns["PlanQty"].ReadOnly = true;
                gvListData.Columns["BalQty"].ReadOnly = true;
                //gvListData.Columns["FromStock"].ReadOnly = true;
                gvListData.Columns["QTY"].ReadOnly = true;
                gvListData.Columns["PKG"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\

                gvListData.Columns.Add("booking_sub_id", "booking_sub_id");
                gvListData.Columns["booking_sub_id"].Visible = false;

                gvListData.Columns.Add("ScheduleId", "ScheduleId");
                gvListData.Columns["ScheduleId"].Visible = false;

                gvListData.Columns.Add("location_id", "location_id");
                gvListData.Columns["location_id"].Visible = false;

                gvListData.Columns.Add("product_id", "product_id");
                gvListData.Columns["product_id"].Visible = false;

                gvListData.Columns.Add("Unit", "Unit");
                gvListData.Columns["Unit"].Visible = false;

                gvListData.Columns.Add("FamilyGroup", "FamilyGroup");
                gvListData.Columns["FamilyGroup"].Visible = false;

                gvListData.Columns.Add("PrdCount", "PrdCount");
                gvListData.Columns["PrdCount"].Visible = false;

                gvListData.Columns.Add("BrandId", "BrandId");
                gvListData.Columns["BrandId"].Visible = false;

                gvListData.Columns.Add("CS_SchId", "CS_SchId");
                gvListData.Columns["CS_SchId"].Visible = false;

                // gvListData.Columns["StockQty"].Visible = false;
                gvListData.Columns["FromStock"].Visible = false;

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
            gvListData.Rows.Clear();
            SqlDataReader dr;
            try
            {
                int CommId = 0;
                string Shade = txtShade.Text.Trim();
                string JobNo = txtJob.Text.Trim();
                int SchMachineId = Convert.ToInt32(cmbSchMachine.SelectedValue);
                //string SchDate = cmbSchDate.SelectedValue.ToString();
                DateTime FromDate = dtFromDate.Value;
                DateTime ToDate = dtToDate.Value;

                if (Shade == "")
                {
                    MessageBox.Show("Enter Shade..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int IsStockShade = 0;
                if (Check_IsShadeInStockList(Shade) == 1)
                {
                    IsStockShade = 1;
                   // gvListData.Columns["StockQty"].Visible = true;
                    gvListData.Columns["FromStock"].Visible = true;
                }

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_PlanningScheduleGv_Proc '" + JobNo + "','" + Shade + "','" + SchMachineId + "','" + FromDate + "','" + ToDate + "','" + CommId + "'");
                // gvListData.ReadOnly = true;
                int rows = 0;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();


                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();

                    gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = Convert.ToInt32(dr["schedule_qty"]);
                    //gvListData.Rows[rowAdd].Cells["StockQty"].Value = Convert.ToInt32(dr["StockQty"]);
                    gvListData.Rows[rowAdd].Cells["OrderQty"].Value = Convert.ToInt32(dr["OrderQty"]);
                    gvListData.Rows[rowAdd].Cells["PlanQty"].Value = Convert.ToInt32(dr["PlanQty"]);
                    gvListData.Rows[rowAdd].Cells["BalQty"].Value = Convert.ToInt32(dr["BalQty"]);
                    gvListData.Rows[rowAdd].Cells["cone_per_pack"].Value = dr["cone_per_pack"].ToString();
                    gvListData.Rows[rowAdd].Cells["SchPKG"].Value = dr["SchPKG"].ToString();
                    gvListData.Rows[rowAdd].Cells["PKG"].Value = dr["SchPKG"].ToString();
                    //gvListData.Rows[rowAdd].Cells["per_lot_cone"].Value = dr["per_lot_cone"].ToString();
                    gvListData.Rows[rowAdd].Cells["Machine"].Value = dr["Machine"].ToString();
                    gvListData.Rows[rowAdd].Cells["IsUrgent"].Value = dr["IsUrgent"].ToString();

                    gvListData.Rows[rowAdd].Cells["product_id"].Value = dr["product_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["booking_sub_id"].Value = dr["booking_sub_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["ScheduleId"].Value = dr["ScheduleId"].ToString();
                    gvListData.Rows[rowAdd].Cells["location_id"].Value = dr["location_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["Unit"].Value = dr["Unit"].ToString();
                    gvListData.Rows[rowAdd].Cells["FamilyGroup"].Value = dr["FamilyGroup"].ToString();
                    gvListData.Rows[rowAdd].Cells["PrdCount"].Value = dr["PrdCount"].ToString();
                    gvListData.Rows[rowAdd].Cells["BrandId"].Value = dr["BrandId"].ToString();
                    gvListData.Rows[rowAdd].Cells["CS_SchId"].Value = dr["ScheduleId"].ToString();


                    rowAdd++;

                    if(IsStockShade == 1)
                    {
                        //int StockQty = Convert.ToInt32(dr["StockQty"]);
                        //if (StockQty > 0)
                        //{
                        //    gvListData.Rows[rows].Cells["StockQty"].Style.ForeColor = Color.Blue;
                        //    //gvListData.Rows[rows].Cells["FromStock"].ReadOnly = false;
                        //    gvListData.Rows[rows].Cells["FromStock"].Style.BackColor = Color.LightGreen;
                        //    gvListData.Rows[rows].Cells["FromStock"].Style.Font = new Font("Calibri", 12F, FontStyle.Bold);

                        //}

                        gvListData.Rows[rows].Cells["FromStock"].Style.BackColor = Color.LightGreen;
                        gvListData.Rows[rows].Cells["FromStock"].Style.Font = new Font("Calibri", 12F, FontStyle.Bold);

                        rows++;
                    }

                }
                dr.Close();
                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private void Initial_UsedLotQty_DataGrid()
        {
            try
            {
                gvUsedCapacity.Columns.Clear();

                //================================= Second DataGrid View ===========================
                this.gvUsedCapacity.EnableHeadersVisualStyles = false;
                this.gvUsedCapacity.ColumnHeadersHeight = 50;
                gvUsedCapacity.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                gvUsedCapacity.Columns.Add("machine_name", "Machine");
                gvUsedCapacity.Columns.Add("capacity", "Cap.");
                gvUsedCapacity.Columns.Add("UsedLot", "Lot");
                gvUsedCapacity.Columns.Add("UsedQty", "Qty");

                gvUsedCapacity.Columns["machine_name"].Width = 80;
                gvUsedCapacity.Columns["capacity"].Width = 60;
                gvUsedCapacity.Columns["UsedLot"].Width = 60;
                gvUsedCapacity.Columns["UsedQty"].Width = 80;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        private void Get_UsedCapacity_GridDataLoad()
        {
            gvUsedCapacity.Rows.Clear();
            gvUsedCapacity.AllowUserToAddRows = false;
            SqlDataReader dr;
            try
            {
                int MachineId = 0;
                if (cmbPlanMachine.Text != "Select" || cmbPlanMachine.Text != "")
                {
                    try
                    {
                        MachineId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
                    }
                    catch { }

                }
                DateTime PlanDate = dtPlanDate.Value;

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_PlanUsed_Lot_QtyData_Proc '" + MachineId + "','" + PlanDate + "'");
                rowAdd = gvUsedCapacity.Rows.Count;
                while (dr.Read())
                {
                    gvUsedCapacity.Rows.Add();


                    gvUsedCapacity.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
                    gvUsedCapacity.Rows[rowAdd].Cells["capacity"].Value = dr["capacity"].ToString();
                    gvUsedCapacity.Rows[rowAdd].Cells["UsedLot"].Value = dr["UsedLot"].ToString();
                    gvUsedCapacity.Rows[rowAdd].Cells["UsedQty"].Value = dr["UsedQty"].ToString();

                    rowAdd++;

                }
                dr.Close();
                gvUsedCapacity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private void Get_Shade_ByDateAndMachine()
        {
            //int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            int Unit = 1; // CTG
            if(chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }

            DateTime FromDate = Convert.ToDateTime(dtFromDate.Value);
            DateTime ToDate = Convert.ToDateTime(dtToDate.Value);
            string Shade = txtShade.Text.Trim();
            int MchId = Convert.ToInt32(cmbSchMachine.SelectedValue);

            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_Shade_BySchDateAndMachine_Proc '" + FromDate + "','" + ToDate + "','" + MchId + "','" + Unit + "'");
        }//
        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            Get_Shade_ByDateAndMachine();
            //int Unit = frmLogin.UserLocation.ToString();
            int Unit = 1; // CTG
            if (chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }

            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;
            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            Get_Shade_ByDateAndMachine();
            //int Unit = frmLogin.UserLocation.ToString();
            int Unit = 1; // CTG
            if (chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }
            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;
            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");
        }
        private void cmbSearchType_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //int Unit = frmLogin.UserLocation.ToString();
            //    int Unit = 1;
            //    txtJob.Text = "";
            //    txtShade.Text = "";
            //    cmbSchMachine.SelectedIndex = 0;
            //    string SearchType = cmbSearchType.Text;
            //    if (SearchType != "Select")
            //    {
            //        if (SearchType == "Job")
            //        {
            //            txtJob.Enabled = true;
            //            //txtShade.Enabled = false;
            //            cmbSchMachine.Enabled = false;
            //            gridShade.Visible = false;
            //            dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND IsPlan=0");
            //        }
            //        else if (SearchType == "Shade")
            //        {
            //            txtShade.Enabled = true;
            //            txtJob.Enabled = false;
            //            cmbSchMachine.Enabled = false;
            //            gridJob.Visible = false;
            //            dbConCrUser.FillDataGridView(gridShade, @"SELECT DISTINCT shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND IsPlan=0");
            //        }
            //        else if (SearchType == "Machine") 
            //        {
            //            cmbSchMachine.Enabled = true;
            //            txtShade.Enabled = false;
            //            txtJob.Enabled = false;
            //            gridJob.Visible = false;
            //            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + dtFromDate.Text + "','" + Unit + "'");
            //        }
            //        else // schedule date
            //        {
            //            dtFromDate.Enabled = true;
            //            cmbSchMachine.Enabled = true;
            //            txtShade.Enabled = true;
            //            txtJob.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        txtJob.Enabled = false;
            //        //txtShade.Enabled = false;
            //        dtFromDate.Enabled = false;
            //        cmbSchMachine.Enabled = false;

            //        gridShade.Visible = false;
            //        gridJob.Visible = false;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }//
        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridJob.Focus();
            }
        }

        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gridJob.Visible = false;
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
                        gridShade.Visible = false;
                        var dataTable = (DataTable)gridJob.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gridJob.Visible = true;
                            dataView.RowFilter = "[" + gridJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";

                            //gridJob.DefaultCellStyle.BackColor = Color.Teal;
                            //gridJob.DefaultCellStyle.ForeColor = Color.Gold;
                        }

                        gridJob.RowHeadersVisible = false;
                        gridJob.Columns["OrderId"].Visible = true;

                        //// Set the column header text
                        gridJob.Columns["OrderId"].HeaderText = " Order ID";
                        //gridJob.Columns["OrderId"].ReadOnly = true;
                        gridJob.Columns["OrderId"].Width = 300;
                        gridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        gridJob.ColumnHeadersHeight = 60;
                        gridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    }

                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//

        public void Select_JobGrid_ToTextFiled()
        {
            if (gridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    gridJob.Visible = false;
                }
                txtJob.Focus();
                Get_CountGroup_ByShadeJob();
                //cmbSchDate.Text = "";
                //dbConCrUser.FillComboBox(cmbSchDate, @"T_Get_NonPlan_SchDateList_Proc '1','" + txtJob.Text.Trim() + "'");
            }
        }//
        private void txtJob_Enter(object sender, EventArgs e)
        {
            if(txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextFiled();
            }
            gridShade.Visible = false;
        }
        private void gridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }

        private void Get_CountGroup_ByShadeJob()
        {
            //int Unit = frmLogin.UserLocation.ToString();
            int Unit = 1; // CTG
            if (chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }
            dbConCrUser.FillComboBox_SingleColumn(cmbCount, @"SELECT 'Select' AS CountGroup
            UNION ALL
            SELECT DISTINCT LTRIM(RTRIM(PrdCount)) CountGroup
            FROM dbo.thread_schedule WHERE Shade='" + txtShade.Text.Trim() + "' AND OrderId='" + txtJob.Text.Trim() + "' AND Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");
        }
        private void txtShade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridShade.Focus();
            }
        }

        private void txtShade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gridShade.Visible = false;
            }
        }

        private void txtShade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtShade.Text.Trim() != "")
                {
                    if (Is_NotSamePage != 1)
                    {
                        gridJob.Visible = false;

                        var dataTable = (DataTable)gridShade.DataSource;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gridShade.Visible = true;
                            dataView.RowFilter = "[" + gridShade.Columns[0].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";

                            //gridShade.DefaultCellStyle.BackColor = Color.DarkOliveGreen;
                            //gridShade.DefaultCellStyle.ForeColor = Color.White;
                        }

                        //Hide row header
                        gridShade.RowHeadersVisible = false;
                        // Show the "shade_name" column
                        gridShade.Columns["shade"].Visible = true;

                        // Set the column header text
                        gridShade.Columns["shade"].HeaderText = " Shade";
                        //gridShade.Columns["shade"].ReadOnly = true;
                        gridShade.Columns["shade"].Width = 200;
                        gridShade.Columns["shade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gridShade.Columns["shade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        gridShade.ColumnHeadersHeight = 60;
                        gridShade.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gridShade.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public int BrandId_glb = 0;
        public void Select_ShadeGrid_ToTextfield()
        {
            if (gridShade.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridShade.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtShade.Text = cellValue.ToString();
                    gridShade.Visible = false;
                }
                txtShade.Focus();
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND Shade='" + txtShade.Text.Trim() + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");


                Get_CountGroup_ByShadeJob();

                string Brand = Select_BrandByShade();
                BrandId_glb = Get_BrandId(Brand);

                //cmbSchDate.Text = "";
                //dbConCrUser.FillComboBox(cmbSchDate, @"T_Get_NonPlan_SchDateList_Proc '2','" + txtShade.Text.Trim() + "'");
            }
        }//
        private void txtShade_Enter(object sender, EventArgs e)
        {
            if(txtShade.Text.Trim() != "")
            {
                Select_ShadeGrid_ToTextfield();
            }
            gridJob.Visible = false;
        }
        private void gridShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
        }

        public void clearField()
        {

            gvListData.Rows.Clear();
            InitialDataGrid();


            //cmbSearchType.SelectedItem = "Select";
            cmbSchMachine.SelectedItem = "Select";
            cmbPlanMachine.SelectedIndex = 0;
            cmbProduct.SelectedIndex = 0;

            txtJob.Text = "";
            txtShade.Text = "";
            txtStockQty.Text = "0";
            txtMchKG.Text = "0";
            txtMinKG.Text = "";
            //txtPackage.Text = "";

            lblDayTotal.Text = "0";
            lblDayTotalLot.Text = "0";
            lblTotalPack.Text = "0";

            //txtJob.Enabled = false;
            //txtShade.Enabled = false;
            //cmbSchMachine.Enabled = false;

            //dtFromDate.Enabled = false;
            dtFromDate.Text = "";
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(1);
            dtFromDate.MinDate = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);
            dtToDate.MinDate = DateTime.Now.AddDays(-1);

            dtPlanDate.Text = "";
            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MMM-yyyy";
            dtPlanDate.Value = DateTime.Now.AddDays(1);
            dtPlanDate.MinDate = DateTime.Now;

            gridJob.Visible = false;
            gridShade.Visible = false;

            gvUsedCapacity.Rows.Clear();
            Initial_UsedLotQty_DataGrid();

            Get_CountGroup_ByShadeJob();
            cmbCount.SelectedIndex = 0;

            txtJob.Enabled = true;
            txtShade.Enabled = true;

            BrandId_glb = 0;


        }//
        public int Get_ScheduleDate_OnOff(DateTime SchDate)
        {
            int count = 0;
            int Unit = 1;
            if (chkUnitDhaka.Checked == true)
            {
                Unit = 2;
            }
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.Schedule_OnOff WHERE Unit='"+ Unit + "' AND  schedule_date='" + SchDate + "' AND sch_status='OFF'");
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
        public void Get_Machine_Lot_KG()
        {
            SqlDataReader dtRdr;
            int MachineId = 0;
            try
            {
                if (cmbPlanMachine.Text != "Select" || cmbPlanMachine.Text != "")
                {
                    try
                    {
                        MachineId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
                    }
                    catch { }

                }

                SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Machine_Lot_KG_Proc '" + MachineId + "' ");

                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
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

        public void Sum_TotalSchQTY_KG()
        {
            decimal sumQTY = 0;
            decimal SumPack_KG = 0;
            decimal SumLot = 0;
            int Sum_StockQty = 0;
            int count = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                if (c >= 0)
                {
                    try
                    {
                        //DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                        bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[c].Cells["X"].Value);
                        if (checkBoxStatus)
                        {
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value) > 0)
                            {
                                count++;

                                decimal QTY = Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value.ToString());
                                sumQTY += QTY;
                                lblDayTotal.Text = sumQTY.ToString();

                                decimal conePack = Convert.ToDecimal(gvListData.Rows[c].Cells["cone_per_pack"].Value);
                                SumPack_KG += decimal.Round(QTY / conePack, 2); // 40/8=5kg
                                lblTotalPack.Text = SumPack_KG.ToString();

                                SumLot = Math.Ceiling(SumPack_KG / Convert.ToDecimal(txtMchKG.Text));
                                lblDayTotalLot.Text = SumLot.ToString();
                            }
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["FromStock"].Value) > 0)
                            {
                                int FromStock = Convert.ToInt32(gvListData.Rows[c].Cells["FromStock"].Value.ToString());
                                Sum_StockQty += FromStock;
                                lblSumStockQty.Text = Sum_StockQty.ToString();
                            }
                        }
                        if (count == 0)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }
        public int Check_IsShadeInStockList(string Shade)
        {
            int IsExists = 0;
            if(Shade == "WHITE" || Shade == "BWHITE" || Shade == "FWHITE" 
                || Shade == "BLACK" || Shade == "TBLACK")
            {
                IsExists = 1;
            }
            return IsExists;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblDayTotal.Text = "0";
            lblDayTotalLot.Text = "0";
            lblTotalPack.Text = "0";

            try
            {
                //string SearchType = cmbSearchType.Text;
                //if (SearchType == "Select")
                //{
                //    MessageBox.Show("Select valid search type..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (SearchType == "Job")
                //{
                //    if (txtJob.Text.Trim() == "")
                //    {
                //        MessageBox.Show("Enter Job No..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                string Shade = txtShade.Text.Trim();
                if (Shade == "")
                {
                    MessageBox.Show("Enter Shade..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Check_IsShadeInStockList(Shade) == 1)
                {
                    if (txtJob.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Job For " + Shade + " Shade (Stock Type Shade)..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

                if (Get_ScheduleDate_OnOff(dtPlanDate.Value) > 0)
                {
                    MessageBox.Show("Schedule off on your selected date.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbPlanMachine.Text.Trim() == "Select")
                {
                    MessageBox.Show("Select Plan Machine..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Get_GridDataLoad();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                gvListData.BeginEdit(true);
                if (e.ColumnIndex == 0)
                {
                    gvListData.EndEdit();

                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    //DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    if (checkBoxStatus)
                    {
                        decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);
                        decimal BalQty = Convert.ToDecimal(row.Cells["BalQty"].Value);
                        //decimal PerLotCone = Convert.ToDecimal(gvListData.Rows[e.RowIndex].Cells["per_lot_cone"].Value.ToString());
                        decimal ConePerPack = Convert.ToDecimal(row.Cells["cone_per_pack"].Value);
                        decimal PerLotCone = Math.Ceiling(ConePerPack * mch_maxKg);

                        int BalQty_Int = Convert.ToInt32(BalQty);
                        //int PerLotCone_Int = Convert.ToInt32(PerLotCone);
                        row.Cells["QTY"].Style.BackColor = Color.HotPink;
                        row.Cells["QTY"].Style.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        row.Cells["QTY"].ReadOnly = false;
                        //row.Cells["QTY"].Value = BalQty_Int;

                        row.Cells["PKG"].Style.BackColor = Color.LightGreen;
                        row.Cells["PKG"].Style.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        row.Cells["PKG"].ReadOnly = false;

                        decimal TotalPack = Convert.ToDecimal(lblTotalPack.Text);
                        decimal due_kg = mch_maxKg - TotalPack; // 10kg - 8kg=2kg
                        decimal req_qty = Math.Ceiling(ConePerPack * due_kg); // 10*2kg=20
                        if (BalQty >= PerLotCone && req_qty > 0) //100>=40
                        {
                            row.Cells["QTY"].Value = req_qty;
                        }
                        else
                        {
                            if (req_qty >= BalQty && req_qty > 0) // 20 > 5
                            {
                                row.Cells["QTY"].Value = BalQty;
                            }
                            else if(req_qty < BalQty && req_qty > 0)
                            {
                                row.Cells["QTY"].Value = req_qty;
                            }
                            else
                            {
                                MessageBox.Show("Lot capacity(KG) exceed..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        }
                    }
                    else
                    {
                        row.Cells["QTY"].Value = "";
                        row.Cells["QTY"].Style.BackColor = Color.White;
                        row.Cells["QTY"].ReadOnly = true;

                        row.Cells["PKG"].Value = "";
                        row.Cells["PKG"].Style.BackColor = Color.White;
                        row.Cells["PKG"].ReadOnly = true;

                        Sum_TotalSchQTY_KG();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvListData.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    //DataGridViewRow selectedRow = gvListData.SelectedRows[0];

                    // Get the value of the checkbox cell in the selected row
                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    if (checkBoxStatus)
                    {
                        decimal BlncQty = Convert.ToDecimal(row.Cells["BalQty"].Value);
                        int BlncQty_Int = Convert.ToInt32(BlncQty);
                        if (Convert.ToString(row.Cells["QTY"].Value) != "")
                        {
                            int Qty = Convert.ToInt32(row.Cells["QTY"].Value);
                            if (Qty > BlncQty_Int)
                            {
                                row.Cells["QTY"].Value = 0;
                                MessageBox.Show("Plan QTY is more than balance QTY..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            Sum_TotalSchQTY_KG();

                            // --- From Stock
                            int IsStockTypeShade = Check_IsShadeInStockList(txtShade.Text.Trim());
                            if (IsStockTypeShade == 1)
                            {
                                //int StockQty = Convert.ToInt32(row.Cells["StockQty"].Value);
                                int TotalStockQty = Convert.ToInt32(lblSumStockQty.Text);
                                int StockQty = Convert.ToInt32(txtStockQty.Text);
                                int FromStock = Convert.ToInt32(row.Cells["FromStock"].Value);
                                if (Convert.ToString(row.Cells["FromStock"].Value) != "")
                                {
                                    if(StockQty > TotalStockQty) // 2500>200
                                    {
                                        if (FromStock > BlncQty_Int) // 120>100
                                        {
                                            row.Cells["FromStock"].Value = "";
                                            MessageBox.Show("QTY is more than balance QTY..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    else if (TotalStockQty > StockQty) // 1200>500
                                    {
                                        row.Cells["FromStock"].Value = "";
                                        MessageBox.Show("QTY is more than Stock..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                }
                            }// stock part

                            /// new added validation for only 1 lot
                            decimal TotalPack_KG = Convert.ToDecimal(lblTotalPack.Text);
                            decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);
                            if (TotalPack_KG > mch_maxKg)
                            {
                                row.Cells["QTY"].Value = "";
                                MessageBox.Show("Lot capacity("+ mch_maxKg + " KG) exceed..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }//

                           
                        }

                    }
                }// if
            }
            catch
            {

            }

        }//
        
        private void cmbPlanMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanMachine.Text != "Select" || cmbPlanMachine.Text != "")
            {
                Get_Machine_Lot_KG();
                Get_UsedCapacity_GridDataLoad();
            }
        }//

        private void dtSchDate_ValueChanged(object sender, EventArgs e)
        {
            //txtShade.Text = "";
            //gridShade.Visible = false;

            //int Unit = frmLogin.UserLocation.ToString();
            //int Unit = 1;
            //dbConCrUser.FillDataGridView(gridShade, @"SELECT DISTINCT shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND IsPlan=0 AND schedule_date='" + dtSchDate.Text + "'");
            //dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + dtSchDate.Text + "','" + Unit + "'");

        }

        public int Get_UsedLot(string ScheduleDate)
        {
            int UsedLot = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) used_lot FROM dbo.Plan_Lot WHERE MchId = '" + cmbPlanMachine.SelectedValue + "' AND  PlanDate = '" + ScheduleDate + "'");

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
        public int Get_Assigned_MchLot_OnSchDate(string SchDate)
        {
            int count = 0;
            int machine_id = Convert.ToInt32(cmbPlanMachine.SelectedValue);
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT capacity FROM dbo.machine_capacity WHERE machine_id='" + machine_id + "' AND schedule_date='" + SchDate + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    count = Convert.ToInt32(dr["capacity"].ToString());
                }
            }
            dr.Close();
            return count;
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
                            decimal cone_per_pack = Convert.ToDecimal(gvListData.Rows[c].Cells["cone_per_pack"].Value.ToString());
                            decimal SchQTY = Convert.ToDecimal(gvListData.Rows[c].Cells["QTY"].Value.ToString());
                            Total_PackKG += decimal.Round(SchQTY / cone_per_pack, 2);
                        }

                    }

                }

            }// for
            return Total_PackKG;
        }//
        public decimal Get_UsedPackInMachine_OnSchDate(int machine_id, string PlanDate)
        {
            decimal pack = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT SUM(d.UsedPack) used_pack FROM dbo.Plan_Schedule s " +
                "LEFT JOIN dbo.Plan_Lot_Details d ON s.id=d.PlanSchId " +
                "WHERE s.MachineId='" + machine_id + "'  AND s.PlanDate='" + PlanDate + "'");
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
        public int Check_IsExist_RemainingPack_Lot(int MachineId, string Shade, string ScheduleDate, int LocationId, int BrandId)
        {
            int count = 0;
            int CommId = 1;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Plan_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + LocationId + "','" + BrandId + "','" + CommId + "'");

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
        public string Bind_RemainingPack_LotNo(int MachineId, string Shade, string ScheduleDate, int LocationId, int BrandId)
        {
            string LotNo = "";
            int CommId = 2;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Plan_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + LocationId + "','" + BrandId + "','" + CommId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    LotNo = dr["LotNo"].ToString();
                }
            }

            dr.Close();
            return LotNo;
        }//
        public decimal Bind_UsedPack_KG_GroupByLot(int MachineId, string Shade, string ScheduleDate, int LocationId, int BrandId)
        {
            decimal used_pack = 0;
            int CommId = 3;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Plan_RemainingPack_LotNo_Proc '" + MachineId + "','" + Shade + "','" + ScheduleDate + "','" + LocationId + "','" + BrandId + "','" + CommId + "'");
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

        public decimal Bind_LotUsedPack_KG(string LotNo, int MachineId)
        {
            decimal used_pack = 0;
            int CommId = 2;
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
        public decimal Bind_Machine_UsedPackOnDate_KG(DateTime SchDate,int MachineId,int locationId)
        {
            decimal used_pack = 0;
            int CommId = 2; // Planning
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_Machine_UsedPackOnDate_Proc '" + SchDate + "','" + MachineId + "','"+ locationId + "','" + CommId + "'");

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
        public string Get_DyeLotNo(string SchDate, int machineId)
        {
            string LOTNO = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Generate_DyeLotNo_Proc '" + SchDate + "','" + machineId + "'");

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
            else
            {
                Id = 7; //Filament
            }
            return Id;
        }
        public int Get_Assigned_MchLot_OnSchDate(int machine_id, DateTime SchDate)
        {
            int count = 0;
            //int location_id = Convert.ToInt32(frmLogin.UserLocation.ToString());
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
            //int location_id = Convert.ToInt32(frmLogin.UserLocation.ToString());
            int location_id = Convert.ToInt32(cmbOrdLocation.SelectedValue);
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(LotNo) cnt FROM dbo.Plan_Lot WHERE LocationId='" + location_id + "' AND MchId= '" + machine_id + "' AND PlanDate='" + SchDate + "'");
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
        public void Update_Schedule_IsPlan(int schedule_id)
        {
            int IsPlan = 1;
            string[] Cols = { "IsPlan" };
            string[] Vals = { IsPlan.ToString() };
            string[] WhCols = { "id" };
            string[] WhVals = { schedule_id.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("thread_schedule", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
       public void Stock_Insert_RFD(string OrderId,int BookingSubId, int ProductId,string Shade, int QTY, string ScheduleDate, int PlanSchId, int Unit, string EntryBy)
        {
            //-------- Insert in RFD Table
            string[] Cols_RFD = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "PKQty", "DesQTY", "Shift", "DesDate", "PlanSchId", "UnitId", "EntryBy", "EntryDate" };
            string[] Vals_RFD = { "STK", OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, "0", QTY.ToString(), "1", ScheduleDate, PlanSchId.ToString(), Unit.ToString(), EntryBy, DateTime.Now.ToString() };
            string sql_RFD = dbConCrUser.CreateSQLStatement("ThreadDES", Cols_RFD, Vals_RFD, "INSERT", null, null);
            dbConCrUser.DBExecuteScalarWithSQL(sql_RFD);
        }
        public void Confirm_Plan()
        {
            string sql_master = "";
            string sql_details = "";
            string sql_details_2 = "";
            string sql_lot = "";
            int schedule_id = 0;
            string LotNo = "";

            int gridRow = 0;

            int Lot = 0;

            int MachineId = 0;
            int BookingId = 0;
            int BookingSubId = 0;
            int ProductId = 0;
            int Unit = 0;
            int BrandId = 0;

            int CS_SchQty = 0;
            string OrderId = "";
            string Shade = "";
            string Color = "";
            string FamilyGroup = "";
            string PrdCount = "";
            decimal ConePerPack = 0;
            decimal PerLotCone = 0;
            int FromStockQTY = 0;
            decimal BalanceQty = 0;
            string ScheduleDate = "";
            decimal DueQTY = 0;
            decimal TotalPack = 0;
            decimal SchDayQTY = 0;
            decimal TotalScheduleQTY = 0;
            decimal PKG = 0;
            int CS_SchId = 0;

            bool checkBoxStatus = false;
            int LocationId = 0;
            int insertCount = 0;

            try
            {
                string EntryBy = frmLogin.UserID.ToString();
                //Unit = frmLogin.UserLocation.ToString();
                LocationId = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //LocationId = 1;
                //string EntryBy = "arif";
                MachineId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
                decimal machine_capacity = Convert.ToDecimal(txtMchKG.Text);
                ScheduleDate = dtPlanDate.Text;
                //PKG = Convert.ToDecimal(txtPackage.Text);
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
                            try
                            {

                                OrderId = gvListData.Rows[i].Cells["OrderId"].Value.ToString();
                                Shade = gvListData.Rows[i].Cells["Shade"].Value.ToString();
                                //PKG = Convert.ToDecimal(gvListData.Rows[i].Cells["PKG"].Value.ToString());

                                CS_SchQty = Convert.ToInt32(gvListData.Rows[i].Cells["schedule_qty"].Value.ToString());
                                ConePerPack = Convert.ToDecimal(gvListData.Rows[i].Cells["cone_per_pack"].Value.ToString());
                                //PerLotCone = Convert.ToDecimal(gvListData.Rows[i].Cells["per_lot_cone"].Value.ToString());
                                PerLotCone = ConePerPack * machine_capacity;
                            }
                            catch { }

                            //// int Id
                            if (Check_IsShadeInStockList(Shade) == 1)
                            {
                                if (Convert.ToString(gvListData.Rows[i].Cells["FromStock"].Value) != "")
                                {
                                    FromStockQTY = Convert.ToInt32(gvListData.Rows[i].Cells["FromStock"].Value.ToString());
                                }
                            }
                            PKG = Convert.ToDecimal(gvListData.Rows[i].Cells["PKG"].Value.ToString());
                            Unit = Convert.ToInt32(gvListData.Rows[i].Cells["Unit"].Value.ToString());
                            BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["booking_sub_id"].Value.ToString());
                            LocationId = Convert.ToInt32(gvListData.Rows[i].Cells["location_id"].Value.ToString());
                            ProductId = Convert.ToInt32(gvListData.Rows[i].Cells["product_id"].Value.ToString());
                            schedule_id = Convert.ToInt32(gvListData.Rows[i].Cells["ScheduleId"].Value.ToString());
                            FamilyGroup = gvListData.Rows[i].Cells["FamilyGroup"].Value.ToString();
                            PrdCount = gvListData.Rows[i].Cells["PrdCount"].Value.ToString();
                            BrandId = Convert.ToInt32(gvListData.Rows[i].Cells["BrandId"].Value.ToString());
                            CS_SchId = Convert.ToInt32(gvListData.Rows[i].Cells["CS_SchId"].Value.ToString());


                            /// schedule date & qty details save
                            //ScheduleDate = dtPlanDate.Value;
                            SchDayQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value);
                            // decimal Total_SumDayQTY = Check_Sum_TotalSchQTY(ScheduleDate);

                            //----------- Used & Due Lot Part
                            int UsedLot = Get_UsedLot(ScheduleDate);
                            int Lot_PerDay = Get_Assigned_MchLot_OnSchDate(ScheduleDate);
                            int DueLot = Lot_PerDay - UsedLot;

                            decimal FullDay_MachineKG = DueLot * machine_capacity;
                            decimal assignLot_KG = Lot_PerDay * machine_capacity; // 4*10=40kg
                            decimal UsedPack_InAssignLot = Math.Ceiling(Get_UsedPackInMachine_OnSchDate(MachineId, ScheduleDate));
                            decimal DueKG = assignLot_KG - UsedPack_InAssignLot; // 40kg-10kg=30kg

                            //--------------- Date wise pack check
                            TotalPack = Sum_Total_Pack(ScheduleDate); // total pack kg                                   
                            //Lot = (int)Math.Ceiling(CalculateLot(MachineId, TotalPack)); //lot exceed check
                            if (TotalPack > FullDay_MachineKG)
                            {
                                if (DueKG <= 0)
                                {
                                    throw new Exception("" + cmbPlanMachine.Text + " machine capacity exceed on this " + ScheduleDate + " date!!. ");
                                }
                            }

                            // check current lot exceed due lot
                            decimal MaximumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMchKG.Text));
                            decimal MinimumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMinKG.Text));

                            decimal TotalLot = Math.Ceiling(TotalPack / machine_capacity); // (27/5=6) day kg/mchKg to lot 
                            decimal TotalLot_lineWise = Math.Ceiling(SchDayQTY / PerLotCone); // day Qty to lot 
                            decimal TotalPack_lineWise = Math.Ceiling(SchDayQTY / ConePerPack);

                            if (TotalPack < Convert.ToDecimal(txtMinKG.Text))
                            {
                                // checking if exists lot has enough pack for this QTY
                                if (Convert.ToDecimal(txtMchKG.Text) > 1)
                                {
                                    if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) == 0)
                                    {
                                        throw new Exception("Enter minimum capacity QTY for one lot.!! ");
                                    }
                                }


                            }
                            //------------ exceed qty calculation
                            decimal Exceed_DueQTY = 0;
                            if (TotalLot_lineWise > 0)
                            {

                                if (TotalLot_lineWise == 1 && SchDayQTY > PerLotCone) // 90>80
                                {
                                    Exceed_DueQTY = SchDayQTY - PerLotCone; // exceed=10
                                }
                                if (TotalLot_lineWise > 1 && SchDayQTY > PerLotCone) // 240>200
                                {
                                    Exceed_DueQTY = SchDayQTY % PerLotCone; //200%80=40
                                }
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
                            decimal UsedPackKg = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, ScheduleDate, LocationId, BrandId);
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
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) == 0)
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
                                        OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
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
                            if (Exceed_DueQTY > 0 && PerLotCone > Exceed_DueQTY)
                            {
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) > 0)
                                {
                                    OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
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

                            if (SchDayQTY < PerLotCone && TotalLot_lineWise <= 1 && Exceed_DueQTY == 0)
                            {
                                if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) > 0)
                                {
                                    if (SchQTY_LotKg <= DuePack && UsedPackKg > 0)
                                    {
                                        IsEmptyLot = "YES";
                                        OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
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

                            //-------------------- Start Save part
                            if (IsEmptyLot == "YES" && TotalLot <= 1) // SchDayQTY < PerLotCone multiple row into a lot function 
                            {
                                // plan schedule main table data save
                                string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "CS_SchId", "EntryBy", "EntryDate" };
                                string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromStockQTY.ToString(), NetSchQTY.ToString(), PKG.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, CS_SchId.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

                                //if (sql_master != "" && SchDayQTY > 0)
                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
                                    insertCount++;

                                    Update_Schedule_IsPlan(CS_SchId);

                                }

                                // lot details table data save
                                string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }
                            }
                            else if (IsEmptyLot == "NO" && TotalLot > 0 & SchDayQTY < PerLotCone) // multiple row into a lot function 
                            {
                                // uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
                                string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
                                //LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
                                LotNo =  Generate_LotNo;
                                // plan schedule main table data save
                                string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "CS_SchId", "EntryBy", "EntryDate" };
                                string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromStockQTY.ToString(), NetSchQTY.ToString(), PKG.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount,CS_SchId.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);
                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

                                    Update_Schedule_IsPlan(CS_SchId);
                                }


                                //  lot table data save
                                string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate" };
                                string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate };
                                sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

                                if (sql_lot != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                    insertCount++;
                                }

                                // lot details table data save
                                string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                string[] Vals4 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY == 0) // multiple row into a lot function 
                            {
                                // plan schedule main table data save
                                string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "CS_SchId", "EntryBy", "EntryDate" };
                                string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromStockQTY.ToString(), NetSchQTY.ToString(), PKG.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount,CS_SchId.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

                                    Update_Schedule_IsPlan(CS_SchId);
                                }

                                // lot details table data save
                                string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else if (IsEmptyLot == "YES" && TotalLot > 0 && SchDayQTY < PerLotCone) // multiple row into a lot function 
                            {
                                // plan schedule main table data save
                                string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "CS_SchId", "EntryBy", "EntryDate" };
                                string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromStockQTY.ToString(), NetSchQTY.ToString(), PKG.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount,CS_SchId.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

                                    Update_Schedule_IsPlan(CS_SchId);
                                }

                                // lot details table data save
                                string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
                                sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                if (sql_details_2 != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    insertCount++;
                                }

                            }
                            else // single row or large qty into a lot function
                            {
                                // plan schedule main table data save
                                string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "CS_SchId", "EntryBy", "EntryDate" };
                                string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromStockQTY.ToString(), NetSchQTY.ToString(), PKG.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount,CS_SchId.ToString(), EntryBy, DateTime.Now.ToString() };
                                sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

                                if (sql_master != "")
                                {
                                    sql_master += "SELECT SCOPE_IDENTITY();";
                                    schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

                                    Update_Schedule_IsPlan(CS_SchId);
                                }


                                // Lot details save
                                // uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
                                decimal PerLotSchQty = 0;
                                decimal DueLotSchQty = 0;
                                //for (int l = 0; l < TotalLot; l++)
                                for (int l = 0; l < TotalLot_lineWise; l++)
                                {
                                    string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
                                    //LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
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
                                        string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate" };
                                        string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate };
                                        sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

                                        if (sql_lot != "")
                                        {
                                            dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                            insertCount++;
                                        }

                                        // lot details table data save
                                        string[] Cols3 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                        string[] Vals3 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Used_PerLotKg.ToString(), PerLotSchQty.ToString() };
                                        sql_details = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols3, Vals3, "INSERT", null, null);
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
                                            string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                            string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                            sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                            if (sql_details_2 != "")
                                            {
                                                dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                            }
                                        }
                                    }

                                    //if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY >= MinimumSchQty)
                                    //{
                                    //    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                    //                                                        // lot details table data save
                                    //    string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                    //    string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                    //    sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                    //    if (sql_details_2 != "")
                                    //    {
                                    //        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                    //    }
                                    //}


                                }

                                if (IsEmptyLot == "YES" && Exceed_DueQTY <= MinimumSchQty)
                                {

                                    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                                                                        // lot details table data save
                                    string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                    string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                    sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                    if (sql_details_2 != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                        insertCount++;
                                    }
                                }
                                if (IsExtraLot == "YES" && IsEmptyLot == "NO" && Exceed_DueQTY >= MinimumSchQty)
                                {
                                    string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
                                    //LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
                                    LotNo = Generate_LotNo;
                                    //  lot table data save
                                    string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate"};
                                    string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate };
                                    sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

                                    if (sql_lot != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
                                        insertCount++;
                                    }

                                    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
                                    // lot details table data save
                                    string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
                                    string[] Vals4 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate, Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
                                    sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
                                    if (sql_details_2 != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
                                        insertCount++;
                                    }
                                }

                            }
                            // minus stock qty
                            if(FromStockQTY > 0)
                            {
                                string[] Cols1 = { "Shade", "CountGroup", "QTY", "Status", "PlanSchDate", "Unit", "EntryBy", "EntryDate" };
                                string[] Vals1 = { Shade, cmbCount.Text.Trim(), FromStockQTY.ToString(), "OUT", ScheduleDate ,Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                string sql = dbConCrUser.CreateSQLStatement("Stock_Main", Cols1, Vals1, "INSERT", null, null);
                                if (sql != "")
                                {
                                    dbConCrUser.DBExecuteScalarWithSQL(sql);
                                }

                                ////--- Insert Into RFD

                                Stock_Insert_RFD(OrderId, BookingSubId, ProductId, Shade, FromStockQTY, ScheduleDate, schedule_id, Unit, EntryBy);
                                //if (FromStockQTY > 0)
                                //{
                                //    Stock_Insert_RFD(OrderId, BookingSubId, ProductId, Shade, FromStockQTY, ScheduleDate, schedule_id, Unit, EntryBy);
                                //}
                            }
                        }// if checkbox

                    }//for grid row
                    if (insertCount > 0)
                    {
                        lblDayTotal.Text = "0";
                        lblDayTotalLot.Text = "0";
                        lblTotalPack.Text = "0";
                        //clearField();
                        Get_UsedCapacity_GridDataLoad();

                        gvListData.Rows.Clear();
                        Get_GridDataLoad();
                        Get_StockQty(Shade, Convert.ToInt32(cmbProduct.SelectedValue), Unit);

                        txtJob.Enabled = true;
                        txtShade.Enabled = true;
                        txtJob.Text = "";
                        txtShade.Text = "";


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

                //if (txtPackage.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Package..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (Convert.ToDecimal(lblTotalPack.Text.Trim()) > Convert.ToDecimal(txtMchKG.Text.Trim()))
                {
                    MessageBox.Show("Total KG exceed machine capacity..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //----- Check is lot exceed set capacity 
                DateTime sch_date_formated = dtPlanDate.Value;
                int MachineId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
                int Assigned_MchLot = Get_Assigned_MchLot_OnSchDate(MachineId, sch_date_formated);
                int UsedLot = Get_UsedLot(MachineId, sch_date_formated);
                int NetLot = UsedLot + 1;
                if (NetLot > Assigned_MchLot)
                {
                    string Shade = txtShade.Text.Trim();
                    string PlanSchDate = dtPlanDate.Text;
                    decimal mch_maxKg = Convert.ToDecimal(txtMchKG.Text);
                    decimal CurrentTotal_KG = Convert.ToDecimal(lblTotalPack.Text); /// 20
                    ///int LocationId = Convert.ToInt32(frmLogin.UserLocation.ToString());
                    int LocationId = Convert.ToInt32(cmbOrdLocation.SelectedValue);
                    int Is_RemainingLot = Check_IsExist_RemainingPack_Lot(MachineId, Shade, PlanSchDate, LocationId, BrandId_glb);
                    
                    if (Is_RemainingLot == 0)
                    {
                        MessageBox.Show("Machine lot capacity exceed.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (Is_RemainingLot > 0)
                    {
                        decimal UsedPack_KG = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, PlanSchDate, LocationId, BrandId_glb);
                        decimal DuePack_KG = mch_maxKg - UsedPack_KG; // 10-8=2
                        if (CurrentTotal_KG > DuePack_KG) // 4>2
                        {
                            MessageBox.Show("Machine lot capacity exceed.! Reduce QTY.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Machine lot capacity exceed.! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }//

                if (MessageBox.Show("Are you sure to save this schedule?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Confirm_Plan();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void txtPackage_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txtPackage.Text, "[^0-9.]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    txtPackage.Text = txtPackage.Text.Remove(txtPackage.Text.Length - 1);
            //}
        }//
        private void Get_StockQty(string Shade, int ProductId, int Unit)
        {
            //int StockQTY = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_StockQtyByProduct_Proc '" + Shade + "','" + ProductId + "','" + Unit + "' ");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtStockQty.Text = dr["StockQty"].ToString();
                }
            }

            dr.Close();
            //return StockQTY;
        }//
        private void cmbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                string Count = cmbCount.Text.Trim().ToString();
                //if (Count == "Select")
                //{
                //    MessageBox.Show("Select Count..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (Count != "Select" && Count.Length > 2 && Count.Length < 10)
                {
                    string Shade = txtShade.Text.Trim();
                    //int StockQty = Get_StockQty(Shade, Count, Unit);
                    //txtStockQty.Text = StockQty.ToString();
                    //Get_StockQty(Shade, Count, Unit);

                    dbConCrUser.FillComboBox(cmbProduct, @"T_Get_WhiteProductByCount_Proc '" + Count + "'");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                string Shade = txtShade.Text.Trim();
                string Count = cmbCount.Text.Trim().ToString();
                if(Count != "Select")
                {
                    int ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
                    if (ProductId > 0)
                    {
                        Get_StockQty(Shade, ProductId, Unit);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkUnitCTG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnitCTG.Checked == true)
            {
                chkUnitDhaka.Checked = false;
                dbConCrUser.FillComboBox(cmbPlanMachine, @"T_Get_UnitMachineList_Proc '1'");
            }
        }

        private void chkUnitDhaka_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnitDhaka.Checked == true)
            {
                chkUnitCTG.Checked = false;
                dbConCrUser.FillComboBox(cmbPlanMachine, @"T_Get_UnitMachineList_Proc '2'");
            }
        }

        private void btnViewSchBalance_Click(object sender, EventArgs e)
        {
            frmViewScheduledData frm = new frmViewScheduledData();
            frm.MdiParent = this.MdiParent;
            frm.Show();
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
