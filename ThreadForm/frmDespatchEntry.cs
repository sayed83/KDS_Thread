using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KDS_Thread.ThreadForm
{
    public partial class frmDespatchEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmDespatchEntry()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmDespatchEntry_Load(object sender, EventArgs e)
        {
            gridDyeLot.Visible = false;
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //Unit = 1;
            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'RFD','" + Unit + "'");
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
                gvListData.Columns.Add("PKDate", "Packing Date");
                gvListData.Columns.Add("PKQTY", "Packing QTY");
                gvListData.Columns.Add("DesQTY", "RFD QTY");

                gvListData.Columns["OrderId"].Width = 140;
                gvListData.Columns["Product"].Width = 190;
                gvListData.Columns["Shade"].Width = 90;
                gvListData.Columns["PKDate"].Width = 110;
                gvListData.Columns["PKQTY"].Width = 80;
                gvListData.Columns["DesQTY"].Width = 90;

                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["PKDate"].ReadOnly = true;
                gvListData.Columns["PKQTY"].ReadOnly = true;

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

                gvListData.Columns["DesQTY"].DefaultCellStyle.BackColor = Color.HotPink;
                gvListData.Columns["DesQTY"].DefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);

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
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Entry_DespatchGv_Proc '" + LotNo + "'");

                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["PKDate"].Value = dr["PKDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["PKQty"].Value = dr["PKQty"].ToString();
                    
                    gvListData.Rows[rowAdd].Cells["DesQTY"].Value = dr["PKQty"].ToString();

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
        }
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

            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'RFD','" + Unit + "'");
        }//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }
        public int Get_OrderQty(int BookingSubId)
        {
            int OrderQty = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_OrderQty_Proc '" + BookingSubId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    OrderQty = Convert.ToInt32(dr["OrderQty"].ToString());
                }
            }
            dr.Close();
            return OrderQty;
        }//
        public int Get_Total_DesQty(int BookingSubId)
        {
            int DesQty = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT SUM(DesQty) DesQty FROM KdsThreadPMS.dbo.ThreadDES WHERE BookingSubId='" + BookingSubId + "'");
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    DesQty = Convert.ToInt32(dr["DesQty"].ToString());
                }
            }
            dr.Close();
            return DesQty;
        }//

        public int Check_TotalQtyInGrid()
        {
            int DesQTY = 0;
            int TotalQty = 0;
            int gridRow = 0;
            gridRow = gvListData.Rows.Count;
            for (int i = 0; i < gridRow; i++)
            {
                try
                {
                    if (gvListData.Rows[i].Cells["DesQTY"].Value != null)
                    {
                        DesQTY = Convert.ToInt32(gvListData.Rows[i].Cells["DesQTY"].Value.ToString());

                        TotalQty = TotalQty + DesQTY;
                    }
                }
                catch { }
            }
            return TotalQty;
        }//
        public int Check_IsFill_QTY()
        {
            int count = 0;
            for (int i = 0; i < gvListData.Rows.Count; i++)
            {
                if (gvListData.Rows[i].Cells["DesQTY"].Value == "" || gvListData.Rows[i].Cells["DesQTY"].Value == null)
                {
                    count++;
                }
            }
            return count;
        }//
        public void UpdatePacking_DespatchStatus(int PlanSchId)
        {
            int IsDes = 1;
            string[] Cols = { "IsDes" };
            string[] Vals = { IsDes.ToString() };
            string[] WhCols = { "PlanSchId" };
            string[] WhVals = { PlanSchId.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("ThreadPCK", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public int Get_Lot_PackQty(int BookingSubId, int PlanSchId)
        {
            int QTY = 0;
            string Dyelot = txtDyeLot.Text.Trim();
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT ISNULL(SUM(PKQty),0) QTY FROM dbo.ThreadPCK WHERE DyeLotNo='" + Dyelot + "' AND BookingSubId='" + BookingSubId + "' AND PlanSchId='" + PlanSchId + "'");
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
        public void Insert_Delivery()
        {
            try
            {
                string user = frmLogin.UserID.ToString();
                //string user = "arif";

                string DyeLotNo = txtDyeLot.Text.Trim();
                // DateTime DesDate = Convert.ToDateTime(dtDate.Text);
                DateTime des_date = dtDate.Value;
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
                    int PKQty = Convert.ToInt32(gvListData.Rows[i].Cells["PKQTY"].Value.ToString());
                    int DesQTY = 0;
                    try
                    {
                        if (gvListData.Rows[i].Cells["DesQTY"].Value != null)
                        {
                            DesQTY = Convert.ToInt32(gvListData.Rows[i].Cells["DesQTY"].Value.ToString());
                        }
                    }
                    catch{}

                    // check validation
                    int BookingQty = Get_OrderQty(BookingSubId);
                    int Total_DesQty = Get_Total_DesQty(BookingSubId);
                    //int TotalQtyInGridQty = Check_TotalQtyInGrid();
                    //int Net_TotalQty = Total_DesQty + TotalQtyInGridQty;
                    int Net_TotalQty = Total_DesQty + DesQTY;

                    if (Net_TotalQty > BookingQty) // -- 210>200
                    {
                        MessageBox.Show("Total qty is more than Booking qty.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    int PlanSchId = Convert.ToInt32(gvListData.Rows[i].Cells["PlanSchId"].Value.ToString());
                    int Unit = Convert.ToInt32(gvListData.Rows[i].Cells["Unit"].Value.ToString());

                    string[] Cols = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "PKQty", "DesQTY", "Shift", "DesDate", "PlanSchId", "UnitId", "EntryBy", "EntryDate" };
                    string[] Vals = { DyeLotNo, OrderId, BookingSubId.ToString(), ProdId.ToString(), Shade, PKQty.ToString(), DesQTY.ToString(), Shift.ToString(), des_date.ToString(), PlanSchId.ToString(), Unit.ToString(), user, DateTime.Now.ToString() };
                    string sql = dbConCrUser.CreateSQLStatement("ThreadDES", Cols, Vals, "INSERT", null, null);

                    if (DesQTY > 0)
                    {
                        if (sql != "")
                        {
                            sql += "SELECT SCOPE_IDENTITY();";
                            dbConCrUser.DBExecuteScalarWithSQL(sql);

                            int PackQty_InLot = Get_Lot_PackQty(BookingSubId, PlanSchId);
                            if (PackQty_InLot == DesQTY)
                            {
                                UpdatePacking_DespatchStatus(PlanSchId);
                            }

                            count++;
                        }
                    }
                       


                    //////----------- Stock Entry
                    //if(SchQty > DesQTY) // 100>80
                    //{
                    //    int StockQty = SchQty - DesQTY; // 100-80=20
                    //    string[] Cols2 = { "BookingSubId", "ProductId", "BookingSubId", "ProdId", "Shade", "DeliveryDate", "StockQty", "EntryBy", "EntryDate" };
                    //    string[] Vals2 = { BookingSubId.ToString(), ProdId.ToString(), Shade, DesDate.ToString(), StockQty.ToString(), user, DateTime.Now.ToString() };
                    //    string sql_Stock = dbConCrUser.CreateSQLStatement("Thread_Stock", Cols2, Vals2, "INSERT", null, null);

                    //    if (sql_Stock != "")
                    //    {
                    //        dbConCrUser.DBExecuteScalarWithSQL(sql_Stock);
                    //    }
                    //}

                }
                if (count > 0)
                {
                    //UpdatePacking_DespatchStatus(DyeLotNo);
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

                Insert_Delivery();
                //if (Check_IsFill_QTY() > 0)
                //{
                //    MessageBox.Show("Enter RFD QTY..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{

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
