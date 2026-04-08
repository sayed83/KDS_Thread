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
    public partial class frmWindingEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmWindingEntry()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmWindingEntry_Load(object sender, EventArgs e)
        {
            gridDyeLot.Visible = false;
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //Unit = 1;
            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'Winding','" + Unit + "'");

            dbConCrUser.FillComboBox(cmbWinMachine, @"SELECT '0' Id,'Select' ShortNam
                                    UNION ALL
                                    SELECT Id,ShortNam FROM dbo.WindingMachine WHERE Unit='" + Unit + "'");

            dbConCrUser.FillComboBox(cmbShift, @"SELECT 0 Id,'Select' ShiftName
                                                UNION ALL
                                                SELECT Id,ShiftName FROM dbo.ShiftInfo");

            cmbWinMachine.SelectedItem = "Select";
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
                gvListData.Columns.Add("DyeDate", "Dye Date");
                gvListData.Columns.Add("DyeKG", "Dye KG");
                gvListData.Columns.Add("DyeQty", "Dye QTY");
                gvListData.Columns.Add("WinQTY", "Wind. QTY");

                gvListData.Columns["OrderId"].Width = 140;
                gvListData.Columns["Product"].Width = 180;
                gvListData.Columns["Shade"].Width = 90;
                gvListData.Columns["machine"].Width = 80;
                gvListData.Columns["DyeDate"].Width = 100;
                gvListData.Columns["DyeQty"].Width = 60;
                gvListData.Columns["DyeKG"].Width = 60;
                gvListData.Columns["WinQTY"].Width = 60;

                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["machine"].ReadOnly = true;
                gvListData.Columns["DyeDate"].ReadOnly = true;
                gvListData.Columns["DyeQty"].ReadOnly = true;
                gvListData.Columns["DyeKG"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\

                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false;

                gvListData.Columns.Add("PlanSchId", "PlanSchId");
                gvListData.Columns["PlanSchId"].Visible = false;

                gvListData.Columns.Add("ProductId", "ProductId");
                gvListData.Columns["ProductId"].Visible = false;

                gvListData.Columns.Add("Unit", "Unit");
                gvListData.Columns["Unit"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvListData.Columns["WinQTY"].DefaultCellStyle.BackColor = Color.HotPink;
                gvListData.Columns["WinQTY"].DefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);

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
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Entry_WindingGv_Proc '" + LotNo + "'");

                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine"].Value = dr["machine"].ToString();
                    gvListData.Rows[rowAdd].Cells["DyeDate"].Value = dr["DyeDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["DyeQty"].Value = dr["DyeQty"].ToString();
                    gvListData.Rows[rowAdd].Cells["DyeKG"].Value = dr["DyeKG"].ToString();

                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    gvListData.Rows[rowAdd].Cells["PlanSchId"].Value = dr["PlanSchId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Unit"].Value = dr["Unit"].ToString();


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
                    // gridDyeLot.Columns["LotNo"].ReadOnly = true;
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
        }//
        public void clearField()
        {
            txtDyeLot.Text = "";
            gridDyeLot.Visible = false;
            gvListData.Rows.Clear();
            //cmbWinMachine.SelectedIndex = 0;
            //cmbShift.SelectedIndex = 0;

            //dtDate.Text = "";
            //dtDate.Format = DateTimePickerFormat.Custom;
            //dtDate.CustomFormat = "dd-MM-yyyy";
            //dtDate.Value = DateTime.Now;
            //dtDate.MinDate = DateTime.Now.AddDays(-1);

            dbConCrUser.FillDataGridView(gridDyeLot, @"T_Get_DyelotList_ForScan_Proc 'Winding','" + Unit + "'");
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
            catch (Exception)
            {

                throw;
            }
        }//
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }
        public int Get_Lot_DyeQty(int BookingSubId, int PlanSchId)
        {
            int QTY = 0;
            string Dyelot = txtDyeLot.Text.Trim();
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT ISNULL(SUM(DyeQty),0) QTY FROM dbo.ThreadDYE WHERE DyeLotNo='" + Dyelot + "' AND BookingSubId='" + BookingSubId + "' AND PlanSchId='" + PlanSchId + "'");
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
        public int Check_IsFill_QTY()
        {
            int count = 0;
            for (int i = 0; i < gvListData.Rows.Count; i++)
            {
                if (Convert.ToString(gvListData.Rows[i].Cells["WinQTY"].Value) == "" || gvListData.Rows[i].Cells["WinQTY"].Value == null)
                {
                    count++;
                }
            }
            return count;
        }//
        public void UpdateDyeing_WindingStatus(int PlanSchId)
        {
            int IsWinding = 1;
            string[] Cols = { "IsWin" };
            string[] Vals = { IsWinding.ToString() };
            string[] WhCols = { "PlanSchId" };
            string[] WhVals = { PlanSchId.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("ThreadDYE", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public void Insert_Winding()
        {
            try
            {
                string user = frmLogin.UserID.ToString();

                string DyeLotNo = txtDyeLot.Text.Trim();
                int MchId = Convert.ToInt32(cmbWinMachine.SelectedValue);
                //string WinDate = dtDate.Text.Trim();
                DateTime win_date = dtDate.Value;
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
                    int DyeQTY = Convert.ToInt32(gvListData.Rows[i].Cells["DyeQty"].Value.ToString());
                    // decimal DyeKG = Convert.ToDecimal(gvListData.Rows[i].Cells["DyeKG"].Value.ToString());
                    int WinQTY = 0;
                    try
                    {
                        if (gvListData.Rows[i].Cells["WinQTY"].Value != null)
                        {
                            WinQTY = Convert.ToInt32(gvListData.Rows[i].Cells["WinQTY"].Value.ToString());
                        }
                    }
                    catch {}

                    int PlanSchId = Convert.ToInt32(gvListData.Rows[i].Cells["PlanSchId"].Value.ToString());
                    int Unit = Convert.ToInt32(gvListData.Rows[i].Cells["Unit"].Value.ToString());

                    string[] Cols = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "DyeQty", "WinQty", "MchId", "Shift", "WinDate", "PlanSchId", "IsPack", "UnitId", "EntryBy", "EntryDate" };
                    string[] Vals = { DyeLotNo, OrderId, BookingSubId.ToString(), ProdId.ToString(), Shade, DyeQTY.ToString(), WinQTY.ToString(), MchId.ToString(), Shift.ToString(), win_date.ToString(), PlanSchId.ToString(), "0", Unit.ToString(), user, DateTime.Now.ToString() };
                    string sql = dbConCrUser.CreateSQLStatement("ThreadWIN", Cols, Vals, "INSERT", null, null);

                    if (WinQTY > 0)
                    {
                        if (sql != "")
                        {
                            sql += "SELECT SCOPE_IDENTITY();";
                            dbConCrUser.DBExecuteScalarWithSQL(sql);
                            int DyeQty_InLot = Get_Lot_DyeQty(BookingSubId, PlanSchId);
                            if (DyeQty_InLot == WinQTY)
                            {
                                UpdateDyeing_WindingStatus(PlanSchId);
                            }

                            count++;
                        }
                    }
                        
                }
                if (count > 0)
                {
                    //UpdateDyeing_WindingStatus(DyeLotNo);
                    clearField();
                    MessageBox.Show("Winding Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //if (Check_IsFill_QTY() > 0)
                //{
                //    MessageBox.Show("Enter Winding QTY..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                Insert_Winding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_SelectionChanged(object sender, EventArgs e)
        {
           // this.gvListData.ClearSelection();
        }

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

        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvListData.BeginEdit(true);
        }

       
    }
}
