using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KDS_Thread.ThreadForm
{
    public partial class frmRpt_Backlog : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_Backlog()
        {
            InitializeComponent();
        }
        private int BookingId_glb = 0;
        private int CustomerId_glb = 0;
        private int RepId_glb = 0;
        private int ProductId_glb = 0;
        private int RetailId_glb = 0;
        int Unit = 0;
        private void frmRpt_Backlog_Load(object sender, EventArgs e)
        {

            gridJob.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gvRetailer.Visible = false;
            gvProduct.Visible = false;

            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());


            dbConCrUser.FillComboBox(cmbZone, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            cmbZone.SelectedItem = "All";

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(-1);
            //dtFromDate.MinDate = DateTime.Now.AddDays(-60);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;
            //dtFromDate.MinDate = DateTime.Now.AddDays(-60);

            dtDeliveryDate.Format = DateTimePickerFormat.Custom;
            dtDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            dtDeliveryDate.Value = DateTime.Now;
            //dtFromDate.MinDate = DateTime.Now.AddDays(-60);


            cmbUnit.SelectedValue = Unit;
            //int UnitId = Convert.ToInt32(cmbUnit.SelectedValue);
            //dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");
            dbConCrUser.FillDataGridView(gridJob, @"T_Get_JobNo_Combined_BySchDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");
            
            dbConCrUser.FillDataGridView(gvRetailer, @"EXEC T_Get_RetailerBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "'");
            dbConCrUser.FillDataGridView(dtGvCustomer, @"EXEC T_Get_Customer_SalesRep_Proc 0, 1");
            dbConCrUser.FillDataGridView(dtGvRepresentative, @"EXEC T_Get_Customer_SalesRep_Proc 0, 2");
            dbConCrUser.FillDataGridView(gvProduct, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");
            
            dbConCrUser.FillComboBox(cmbReport, @"EXEC T_Get_Backlog_ReportList_Proc");
            cmbReport.SelectedItem = "Select";


        }//


        public void clearField()
        {
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gridJob.Visible = false;
            gvProduct.Visible = false;
            gvRetailer.Visible = false;

            //cmbUnit.SelectedIndex = 0;
            cmbZone.SelectedIndex = 0;
            cmbReport.SelectedIndex = 0;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;

            dtDeliveryDate.Format = DateTimePickerFormat.Custom;
            dtDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            dtDeliveryDate.Value = DateTime.Now;

            txtJob.Text = "";
            txtCustomer.Text = "";
            txtRep.Text = "";
            txtProduct.Text = "";
            txtRetailer.Text = "";

            BookingId_glb = 0;
            CustomerId_glb = 0;
            RepId_glb = 0;
            ProductId_glb = 0;
            RetailId_glb = 0;

            //chkFullDelivered.Checked = true;
            //chkLCRecv.Checked = false;
        }//

        //------------- Job field & grid click event
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
                if(txtJob.Text.Trim() != "")
                {
                    dtGvCustomer.Visible = false;
                    gvProduct.Visible = false;
                    dtGvRepresentative.Visible = false;
                    gvRetailer.Visible = false;

                    var dataTable = (DataTable)gridJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridJob.Visible = true;
                        dataView.RowFilter = "[" + gridJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";

                        //gridJob.DefaultCellStyle.BackColor = Color.ForestGreen;
                        //gridJob.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    }

                    gridJob.RowHeadersVisible = false;
                    gridJob.Columns["OrderId"].Visible = true;
                    gridJob.Columns["BookingId"].Visible = false;
                    //// Set the column header text
                    gridJob.Columns["OrderId"].HeaderText = "Order ID";
                    //gridJob.Columns["OrderId"].ReadOnly = true;
                    gridJob.Columns["OrderId"].Width = 300;
                    gridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    gridJob.ColumnHeadersHeight = 60;
                    gridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    gridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
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
                    BookingId_glb = Convert.ToInt32(cellId);
                    gridJob.Visible = false;
                }
                txtJob.Focus();
              
            }
        }//
        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextFiled();
            }
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gvRetailer.Visible = false;
            gvProduct.Visible = false;
        }
        private void gridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }
        //------------- Customer field & grid click event
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
                if(txtCustomer.Text.Trim() != "")
                {
                    gridJob.Visible = false;
                    gvProduct.Visible = false;
                    dtGvRepresentative.Visible = false;
                    gvRetailer.Visible = false;

                    if (txtCustomer.Text.Trim() != "")
                    {
                        var dataTable = (DataTable)dtGvCustomer.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            dtGvCustomer.Visible = true;
                            dataView.RowFilter = "[" + dtGvCustomer.Columns[1].Name + "] LIKE '%" + txtCustomer.Text + "%'";

                            //dtGvCustomer.DefaultCellStyle.BackColor = Color.SlateBlue;
                            //dtGvCustomer.DefaultCellStyle.ForeColor = Color.White;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            gridJob.Visible = false;
            dtGvRepresentative.Visible = false;
            gvRetailer.Visible = false;
            gvProduct.Visible = false;
        }
        private void dtGvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CusGrid_ToTextfield();
        }
        //------------- Sales Representative field & grid click event
        private void txtRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtGvRepresentative.Focus();
            }
        }
        private void txtRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtGvRepresentative.Visible = false;
            }
        }
        private void txtRep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtRep.Text.Trim() != "")
                {
                    gridJob.Visible = false;
                    gvProduct.Visible = false;
                    dtGvCustomer.Visible = false;
                    gvRetailer.Visible = false;

                    if (txtRep.Text.Trim() != "")
                    {
                        var dataTable = (DataTable)dtGvRepresentative.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            dtGvRepresentative.Visible = true;
                            dataView.RowFilter = "[" + dtGvRepresentative.Columns[1].Name + "] LIKE '%" + txtRep.Text + "%'";

                            //dtGvRepresentative.DefaultCellStyle.BackColor = Color.Teal;
                            //dtGvRepresentative.DefaultCellStyle.ForeColor = Color.White;
                        }

                        dtGvRepresentative.RowHeadersVisible = false;
                        //// Show the "shade_name" column
                        dtGvRepresentative.Columns["name_value"].Visible = true;
                        dtGvRepresentative.Columns["id"].Visible = false;

                        //// Set the column header text
                        dtGvRepresentative.Columns["name_value"].HeaderText = " Name";
                        //dtGvRepresentative.Columns["name_value"].ReadOnly = true;
                        dtGvRepresentative.Columns["name_value"].Width = 300;
                        dtGvRepresentative.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dtGvRepresentative.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        dtGvRepresentative.ColumnHeadersHeight = 60;
                        dtGvRepresentative.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        dtGvRepresentative.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public void Select_RepGrid_ToTextfield()
        {
            if (dtGvRepresentative.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtGvRepresentative.SelectedCells[0].Value;
                object cellId = dtGvRepresentative.CurrentRow.Cells["id"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtRep.Text = cellValue.ToString();
                    RepId_glb = Convert.ToInt32(cellId);
                    dtGvRepresentative.Visible = false;
                }
                txtRep.Focus();
            }
        }//
        private void txtRep_Enter(object sender, EventArgs e)
        {       
            if (txtRep.Text.Trim() != "")
            {
                Select_RepGrid_ToTextfield();
            }
            gridJob.Visible = false;
            dtGvCustomer.Visible = false;
            gvRetailer.Visible = false;
            gvProduct.Visible = false;
        }
        private void dtGvRepresentative_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RepGrid_ToTextfield();
        }
        //------------- Retailer field & grid click event
        private void txtRetailer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gvRetailer.Focus();
            }
        }
        private void txtRetailer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gvRetailer.Visible = false;
            }
        }
        private void txtRetailer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtRetailer.Text.Trim() != "")
                {
                    gridJob.Visible = false;
                    gvProduct.Visible = false;
                    dtGvCustomer.Visible = false;
                    dtGvRepresentative.Visible = false;

                    if (txtRetailer.Text.Trim() != "")
                    {
                        var dataTable = (DataTable)gvRetailer.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gvRetailer.Visible = true;
                            dataView.RowFilter = "[" + gvRetailer.Columns[1].Name + "] LIKE '%" + txtRetailer.Text + "%'";

                            //gvRetailer.DefaultCellStyle.BackColor = Color.ForestGreen;
                            //gvRetailer.DefaultCellStyle.ForeColor = Color.White;
                        }

                        gvRetailer.RowHeadersVisible = false;
                        //// Show the "shade_name" column
                        gvRetailer.Columns["RetailerName"].Visible = true;
                        gvRetailer.Columns["RetailerId"].Visible = false;

                        //// Set the column header text
                        gvRetailer.Columns["RetailerName"].HeaderText = " Retailer";
                        //gvRetailer.Columns["RetailerName"].ReadOnly = true;
                        gvRetailer.Columns["RetailerName"].Width = 300;
                        gvRetailer.Columns["RetailerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gvRetailer.Columns["RetailerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        gvRetailer.ColumnHeadersHeight = 60;
                        gvRetailer.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gvRetailer.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }//
        public void Select_RetailGrid_ToTextfield()
        {
            if (gvRetailer.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gvRetailer.SelectedCells[0].Value;
                object cellId = gvRetailer.CurrentRow.Cells["RetailerId"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtRetailer.Text = cellValue.ToString();
                    RetailId_glb = Convert.ToInt32(cellId);
                    gvRetailer.Visible = false;
                }
                txtRetailer.Focus();
            }
        }//
        private void txtRetailer_Enter(object sender, EventArgs e)
        {
            if (txtRetailer.Text.Trim() != "")
            {
                Select_RetailGrid_ToTextfield();
            }
            gridJob.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gvProduct.Visible = false;
        }
        private void gvRetailer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RetailGrid_ToTextfield();
        }

        //------------- Product field & grid click event
        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gvProduct.Focus();
            }
        }
        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gvProduct.Visible = false;
            }
        }
        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtProduct.Text.Trim() != "")
                {
                    gridJob.Visible = false;
                    gvRetailer.Visible = false;
                    dtGvCustomer.Visible = false;
                    dtGvRepresentative.Visible = false;

                    if (txtProduct.Text.Trim() != "")
                    {
                        var dataTable = (DataTable)gvProduct.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gvProduct.Visible = true;
                            dataView.RowFilter = "[" + gvProduct.Columns[1].Name + "] LIKE '%" + txtProduct.Text + "%'";

                            //gvProduct.DefaultCellStyle.BackColor = Color.SeaGreen;
                            //gvProduct.DefaultCellStyle.ForeColor = Color.White;
                        }

                        gvProduct.RowHeadersVisible = false;
                        //// Show the "shade_name" column
                        gvProduct.Columns["ProductName"].Visible = true;
                        gvProduct.Columns["Id"].Visible = false;

                        //// Set the column header text
                        gvProduct.Columns["ProductName"].HeaderText = " Product";
                        //gvProduct.Columns["ProductName"].ReadOnly = true;
                        gvProduct.Columns["ProductName"].Width = 300;
                        gvProduct.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gvProduct.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                       
                        gvProduct.ColumnHeadersHeight = 60;
                        gvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }//
        public void Select_ProductGrid_ToTextfield()
        {
            if (gvProduct.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gvProduct.SelectedCells[0].Value;
                object cellId = gvProduct.CurrentRow.Cells["Id"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtProduct.Text = cellValue.ToString();
                    ProductId_glb = Convert.ToInt32(cellId);
                    gvProduct.Visible = false;
                }
                txtProduct.Focus();
            }
        }//
        private void txtProduct_Enter(object sender, EventArgs e)
        {
            if (txtProduct.Text.Trim() != "")
            {
                Select_ProductGrid_ToTextfield();
            }
            gridJob.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gvRetailer.Visible = false;
        }
        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ProductGrid_ToTextfield();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            txtJob.Text = "";
            txtRetailer.Text = "";
            txtProduct.Text = "";

            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridJob, @"T_Get_JobNo_Combined_BySchDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

            dbConCrUser.FillDataGridView(gvRetailer, @"EXEC T_Get_RetailerBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "'");
            dbConCrUser.FillDataGridView(gvProduct, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            txtJob.Text = "";
            txtRetailer.Text = "";
            txtProduct.Text = "";

            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            //dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");
            dbConCrUser.FillDataGridView(gridJob, @"T_Get_JobNo_Combined_BySchDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

            dbConCrUser.FillDataGridView(gvRetailer, @"EXEC T_Get_RetailerBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "'");
            dbConCrUser.FillDataGridView(gvProduct, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtProduct.Text = "";
                string UnitText = cmbUnit.Text.Trim();
                if (UnitText != "0" && UnitText.Length < 12)
                {
                    int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    dbConCrUser.FillDataGridView(gvProduct, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        public void Backlog_Production_BasedOn_Schedule_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            //string OrderId = txtJob.Text.Trim();

            DateTime FromDate = Convert.ToDateTime(dtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(dtToDate.Text);
            DateTime DeliveryAsOn = Convert.ToDateTime(dtDeliveryDate.Text);

            int IsFullDelivered = 0;
            int IsLCReceive = 0;
            //if(chkFullDelivered.Checked == true)
            //{
            //    IsFullDelivered = 1;
            //}
            //if (chkLCRecv.Checked == true)
            //{
            //    IsLCReceive = 1;
            //}

            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Backlog_Prod_Vs_Sch '" + FromDate + "','" + ToDate + "','" + DeliveryAsOn + "','" + Unit + "','" + Zone + "','" + BookingId_glb + "'," +
                    "'" + CustomerId_glb + "','" + RepId_glb + "','" + ProductId_glb + "','" + IsFullDelivered + "','" + IsLCReceive + "'");
                while (dtRdr.Read())
                {
                    Row++;
                }

                if (Row == 0)
                {
                    MessageBox.Show("There are no data available to show report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load.Close();
                    return;
                }
                cryReport.Load(Application.StartupPath + @"\Report\Backlog_ProdVsSch.rpt");

                cryReport.SetParameterValue("@FromDate", FromDate);
                cryReport.SetParameterValue("@ToDate", ToDate);
                cryReport.SetParameterValue("@DeliveryAsOn", DeliveryAsOn);

                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@Zone", Zone);
                cryReport.SetParameterValue("@OrderId", BookingId_glb);

                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);

                cryReport.SetParameterValue("@FullDelivered", IsFullDelivered);
                cryReport.SetParameterValue("@LCReceive", IsLCReceive);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = " '" + cmbReport.Text + "' Report";
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                load.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Close();
            }
        }//
        public void Backlog_Delivery_BasedOn_Production_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            //string OrderId = txtJob.Text.Trim();

            DateTime FromDate = Convert.ToDateTime(dtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(dtToDate.Text);
            DateTime DeliveryAsOn = Convert.ToDateTime(dtDeliveryDate.Text);

            int IsFullDelivered = 0;
            int IsLCReceive = 0;
            //if(chkFullDelivered.Checked == true)
            //{
            //    IsFullDelivered = 1;
            //}
            //if (chkLCRecv.Checked == true)
            //{
            //    IsLCReceive = 1;
            //}

            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Backlog_Del_Vs_Prod_Proc '" + FromDate + "','" + ToDate + "','" + DeliveryAsOn + "','" + Unit + "','" + Zone + "','" + BookingId_glb + "'," +
                    "'" + CustomerId_glb + "','" + RepId_glb + "','" + ProductId_glb + "','" + IsFullDelivered + "','" + IsLCReceive + "'");
                while (dtRdr.Read())
                {
                    Row++;
                }

                if (Row == 0)
                {
                    MessageBox.Show("There are no data available to show report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load.Close();
                    return;
                }
                cryReport.Load(Application.StartupPath + @"\Report\Backlog_Sys_DelVsProd.rpt");

                cryReport.SetParameterValue("@FromDate", FromDate);
                cryReport.SetParameterValue("@ToDate", ToDate);
                cryReport.SetParameterValue("@DeliveryAsOn", DeliveryAsOn);
                
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@Zone", Zone);
                cryReport.SetParameterValue("@OrderId", BookingId_glb);

                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);

                cryReport.SetParameterValue("@FullDelivered", IsFullDelivered);
                cryReport.SetParameterValue("@LCReceive", IsLCReceive);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = " '" + cmbReport.Text + "' Report";
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                load.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Close();
            }
        }//
        public void Backlog_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            
            int ReportId = Convert.ToInt32(cmbReport.SelectedValue);
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            //string OrderId = txtJob.Text.Trim();

            DateTime FromDate = Convert.ToDateTime(dtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(dtToDate.Text);
            DateTime DeliveryDate = Convert.ToDateTime(dtDeliveryDate.Text);

            int IsFullDelivered = 0;
            int IsLCReceive = 0;
            //if(chkFullDelivered.Checked == true)
            //{
            //    IsFullDelivered = 1;
            //}
            //if (chkLCRecv.Checked == true)
            //{
            //    IsLCReceive = 1;
            //}

            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Backlog_All_Proc '" + FromDate + "','" + ToDate + "','" + DeliveryDate + "','" + BookingId_glb + "','" + Zone + "','" + Unit + "'," +
                    "'" + CustomerId_glb + "','" + RepId_glb + "','" + ProductId_glb + "','" + IsFullDelivered + "','" + IsLCReceive + "','" + ReportId + "'");
                while (dtRdr.Read())
                {
                    Row++;
                }

                if (Row == 0)
                {
                    MessageBox.Show("There are no data available to show report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load.Close();
                    return;
                }
                //string path = Application.StartupPath + @"\Report\ScheduleSummary_Count.rpt";
                cryReport.Load(Application.StartupPath + @"\Report\BacklogAll.rpt");

                cryReport.SetParameterValue("@FromDate", FromDate);
                cryReport.SetParameterValue("@ToDate", ToDate);
                cryReport.SetParameterValue("@DeliveryDate", DeliveryDate);

                //cryReport.SetParameterValue("@OrderId", OrderId);
                cryReport.SetParameterValue("@OrderId", BookingId_glb);
                cryReport.SetParameterValue("@Zone", Zone);
                cryReport.SetParameterValue("@Unit", Unit);

                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);

                cryReport.SetParameterValue("@FullDelivered", IsFullDelivered);
                cryReport.SetParameterValue("@LCReceive", IsLCReceive);
                cryReport.SetParameterValue("@ReportId", ReportId);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = " '" + cmbReport.Text + "' Report";
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                load.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Close();
            }
        }//
        private void btnPreview_Click(object sender, EventArgs e)
        {
            int Report = Convert.ToInt32(cmbReport.SelectedValue);
            if (Report == 0)
            {
                MessageBox.Show("Select Report..!!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(Report == 1) ///--- Production Backlog Based On Schedule
            {
                Backlog_Production_BasedOn_Schedule_Report();
            }
            if(Report == 5) //-- Delivery Backlog Based On Production
            {
                Backlog_Delivery_BasedOn_Production_Report();
            }
            //else
            //{
            //    MessageBox.Show("'"+ cmbReport.SelectedText + "' Report Under Developmet.! Contact With IT.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else 
            //{
            //    Backlog_Report();
            //    //clearField();
            //}



        }//
    }
}
