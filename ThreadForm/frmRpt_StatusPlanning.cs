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
    public partial class frmRpt_StatusPlanning : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_StatusPlanning()
        {
            InitializeComponent();
        }
        private void frmRpt_StatusPlanning_Load(object sender, EventArgs e)
        {
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            cmbUnit.SelectedValue = Unit;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now;
           // dtFromDate.MinDate = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;
            //dtToDate.MinDate = DateTime.Now.AddDays(-1);
        }
        public void PlanningStatus_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Status_Planning_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\Status_Planning.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Unit", Unit);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Planning Status Report";
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.crViewer.Refresh();
                rptForm.UseWaitCursor = false;
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
                if(Unit != 0)
                {
                    PlanningStatus_Report();
                }
                else
                {
                    MessageBox.Show("Select Unit!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
