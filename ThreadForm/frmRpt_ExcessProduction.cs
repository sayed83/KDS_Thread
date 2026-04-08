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
    public partial class frmRpt_ExcessProduction : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_ExcessProduction()
        {
            InitializeComponent();
        }
        private int ProductId_glb = 0;
        private void frmRpt_ExcessProduction_Load(object sender, EventArgs e)
        {

            gridShade.Visible = false;
            dtgvCount.Visible = false;

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);




            //cmbUnit.SelectedIndex = 0;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            cmbUnit.SelectedValue = Unit;
            cmbUnit.Enabled = false;
            dbConCrUser.FillDataGridView(gridShade, @"EXEC T_Get_Shade_Job_ByScheduleDate_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "', 1");
            dbConCrUser.FillDataGridView(dtgvCount, @"EXEC T_Get_ProductBySchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");

        }

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
            dtgvCount.Visible = false;

            try
            {
                if (txtShade.Text.Trim() != "")
                {
                    var dataTable = (DataTable)gridShade.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridShade.Visible = true;
                        dataView.RowFilter = "[" + gridShade.Columns[0].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";

                        gridShade.DefaultCellStyle.BackColor = Color.Green;
                        gridShade.DefaultCellStyle.ForeColor = Color.White;
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
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        private void gridShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
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
            gridShade.Visible = false;
            try
            {
                if (txtCount.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgvCount.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvCount.Visible = true;
                        dataView.RowFilter = "[" + dtgvCount.Columns[1].Name + "] LIKE '%" + txtCount.Text.Trim() + "%'";

                        dtgvCount.DefaultCellStyle.BackColor = Color.Green;
                        dtgvCount.DefaultCellStyle.ForeColor = Color.White;
                    }

                    //Hide row header
                    dtgvCount.RowHeadersVisible = false;
                    // Show the  column
                    dtgvCount.Columns["ProductName"].Visible = true;
                    dtgvCount.Columns["Id"].Visible = false;
                    // Set the column header text
                    dtgvCount.Columns["ProductName"].HeaderText = " Product";
                    //dtgvCount.Columns["ProductName"].ReadOnly = true;
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
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void dtgvCount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_CountGrid_ToTextfield();
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
        public void ExcessProduction_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string Shade = txtShade.Text.Trim();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_ExcessProduction_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + ProductId_glb + "','"+ Shade + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\ExcessProduction.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@ProductId", ProductId_glb);
                cryReport.SetParameterValue("@Shade", Shade);

                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Excess Production Report";
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
            ExcessProduction_Report();

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);

            cmbUnit.SelectedIndex = 0;
            ProductId_glb = 0;
            txtCount.Text = "";
            txtShade.Text = "";
        }

       

        
    }
}
