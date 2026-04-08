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
    public partial class frmRpt_CurrentStock : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_CurrentStock()
        {
            InitializeComponent();
        }

        private void frmRpt_CurrentStock_Load(object sender, EventArgs e)
        {
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cmbUnit.SelectedValue = Unit;
            cmbUnit.Enabled = false;
            cmbShade.SelectedItem = "ALL";
        }
        public void CurrentStock_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string Shade = cmbShade.Text.Trim();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_CurrentStockStatus_Proc '" + Shade + "','" + Unit + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\CurrentStock.rpt");

                cryReport.SetParameterValue("@Shade", Shade);
                cryReport.SetParameterValue("@Unit", Unit);

                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Current Stock Report";
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
                CurrentStock_Report();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
