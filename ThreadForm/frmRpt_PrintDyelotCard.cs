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
    public partial class frmRpt_PrintDyelotCard : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmRpt_PrintDyelotCard()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmPrintTravelCard_Load(object sender, EventArgs e)
        {
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'Select' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cmbUnit.SelectedValue = Unit;
            cmbUnit.Enabled = false;

            dbConCrUser.FillComboBox(cmbDyeMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MMM-yyyy";
            dtDate.Value = DateTime.Now;
            //dtDate.MinDate = DateTime.Now;
        }
        public void DyelotCardPrint_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            int MachineId = Convert.ToInt32(cmbDyeMachine.SelectedValue);
            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_Print_DyelotCard_Proc '" + dtDate.Text + "','" + MachineId + "','" + Unit + "'");
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
                cryReport.Load(Application.StartupPath + @"\Report\PrintDyelotCard.rpt");
                cryReport.SetParameterValue("@ProdDate", dtDate.Text);
                cryReport.SetParameterValue("@MachineId", MachineId);
                cryReport.SetParameterValue("@Unit", Unit);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;

                rptForm.Text = "Dyelot Card Print";
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
                if(cmbDyeMachine.Text == "Select")
                {
                    MessageBox.Show("Select Machine..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DyelotCardPrint_Report();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
