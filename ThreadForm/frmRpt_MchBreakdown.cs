using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace KDS_Thread.ThreadForm
{
    public partial class frmRpt_MchBreakdown : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_MchBreakdown()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmRpt_MchBreakdown_Load(object sender, EventArgs e)
        {
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MMM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(-1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MMM-yyyy";
            dtToDate.Value = DateTime.Now;

            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());

            cmbMchType.SelectedItem = "Select";
            dbConCrUser.FillComboBox_SingleColumn(cmbMachine, @" SELECT  'All' AS MchName UNION ALL SELECT LTRIM(RTRIM(MchName)) FROM ProductionCube.dbo.ThreadMachines
                        WHERE MchType='" + cmbMchType.Text.Trim() + "' AND IsActive=1 AND UnitId='" + Unit + "'");
        }
        public void MachineBreakdown_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string MchType = cmbMchType.Text.Trim();
            string Machine = cmbMachine.Text.Trim();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_MchBreakdown_Proc '" + dtFromDate.Text + "','" + dtToDate.Text + "','" + Unit + "','"+ Machine + "','"+ MchType + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\MachineBreakdown.rpt");

                cryReport.SetParameterValue("@FromDate", dtFromDate.Text);
                cryReport.SetParameterValue("@ToDate", dtToDate.Text);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@Machine", Machine);
                cryReport.SetParameterValue("@MchType", MchType);

                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Machine Breakdown Report";
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
                MachineBreakdown_Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int Unit = frmLogin.UserLocation.ToString();
            //int Unit = 1;
            string MchType = cmbMchType.Text.Trim();
            if (MchType == "DY" || MchType == "SW" || MchType == "WI")
            {
                dbConCrUser.FillComboBox_SingleColumn(cmbMachine, @" SELECT  'All' AS MchName UNION ALL SELECT LTRIM(RTRIM(MchName)) FROM ProductionCube.dbo.ThreadMachines
                        WHERE MchType='" + cmbMchType.Text.Trim() + "' AND IsActive=1 AND UnitId='" + Unit + "'");
            }
        }
    }
}
