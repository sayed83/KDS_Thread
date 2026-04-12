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
    public partial class frmRpt_BookingReport : Form
    {
        private clsCommonFunctions dbconnection = new clsCommonFunctions();
        public frmRpt_BookingReport()
        {
            InitializeComponent();
        }

        private void frmRpt_BookingReport_Load(object sender, EventArgs e)
        {
            dtFrom.Format = DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "dd-MMM-yyyy";
            dtFrom.Value = DateTime.UtcNow;

            dtTo.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = "dd-MMM-yyyy";
            dtTo.Value = DateTime.UtcNow;

            dbconnection.FillComboBox(cbCategory, @"select 0 CategoryId, 'All' CategoryName
                                                    union all
                                                    select CategoryId, CategoryName from SalesCube.dbo.ProductCategory");

        }

        private void btn_booking_preview_Click(object sender, EventArgs e)
        {
            int UnitId = Convert.ToInt32(cbCategory.SelectedValue);
            //if(UnitId == 0)
            //{
            //    MessageBox.Show("Please Select Unit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            LoadBookingData();
        }

        public void LoadBookingData()
        {
            frmLoader loader = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;
            int CatId = Convert.ToInt32(cbCategory.SelectedValue);
            try
            {
                loader.Show();
                loader.TopMost = true;
                var query = $@"EXEC dbo.PrcRptBookingData '{dtFrom.Text}','{dtTo.Text}',{CatId}";
                dtRdr = dbconnection.DBRetrieveFunction(query);
                while (dtRdr.Read())
                {
                    Row++;
                }
                if(Row == 0)
                {
                    MessageBox.Show("There are no data available to show report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loader.Close();
                    return;
                }

                cryReport.Load(Application.StartupPath + @"\Report\rptBookingSummary.rpt");

                cryReport.SetParameterValue("@FromDate", dtFrom.Text);
                cryReport.SetParameterValue("@ToDate", dtTo.Text);
                cryReport.SetParameterValue("@CategoryId", CatId);

                dbconnection.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;
                rptForm.Text = "Booking Summary Report"; 
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                loader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loader.Close();
            }
        }
    }
}
