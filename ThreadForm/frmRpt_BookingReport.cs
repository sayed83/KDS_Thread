using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            dbconnection.FillComboBox(cbUnit, @"SELECT 0 as Id,'All' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cbUnit.SelectedValue = Unit;
        }

        private void btn_booking_preview_Click(object sender, EventArgs e)
        {
            int UnitId = Convert.ToInt32(cbUnit.SelectedValue);
        }
    }
}
