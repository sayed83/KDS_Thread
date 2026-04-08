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

namespace KDS_Thread.ThreadForm
{
    public partial class frmStockSchDelivery : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;
        public frmStockSchDelivery()
        {
            InitializeComponent();
        }

        private void frmStockSchDelivery_Load(object sender, EventArgs e)
        {
            dtgvJob.Visible = false;
            int UnitId = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int UnitId = 1;
            dbConCrUser.FillDataGridView(dtgvJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE STT=1  AND Unit= '" + UnitId + "'");

            dtSchDate.Format = DateTimePickerFormat.Custom;
            dtSchDate.CustomFormat = "dd-MMM-yyyy";
            dtSchDate.Value = DateTime.Now;
            dtSchDate.MinDate = DateTime.Now;

            InitDataGrid();
        }
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

                chkColumn.Name = "X";
                chkColumn.HeaderText = "";
                chkColumn.Width = 30;
                chkColumn.ReadOnly = false;
                chkColumn.FillWeight = 10;
                gvListData.Columns.Add(chkColumn);

                gvListData.Columns.Add("schedule_date", "Sch. Date");
                gvListData.Columns.Add("BookingNo", "BookingNo");
                gvListData.Columns.Add("Customer", "Customer");

                gvListData.Columns.Add("Product", "Product");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("schedule_qty", "Sch. QTY");
                gvListData.Columns.Add("QTY", "QTY");

                gvListData.Columns["schedule_date"].Width = 90;
                gvListData.Columns["BookingNo"].Width = 120;
                gvListData.Columns["Customer"].Width = 120;
                gvListData.Columns["Product"].Width = 180;
                gvListData.Columns["Shade"].Width = 60;
                gvListData.Columns["Color"].Width = 60;
                gvListData.Columns["schedule_qty"].Width = 60;
                gvListData.Columns["QTY"].Width = 60;


                gvListData.Columns["schedule_date"].ReadOnly = true;
                gvListData.Columns["BookingNo"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["schedule_qty"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\
                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false;

                gvListData.Columns.Add("ProductId", "ProductId"); 
                gvListData.Columns["ProductId"].Visible = false;

                gvListData.Columns.Add("ScheduleId", "ScheduleId");
                gvListData.Columns["ScheduleId"].Visible = false;

                gvListData.Columns.Add("location_id", "location_id"); 
                gvListData.Columns["location_id"].Visible = false;
                gvListData.Columns.Add("PrdCount", "PrdCount");
                gvListData.Columns["PrdCount"].Visible = false;



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
            SqlDataReader dr;
            try
            {

                int UnitId = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int UnitId = 1;
                string OrderNo = txtJob.Text.Trim();

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_StockScheduleDeliveryGv_Proc '" + OrderNo + "','" + UnitId + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();


                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["BookingNo"].Value = dr["BookingNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();

                    gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = Convert.ToInt32(dr["schedule_qty"]);

                    // visible false
                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ScheduleId"].Value = dr["ScheduleId"].ToString();
                    gvListData.Rows[rowAdd].Cells["location_id"].Value = dr["location_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["PrdCount"].Value = dr["PrdCount"].ToString();

                    rowAdd++;

                }
                dr.Close();
                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvJob.Focus();
            }
        }

        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvJob.Visible = false;
            }
        }

        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgvJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvJob.Visible = true;
                        dataView.RowFilter = "[" + dtgvJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";
                    }

