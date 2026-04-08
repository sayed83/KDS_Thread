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
    public partial class frmWhiteSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;
        public frmWhiteSchedule()
        {
            InitializeComponent();
        }

        private void frmWhiteSchedule_Load(object sender, EventArgs e)
        {
            dtgvJob.Visible = false;
            int UnitId = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int UnitId = 1;
            dbConCrUser.FillDataGridView(dtgvJob, @"EXEC proc_get_booking_no '" + UnitId + "'");

            dtSchDate.Format = DateTimePickerFormat.Custom;
            dtSchDate.CustomFormat = "dd-MMM-yyyy";
            dtSchDate.Value = DateTime.Now;
            dtSchDate.MinDate = DateTime.Now;

            cmbShade.SelectedItem = "Select";
            dbConCrUser.FillComboBox(cmbCount, @"EXEC T_Get_CountByJob_Proc '" + txtJob.Text.Trim() + "'");
            cmbCount.SelectedItem = "Select";
            dbConCrUser.FillComboBox(cmbProduct, @"EXEC T_Get_WhiteProductByCount_Proc '" + cmbCount.Text.Trim() + "'");


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

                gvListData.Columns.Add("BookingNo", "Booking No");
                gvListData.Columns.Add("Customer", "Customer");

                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("BookingQty", "Booking Qty");
                //gvListData.Columns.Add("ScheduledQty", "Sch. Qty");
                gvListData.Columns.Add("BalQty", "Balance Qty");
                gvListData.Columns.Add("QTY", "QTY");

                gvListData.Columns["BookingNo"].Width = 120;
                gvListData.Columns["Customer"].Width = 120;
                gvListData.Columns["ProductName"].Width = 180;
                gvListData.Columns["Shade"].Width = 60;
                gvListData.Columns["Color"].Width = 60;
                gvListData.Columns["BookingQty"].Width = 60;
                //gvListData.Columns["ScheduledQty"].Width = 50;
                gvListData.Columns["BalQty"].Width = 60;
                gvListData.Columns["QTY"].Width = 60;


                gvListData.Columns["BookingNo"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["ProductName"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["BookingQty"].ReadOnly = true;
                gvListData.Columns["BalQty"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\
                gvListData.Columns.Add("BookingId", "BookingId");
                gvListData.Columns["BookingId"].Visible = false;

                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                gvListData.Columns["BookingSubId"].Visible = false; 

                gvListData.Columns.Add("ProductId", "ProductId");
                gvListData.Columns["ProductId"].Visible = false;

                gvListData.Columns.Add("RepId", "RepId");
                gvListData.Columns["RepId"].Visible = false;

                gvListData.Columns.Add("CusId", "CusId");
                gvListData.Columns["CusId"].Visible = false;

                gvListData.Columns.Add("CountGroup", "CountGroup");
                gvListData.Columns["CountGroup"].Visible = false;


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
                string Shade = cmbShade.Text.Trim();
                int ProductId = Convert.ToInt32(cmbProduct.SelectedValue);

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_StockScheduleData_Proc '" + OrderNo + "','"+ Shade + "','"+ ProductId + "','" + UnitId + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();


                    gvListData.Rows[rowAdd].Cells["BookingNo"].Value = dr["BookingNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();

                    gvListData.Rows[rowAdd].Cells["BookingQty"].Value = Convert.ToInt32(dr["BookingQty"]);
                    gvListData.Rows[rowAdd].Cells["BalQty"].Value = Convert.ToInt32(dr["BalQty"]);

                    // visible false
                    gvListData.Rows[rowAdd].Cells["BookingId"].Value = dr["BookingId"].ToString();
                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    gvListData.Rows[rowAdd].Cells["RepId"].Value = dr["RepId"].ToString();
                    gvListData.Rows[rowAdd].Cells["CusId"].Value = dr["CusId"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductId"].Value = dr["ProductId"].ToString();
                    gvListData.Rows[rowAdd].Cells["CountGroup"].Value = dr["CountGroup"].ToString();


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
                        dataView.RowFilter = "[" + dtgvJob.Columns[1].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";
                    }

                    dtgvJob.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtgvJob.Columns["name_value"].Visible = true;
                    dtgvJob.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtgvJob.Columns["name_value"].HeaderText = " Order ID";
                    //dgvSearchResult.Columns["name_value"].ReadOnly = true;
                    dtgvJob.Columns["name_value"].Width = 300;
                    dtgvJob.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvJob.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvJob.ColumnHeadersHeight = 60;
                    dtgvJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                dbConCrUser.FillComboBox(cmbCount, @"EXEC T_Get_CountByJob_Proc '" + txtJob.Text.Trim() + "'");
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
        private void cmbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                string Count = cmbCount.Text.Trim().ToString();
                if (Count != "Select" && Count.Length > 2 && Count.Length < 10)
                {
                    dbConCrUser.FillComboBox(cmbProduct, @"T_Get_WhiteProductByCount_Proc '" + Count + "'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                string Shade = cmbShade.Text.Trim();
                string Count = cmbCount.Text.Trim().ToString();
                if (Count != "Select")
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
        }//
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Job No.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbShade.Text.Trim() == "Select")
                {
                    MessageBox.Show("Select Shade.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(cmbShade.Text.Trim() != "RYWHT" )
                {
                    if (Convert.ToInt32(txtStockQty.Text) == 0 || txtStockQty.Text == "")
                    {
                        throw new Exception("No Stock Available..!!");
                    }
                }


                Get_GridDataLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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
                        decimal BalQty = Convert.ToDecimal(row.Cells["BalQty"].Value);
                        if (BalQty > 0) //100>=40
                        {
                            row.Cells["QTY"].Value = BalQty;
                        }
                       
                    }// if checkbox
                    else
                    {

                        row.Cells["QTY"].Style.BackColor = Color.White;
                        row.Cells["QTY"].ReadOnly = true;
                        row.Cells["QTY"].Value = "";
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvListData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gvListData.SelectedCells.Count > 0)
                {
                    Sum_TotalSchQTY();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                            decimal BalanceQty = Convert.ToDecimal(gvListData.Rows[i].Cells["BalQty"].Value.ToString());
                            decimal SchQTY = Convert.ToDecimal(gvListData.Rows[i].Cells["QTY"].Value.ToString());
                            string PrdCount = gvListData.Rows[i].Cells["CountGroup"].Value.ToString();

                            //// int Id
                            int BookingId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingId"].Value.ToString());
                            int BookingSubId = Convert.ToInt32(gvListData.Rows[i].Cells["BookingSubId"].Value.ToString());
                            int ProductId = Convert.ToInt32(gvListData.Rows[i].Cells["ProductId"].Value.ToString());
                            int RepId = Convert.ToInt32(gvListData.Rows[i].Cells["RepId"].Value.ToString());
                            int CusId = Convert.ToInt32(gvListData.Rows[i].Cells["CusId"].Value.ToString());


                            // thread schedule main table data save
                            string[] Cols1 = { "OrderId", "booking_sub_id", "product_id", "RepID", "CusID", "location_id", "machine_id", "shade", "IsUrgent", "schedule_date", "schedule_qty", "IsPlan", "BrandId", "FamilyGroup", "PrdCount", "STT", "Unit", "entry_by", "entry_date" };
                            string[] Vals1 = { BookingNo, BookingSubId.ToString(), ProductId.ToString(), RepId.ToString(), CusId.ToString(), Unit.ToString(), "0", Shade, "0", ScheduleDate, SchQTY.ToString(), "0", "0", "N/A", PrdCount, "1", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                            string sql_master = dbConCrUser.CreateSQLStatement("thread_schedule", Cols1, Vals1, "INSERT", null, null);

                            if (sql_master != "")
                            {
                                sql_master += "SELECT SCOPE_IDENTITY();";
                                dbConCrUser.DBExecuteScalarWithSQL(sql_master);

                                count++;

                                //------- Stock IN Entry
                                if (Shade == "RYWHT")
                                {
                                    string[] Cols2 = { "Shade", "CountGroup", "ProductId", "StockDate", "QTY", "Status", "Unit", "EntryBy", "EntryDate" };
                                    string[] Vals2 = { Shade, PrdCount, ProductId.ToString(), ScheduleDate, SchQTY.ToString(), "IN", Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                                    string sql_stk = dbConCrUser.CreateSQLStatement("Stock_Main", Cols2, Vals2, "INSERT", null, null);

                                    if (sql_stk != "")
                                    {
                                        dbConCrUser.DBExecuteScalarWithSQL(sql_stk);
                                    }
                                }



                            }
                        }
                    }// for loop
                }


                if (count > 0)
                {
                    cmbProduct.SelectedIndex = 0;
                    txtStockQty.Text = "0";
                    gvListData.Rows.Clear();
                    Get_GridDataLoad();

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
                if(cmbShade.Text.Trim() != "RYWHT")
                {
                    if (Convert.ToInt32(lblDayTotal.Text) > Convert.ToInt32(txtStockQty.Text))
                    {
                        throw new Exception("Qty is more than stock qty..!!");
                    }
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
