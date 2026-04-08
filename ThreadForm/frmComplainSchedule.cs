using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KDS_Thread.ThreadForm
{
    public partial class frmComplainSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn1= new DataGridViewCheckBoxColumn();
        DataGridViewButtonColumn btnSaveCell= new DataGridViewButtonColumn();
        private int rowAdd = 0;
        
        public frmComplainSchedule()
        {
            InitializeComponent();
        }
        private int BookingId_glb = 0;
        private void frmComplainSchedule_Load(object sender, EventArgs e)
        {
            gridJob.Visible = false;

            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MMM-yyyy";
            dtPlanDate.MinDate = DateTime.Now;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            string UnitName = GetUnit(Unit);
            cmbUnit.SelectedItem = UnitName;
            dbConCrUser.FillComboBox(cmbPlanMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");
            //dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
            //                              UNION ALL
            //                              SELECT Id,Loc_Name FROM dbo.location_info");
            dbConCrUser.FillDataGridView(gridJob, @"EXEC T_Get_ComplainOrderList_Proc '" + Unit + "'");


            InitialDataGrid();
            Get_GridDataLoad();
        }
        private string GetUnit(int Id)
        {
            string Name = "";
            if(Id == 1)
            {
                Name = "Chattogram";
            }
            else
            {
                Name = "Dhaka";
            }
            return Name;
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

                checkColumn1.Name = "X";
                checkColumn1.HeaderText = "";
                checkColumn1.Width = 30;
                checkColumn1.ReadOnly = false;
                checkColumn1.FillWeight = 10;
                gvListData.Columns.Add(checkColumn1);


                gvListData.Columns.Add("ComplainDate", "Complain Date");
                gvListData.Columns.Add("ComplainNo", "Complain No.");
                gvListData.Columns.Add("BookingNo", "Job No.");
                gvListData.Columns.Add("Product", "Product");
                gvListData.Columns.Add("Shade", "Shade");
                //gvListData.Columns.Add("Solution", "Solution");
                gvListData.Columns.Add("ComplainQty", "Complain Qty");
                gvListData.Columns.Add("ScheduleQty", "Schedule Qty");
                gvListData.Columns.Add("BalanceQty", "Balance Qty");
                gvListData.Columns.Add("QTY", "QTY");


                gvListData.Columns["ComplainDate"].Width = 80;
                gvListData.Columns["ComplainNo"].Width = 100;
                gvListData.Columns["BookingNo"].Width = 100;
                gvListData.Columns["Product"].Width = 200;
                gvListData.Columns["Shade"].Width = 80;
                //gvListData.Columns["Solution"].Width = 200;
                gvListData.Columns["ComplainQty"].Width = 60;
                gvListData.Columns["ScheduleQty"].Width = 60;
                gvListData.Columns["BalanceQty"].Width = 60;
                gvListData.Columns["QTY"].Width = 60;
                gvListData.Columns["QTY"].ReadOnly = false;

                gvListData.Name = "btnSaveCell";
                btnSaveCell.HeaderText = "";
                //btnSaveCell.Text = "Save";
                btnSaveCell.FlatStyle = FlatStyle.Popup;
                //btnSaveCell.DefaultCellStyle.ForeColor = Color.Navy;
                btnSaveCell.DefaultCellStyle.BackColor = Color.YellowGreen;
                btnSaveCell.Width = 30;
                gvListData.Columns.Add(btnSaveCell);

                gvListData.Columns["ComplainDate"].ReadOnly = true;
                gvListData.Columns["ComplainNo"].ReadOnly = true;
                gvListData.Columns["BookingNo"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                //gvListData.Columns["Solution"].ReadOnly = true;
                gvListData.Columns["ComplainQty"].ReadOnly = true;
                gvListData.Columns["ScheduleQty"].ReadOnly = true;
                gvListData.Columns["BalanceQty"].ReadOnly = true;

                
                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false;

                gvListData.Columns.Add("CountGroup", "CountGroup");
                gvListData.Columns["CountGroup"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);

                //gvListData.Columns["QTY"].DefaultCellStyle.BackColor = Color.YellowGreen;
                //gvListData.Columns["QTY"].DefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);


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
                //string ComplainNo = txtComplain.Text.Trim();
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Complain_DataForSchedule_Proc '" + BookingId_glb + "','" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["ComplainDate"].Value = dr["ComplainDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["ComplainNo"].Value = dr["ComplainNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["BookingNo"].Value = dr["BookingNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    //gvListData.Rows[rowAdd].Cells["Solution"].Value = dr["Solution"].ToString();
                    gvListData.Rows[rowAdd].Cells["ComplainQty"].Value = Convert.ToInt32(dr["ComplainQty"]);
                    gvListData.Rows[rowAdd].Cells["ScheduleQty"].Value = Convert.ToInt32(dr["ScheduleQty"]);
                    gvListData.Rows[rowAdd].Cells["BalanceQty"].Value = Convert.ToInt32(dr["BalanceQty"]);
                   
                    gvListData.Rows[rowAdd].Cells["CountGroup"].Value = dr["CountGroup"];

                    rowAdd++;


                }
                dr.Close();
                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Get_GridDataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var dataTable = (DataTable)gridJob.DataSource;
                //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    var dataView = dataTable.DefaultView;
                    gridJob.Visible = true;
                    dataView.RowFilter = "[" + gridJob.Columns[1].Name + "] LIKE '%" + txtJob.Text + "%'";
                }

                gridJob.RowHeadersVisible = false;
                gridJob.Columns["BookingId"].Visible = false;
                gridJob.Columns["OrderId"].Visible = true;

                //// Set the column header text
                gridJob.Columns["OrderId"].HeaderText = "Order ID";
                gridJob.Columns["OrderId"].ReadOnly = true;
                gridJob.Columns["OrderId"].Width = 300;
                gridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextFiled();
                Get_GridDataLoad();
            }
        }
        public void Select_JobGrid_ToTextFiled()
        {
            if (gridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridJob.SelectedCells[0].Value;
                object cellId = gridJob.CurrentRow.Cells["BookingId"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    BookingId_glb = Convert.ToInt32(cellId.ToString());
                    gridJob.Visible = false;
                }
                txtJob.Focus();
               
            }
        }//
        private void gridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }

        private void gridJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_JobGrid_ToTextFiled();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvListData.BeginEdit(true);
        }

        private void gvListData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //gvListData.BeginEdit(true);
                if (e.ColumnIndex == 0)
                {
                    gvListData.EndEdit();

                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    //DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    if (checkBoxStatus)
                    {
                        int BalanceQty = Convert.ToInt32(row.Cells["BalanceQty"].Value);
                        int ComplainQty = Convert.ToInt32(row.Cells["ComplainQty"].Value);

                        row.Cells["QTY"].Style.BackColor = Color.HotPink;
                        row.Cells["QTY"].Style.Font = new Font("Calibri", 12F, FontStyle.Bold);
                        row.Cells["QTY"].ReadOnly = false;

                        row.Cells["QTY"].Value = BalanceQty;
                    }
                    else
                    {
                        row.Cells["QTY"].Value = "";
                        row.Cells["QTY"].Style.BackColor = Color.White;
                        row.Cells["QTY"].ReadOnly = true;

                    }


                   
                }
                /////--------------- Save Button
                DataGridViewRow row2 = gvListData.Rows[e.RowIndex];
                //DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                bool checkBox = Convert.ToBoolean(row2.Cells["X"].Value);
                
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    if (checkBox)
                    {
                        int PlanQty = Convert.ToInt32(row2.Cells["QTY"].Value);
                        if (PlanQty > 0 )
                        {
                           
                        }
                        else
                        {
                            MessageBox.Show("Enter Quantity!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                }// if button



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
       

        private void cmbPlanMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanMachine.Text != "Select" || cmbPlanMachine.Text != "")
            {
                Get_Machine_Lot_KG();
            }
        }

        //public void Confirm_Plan()
        //{
        //    string sql_master = "";
        //    string sql_details = "";
        //    string sql_details_2 = "";
        //    string sql_lot = "";
        //    int schedule_id = 0;
        //    string LotNo = "";

        //    int gridRow = 0;

        //    int Lot = 0;

        //    int MachineId = 0;
        //    int BookingId = 0;
        //    int BookingSubId = 0;
        //    int ProductId = 0;
        //    int Unit = 0;
        //    int BrandId = 0;

        //    int CS_SchQty = 0;
        //    string OrderId = "";
        //    string Shade = "";
        //    string Color = "";
        //    string FamilyGroup = "";
        //    string PrdCount = "";
        //    decimal ConePerPack = 0;
        //    decimal PerLotCone = 0;
        //    int FromPackQTY = 0;
        //    decimal BalanceQty = 0;
        //    string ScheduleDate = "";
        //    decimal DueQTY = 0;
        //    decimal TotalPack = 0;
        //    decimal SchDayQTY = 0;
        //    decimal TotalScheduleQTY = 0;
        //    decimal PKG = 0;

        //    bool checkBoxStatus = false;
        //    int LocationId = 0;
        //    int insertCount = 0;

        //    try
        //    {
        //        //string EntryBy = frmLogin.UserID.ToString();
        //        //Unit = frmLogin.UserLocation.ToString();
        //        //LocationId = frmLogin.UserLocation.ToString();
        //        LocationId = 1;
        //        string EntryBy = "arif";
        //        MachineId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
        //        decimal machine_capacity = Convert.ToDecimal(txtMchKG.Text);
        //        ScheduleDate = dtPlanDate.Text;
        //        PKG = Convert.ToDecimal(txtPackage.Text);
        //        if (gvListData.Rows.Count > 0)
        //        {
        //            gridRow = gvListData.Rows.Count;

        //            DateTime date = DateTime.UtcNow;

        //            for (int i = 0; i < gridRow; i++)
        //            {
        //                try
        //                {
        //                    if (gvListData.Rows[i].Cells["X"].Value == null)
        //                    {
        //                        checkBoxStatus = false;
        //                    }
        //                    else
        //                    {
        //                        checkBoxStatus = Convert.ToBoolean((gvListData.Rows[i].Cells["X"].Value).ToString());
        //                    }

        //                }
        //                catch { }

        //                if (checkBoxStatus)
        //                {
        //                    try
        //                    {

        //                        OrderId = gvListData.Rows[i].Cells["OrderId"].Value.ToString();
        //                        Shade = gvListData.Rows[i].Cells["Shade"].Value.ToString();
        //                        //PKG = Convert.ToDecimal(gvListData.Rows[i].Cells["PKG"].Value.ToString());

        //                        CS_SchQty = Convert.ToInt32(gvListData.Rows[i].Cells["schedule_qty"].Value.ToString());
        //                        ConePerPack = Convert.ToDecimal(gvListData.Rows[i].Cells["cone_per_pack"].Value.ToString());
        //                        //PerLotCone = Convert.ToDecimal(gvListData.Rows[i].Cells["per_lot_cone"].Value.ToString());
        //                        PerLotCone = ConePerPack * machine_capacity;
        //                    }
        //                    catch { }

        //                    //// int Id
        //                    if (Check_IsShadeInStockList(Shade) == 1)
        //                    {
        //                        if (gvListData.Rows[i].Cells["FromStock"].Value != "")
        //                        {
        //                            FromPackQTY = Convert.ToInt32(gvListData.Rows[i].Cells["FromStock"].Value.ToString());
        //                        }
        //                    }
        //                    Unit = Convert.ToInt32(gvListData.Rows[i].Cells["Unit"].Value.ToString());
        //                    BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["booking_sub_id"].Value.ToString());
        //                    LocationId = Convert.ToInt32(gvListData.Rows[i].Cells["location_id"].Value.ToString());
        //                    ProductId = Convert.ToInt32(gvListData.Rows[i].Cells["product_id"].Value.ToString());
        //                    schedule_id = Convert.ToInt32(gvListData.Rows[i].Cells["ScheduleId"].Value.ToString());
        //                    FamilyGroup = gvListData.Rows[i].Cells["FamilyGroup"].Value.ToString();
        //                    PrdCount = gvListData.Rows[i].Cells["PrdCount"].Value.ToString();
        //                    BrandId = Convert.ToInt32(gvListData.Rows[i].Cells["BrandId"].Value.ToString());


        //                    /// schedule date & qty details save
        //                    //ScheduleDate = dtPlanDate.Value;
        //                    SchDayQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value);
        //                    // decimal Total_SumDayQTY = Check_Sum_TotalSchQTY(ScheduleDate);

        //                    //----------- Used & Due Lot Part
        //                    int UsedLot = Get_UsedLot(ScheduleDate);
        //                    int Lot_PerDay = Get_Assigned_MchLot_OnSchDate(ScheduleDate);
        //                    int DueLot = Lot_PerDay - UsedLot;

        //                    decimal FullDay_MachineKG = DueLot * machine_capacity;
        //                    decimal assignLot_KG = Lot_PerDay * machine_capacity; // 4*10=40kg
        //                    decimal UsedPack_InAssignLot = Math.Ceiling(Get_UsedPackInMachine_OnSchDate(MachineId, ScheduleDate));
        //                    decimal DueKG = assignLot_KG - UsedPack_InAssignLot; // 40kg-10kg=30kg

        //                    //--------------- Date wise pack check
        //                    TotalPack = Sum_Total_Pack(ScheduleDate); // total pack kg                                   
        //                    //Lot = (int)Math.Ceiling(CalculateLot(MachineId, TotalPack)); //lot exceed check
        //                    if (TotalPack > FullDay_MachineKG)
        //                    {
        //                        if (DueKG <= 0)
        //                        {
        //                            throw new Exception("" + cmbPlanMachine.Text + " machine capacity exceed on this " + ScheduleDate + " date!!. ");
        //                        }
        //                    }

        //                    // check current lot exceed due lot
        //                    decimal MaximumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMchKG.Text));
        //                    decimal MinimumSchQty = Math.Ceiling(ConePerPack * Convert.ToDecimal(txtMinKG.Text));

        //                    decimal TotalLot = Math.Ceiling(TotalPack / machine_capacity); // (27/5=6) day kg/mchKg to lot 
        //                    decimal TotalLot_lineWise = Math.Ceiling(SchDayQTY / PerLotCone); // day Qty to lot 
        //                    decimal TotalPack_lineWise = Math.Ceiling(SchDayQTY / ConePerPack);

        //                    if (TotalPack < Convert.ToDecimal(txtMinKG.Text))
        //                    {
        //                        // checking if exists lot has enough pack for this QTY
        //                        if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) == 0)
        //                        {
        //                            throw new Exception("Enter minimum capacity QTY for one lot.!! ");
        //                        }

        //                    }
        //                    //------------ exceed qty calculation
        //                    decimal Exceed_DueQTY = 0;
        //                    if (TotalLot_lineWise > 0)
        //                    {

        //                        if (TotalLot_lineWise == 1 && SchDayQTY > PerLotCone) // 90>80
        //                        {
        //                            Exceed_DueQTY = SchDayQTY - PerLotCone; // exceed=10
        //                        }
        //                        if (TotalLot_lineWise > 1 && SchDayQTY > PerLotCone) // 240>200
        //                        {
        //                            Exceed_DueQTY = SchDayQTY % PerLotCone; //200%80=40
        //                        }
        //                    }

        //                    //---------- Net scheduleQTY & due pack calculation
        //                    decimal NetSchQTY = 0;
        //                    //if (TotalLot_lineWise > 1)
        //                    //{
        //                    //    NetSchQTY = SchDayQTY;
        //                    //}
        //                    //else
        //                    //{
        //                    //    NetSchQTY = Math.Ceiling(SchDayQTY - Exceed_DueQTY); // 120-40=80
        //                    //}
        //                    NetSchQTY = SchDayQTY;
        //                    //decimal SchQTY_LotKg = SchDayQTY / ConePerPack;
        //                    decimal SchQTY_LotKg = NetSchQTY / ConePerPack;
        //                    decimal Exceed_DueQTY_KG = Exceed_DueQTY / ConePerPack; // 40/8=5kg
        //                    decimal UsedPackKg = Bind_UsedPack_KG_GroupByLot(MachineId, Shade, ScheduleDate, LocationId, BrandId);
        //                    decimal DuePack_Exceed = 0;
        //                    if (UsedPackKg > 0)
        //                    {
        //                        //if (Exceed_DueQTY_KG > UsedPackKg) // 2>1
        //                        //{
        //                        //    DuePack_Exceed = Exceed_DueQTY_KG - UsedPackKg;
        //                        //}
        //                        //else
        //                        //{
        //                        //    DuePack_Exceed = UsedPackKg - Exceed_DueQTY_KG; // 2-3=-1kg
        //                        //}
        //                        DuePack_Exceed = machine_capacity - UsedPackKg;
        //                        //DuePack_Exceed = UsedPackKg - Exceed_DueQTY_KG;
        //                    }

        //                    decimal DuePack = Convert.ToDecimal(txtMchKG.Text) - UsedPackKg; // 5-2=3kg

        //                    // minimum kg part
        //                    string OldLotNo = "";
        //                    string IsEmptyLot = "NO";
        //                    //string IsExtraLot = "YES";
        //                    string IsExtraLot = "NO";
        //                    //if (Exceed_DueQTY > MinimumSchQty)
        //                    //{
        //                    //    Exceed_DueQTY = MinimumSchQty;
        //                    //}
        //                    //------------- exceed qty lot check or creat new lot

        //                    decimal Lot_lineWise_Floor = Math.Floor(SchDayQTY / PerLotCone);
        //                    decimal QTY_withoutExceed = Lot_lineWise_Floor * PerLotCone; // 3*35=105

        //                    if (Exceed_DueQTY >= MinimumSchQty && Exceed_DueQTY <= MaximumSchQty)// 40>=32 & 40<=80
        //                    {
        //                        if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) == 0)
        //                        {
        //                            //TotalLot = TotalLot + 1;
        //                            IsExtraLot = "YES";
        //                            //NetSchQTY = NetSchQTY + MinimumSchQty; // 80+32=112
        //                            //NetSchQTY = PerLotCone + MinimumSchQty; // 80+32=112
        //                            //Exceed_DueQTY = Exceed_DueQTY - MinimumSchQty;

        //                            if (Exceed_DueQTY == MinimumSchQty)
        //                            {
        //                                Exceed_DueQTY = MinimumSchQty;
        //                            }

        //                            if (Exceed_DueQTY < MinimumSchQty) // 10<15
        //                            {
        //                                NetSchQTY = QTY_withoutExceed;
        //                                TotalLot_lineWise = Math.Floor(NetSchQTY / PerLotCone);
        //                            }
        //                            else
        //                            {
        //                                NetSchQTY = QTY_withoutExceed + Exceed_DueQTY; // 105+15
        //                            }


        //                        }
        //                        else
        //                        {

        //                            if (Exceed_DueQTY_KG <= DuePack_Exceed) // 2<=3
        //                            {
        //                                //-------- if exceed qty found enough space in exist lot
        //                                OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
        //                                decimal Lot_usedPack = Bind_LotUsedPack_KG(OldLotNo, MachineId);
        //                                decimal Lot_duePack = Convert.ToDecimal(txtMchKG.Text) - Lot_usedPack;
        //                                if (TotalPack_lineWise <= Lot_duePack)
        //                                {
        //                                    IsEmptyLot = "YES";
        //                                    //TotalLot = TotalLot - 1;
        //                                }
        //                            }
        //                            else if (OldLotNo != "" && DuePack_Exceed > 0 && Exceed_DueQTY_KG > DuePack_Exceed) //2>0 & 2>3
        //                            {
        //                                if (MessageBox.Show("Are you want to create a new lot? One existing lot has capacity " + DuePack_Exceed + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //                                {
        //                                    //TotalLot = TotalLot + 1;
        //                                    //IsExtraLot = "YES";
        //                                    //NetSchQTY = NetSchQTY + Exceed_DueQTY;
        //                                }
        //                                else
        //                                {
        //                                    return;
        //                                }

        //                            }
        //                            else
        //                            {
        //                                //TotalLot = TotalLot + 1;
        //                                IsExtraLot = "YES";
        //                                //NetSchQTY = NetSchQTY + Exceed_DueQTY;

        //                            }


        //                        }

        //                    }
        //                    //if (Exceed_DueQTY <= MinimumSchQty && Exceed_DueQTY > 0) // 130 .. 100-30=30
        //                    if (Exceed_DueQTY > 0 && PerLotCone > Exceed_DueQTY)
        //                    {
        //                        if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) > 0)
        //                        {
        //                            OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
        //                            if (Exceed_DueQTY_KG <= DuePack_Exceed)
        //                            {
        //                                if (OldLotNo != "")
        //                                {
        //                                    decimal Lot_usedPack = Bind_LotUsedPack_KG(OldLotNo, MachineId);
        //                                    decimal Lot_duePack = Convert.ToDecimal(txtMchKG.Text) - Lot_usedPack;
        //                                    //decimal PackExceedQTY = Exceed_DueQTY / ConePerPack;
        //                                    if (Exceed_DueQTY_KG <= Lot_duePack)
        //                                    {
        //                                        IsEmptyLot = "YES";
        //                                        //TotalLot = TotalLot - 1;
        //                                        //NetSchQTY = NetSchQTY + Exceed_DueQTY;
        //                                    }
        //                                }
        //                            }
        //                            else if (OldLotNo != "" && DuePack_Exceed > 0 && Exceed_DueQTY_KG > DuePack_Exceed)
        //                            {
        //                                if (MessageBox.Show("Are you want to create a new lot? One Existing lot has due capacity " + DuePack_Exceed + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //                                {
        //                                    //TotalLot = TotalLot + 1;
        //                                    //IsExtraLot = "YES";
        //                                }
        //                                else
        //                                {
        //                                    return;
        //                                }

        //                            }
        //                            else
        //                            {
        //                                //TotalLot = TotalLot + 1;
        //                            }


        //                        }
        //                        else
        //                        {
        //                            if (Exceed_DueQTY < MinimumSchQty) // 10<15
        //                            {
        //                                NetSchQTY = QTY_withoutExceed;
        //                                TotalLot_lineWise = Math.Floor(NetSchQTY / PerLotCone);
        //                            }
        //                        }



        //                    }

        //                    if (SchDayQTY < PerLotCone && TotalLot_lineWise <= 1 && Exceed_DueQTY == 0)
        //                    {
        //                        if (Check_IsExist_RemainingPack_Lot(MachineId, Shade, ScheduleDate, LocationId, BrandId) > 0)
        //                        {
        //                            if (SchQTY_LotKg <= DuePack && UsedPackKg > 0)
        //                            {
        //                                IsEmptyLot = "YES";
        //                                OldLotNo = Bind_RemainingPack_LotNo(MachineId, Shade, ScheduleDate, LocationId, BrandId);
        //                            }
        //                            else
        //                            {
        //                                //if (MessageBox.Show("Do you want to create a new lot? One existing lot has due capacity " + DuePack + " KG. If you reduce QTY you can fulfill existing lot.", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //                                //{
        //                                //    //TotalLot = TotalLot + 1;
        //                                //}
        //                                //else
        //                                //{
        //                                //    return;
        //                                //}

        //                            }
        //                        }
        //                    }

        //                    //-------------------- Start Save part
        //                    if (IsEmptyLot == "YES" && TotalLot <= 1) // SchDayQTY < PerLotCone multiple row into a lot function 
        //                    {
        //                        // plan schedule main table data save
        //                        string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PerLotCone", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "EntryBy", "EntryDate" };
        //                        string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromPackQTY.ToString(), NetSchQTY.ToString(), PerLotCone.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, EntryBy, DateTime.Now.ToString() };
        //                        sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

        //                        //if (sql_master != "" && SchDayQTY > 0)
        //                        if (sql_master != "")
        //                        {
        //                            sql_master += "SELECT SCOPE_IDENTITY();";
        //                            schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));
        //                            insertCount++;

        //                            Update_Schedule_IsPlan(schedule_id);
        //                        }

        //                        // lot details table data save
        //                        string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                        string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
        //                        sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                        if (sql_details_2 != "")
        //                        {
        //                            dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                            insertCount++;
        //                        }
        //                    }
        //                    else if (IsEmptyLot == "NO" && TotalLot > 0 & SchDayQTY < PerLotCone) // multiple row into a lot function 
        //                    {
        //                        // uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
        //                        string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
        //                        LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
        //                        // plan schedule main table data save
        //                        string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PerLotCone", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "EntryBy", "EntryDate" };
        //                        string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromPackQTY.ToString(), NetSchQTY.ToString(), PerLotCone.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, EntryBy, DateTime.Now.ToString() };
        //                        sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);
        //                        if (sql_master != "")
        //                        {
        //                            sql_master += "SELECT SCOPE_IDENTITY();";
        //                            schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

        //                            Update_Schedule_IsPlan(schedule_id);
        //                        }


        //                        //  lot table data save
        //                        string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate", "PKG" };
        //                        string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate, PKG.ToString() };
        //                        sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

        //                        if (sql_lot != "")
        //                        {
        //                            dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
        //                            insertCount++;
        //                        }

        //                        // lot details table data save
        //                        string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                        string[] Vals4 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
        //                        sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                        if (sql_details_2 != "")
        //                        {
        //                            dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                            insertCount++;
        //                        }

        //                    }
        //                    else if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY == 0) // multiple row into a lot function 
        //                    {
        //                        // plan schedule main table data save
        //                        string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PerLotCone", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "EntryBy", "EntryDate" };
        //                        string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromPackQTY.ToString(), NetSchQTY.ToString(), PerLotCone.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, EntryBy, DateTime.Now.ToString() };
        //                        sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

        //                        if (sql_master != "")
        //                        {
        //                            sql_master += "SELECT SCOPE_IDENTITY();";
        //                            schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

        //                            Update_Schedule_IsPlan(schedule_id);
        //                        }

        //                        // lot details table data save
        //                        string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                        string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
        //                        sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                        if (sql_details_2 != "")
        //                        {
        //                            dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                            insertCount++;
        //                        }

        //                    }
        //                    else if (IsEmptyLot == "YES" && TotalLot > 0 && SchDayQTY < PerLotCone) // multiple row into a lot function 
        //                    {
        //                        // plan schedule main table data save
        //                        string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PerLotCone", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "EntryBy", "EntryDate" };
        //                        string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromPackQTY.ToString(), NetSchQTY.ToString(), PerLotCone.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, EntryBy, DateTime.Now.ToString() };
        //                        sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

        //                        if (sql_master != "")
        //                        {
        //                            sql_master += "SELECT SCOPE_IDENTITY();";
        //                            schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

        //                            Update_Schedule_IsPlan(schedule_id);
        //                        }

        //                        // lot details table data save
        //                        string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                        string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), SchQTY_LotKg.ToString(), SchDayQTY.ToString() };
        //                        sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                        if (sql_details_2 != "")
        //                        {
        //                            dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                            insertCount++;
        //                        }

        //                    }
        //                    else // single row or large qty into a lot function
        //                    {
        //                        // plan schedule main table data save
        //                        string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PerLotCone", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "EntryBy", "EntryDate" };
        //                        string[] Vals1 = { OrderId, BookingSubId.ToString(), ProductId.ToString(), Shade, MachineId.ToString(), ScheduleDate, CS_SchQty.ToString(), FromPackQTY.ToString(), NetSchQTY.ToString(), PerLotCone.ToString(), Unit.ToString(), LocationId.ToString(), BrandId.ToString(), FamilyGroup, PrdCount, EntryBy, DateTime.Now.ToString() };
        //                        sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

        //                        if (sql_master != "")
        //                        {
        //                            sql_master += "SELECT SCOPE_IDENTITY();";
        //                            schedule_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

        //                            Update_Schedule_IsPlan(schedule_id);
        //                        }


        //                        // Lot details save
        //                        // uniqueNumber = date.ToString("yyyyMMdd"); // lot number day wise
        //                        decimal PerLotSchQty = 0;
        //                        decimal DueLotSchQty = 0;
        //                        //for (int l = 0; l < TotalLot; l++)
        //                        for (int l = 0; l < TotalLot_lineWise; l++)
        //                        {
        //                            string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
        //                            LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
        //                            //decimal PerLotSchQty = 0;
        //                            if (l == 0)
        //                            {
        //                                DueLotSchQty = Math.Ceiling(NetSchQTY - PerLotCone);
        //                                PerLotSchQty = Math.Ceiling(NetSchQTY - DueLotSchQty);
        //                            }
        //                            else
        //                            {
        //                                DueLotSchQty = DueLotSchQty - PerLotCone;
        //                                PerLotSchQty = PerLotCone;
        //                            }

        //                            if (DueLotSchQty < 0)
        //                            {
        //                                //PerLotSchQty = PerLotCone + DueLotSchQty; 
        //                                PerLotSchQty = NetSchQTY - PerLotSchQty;
        //                            }
        //                            decimal Used_PerLotKg = PerLotSchQty / ConePerPack;
        //                            if (PerLotSchQty == PerLotCone)
        //                            {
        //                                //  lot table data save
        //                                string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate", "PKG" };
        //                                string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate, PKG.ToString() };
        //                                sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

        //                                if (sql_lot != "")
        //                                {
        //                                    dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
        //                                    insertCount++;
        //                                }

        //                                // lot details table data save
        //                                string[] Cols3 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                                string[] Vals3 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Used_PerLotKg.ToString(), PerLotSchQty.ToString() };
        //                                sql_details = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols3, Vals3, "INSERT", null, null);
        //                                if (sql_details != "")
        //                                {
        //                                    dbConCrUser.DBExecuteScalarWithSQL(sql_details);
        //                                }


        //                            }

        //                            // add under remaining lot
        //                            if (l > 0)
        //                            {
        //                                if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY >= MinimumSchQty)
        //                                {
        //                                    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
        //                                                                                        // lot details table data save
        //                                    string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                                    string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
        //                                    sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                                    if (sql_details_2 != "")
        //                                    {
        //                                        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                                    }
        //                                }
        //                            }

        //                            //if (IsEmptyLot == "YES" && TotalLot > 0 && Exceed_DueQTY >= MinimumSchQty)
        //                            //{
        //                            //    decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
        //                            //                                                        // lot details table data save
        //                            //    string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                            //    string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
        //                            //    sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                            //    if (sql_details_2 != "")
        //                            //    {
        //                            //        dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                            //    }
        //                            //}


        //                        }

        //                        if (IsEmptyLot == "YES" && Exceed_DueQTY <= MinimumSchQty)
        //                        {

        //                            decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
        //                                                                                // lot details table data save
        //                            string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                            string[] Vals4 = { OldLotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate.ToString(), Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
        //                            sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                            if (sql_details_2 != "")
        //                            {
        //                                dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                                insertCount++;
        //                            }
        //                        }
        //                        if (IsExtraLot == "YES" && IsEmptyLot == "NO" && Exceed_DueQTY >= MinimumSchQty)
        //                        {
        //                            string Generate_LotNo = Get_DyeLotNo(ScheduleDate, MachineId);
        //                            LotNo = cmbPlanMachine.Text.Replace("-", "") + "-" + Generate_LotNo;
        //                            //  lot table data save
        //                            string[] Cols2 = { "PlanSchId", "LotNo", "Shade", "MchId", "LocationId", "PlanDate", "PKG" };
        //                            string[] Vals2 = { schedule_id.ToString(), LotNo, Shade, MachineId.ToString(), LocationId.ToString(), ScheduleDate, PKG.ToString() };
        //                            sql_lot = dbConCrUser.CreateSQLStatement("Plan_Lot", Cols2, Vals2, "INSERT", null, null);

        //                            if (sql_lot != "")
        //                            {
        //                                dbConCrUser.DBExecuteScalarWithSQL(sql_lot);
        //                                insertCount++;
        //                            }

        //                            decimal Exceed_LotKg = Exceed_DueQTY / ConePerPack; // 40/8=4kg
        //                            // lot details table data save
        //                            string[] Cols4 = { "LotNo", "PlanSchId", "BookingSubId", "Shade", "MchId", "PlanDate", "UsedPack", "UsedCone" };
        //                            string[] Vals4 = { LotNo, schedule_id.ToString(), BookingSubId.ToString(), Shade, MachineId.ToString(), ScheduleDate, Exceed_LotKg.ToString(), Exceed_DueQTY.ToString() };
        //                            sql_details_2 = dbConCrUser.CreateSQLStatement("Plan_Lot_Details", Cols4, Vals4, "INSERT", null, null);
        //                            if (sql_details_2 != "")
        //                            {
        //                                dbConCrUser.DBExecuteScalarWithSQL(sql_details_2);
        //                                insertCount++;
        //                            }
        //                        }

        //                    }
        //                }

        //            }//for grid row
        //            if (insertCount > 0)
        //            {
        //                clearField();
        //                MessageBox.Show("Confirm Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}//
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

       
    }
}
