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
    public partial class frmRpt_UsedLotRepJob : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int RepId_glb = 0;
        public frmRpt_UsedLotRepJob()
        {
            InitializeComponent();
        }

        private void frmRpt_UsedLotRepJob_Load(object sender, EventArgs e)
        {
            gridRep.Visible = false;
            gridJob.Visible = false;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            cmbUnit.SelectedValue = Unit;

            dbConCrUser.FillDataGridView(gridRep, @"EXEC T_Get_Customer_SalesRep_Proc 0, 2");
            dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");


        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + dtFromDate.Text + "' AND '" + dtToDate.Text + "'");
        }

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
                if (txtJob.Text.Trim() != "")
                {
                    gridRep.Visible = false;

                    var dataTable = (DataTable)gridJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridJob.Visible = true;
                        dataView.RowFilter = "[" + gridJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";
                    }

                    gridJob.RowHeadersVisible = false;
                    gridJob.Columns["OrderId"].Visible = true;

                    //// Set the column header text
                    gridJob.Columns["OrderId"].HeaderText = " Job No.";
                    //gridJob.Columns["OrderId"].ReadOnly = true;
                    gridJob.Columns["OrderId"].Width = 200;
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

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
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
            gridRep.Visible = false;
        }

        private void gridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }

        private void txtRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridRep.Focus();
            }
        }

        private void txtRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gridRep.Visible = false;
            }
        }

        private void txtRep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRep.Text.Trim() != "")
                {
                    gridJob.Visible = false;

                    if (txtRep.Text.Trim() != "")
                    {
                        var dataTable = (DataTable)gridRep.DataSource;
                        //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gridRep.Visible = true;
                            dataView.RowFilter = "[" + gridRep.Columns[1].Name + "] LIKE '%" + txtRep.Text.Trim() + "%'";
                        }

                        gridRep.RowHeadersVisible = false;
                        //// Show the "shade_name" column
                        gridRep.Columns["name_value"].Visible = true;
                        gridRep.Columns["id"].Visible = false;

                        //// Set the column header text
                        gridRep.Columns["name_value"].HeaderText = " Rep.Name";
                        //dtGvRepresentative.Columns["name_value"].ReadOnly = true;
                        gridRep.Columns["name_value"].Width = 300;
                        gridRep.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gridRep.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        gridRep.ColumnHeadersHeight = 60;
                        gridRep.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gridRep.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
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
            if (gridRep.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridRep.SelectedCells[0].Value;
                object cellId = gridRep.CurrentRow.Cells["id"].Value;
                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtRep.Text = cellValue.ToString();
                    RepId_glb = Convert.ToInt32(cellId);
                    gridRep.Visible = false;
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
        }

        private void gridRep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_RepGrid_ToTextfield();
        }

        public void UsedLotStatus_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string JobNo = txtJob.Text.Trim();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_UsedLot_RepJobWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + RepId_glb + "','" + JobNo + "','" + Unit + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\UsedLotRepJobWise.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@JobNo", JobNo);
                cryReport.SetParameterValue("@Unit", Unit);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Used Lot Status Report";
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
                UsedLotStatus_Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
