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
    public partial class frmStockScheduleView : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmStockScheduleView()
        {
            InitializeComponent();
        }

        private void frmStockScheduleView_Load(object sender, EventArgs e)
        {
            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(1);
            //dtFromDate.MinDate = DateTime.Now;

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);
            //dtToDate.MinDate = DateTime.Now;

            InitialDataGrid();
        }
        private void InitialDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;

                //================================= Second DataGrid View ===========================
                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeight = 50;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;


                gvListData.Columns.Add("PlanDate", "Plan Date");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("Machine", "Machine");
                gvListData.Columns.Add("QTY", "QTY");
                gvListData.Columns.Add("EntryBy", "User");
                gvListData.Columns.Add("EntryDate", "Entry Date");


                gvListData.Columns["PlanDate"].Width = 90;
                gvListData.Columns["Shade"].Width = 80;
                gvListData.Columns["ProductName"].Width = 180;
                gvListData.Columns["Machine"].Width = 60;
                gvListData.Columns["QTY"].Width = 60;
                gvListData.Columns["EntryBy"].Width = 70;
                gvListData.Columns["EntryDate"].Width = 120;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);

                ////============================= End Grid =========================\\\\\



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        private void Get_GridDataLoad()
        {
            gvListData.Rows.Clear();
            SqlDataReader dr;
            try
            {
                DateTime FromDate = dtFromDate.Value;
                DateTime ToDate = dtToDate.Value;
                //string Shade = cmbShade.Text.Trim();
                 int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_StockScheduledView_Proc '" + FromDate + "','"+ ToDate + "','" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["PlanDate"].Value = dr["PlanDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["Machine"].Value = dr["Machine"].ToString();
                    gvListData.Rows[rowAdd].Cells["QTY"].Value = Convert.ToInt32(dr["QTY"]);
                    gvListData.Rows[rowAdd].Cells["EntryBy"].Value = dr["EntryBy"].ToString();
                    gvListData.Rows[rowAdd].Cells["EntryDate"].Value = dr["EntryDate"].ToString();
                    rowAdd++;


                }
                dr.Close();
                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Get_GridDataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