                    dtgvJob.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtgvJob.Columns["OrderId"].Visible = true;
                    //dtgvJob.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtgvJob.Columns["OrderId"].HeaderText = " Order ID";
                    //dgvSearchResult.Columns["name_value"].ReadOnly = true;
                    dtgvJob.Columns["OrderId"].Width = 300;
                    dtgvJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvJob.ColumnHeadersHeight = 60;
                    dtgvJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch {}
        }//
        public void Select_JobGrid_ToTextfield()
        {
            if (dtgvJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    dtgvJob.Visible = false;
                }
                txtJob.Focus();

            }
        }//

        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextfield();
            }
        }

        private void dtgvJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextfield();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Job No.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Get_GridDataLoad();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Sum_TotalSchQTY()
        {
            decimal sumQTY = 0;
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

                            }
                        }
                        if (count == 0)
                        {
                            lblDayTotal.Text = "0";
                        }

                    }
                    catch { }
                }

            }// for
        }//

        private void gvListData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //gvListData.BeginEdit(true);
                if (e.ColumnIndex == 0)
                {
                    gvListData.EndEdit();

                    // DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    // Get the value of the checkbox cell in the selected row

                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    if (checkBoxStatus)
                    {
                        row.Cells["QTY"].Style.Font = new Font("Calibri", 12F, FontStyle.Bold);
                        row.Cells["QTY"].Style.BackColor = Color.HotPink;
                        row.Cells["QTY"].ReadOnly = false;
                        /// for cell color & enable 
                        decimal schedule_qty = Convert.ToDecimal(row.Cells["schedule_qty"].Value);
                        row.Cells["QTY"].Value = schedule_qty;

                    }// if checkbox
                    else
                    {

                        row.Cells["QTY"].Style.BackColor = Color.White;
                        row.Cells["QTY"].ReadOnly = true;
                        row.Cells["QTY"].Value = "0";
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
                    decimal SchQty = Convert.ToDecimal(row.Cells["schedule_qty"].Value);
                    decimal QTY = Convert.ToDecimal(row.Cells["QTY"].Value);
                    if (QTY > SchQty)
                    {
                        MessageBox.Show("Qty is more than schedule qty.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        Sum_TotalSchQTY();
                    }

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

        public void Confirm()
        {
            int count = 0;
            int gridRow = 0;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            string EntryBy = frmLogin.UserID.ToString();
            DateTime SchDate = Convert.ToDateTime(dtSchDate.Text);
            string ScheduleDate = SchDate.ToString("yyyy-MM-dd");
            try
            {
                bool checkBoxStatus = false;
                if (gvListData.Rows.Count > 0)
                {
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

                            string BookingNo = gvListData.Rows[i].Cells["BookingNo"].Value.ToString();
                            string Shade = gvListData.Rows[i].Cells["Shade"].Value.ToString();
                            string Color = gvListData.Rows[i].Cells["Color"].Value.ToString();
                            //ConePerPack = Convert.ToDecimal(gvListData.Rows[i].Cells["ConePerPack"].Value.ToString());
                            //PerLotCone = Convert.ToInt32(gvListData.Rows[i].Cells["PerLotCone"].Value.ToString());
                            //decimal BalanceQty = Convert.ToDecimal(gvListData.Rows[i].Cells["BalQty"].Value.ToString());
                            decimal SchQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["schedule_qty"].Value.ToString());
                            decimal QTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value.ToString());
    

                            //// int Id
                            //int BookingId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingId"].Value.ToString());
                            int BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingSubId"].Value.ToString());
                            int ProductId = Convert.ToInt32(gvListData.Rows[i].Cells["ProductId"].Value.ToString());
                            int CS_ScheduleId = Convert.ToInt32(gvListData.Rows[i].Cells["ScheduleId"].Value.ToString());
                            int location_id = Convert.ToInt32(gvListData.Rows[i].Cells["location_id"].Value.ToString());
                            string PrdCount = gvListData.Rows[i].Cells["PrdCount"].Value.ToString();

                            // plan schedule main table data save
                            string[] Cols1 = { "OrderId", "BookingSubId", "ProductId", "Shade", "MachineId", "PlanDate", "SchQty", "StockQty", "PlanQty", "PKG", "Unit", "LocationId", "BrandId", "FamilyGroup", "PrdCount", "IsComplete", "EntryBy", "EntryDate" };
                            string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), Shade, "0", ScheduleDate, SchQTY.ToString(), QTY.ToString(), "0", "0", Unit.ToString(), location_id.ToString(), "0", "N/A", PrdCount,"1", EntryBy, DateTime.Now.ToString() };
                            string sql_master = dbConCrUser.CreateSQLStatement("Plan_Schedule", Cols1, Vals1, "INSERT", null, null);

                            if (sql_master != "")
                            {
                                sql_master += "SELECT SCOPE_IDENTITY();";
                                int Plan_Sch_id = Convert.ToInt32(dbConCrUser.DBExecuteScalarWithSQL(sql_master));

                                Update_Schedule_IsPlan(CS_ScheduleId);
                                count++;

                                //------- Stock Out Entry
                                string[] Cols2 = { "Shade", "CountGroup", "ProductId", "StockDate", "QTY", "Status", "Unit", "EntryBy", "EntryDate" };
                                string[] Vals2 = { Shade, PrdCount, ProductId.ToString(), ScheduleDate, QTY.ToString(), "OUT", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                string sql_stk = dbConCrUser.CreateSQLStatement("Stock_Main", Cols2, Vals2, "INSERT", null, null);
                                dbConCrUser.DBExecuteScalarWithSQL(sql_stk);

                                //-------- Insert in RFD Table
                                string[] Cols_RFD = { "DyeLotNo", "OrderId", "BookingSubId", "ProdId", "Shade", "PKQty", "DesQTY", "Shift", "DesDate", "PlanSchId", "UnitId", "EntryBy", "EntryDate" };
                                string[] Vals_RFD = { "STK", BookingNo, BookingSubId.ToString(), ProductId.ToString(), Shade, "0", QTY.ToString(), "1", ScheduleDate, Plan_Sch_id.ToString(), Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                string sql_RFD = dbConCrUser.CreateSQLStatement("ThreadDES", Cols_RFD, Vals_RFD, "INSERT", null, null);
                                dbConCrUser.DBExecuteScalarWithSQL(sql_RFD);

                            }

                        }
                    }// for loop

                }
                   

                if (count > 0)
                {
                    
                    gvListData.Rows.Clear();
                    //Get_GridDataLoad();
                    MessageBox.Show("Confirm Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_IsSelected() == 0)
                {
                    MessageBox.Show("Select minimum one..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure to save this?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Confirm();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
