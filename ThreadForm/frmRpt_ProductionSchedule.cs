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
    public partial class frmRpt_ProductionSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_ProductionSchedule()
        {
            InitializeComponent();
        }
        private int RepId_glb = 0;
        private void frmRpt_ProductionSchedule_Load(object sender, EventArgs e)
        {
            gridRep.Visible = false;
            RepId_glb = 0;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);

            dbConCrUser.FillDataGridView(gridRep, @"EXEC T_Get_Customer_SalesRep_Proc 0, 2");
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            cmbUnit.SelectedValue = Unit;
            dbConCrUser.FillComboBox(cmbMachine, @"SELECT 0 id ,'All' machine_name
                        UNION ALL
                        SELECT id ,LTRIM(RTRIM(machine_name)) machine_name 
                        FROM thread_machine_master 
                        WHERE machine_type = 'DY' AND is_active = 1 AND location_id='" + Unit + "'");
            

        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridRep.Visible = false;
                string UnitText = cmbUnit.Text.Trim();
                if (UnitText != "0" && UnitText.Length < 12)
                {
                    int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                    dbConCrUser.FillComboBox(cmbMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

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
                    var dataTable = (DataTable)gridRep.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        gridRep.Visible = true;
                        dataView.RowFilter = "[" + gridRep.Columns[1].Name + "] LIKE '%" + txtRep.Text + "%'";

                        //gridRep.DefaultCellStyle.BackColor = Color.Navy;
                        //gridRep.DefaultCellStyle.ForeColor = Color.White;
                    }

                    gridRep.RowHeadersVisible = false;
                    //// Show the  column
                    gridRep.Columns["name_value"].Visible = true;
                    gridRep.Columns["id"].Visible = false;

                    //// Set the column header text
                    gridRep.Columns["name_value"].HeaderText = " Name";
                    gridRep.Columns["name_value"].ReadOnly = true;
                    gridRep.Columns["name_value"].Width = 300;
                    gridRep.Columns["name_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridRep.Columns["name_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    gridRep.ColumnHeadersHeight = 60;
                    gridRep.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    gridRep.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
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
        }

        private void gridRep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //RepId_glb = 0;
            Select_RepGrid_ToTextfield();
        }
        public void Production_Schedule_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            int MchId = Convert.ToInt32(cmbMachine.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_ProductionSchedule_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + RepId_glb + "','"+ MchId + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\ProductionSchedule.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@RepId", RepId_glb);
                cryReport.SetParameterValue("@MchId", MchId);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Production Schedule Report";
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
                Production_Schedule_Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
