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
    public partial class frmDuePlanBalance : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        int Unit = 0;
        public frmDuePlanBalance()
        {
            InitializeComponent();
        }



        private void frmDuePlanBalance_Load(object sender, EventArgs e)
        {
            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MM-yyyy";

            InitialDataGrid();
        }
        private void dtPlanDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Bind_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                gvListData.Columns.Add("OrderId", "Order ID");
                gvListData.Columns.Add("Product", "Product");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("PlanQty", "Plan QTY");
                gvListData.Columns.Add("BalanceQty", "Balance QTY");

                gvListData.Columns["OrderId"].Width = 140;
                gvListData.Columns["Product"].Width = 180;
                gvListData.Columns["Shade"].Width = 90;
                gvListData.Columns["PlanQty"].Width = 60;
                gvListData.Columns["BalanceQty"].Width = 60;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.Columns["BalanceQty"].DefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);
                gvListData.Columns["BalanceQty"].DefaultCellStyle.ForeColor = Color.Navy;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }//
        public void Bind_DataLoad()
        {
            SqlDataReader dr;
            try
            {

                gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;

                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                DateTime PlanDate = dtPlanDate.Value;

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Plan_DueBalanceList_Prc '"+ Unit + "','" + PlanDate + "'");

                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["PlanQty"].Value = dr["PlanQty"].ToString();
                    gvListData.Rows[rowAdd].Cells["BalanceQty"].Value = dr["BalanceQty"].ToString();

                    rowAdd++;

                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void gvListData_SelectionChanged(object sender, EventArgs e)
        {
            this.gvListData.ClearSelection();
        }

        private void gvListData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                gvListData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void gvListData_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                gvListData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
