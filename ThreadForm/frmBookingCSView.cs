using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmBookingCSView : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
        DataGridViewImageColumn SelectBtn = new DataGridViewImageColumn();

        private frmScheduleEntry _ScheduleEntry_;

        private int rowAdd = 0;
        private int RepId_glb = 0;
        private int CustomerId_glb = 0;
        private int BrandId_glb = 0;
        public frmBookingCSView()
        {
            InitializeComponent();
        }

        private void frmBookingCSView_Load(object sender, EventArgs e)
        {
            int UnitId = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int UnitId = 1;

            dtgvJob.Visible = false;
            dtgvShade.Visible = false;
            dtgvColor.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepres.Visible = false;

            cmbFamily.SelectedItem = "N/A";

            dbConCrUser.FillDataGridView(dtgvShade, @"EXEC proc_get_shade '" + UnitId + "'");
            dbConCrUser.FillDataGridView(dtgvJob, @"EXEC proc_get_booking_no '" + UnitId + "'");
            dbConCrUser.FillDataGridView(dtgvColor, @"EXEC T_Get_Color_Proc '" + UnitId + "','" + txtJob.Text.Trim() + "'");
            dbConCrUser.FillDataGridView(dtGvRepres, @"EXEC proc_get_representative");
            dbConCrUser.FillDataGridView(dtGvCustomer, @"EXEC T_Get_Customer_SalesRep_Proc 0, 1");
            dbConCrUser.FillComboBox(cmbCount, @"SELECT * FROM vw_count ORDER BY id");

            InitDataGrid();

        }
        private void InitDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                //gvListData.Rows.Clear();
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
                gvListData.Columns.Add("Rep", "Rep. Name");
                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Unit", "Unit");
                gvListData.Columns.Add("BookingQty", "Booking Qty");
                gvListData.Columns.Add("ScheduledQty", "Scheduled Qty");
                gvListData.Columns.Add("BalQty", "Balance Qty");
                gvListData.Columns.Add("PKG", "PKG");

                gvListData.Columns["BookingNo"].Width = 110;
                gvListData.Columns["Customer"].Width = 120;
                gvListData.Columns["Rep"].Width = 100;
                gvListData.Columns["ProductName"].Width = 140;
                gvListData.Columns["Color"].Width = 100;
                gvListData.Columns["Shade"].Width = 80;
                gvListData.Columns["Unit"].Width = 70;
                gvListData.Columns["BookingQty"].Width = 60;
                gvListData.Columns["ScheduledQty"].Width = 60;
                gvListData.Columns["BalQty"].Width = 60;
                gvListData.Columns["PKG"].Width = 50;

                gvListData.Columns["BookingNo"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["Rep"].ReadOnly = true;
                gvListData.Columns["ProductName"].Width = 180;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Unit"].ReadOnly = true;
                gvListData.Columns["BookingQty"].ReadOnly = true;
                gvListData.Columns["ScheduledQty"].ReadOnly = true;
                gvListData.Columns["BalQty"].ReadOnly = true;
                gvListData.Columns["PKG"].ReadOnly = true;

                SelectBtn.Image = Properties.Resources.right_arrow1;
                SelectBtn.HeaderText = "";
                SelectBtn.Name = "btnSelect";
                gvListData.Columns.Add(SelectBtn);
                gvListData.Columns["btnSelect"].Width = 50;

                gvListData.Columns["btnSelect"].Visible = false;

                gvListData.Columns.Add("ConePerPack", "ConePerPack");
                gvListData.Columns["ConePerPack"].Visible = false;

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
                gvListData.Rows.Clear();
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                string OrderID = txtJob.Text.Trim();
                string Shade = txtShade.Text.Trim();
                string Color = txtColor.Text.Trim();
                int SalesRep = RepId_glb;
                int CusId = CustomerId_glb;
                string Count = cmbCount.Text.Trim();
                string FamilyCount = cmbFamily.Text.Trim();

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_BookingData_SchView_Proc '" + OrderID + "','" + Shade + "','" + Color + "','" + RepId_glb + "','"+ CusId + "','" + Count + "' ,'" + FamilyCount + "','" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                int TotalBookingQty = 0;
                int TotalScheduledQty = 0;
                int TotalBalanceQty = 0;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["BookingNo"].Value = dr["BookingNo"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["Rep"].Value = dr["Rep"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Unit"].Value = dr["Unit"].ToString();

                    gvListData.Rows[rowAdd].Cells["BookingQty"].Value = Convert.ToInt32(dr["BookingQty"]);
                    gvListData.Rows[rowAdd].Cells["ScheduledQty"].Value = Convert.ToInt32(dr["ScheduledQty"]);
                    gvListData.Rows[rowAdd].Cells["BalQty"].Value = Convert.ToInt32(dr["BalQty"]);
                    gvListData.Rows[rowAdd].Cells["PKG"].Value = Convert.ToDecimal(dr["PKG"]);
                    gvListData.Rows[rowAdd].Cells["ConePerPack"].Value = Convert.ToDecimal(dr["ConePerPack"]);

                    rowAdd++;
                    TotalBookingQty += Convert.ToInt32(dr["BookingQty"]);
                    TotalScheduledQty += Convert.ToInt32(dr["ScheduledQty"]);
                    TotalBalanceQty += Convert.ToInt32(dr["BalQty"]);
                }
                // for total sum
                gvListData.Rows.Add();
                gvListData.Rows[rowAdd].DefaultCellStyle.BackColor = System.Drawing.Color.HotPink;
                gvListData.Rows[rowAdd].DefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);
                gvListData.Rows[rowAdd].Cells["BookingQty"].Value = TotalBookingQty;
                gvListData.Rows[rowAdd].Cells["ScheduledQty"].Value = TotalScheduledQty;
                gvListData.Rows[rowAdd].Cells["BalQty"].Value = TotalBalanceQty;
                gvListData.Rows[rowAdd].Cells["X"].ReadOnly = true;

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
            if (txtJob.Text.Trim() != "")
            {
                dtgvShade.Visible = false;
                dtgvColor.Visible = false;
                dtGvRepres.Visible = false;
                dtGvCustomer.Visible = false;

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
                //dtgvJob.Columns["name_value"].ReadOnly = true;
                dtgvJob.Columns["name_value"].Width = 300;
                dtgvJob.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgvJob.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                this.dtgvJob.ColumnHeadersHeight = 60;
                dtgvJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                dtgvJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
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
                txtJob.Focus();

                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                dbConCrUser.FillDataGridView(dtgvColor, @"EXEC T_Get_Color_Proc '" + Unit + "','" + txtJob.Text.Trim() + "'");
                //txtShade.Text = "";
                if(txtJob.Text.Trim() != "")
                {
                    dbConCrUser.FillDataGridView(dtgvShade, @"EXEC T_Get_ShadeByJobNo_Proc '" + txtJob.Text.Trim() + "'");
                }
                else
                {
                    dbConCrUser.FillDataGridView(dtgvShade, @"EXEC proc_get_shade '" + Unit + "'");
                }

            }
        }//
        private void txtJob_Enter(object sender, EventArgs e)
        {
            if(txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextfield();
            }
            dtgvShade.Visible = false;
            dtgvColor.Visible = false;
            dtGvRepres.Visible = false;
            dtGvCustomer.Visible = false;
        }

        private void dtgvJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextfield();
        }
        private void txtShade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvShade.Focus();
            }
        }

        private void txtShade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvShade.Visible = false;
            }
        }
        private void txtShade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtShade.Text.Trim() != "")
                {
                    dtgvJob.Visible = false;
                    dtgvColor.Visible = false;
                    dtGvRepres.Visible = false;
                    dtGvCustomer.Visible = false;

                    var dataTable = (DataTable)dtgvShade.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvShade.Visible = true;
                        dataView.RowFilter = "[" + dtgvShade.Columns[1].Name + "] LIKE '%" + txtShade.Text + "%'";

                        //for (int i = 0; i < dtgvShade.Rows.Count; i++)
                        //{
                        //    if (i % 2 == 0)
                        //    {
                        //        dtgvShade.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                        //    }

                        //}
                    }
                    foreach (DataGridViewColumn column in dtgvShade.Columns)
                    {
                        //column.Visible = false;
                        if (column.Name != "shade_name")
                            column.Visible = false;
                    }

                    //Hide row header
                    dtgvShade.RowHeadersVisible = false;
                    // Show the "shade_name" column
                    dtgvShade.Columns["shade_name"].Visible = true;

                    // Set the column header text
                    dtgvShade.Columns["shade_name"].HeaderText = " Shade";
                    //dtgvShade.Columns["shade_name"].ReadOnly = true;
                    dtgvShade.Columns["shade_name"].Width = 200;
                    dtgvShade.Columns["shade_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvShade.Columns["shade_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    this.dtgvShade.ColumnHeadersHeight = 60;
                    dtgvShade.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvShade.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }//
        public void Select_ShadeGrid_ToTextfield()
        {
            if (dtgvShade.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvShade.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtShade.Text = cellValue.ToString();
                    dtgvShade.Visible = false;
                }
                txtShade.Focus();

                string Brand = Select_BrandByShade();
                dbConCrUser.FillComboBox_SingleColumn(cmbFamily, @"SELECT 'N/A' GroupName
                            UNION ALL
                            SELECT DISTINCT GroupName FROM dbo.Family_Count WHERE Brand='" + Brand + "'"
     );
            }
        }//
        private void txtShade_Enter(object sender, EventArgs e)
        {
            if(txtShade.Text.Trim() != "")
            {
                Select_ShadeGrid_ToTextfield();
            }
            dtgvJob.Visible = false;
            dtgvColor.Visible = false;
            dtGvRepres.Visible = false;
            dtGvCustomer.Visible = false;
        }

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

        private void dtgvShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
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

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtColor.Text.Trim() != "")
                {
                    dtgvJob.Visible = false;
                    dtgvShade.Visible = false;
                    dtGvRepres.Visible = false;
                    dtGvCustomer.Visible = false;

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

                    this.dtgvColor.ColumnHeadersHeight = 60;
                    dtgvColor.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvColor.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
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
        private void txtColor_Enter(object sender, EventArgs e)
        {
            if(txtColor.Text.Trim() != "")
            {
                Select_ColorGrid_ToTextfield();
            }
            dtgvShade.Visible = false;
            dtgvJob.Visible = false;
            dtGvRepres.Visible = false;
            dtGvCustomer.Visible = false;
        }

        private void dtgvColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ColorGrid_ToTextfield();
        }
        private void dtgvColor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtRepres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtGvRepres.Focus();
            }
        }

        private void txtRepres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtGvRepres.Visible = false;
            }
        }

        private void txtRepres_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRepres.Text.Trim() != "")
                {
                    dtgvJob.Visible = false;
                    dtgvShade.Visible = false;
                    dtgvColor.Visible = false;
                    dtGvCustomer.Visible = false;

                    var dataTable = (DataTable)dtGvRepres.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtGvRepres.Visible = true;
                        dataView.RowFilter = "[" + dtGvRepres.Columns[1].Name + "] LIKE '%" + txtRepres.Text.Trim() + "%'";

                        for (int i = 0; i < dtGvRepres.Rows.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                dtGvRepres.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                            }

                        }
                    }

                    dtGvRepres.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtGvRepres.Columns["name_value"].Visible = true;
                    dtGvRepres.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtGvRepres.Columns["name_value"].HeaderText = " Rep. Name";
                    dtGvRepres.Columns["name_value"].Width = 300;
                    //dtGvRepres.Columns["name_value"].ReadOnly = true;
                    dtGvRepres.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGvRepres.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    this.dtGvRepres.ColumnHeadersHeight = 60;
                    dtGvRepres.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtGvRepres.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public void Select_RepGrid_ToTextfield()
        {
            try
            {
                if (dtGvRepres.SelectedCells.Count > 0)
                {
                    // Get the value of the selected cell
                    object cellValue = dtGvRepres.SelectedCells[0].Value;
                    object cellId = dtGvRepres.CurrentRow.Cells["id"].Value;
                    // Check if the cell value is not null
                    if (cellValue != null)
                    {
                        // Convert the cell value to string and assign it to the TextBox
                        txtRepres.Text = cellValue.ToString();
                        RepId_glb = Convert.ToInt32(cellId);
                        dtGvRepres.Visible = false;
                    }
                    txtRepres.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }//

        private void txtRepres_Enter(object sender, EventArgs e)
        {
            if (txtRepres.Text.Trim() != "")
            {
                Select_RepGrid_ToTextfield();
            }
            dtgvShade.Visible = false;
            dtgvJob.Visible = false;
            dtgvColor.Visible = false;
            dtGvCustomer.Visible = false;
        }

        private void dtGvRepres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RepGrid_ToTextfield();
        }
        private void dtGvRepres_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtGvCustomer.Focus();
            }
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtGvCustomer.Visible = false;
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvShade.Visible = false;
                dtgvJob.Visible = false;
                dtgvColor.Visible = false;
                dtGvRepres.Visible = false;

                if (txtCustomer.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtGvCustomer.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtGvCustomer.Visible = true;
                        dataView.RowFilter = "[" + dtGvCustomer.Columns[1].Name + "] LIKE '%" + txtCustomer.Text + "%'";
                    }

                    dtGvCustomer.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtGvCustomer.Columns["name_value"].Visible = true;
                    dtGvCustomer.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtGvCustomer.Columns["name_value"].HeaderText = " Customer";
                    //dtGvCustomer.Columns["name_value"].ReadOnly = true;
                    dtGvCustomer.Columns["name_value"].Width = 300;
                    dtGvCustomer.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGvCustomer.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtGvCustomer.ColumnHeadersHeight = 60;
                    dtGvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtGvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//
        public void Select_CusGrid_ToTextfield()
        {
            if (dtGvCustomer.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtGvCustomer.SelectedCells[0].Value;
                object cellId = dtGvCustomer.CurrentRow.Cells["id"].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtCustomer.Text = cellValue.ToString();
                    CustomerId_glb = Convert.ToInt32(cellId);
                    dtGvCustomer.Visible = false;
                }
                txtCustomer.Focus();
            }
        }//

        private void txtCustomer_Enter(object sender, EventArgs e)
        {

            if (txtCustomer.Text.Trim() != "")
            {
                Select_CusGrid_ToTextfield();
            }
            dtgvShade.Visible = false;
            dtgvJob.Visible = false;
            dtgvColor.Visible = false;
            dtGvRepres.Visible = false;
        }

        private void dtGvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CusGrid_ToTextfield();
        }
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Sum_TotalSchQTY_KG()
        {
            decimal sumQTY = 0;
            decimal SumPack_KG = 0;
            int count = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                if (c >= 0)
                {
                    try
                    {
                        bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[c].Cells["X"].Value);
                        if (checkBoxStatus)
                        {
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["BalQty"].Value) > 0)
                            {
                                count++;

                                decimal QTY = Convert.ToDecimal(gvListData.Rows[c].Cells["BalQty"].Value.ToString());
                                sumQTY += QTY;
                                lblTotalQty.Text = sumQTY.ToString();

                                decimal conePack = Convert.ToDecimal(gvListData.Rows[c].Cells["ConePerPack"].Value);
                                SumPack_KG += decimal.Round(QTY / conePack, 2); // 40/8=5kg
                                lblTotalPack.Text = SumPack_KG.ToString();
                            }
                        }

                        if (count == 0)
                        {
                            lblTotalQty.Text = "0";
                            lblTotalPack.Text = "0";
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
                        Sum_TotalSchQTY_KG();

                    }// if checkbox
                    else
                    {
                        Sum_TotalSchQTY_KG();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtJob.Text = "";
            txtShade.Text = "";
            txtColor.Text = "";
            txtRepres.Text = "";
            txtCustomer.Text = "";
            cmbCount.SelectedIndex = 0;
            cmbFamily.SelectedItem = "N/A";

            lblTotalQty.Text = "0";
            lblTotalPack.Text = "0";

            CustomerId_glb = 0;
            RepId_glb = 0;

            dtgvJob.Visible = false;
            dtgvShade.Visible = false;
            dtgvColor.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepres.Visible = false;

            gvListData.Rows.Clear();
        }
        public string _get_OrderId
        {
            get { return lblJob_Transfer.Text; }
        }
        public string _get_Shade
        {
            get { return lblShade_Transfer.Text; }
        }
        public int _get_NotSamePage
        {
            get { return 1; }
        }
        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 12)
            {
                lblShade_Transfer.Text = "";
                DataGridViewRow row = gvListData.Rows[e.RowIndex];
                string BookingNo = row.Cells["BookingNo"].Value.ToString();
                string Shade = row.Cells["Shade"].Value.ToString();
                lblJob_Transfer.Text = BookingNo;
                lblShade_Transfer.Text = Shade;

                frmScheduleEntry frm = new frmScheduleEntry();
                frm._set_Is_NotSamePage = _get_NotSamePage;
                frm._set_OrderId = _get_OrderId;
                frm._set_Shade = _get_Shade;
                //frm.MdiParent = this;
                frm.Show();

                //if (_ScheduleEntry_ == null || _ScheduleEntry_.IsDisposed)
                //{
                //    _ScheduleEntry_ = new frmScheduleEntry();
                //    _ScheduleEntry_.FormClosed += (s, args) => _ScheduleEntry_ = null;
                //    _ScheduleEntry_.MdiParent = this;
                //    _ScheduleEntry_._set_Is_NotSamePage = _get_NotSamePage;
                //    _ScheduleEntry_._set_OrderId = _get_OrderId;
                //    _ScheduleEntry_._set_Shade = _get_Shade;

                //    _ScheduleEntry_.Show();
                //}
                //else
                //{
                //    _ScheduleEntry_.Focus(); // bring it to front if already open
                //}


            }
        }
    }
}
