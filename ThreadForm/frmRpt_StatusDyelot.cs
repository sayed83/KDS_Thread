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
using System.Xml.Linq;

namespace KDS_Thread.ThreadForm
{
    public partial class frmRpt_StatusDyelot : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_StatusDyelot()
        {
            InitializeComponent();
        }

        private void frmRpt_StatusDyelot_Load(object sender, EventArgs e)
        {
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            cmbUnit.SelectedValue = Unit;

            gridDyeLot.Visible = false;
            cmbDyeMachine.Enabled = false;
            cmbWinMachine.Enabled = false;
           // txtDyeLot.Enabled = false;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;
            //dtFromDate.MinDate = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);
            //dtToDate.MinDate = DateTime.Now.AddDays(-1);


            dbConCrUser.FillComboBox(cmbShift, @"SELECT 0 Id,'Select' ShiftName
                                                UNION ALL
                                                SELECT Id,ShiftName FROM dbo.ShiftInfo");

            dbConCrUser.FillComboBox(cmbDyeMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");

            dbConCrUser.FillComboBox(cmbWinMachine, @"SELECT '0' Id,'Select' ShortNam
                                    UNION ALL
                                    SELECT Id,ShortNam FROM dbo.WindingMachine WHERE Unit='" + Unit + "'");

            cmbStatus.SelectedItem = "Select";
            cmbShift.SelectedValue = 0;

            dbConCrUser.FillDataGridView(gridDyeLot, @"EXEC T_Get_Dyelot_DateWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + cmbStatus.Text.Trim() + "'");

            
        }
        public int Check_IsExists_Dyelot(int Unit)
        {
            int cnt = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("EXEC T_Get_DyelotIsExists_DateWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + cmbStatus.Text.Trim() + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    cnt = Convert.ToInt32(dr["cnt"].ToString());
                }
            }

            dr.Close();
            return cnt;
        }//
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text != "Select" || cmbStatus.Text != "")
            {
                //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                //if (Check_IsExists_Dyelot(Unit) > 0)
                //{
                //    txtDyeLot.Enabled = true;
                //}
                //else
                //{
                //    txtDyeLot.Enabled = false;
                //}


                string Status = cmbStatus.Text.Trim();
                if (Status == "Dyeing")
                {
                    cmbDyeMachine.Enabled = true;
                    cmbWinMachine.Enabled = false;
                }
                else if (Status == "Winding")
                {
                    cmbWinMachine.Enabled = true;
                    cmbDyeMachine.Enabled = false;
                }
                else
                {
                    cmbWinMachine.Enabled = false;
                    cmbDyeMachine.Enabled = false;
                }

                //ClearField();
            }
        }

        private void txtDyeLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridDyeLot.Focus();
            }
        }

        private void txtDyeLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                gridDyeLot.Visible = false;
            }
        }

        private void txtDyeLot_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                if (txtDyeLot.Text.Trim() != "")
                {
                    if (Check_IsExists_Dyelot(Unit) > 0)
                    {
                        var dataTable = (DataTable)gridDyeLot.DataSource;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            var dataView = dataTable.DefaultView;
                            gridDyeLot.Visible = true;
                            dataView.RowFilter = "[" + gridDyeLot.Columns[0].Name + "] LIKE '%" + txtDyeLot.Text.Trim() + "%'";

                            //gridDyeLot.DefaultCellStyle.BackColor = Color.LightPink;
                            //gridDyeLot.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                            //gridDyeLot.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                        }

                        //Hide row header
                        gridDyeLot.RowHeadersVisible = false;
                        // Show the "shade_name" column
                        gridDyeLot.Columns["LotNo"].Visible = true;

                        // Set the column header text
                        gridDyeLot.Columns["LotNo"].HeaderText = "Dyelot";
                        //gridDyeLot.Columns["LotNo"].ReadOnly = true;
                        gridDyeLot.Columns["LotNo"].Width = 200;
                        gridDyeLot.Columns["LotNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gridDyeLot.Columns["LotNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                        gridDyeLot.ColumnHeadersHeight = 60;
                        gridDyeLot.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                        gridDyeLot.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    }

                }

            }
            catch 
            {
                //MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Select_DyeLotGrid_ToTextfield()
        {
            if (gridDyeLot.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = gridDyeLot.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtDyeLot.Text = cellValue.ToString();
                    gridDyeLot.Visible = false;
                }
                txtDyeLot.Focus();
            }
        }//

        private void gridDyeLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_DyeLotGrid_ToTextfield();
        }
        private void gridDyeLot_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridDyeLot, @"EXEC T_Get_Dyelot_DateWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + cmbStatus.Text.Trim() + "'");
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            dbConCrUser.FillDataGridView(gridDyeLot, @"EXEC T_Get_Dyelot_DateWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + cmbStatus.Text.Trim() + "'");
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string UnitText = cmbUnit.Text.Trim();
            if (UnitText != "0" && UnitText.Length < 12)
            {
                int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                dbConCrUser.FillDataGridView(gridDyeLot, @"EXEC T_Get_Dyelot_DateWise_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + cmbStatus.Text.Trim() + "'");
            }
        }
        public void ClearField()
        {
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;
            //dtFromDate.MinDate = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);
            //dtToDate.MinDate = DateTime.Now.AddDays(-1);

            cmbStatus.SelectedIndex = 0;
            cmbUnit.SelectedIndex = 0;
            cmbShift.SelectedIndex = 0;
            cmbDyeMachine.SelectedIndex = 0;
            cmbWinMachine.SelectedIndex = 0;
            txtDyeLot.Text = "";
            gridDyeLot.Visible = false;
            cmbWinMachine.Enabled = false;
            cmbDyeMachine.Enabled = false;

        }
        public void Status_Report(string ProdStage)
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            int ShiftId = Convert.ToInt32(cmbShift.SelectedValue);
            string Dyelot = txtDyeLot.Text.Trim();
            int DyeMchId = Convert.ToInt32(cmbDyeMachine.SelectedValue);
            int WinMchId = Convert.ToInt32(cmbWinMachine.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_StatusDyelot_Proc '" + ProdStage + "','" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','" + DyeMchId + "','" + WinMchId + "','" + Dyelot + "','" + ShiftId + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\Status_Dyelot.rpt");

                cryReport.SetParameterValue("@ProductionStage", ProdStage);
                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@DyeMchId", DyeMchId);
                cryReport.SetParameterValue("@WinMchId", WinMchId);
                cryReport.SetParameterValue("@Dyelot", Dyelot);
                cryReport.SetParameterValue("@ShiftId", ShiftId);



                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = " "+ ProdStage + " Status Report";
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
                int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                if(Unit == 0)
                {
                    MessageBox.Show("Select Unit..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string Status = cmbStatus.Text.Trim();
                if(Status != "Select" )
                {
                    Status_Report(Status);
                    //ClearField();
                }
                else
                {
                    MessageBox.Show("Select Status..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
