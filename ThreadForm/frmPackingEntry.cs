using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmPackingEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmPackingEntry()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmPackingEntry_Load(object sender, EventArgs e)
        {

            gridDyeLot.Visible = false;
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //Unit = 1;
            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'Packing','" + Unit + "'");
            dbConCrUser.FillComboBox(cmbShift, @"SELECT 0 Id,'Select' ShiftName
                                                UNION ALL
                                                SELECT Id,ShiftName FROM dbo.ShiftInfo");
            cmbShift.SelectedValue = 1;

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MM-yyyy";
            dtDate.Value = DateTime.Now;
            dtDate.MinDate = DateTime.Now.AddDays(-2);

            InitialDataGrid();
            txtDyeLot.Focus();

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

                gvListData.Columns.Add("OrderId", "Booking No");
                gvListData.Columns.Add("Product", "Product");

                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("machine", "Machine");
                gvListData.Columns.Add("WinDate", "Winding Date");
                gvListData.Columns.Add("WinQTY", "Winding QTY");
                gvListData.Columns.Add("PKQTY", "Packing QTY");

                gvListData.Columns["OrderId"].Width = 140;
                gvListData.Columns["Product"].Width = 180;
                gvListData.Columns["Shade"].Width = 90;
                gvListData.Columns["machine"].Width = 100;
                gvListData.Columns["WinDate"].Width = 100;
                gvListData.Columns["WinQTY"].Width = 70;
                gvListData.Columns["PKQTY"].Width = 70;

                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["machine"].ReadOnly = true;
                gvListData.Columns["WinDate"].ReadOnly = true;
                gvListData.Columns["WinQTY"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\

                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false;

                gvListData.Columns.Add("PlanSchId", "PlanSchId");
                gvListData.Columns["PlanSchId"].Visible = false;

                gvListData.Columns.Add("ProductId", "ProductId");
                gvListData.Columns["ProductId"].Visible = false;

                gvListData.Columns.Add("Unit", "Unit");
                gvListData.Columns["Unit"].Visible = false;

                gvListData.Columns.Add("SchQty", "SchQty");
                gvListData.Columns["SchQty"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvListData.Columns["PKQTY"].DefaultCellStyle.BackColor = Color.HotPink;
                gvListData.Columns["PKQTY"].DefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);

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
                string LotNo = txtDyeLot.Text.Trim();
                //if (LotNo == "")
                //{
                //    MessageBox.Show("Enter Lot No.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Entry_PackingGv_Proc '" + LotNo + "'");

                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine"].Value = dr["machine"].ToString();
                    gvListData.Rows[rowAdd].Cells["WinDate"].Value = dr["WinDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["WinQty"].Value = dr["WinQty"].ToString();
                    gvListData.Rows[rowAdd].Cells["PKQTY"].Value = dr["WinQty"].ToString();

                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    gvListData.Rows[rowAdd].Cells["PlanSchId"].Value = dr["PlanSchId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Unit"].Value = dr["Unit"].ToString();
                    gvListData.Rows[rowAdd].Cells["SchQty"].Value = dr["SchQty"].ToString();


                    rowAdd++;
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void txtDyeLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridDyeLot.Focus();
            }
        }

        private void txtDyeLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gridDyeLot.Visible = false;
            }
        }

        private void txtDyeLot_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtDyeLot.Text.Trim() != "")
                {
                    var dataTable = (DataTable)gridDyeLot.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridDyeLot.Visible = true;
                        dataView.RowFilter = "[" + gridDyeLot.Columns[0].Name + "] LIKE '%" + txtDyeLot.Text.Trim() + "%'";

                        //for (int i = 0; i < gridDyeLot.Rows.Count; i++)
                        //{
                        //    if (i % 2 == 0)
                        //    {
                        //        gridDyeLot.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                        //        gridDyeLot.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                        //        gridDyeLot.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                        //    }

                        //}
                    }

                    //Hide row header
                    gridDyeLot.RowHeadersVisible = false;
                    // Show the "shade_name" column
                    gridDyeLot.Columns["LotNo"].Visible = true;

                    // Set the column header text
                    gridDyeLot.Columns["LotNo"].HeaderText = " Dyelot";
                    //gridDyeLot.Columns["LotNo"].ReadOnly = true;
                    gridDyeLot.Columns["LotNo"].Width = 200;
                    gridDyeLot.Columns["LotNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridDyeLot.Columns["LotNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    gridDyeLot.ColumnHeadersHeight = 60;
                    gridDyeLot.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    gridDyeLot.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//

        private void txtDyeLot_Enter(object sender, EventArgs e)
        {
            try
            {
                Bind_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        public void Select_DyeLotGrid_ToTextfield()
        {
            if (gridDyeLot.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridDyeLot.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtDyeLot.Text = cellValue.ToString();
                    gridDyeLot.Visible = false;
                }
                txtDyeLot.Focus();
            }
        }//

        private void gridDyeLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_DyeLotGrid_ToTextfield();
        }
        private void gridDyeLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_DyeLotGrid_ToTextfield();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string LotNo = txtDyeLot.Text.Trim();
                if (LotNo == "")
                {
                    MessageBox.Show("Enter Lot No.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Bind_DataLoad();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void clearField()
        {
            txtDyeLot.Text = "";
            gridDyeLot.Visible = false;
            gvListData.Rows.Clear();
            //cmbShift.SelectedIndex = 0;

            //dtDate.Text = "";
            //dtDate.Format = DateTimePickerFormat.Custom;
            //dtDate.CustomFormat = "dd-MM-yyyy";
            //dtDate.Value = DateTime.Now;
            //dtDate.MinDate = DateTime.Now.AddDays(-1);

            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'Packing','" + Unit + "'");

        }//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }
        public int Check_IsFill_QTY()
        {
            int count = 0;
            for (int i = 0; i < gvListData.Rows.Count; i++)
            {
                if (Convert.ToString(gvListData.Rows[i].Cells["PKQTY"].Value) == "" || gvListData.Rows[i].Cells["PKQTY"].Value == null)
                {
                    count++;
                }
            }
            return count;
        }//
        public void UpdateWinding_PackingStatus(int PlanSchId)
        {
            int IsPack = 1;
            string[] Cols = { "IsPack" };
            string[] Vals = { IsPack.ToString() };
            string[] WhCols = { "PlanSchId" };
            string[] WhVals = { PlanSchId.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("ThreadWIN", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public int Get_BookingNo_Total_PlanQTY(string OrderId, int BookingSubId)
        {
            string Step = "Plan";
            int PlanQty = 0;
            //SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT CAST(SUM(ISNULL(PlanQty+StockQty,0)) AS INT) PlanQty FROM dbo.Plan_Schedule WHERE OrderId='" + OrderId + "' AND BookingSubId='" + BookingSubId + "'");
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"T_Get_SchPlanProdQTY_ByBookingNo_Proc '" + OrderId + "' ,'" + BookingSubId + "','"+ Step + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    PlanQty = Convert.ToInt32(dr["PlanQty"].ToString());
                }
            }
            dr.Close();
            return PlanQty;
        }//
        public int Get_BookingNo_Total_CsScheduleQTY(string OrderId, int BookingSubId)
        {
            string Step = "Schedule";
            int schedule_qty = 0;
            //SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Total_CsScheduledQty_JobWise_Proc '" + OrderId + "','" + BookingSubId + "'");
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"T_Get_SchPlanProdQTY_ByBookingNo_Proc '" + OrderId + "' ,'" + BookingSubId + "','"+ Step + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    schedule_qty = Convert.ToInt32(dr["schedule_qty"].ToString());
                }
            }
            dr.Close();
            return schedule_qty;
        }//
        public int Get_BookingNo_Total_ProductionQTY(string OrderId, int BookingSubId)
        {
            string Step = "Production";
            int PKQty = 0;
            //SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT SUM(PKQty) PKQty FROM dbo.ThreadPCK WHERE OrderId='" + OrderId + "' AND BookingSubId='" + BookingSubId + "'");
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"T_Get_SchPlanProdQTY_ByBookingNo_Proc '" + OrderId + "' ,'" + BookingSubId + "','"+ Step + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    PKQty = Convert.ToInt32(dr["PKQty"].ToString());
                }
            }
            dr.Close();
            return PKQty;
        }//
        public int Get_AdjustQty_ExcessProd(string OrderId, int BookingSubId)
        {
            int DueAdjustQty = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_ExcessProd_AdjustQty_Proc '" + OrderId + "','" + BookingSubId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    DueAdjustQty = Convert.ToInt32(dr["DueAdjustQty"].ToString());
                }
            }
            dr.Close();
            return DueAdjustQty;
        }//

        public void Insert_AdjustQTY(string OrderId, int BookingSubId, int AdjustQty, int Unit, string UserId)
        {

            string[] Cols = { "OrderId", "BookingSubId", "AdjustQty", "Remarks", "Unit", "EntryBy", "EntryDate" };
            string[] Vals = { OrderId, BookingSubId.ToString(), AdjustQty.ToString(), "From Pack", Unit.ToString(), UserId, DateTime.Now.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("Thread_Adjust", Cols, Vals, "INSERT", null, null);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public void UpdatePlanning_IsComplete(int PlanSchId)
        {
            int IsComplete = 1;
            string[] Cols = { "IsComplete" };
            string[] Vals = { IsComplete.ToString() };
            string[] WhCols = { "Id" };
            string[] WhVals = { PlanSchId.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public int Get_LeftOverQty_ExcessProd(string OrderId, int BookingSubId)
        {
            int ExcessQty = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_ExcessProd_LeftOverQty_Proc '" + OrderId + "','" + BookingSubId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    ExcessQty = Convert.ToInt32(dr["ExcessQty"].ToString());
                }
            }
            dr.Close();
            return ExcessQty;
        }//
        public void Insert_LeftOverQty(string OrderId, int BookingSubId, string Shade,int ProductId, int ExcessQty, int Unit, string UserId)
        {
            DateTime DeliveryDate = dtDate.Value;
            string[] Cols = { "OrderId", "BookingSubId", "Shade", "ProductId", "ExcessQty", "DeliveryDate", "Unit", "EntryBy", "EntryDate" };
            string[] Vals = { OrderId, BookingSubId.ToString(), Shade, ProductId.ToString(), ExcessQty.ToString(), DeliveryDate.ToString(), Unit.ToString(), UserId, DateTime.Now.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("Thread_Excess", Cols, Vals, "INSERT", null, null);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public int Get_Lot_WinQty(int BookingSubId, int PlanSchId)
        {
            int QTY = 0;
            string Dyelot = txtDyeLot.Text.Trim();
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT ISNULL(SUM(WinQty),0) QTY FROM dbo.ThreadWIN WHERE DyeLotNo='" + Dyelot + "' AND BookingSubId='" + BookingSubId + "' AND PlanSchId='" + PlanSchId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    QTY = Convert.ToInt32(dr["QTY"].ToString());
                }
            }
            dr.Close();
            return QTY;
        }//
        
        public void Insert_Packing()
        {
            try
            {
                string user = frmLogin.UserID.ToString();
                //string user = "arif";

                string DyeLotNo = txtDyeLot.Text.Trim();
                //DateTime PKDate = Convert.ToDateTime(dtDate.Text);
                DateTime pk_date = dtDate.Value;
                int Shift = Convert.ToInt32(cmbShift.SelectedValue);
                if (DyeLotNo == "")
                {
                    MessageBox.Show("Enter Dyelot.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Shift == 0)
                {
                    MessageBox.Show("Select Shift.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int count = 0;
                int gridRow = 0;
                gridRow = gvListData.Rows.Count;
                for (int i = 0; i < gridRow; i++)
                {
                    string OrderId = gvListData.Rows[i].Cells["OrderId"].Value.ToString();
                    string Shade = gvListData.Rows[i].Cells["Shade"].Value.ToString();
                    int BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingSubId"].Value.ToString());
                    int ProdId = Convert.ToInt32(gvListData.Rows[i].Cells["ProductId"].Value.ToString());
                    int SchQty = Convert.ToInt32(gvListData.Rows[i].Cells["SchQty"].Value.ToString());
                    int WinQTY = Convert.ToInt32(gvListData.Rows[i].Cells["WinQty"].Value.ToString());
                    int PKQty = 0;
                    try
                    {
                        if (gvListData.Rows[i].Cells["PKQTY"].Value != null)
                        {
                            PKQty = Convert.ToInt32(gvListData.Rows[i].Cells["PKQTY"].Value.ToString());
                        }
                    }
                    catch{}

                    //int PKQty = Convert.ToInt32(gvListData.Rows[i].Cells["PKQTY"].Value.ToString());
                    int PlanSchId = Convert.ToInt32(gvListData.Rows[i].Cells["PlanSchId"].Value.ToString());
                    int Unit = Convert.ToInt32(gvListData.Rows[i].Cells["Unit"].Value.ToString());

                    string[] Cols = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "WinQty", "PKQty", "Shift", "PKDate", "PlanSchId", "IsDes", "UnitId", "EntryBy", "EntryDate" };
                    string[] Vals = { DyeLotNo, OrderId, BookingSubId.ToString(), ProdId.ToString(), Shade, WinQTY.ToString(), PKQty.ToString(), Shift.ToString(), pk_date.ToString(), PlanSchId.ToString(), "0", Unit.ToString(), user, DateTime.Now.ToString() };
                    string sql = dbConCrUser.CreateSQLStatement("ThreadPCK", Cols, Vals, "INSERT", null, null);

                    if (PKQty > 0)
                    {
                        if (sql != "")
                        {
                            sql += "SELECT SCOPE_IDENTITY();";
                            dbConCrUser.DBExecuteScalarWithSQL(sql);

                            int WinQty_InLot = Get_Lot_WinQty(BookingSubId, PlanSchId);
                            if (WinQty_InLot == PKQty)
                            {
                                UpdateWinding_PackingStatus(PlanSchId);
                            }


                            count++;
                        }
                    }
                        

                    //------- Production done as per schedule qty
                    //int Total_PlanQty = Get_BookingNo_Total_PlanQTY(OrderId, BookingSubId);
                    int Total_SchQty = Get_BookingNo_Total_CsScheduleQTY(OrderId, BookingSubId);
                    int Total_PackingQty = Get_BookingNo_Total_ProductionQTY(OrderId, BookingSubId);
                    if (Total_SchQty == Total_PackingQty)
                    {
                        UpdatePlanning_IsComplete(PlanSchId);
                    }

                    //----- Excess Production Entry Part
                  
                    if(Total_PackingQty > Total_SchQty) // 550>500
                    {
                        //------------ Adjust Qty Entry (from pack)
                        int DueAdjustQty = Get_AdjustQty_ExcessProd(OrderId, BookingSubId);
                        if (DueAdjustQty > 0) // 50
                        {
                            Insert_AdjustQTY(OrderId, BookingSubId, DueAdjustQty, Unit, user);

                            UpdatePlanning_IsComplete(PlanSchId);
                        }

                        //-----------Left Over Entry
                        int ExcessQty = Get_LeftOverQty_ExcessProd(OrderId, BookingSubId);
                        if (ExcessQty > 0) // 50
                        {
                            Insert_LeftOverQty(OrderId, BookingSubId, Shade, ProdId, ExcessQty, Unit, user);

                            UpdatePlanning_IsComplete(PlanSchId);
                        }

                    }// if excess production

                }
                if (count > 0)
                {
                    //UpdateWinding_PackingStatus(DyeLotNo);
                    clearField();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Insert_Packing();
                //if (Check_IsFill_QTY() > 0)
                //{
                //    MessageBox.Show("Enter Packing QTY..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{
                //    Insert_Packing();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (e.RowIndex > -1)
            //{
            //    gvListData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
            //}
        }

        private void gvListData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    gvListData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}
        }

        private void gvListData_SelectionChanged(object sender, EventArgs e)
        {
           // this.gvListData.ClearSelection();
        }

        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvListData.BeginEdit(true);
        }

       
    }
}
