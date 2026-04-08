using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmRpt_SpecificJobStatus : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();

        public frmRpt_SpecificJobStatus()
        {
            InitializeComponent();
        }

        private void frmRpt_SpecificJobStatus_Load(object sender, EventArgs e)
        {
            dtgridJob.Visible = false;
            txtJob.Focus();
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND DATEDIFF(DAY, schedule_date, GETDATE()) <= 365");
           // dbConCrUser.FillComboBox_SingleColumn(cmbShade, @"SELECT DISTINCT Shade FROM KdsThreadPMS.dbo.Plan_Schedule WHERE OrderId='" + txtJob.Text.Trim() + "'");

        }

        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgridJob.Focus();
            }
        }

        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgridJob.Visible = false;
            }
        }

        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgridJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgridJob.Visible = true;
                        dataView.RowFilter = "[" + dtgridJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";

                        //for (int i = 0; i < dtgridJob.Rows.Count; i++)
                        //{
                        //    if (i % 2 == 0)
                        //    {
                        //        dtgridJob.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                        //    }

                        //}
                    }

                    dtgridJob.RowHeadersVisible = false;
                    dtgridJob.Columns["OrderId"].Visible = true;

                    //// Set the column header text
                    dtgridJob.Columns["OrderId"].HeaderText = " Order ID";
                    dtgridJob.Columns["OrderId"].ReadOnly = true;
                    dtgridJob.Columns["OrderId"].Width = 300;
                    dtgridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgridJob.ColumnHeadersHeight = 60;
                    dtgridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        public void Select_JobGrid_ToTextFiled()
        {
            if (dtgridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgridJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    dtgridJob.Visible = false;
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
        }
        private void dtgridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();


            SqlDataReader dtRdr;
            int Row = 0;

            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_SpecificJobStatus_Proc '" + txtJob.Text.Trim() + "'");
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
                //string path = Application.StartupPath + @"\Report\SpecificJobStatus.rpt";
                cryReport.Load(Application.StartupPath + @"\Report\SpecificJobStatus.rpt");
               
                cryReport.SetParameterValue("@OrderId", txtJob.Text.Trim());

                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Specific Job Status Report";
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                load.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Close();
            }
        }//

       
    }
}
