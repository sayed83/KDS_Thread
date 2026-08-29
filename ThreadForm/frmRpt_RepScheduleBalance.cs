using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmRpt_RepScheduleBalance : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int CustomerId_glb = 0;
        private int RepId_glb = 0;
        private int ProductId_glb = 0;
        private int RetailId_glb = 0;
        public frmRpt_RepScheduleBalance()
        {
            InitializeComponent();
        }

        private void frmRpt_RepScheduleBalance_Load(object sender, EventArgs e)
        {
            dtGvRepresentative.Visible = false;
            dtgvCount.Visible = false;
            dtGvCustomer.Visible = false;
            gridShade.Visible = false;
            gvRetailer.Visible = false;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());

            dbConCrUser.FillComboBox(cmbZone, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            cmbZone.SelectedItem = "All";

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            //cmbUnit.SelectedValue = Unit;

            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_List_Shade_Proc '" + Unit + "'");
            dbConCrUser.FillDataGridView(gvRetailer, @"EXEC T_Get_List_Retailer_Proc '" + Unit + "'");
            dbConCrUser.FillDataGridView(dtGvCustomer, @"EXEC T_Get_List_Customer_Proc '" + Unit + "'");
            dbConCrUser.FillDataGridView(dtGvRepresentative, @"EXEC T_Get_Customer_SalesRep_Proc 0, 2");
            dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_List_Product_Proc '" + Unit + "'");

        }

        //------ Start Shade Part
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
                dtGvCustomer.Visible = false;
                dtGvRepresentative.Visible = false;
                dtgvCount.Visible = false;
                gvRetailer.Visible = false;

                if (txtShade.Text.Trim() != "")
                {
                    var dataTable = (DataTable)gridShade.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridShade.Visible = true;
                        dataView.RowFilter = "[" + gridShade.Columns[0].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";
                    }

                    //Hide row header
                    gridShade.RowHeadersVisible = false;
                    // Show the "shade_name" column
                    gridShade.Columns["Shade"].Visible = true;

                    // Set the column header text
                    gridShade.Columns["Shade"].HeaderText = " Shade";
                    //gridShade.Columns["shade"].ReadOnly = true;
                    gridShade.Columns["Shade"].Width = 200;
                    gridShade.Columns["Shade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridShade.Columns["Shade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    gridShade.ColumnHeadersHeight = 60;
                    gridShade.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    gridShade.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
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
            }
        }//
        private void txtShade_Enter(object sender, EventArgs e)
        {
            if (txtShade.Text.Trim() != "")
            {
                Select_ShadeGrid_ToTextfield();
            }
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            dtgvCount.Visible = false;
            gvRetailer.Visible = false;
        }
        private void gridShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
        }
        //----------- End Shade Part

        //------ Start Representative Part
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
                if (txtRep.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtGvRepresentative.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtGvRepresentative.Visible = true;
                        dataView.RowFilter = "[" + dtGvRepresentative.Columns[1].Name + "] LIKE '%" + txtRep.Text.Trim() + "%'";

                        //dtGvRepresentative.DefaultCellStyle.BackColor = Color.SlateGray;
                        //dtGvRepresentative.DefaultCellStyle.ForeColor = Color.White;
                    }

                    dtGvRepresentative.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtGvRepresentative.Columns["name_value"].Visible = true;
                    dtGvRepresentative.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtGvRepresentative.Columns["name_value"].HeaderText = " Rep. Name";
                   // dtGvRepresentative.Columns["name_value"].ReadOnly = true;
                    dtGvRepresentative.Columns["name_value"].Width = 300;
                    dtGvRepresentative.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGvRepresentative.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtGvRepresentative.ColumnHeadersHeight = 60;
                    dtGvRepresentative.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtGvRepresentative.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch 
            {
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
        }
        //----------- End Representative Part
        private void dtGvRepresentative_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RepGrid_ToTextfield();
        }

        //------ Start Count/Product Part
        private void txtCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvCount.Focus();
            }
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvCount.Visible = false;
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtGvCustomer.Visible = false;
                dtGvRepresentative.Visible = false;
                gridShade.Visible = false;
                gvRetailer.Visible = false;
                if (txtCount.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgvCount.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvCount.Visible = true;
                        dataView.RowFilter = "[" + dtgvCount.Columns[1].Name + "] LIKE '%" + txtCount.Text.Trim() + "%'";
                    }

                    //Hide row header
                    dtgvCount.RowHeadersVisible = false;
                    // Show the  column
                    dtgvCount.Columns["ProductName"].Visible = true;
                    dtgvCount.Columns["Id"].Visible = false;
                    // Set the column header text
                    dtgvCount.Columns["ProductName"].HeaderText = " Product";
                    // dtgvCount.Columns["ProductName"].ReadOnly = true;
                    dtgvCount.Columns["ProductName"].Width = 200;
                    dtgvCount.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvCount.Columns["ProductName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvCount.ColumnHeadersHeight = 60;
                    dtgvCount.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvCount.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Select_CountGrid_ToTextfield()
        {
            if (dtgvCount.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvCount.SelectedCells[0].Value;
                object cellId = dtgvCount.CurrentRow.Cells["Id"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtCount.Text = cellValue.ToString();
                    ProductId_glb = Convert.ToInt32(cellId);
                    dtgvCount.Visible = false;
                }
                txtCount.Focus();
            }
        }//
        private void txtCount_Enter(object sender, EventArgs e)
        {
            if (txtCount.Text.Trim() != "")
            {
                Select_CountGrid_ToTextfield();
            }
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            gvRetailer.Visible = false;
        }
        private void dtgvCount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CountGrid_ToTextfield();
        }
        //------ End Count Part

        //------ Start Customer Part
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
                gridShade.Visible = false;
                dtgvCount.Visible = false;
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
                        dataView.RowFilter = "[" + dtGvCustomer.Columns[1].Name + "] LIKE '%" + txtCustomer.Text.Trim() + "%'";
                    }

                    dtGvCustomer.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtGvCustomer.Columns["CustomerName"].Visible = true;
                    dtGvCustomer.Columns["CustomerId"].Visible = false;

                    //// Set the column header text
                    dtGvCustomer.Columns["CustomerName"].HeaderText = " Customer";
                    //dtGvCustomer.Columns["name_value"].ReadOnly = true;
                    dtGvCustomer.Columns["CustomerName"].Width = 300;
                    dtGvCustomer.Columns["CustomerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGvCustomer.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtGvCustomer.ColumnHeadersHeight = 60;
                    dtGvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtGvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Select_CusGrid_ToTextfield()
        {
            if (dtGvCustomer.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtGvCustomer.SelectedCells[0].Value;
                object cellId = dtGvCustomer.CurrentRow.Cells["CustomerId"].Value;

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
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;
            gvRetailer.Visible = false;
        }

        private void dtGvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CusGrid_ToTextfield();
        }
        //------ End Customer Part

        //------ Start Retailer Part
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
                if (txtRetailer.Text.Trim() != "")
                {
                    gridShade.Visible = false;
                    dtgvCount.Visible = false;
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
                            dataView.RowFilter = "[" + gvRetailer.Columns[1].Name + "] LIKE '%" + txtRetailer.Text.Trim() + "%'";

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
            gridShade.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            dtgvCount.Visible = false;
        }

        private void gvRetailer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RetailGrid_ToTextfield();
        }
        //------ End Retailer Part


        public void Representative_ScheduleBalance_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string Shade = txtShade.Text.Trim();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction
                    ("EXEC T_Rpt_Reprs_ScheduleBalance_Proc_new '" + RepId_glb + "','" + Unit + "','" + Zone + "','" + CustomerId_glb + "','" + ProductId_glb + "','" + RetailId_glb + "','" + Shade + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\Repres_ScheduleBalance.rpt");

                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@Zone", Zone);

                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);
                cryReport.SetParameterValue("@RetailerId", RetailId_glb);
                cryReport.SetParameterValue("@Shade", Shade);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Representative Schedule Balance Report";
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
            try
            {
                //if(RepId_glb == 0)
                //{
                //    MessageBox.Show("Select Representative..!!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //else
                //{
                    Representative_ScheduleBalance_Report();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;
            gvRetailer.Visible = false;

            cmbUnit.SelectedItem = "All";
            cmbZone.SelectedItem = "All";

            txtCustomer.Text = "";
            txtRep.Text = "";
            txtCount.Text = "";
            txtShade.Text = "";
            txtRetailer.Text = "";

            CustomerId_glb = 0;
            RepId_glb = 0;
            ProductId_glb = 0;
            RetailId_glb = 0;
        }
    }
}
