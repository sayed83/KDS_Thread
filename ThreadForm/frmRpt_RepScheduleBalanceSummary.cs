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
using Dapper;

namespace KDS_Thread.ThreadForm
{
    public partial class frmRpt_RepScheduleBalanceSummary : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int CustomerId_glb = 0;
        private int RepId_glb = 0;
        private int ProductId_glb = 0;
        private int RetailId_glb = 0;

        public frmRpt_RepScheduleBalanceSummary()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmRpt_RepScheduleBalanceSummary
            // 
            this.ClientSize = new System.Drawing.Size(1113, 253);
            this.Name = "frmRpt_RepScheduleBalanceSummary";
            this.ResumeLayout(false);

        }
    }
}