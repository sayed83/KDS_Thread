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
    public partial class frmRpt_ScheduleSummary : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_ScheduleSummary()
        {
            InitializeComponent();
        }

        private int CustomerId_glb = 0;
        private int RepId_glb = 0;
        private int ProductId_glb = 0;
        private void frmRpt_ScheduleSummary_Load(object sender, EventArgs e)
        {
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;
            //txtCount.Enabled = false;
            txtShade.Enabled = false;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());

            dbConCrUser.FillComboBox(cmbZone, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            //cmbZone.SelectedItem = "All";
            cmbSortBy.SelectedItem = "Count";

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;


            //cmbUnit.SelectedIndex = 0;
            //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            cmbUnit.SelectedValue = Unit;
            cmbZone.SelectedValue = Unit;
            //cmbZone.SelectedItem = "All";
            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_Shade_Job_ByScheduleDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "', 1");
            dbConCrUser.FillDataGridView(dtGvCustomer, @"EXEC T_Get_Customer_SalesRep_Proc 0, 1");
            dbConCrUser.FillDataGridView(dtGvRepresentative, @"EXEC T_Get_Customer_SalesRep_Proc 0, 2");
            dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

        }
        private void cmbSortBy_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCount.Text = "";
            txtShade.Text = "";
            gridShade.Visible = false;
            dtgvCount.Visible = false;

            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string SortBy = cmbSortBy.Text;
            if(SortBy == "Count")
            {
                txtCount.Enabled = true;
                txtShade.Enabled = false;
                //gridShade.Visible = false;
                dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

            }
            else if(SortBy == "Shade")
            {
                txtCount.Enabled = false;
                txtShade.Enabled = true;
                //gridShade.Visible = false;

            }
            else 
            {
                txtCount.Text = "";
                txtShade.Text = "";
                txtCount.Enabled = false;
                txtShade.Enabled = false;
                gridShade.Visible = false;
                dtgvCount.Visible = false;
            }//
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_Shade_Job_ByScheduleDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "', 1");
            dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");


        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_Shade_Job_ByScheduleDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "', 1");
            dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");


        }
       
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
                if (txtCount.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgvCount.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvCount.Visible = true;
                        dataView.RowFilter = "[" + dtgvCount.Columns[1].Name + "] LIKE '%" + txtCount.Text.Trim() + "%'";

                        //dtgvCount.DefaultCellStyle.BackColor = Color.Teal;
                        //dtgvCount.DefaultCellStyle.ForeColor = Color.Gold;
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
        }
        private void dtgvCount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CountGrid_ToTextfield();
        }

        //----- End Count
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
                if (txtShade.Text.Trim() != "")
                {
                    var dataTable = (DataTable)gridShade.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridShade.Visible = true;
                        dataView.RowFilter = "[" + gridShade.Columns[0].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";

                        //gridShade.DefaultCellStyle.BackColor = Color.SlateGray;
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

        }

        private void gridShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
        }
        //----- End Shade
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

                if (txtCustomer.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtGvCustomer.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtGvCustomer.Visible = true;
                        dataView.RowFilter = "[" + dtGvCustomer.Columns[1].Name + "] LIKE '%" + txtCustomer.Text.Trim() + "%'";

                        //dtGvCustomer.DefaultCellStyle.BackColor = Color.Teal;
                        //dtGvCustomer.DefaultCellStyle.ForeColor = Color.Gold;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;

        }
        private void dtGvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CusGrid_ToTextfield();
        }

        //----- End Customer
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
                gridShade.Visible = false;
                dtgvCount.Visible = false;
                dtGvCustomer.Visible = false;
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
                    //dtGvRepresentative.Columns["name_value"].ReadOnly = true;
                    dtGvRepresentative.Columns["name_value"].Width = 300;
                    dtGvRepresentative.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGvRepresentative.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtGvRepresentative.ColumnHeadersHeight = 60;
                    dtGvRepresentative.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtGvRepresentative.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtGvCustomer.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;

        }
        private void dtGvRepresentative_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RepGrid_ToTextfield();
        }

        //----- End Representative
        public void clearField()
        {
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;
            gridShade.Visible = false;
            dtgvCount.Visible = false;
            //txtCount.Enabled = false;
            txtShade.Enabled = false;

            //cmbUnit.SelectedItem = "All";
            //cmbZone.SelectedValue = Unit;
            cmbSortBy.SelectedItem = "Count";

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;

            txtCustomer.Text = "";
            txtRep.Text = "";
            txtCount.Text = "";
            txtShade.Text = "";

            CustomerId_glb = 0;
            RepId_glb = 0;
            ProductId_glb = 0;
        }//
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCount.Text = "";
                string UnitText = cmbUnit.Text.Trim();
                if (UnitText !="0" && UnitText.Length < 12)
                {
                    int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");
                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CountWise_Summary_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_CountWise_ScheduleSummary_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + ProductId_glb + "','" + Unit + "','" + CustomerId_glb + "','" + RepId_glb + "','"+ Zone + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\ScheduleSummary_Count.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@Zone", Zone);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Count Wise Schedule Summary Report";
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
        public void ShadeWise_Summary_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Zone = Convert.ToInt32(cmbZone.SelectedValue);
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_ShadeWise_ScheduleSummary_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + txtShade.Text.Trim() + "','" + Unit + "','" + CustomerId_glb + "','" + RepId_glb + "','"+ Zone + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\ScheduleSummary_Shade.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Shade", txtShade.Text.Trim());
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@CusId", CustomerId_glb);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@Zone", Zone);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Shade Wise Schedule Summary Report";
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
            string SortBy = cmbSortBy.Text.Trim();
            if (SortBy == "Shade")
            {
                // print report
                ShadeWise_Summary_Report();
            }
            if (SortBy == "Count")
            {
                // print report
                CountWise_Summary_Report();
            }
            gridShade.Visible = false;
            dtgvCount.Visible = false;
            dtGvCustomer.Visible = false;
            dtGvRepresentative.Visible = false;

        }//
    }
}
