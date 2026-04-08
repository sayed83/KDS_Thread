using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
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
    public partial class frmRpt_DyelotDetails : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_DyelotDetails()
        {
            InitializeComponent();
        }

        private void frmRpt_DyelotDetails_Load(object sender, EventArgs e)
        {
            txtDyeLot.Text = "";
            txtDyeLot.Focus();
        }
        public int Check_IsDyelotExist()
        {
            int IsExist = 0;
            string Dyelot = txtDyeLot.Text.Replace("'", "").Trim().ToString();
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.Plan_Lot WHERE LotNo='" + Dyelot + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    IsExist = Convert.ToInt32(dr["cnt"].ToString());
                }
            }

            dr.Close();
            return IsExist;
        }//
        public void DyelotDetails_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            string Dyelot = txtDyeLot.Text.Replace("'","").Trim().ToString();
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Dyelot_History_Proc '" + Unit + "','" + Dyelot + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\Dyelot_Details.rpt");
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@Dyelot", Dyelot);

                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Dyelot Details Report";
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
                if(Check_IsDyelotExist() > 0)
                {
                    DyelotDetails_Report();

                }
                else
                {
                    MessageBox.Show("No record found..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
