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
    public partial class frmStockPlan : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        public frmStockPlan()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmNonSchBlackWhitePlan_Load(object sender, EventArgs e)
        {
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MMM-yyyy";
            dtPlanDate.Value = DateTime.Now.AddDays(1);
            dtPlanDate.MinDate = DateTime.Now.AddDays(-3);

            dbConCrUser.FillComboBox(cmbPlanMachine, @"T_Get_UnitMachineList_Proc '" + Unit + "'");
            dbConCrUser.FillComboBox(cmbCount, @"SELECT  '0' AS id, 'Select' AS CountGroup
                                                UNION ALL
                                                SELECT DISTINCT LTRIM(RTRIM(CountGroup)) AS id, LTRIM(RTRIM(CountGroup)) CountGroup
                                                FROM SalesCube.dbo. Product
                                                WHERE CategoryId = 3 ORDER BY id");

            dbConCrUser.FillComboBox(cmbShade, @"SELECT 0 AS Id, 'SELECT' AS Shade
	                                            UNION ALL
	                                            SELECT Id,Shade FROM dbo.Stock_ShadeList ORDER BY Id");

            dbConCrUser.FillComboBox(cmbProduct, @"T_Get_WhiteProductByCount_Proc '" + cmbCount.Text.Trim() + "'");

            cmbShade.SelectedItem = "SELECT";
            cmbProduct.SelectedValue = 0;
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
                //gvListData.Columns.Add("CountGroup", "Count");
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
                DateTime PlanDate = dtPlanDate.Value;
                //string Shade = cmbShade.Text.Trim();
                //Unit = frmLogin.UserLocation.ToString();
                //int Unit = 1;
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_StockPlanGrid_Proc '" + PlanDate + "','" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["PlanDate"].Value = dr["PlanDate"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    //gvListData.Rows[rowAdd].Cells["CountGroup"].Value = dr["CountGroup"].ToString();
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
        public void clearField()
        {
            dtPlanDate.Format = DateTimePickerFormat.Custom;
            dtPlanDate.CustomFormat = "dd-MMM-yyyy";
            dtPlanDate.Value = DateTime.Now.AddDays(1);
            dtPlanDate.MinDate = DateTime.Now.AddDays(-3);

            cmbPlanMachine.SelectedIndex = 0;
            cmbShade.SelectedIndex = 0;
            cmbCount.SelectedIndex = 0;
            cmbProduct.SelectedIndex = 0;
            txtQTY.Text = "";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearField();
        }


        private void txtQTY_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQTY.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQTY.Text = txtQTY.Text.Remove(txtQTY.Text.Length - 1);
            }
        }

        private void dtPlanDate_ValueChanged(object sender, EventArgs e)
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
        private void cmbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Count = cmbCount.Text.Trim().ToString();
                if (Count != "Select" && Count.Length > 2 && Count.Length < 10)
                {
                    dbConCrUser.FillComboBox(cmbProduct, @"T_Get_WhiteProductByCount_Proc '" + Count + "'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Save_StockPlan()
        {
            try
            {
                string EntryBy = frmLogin.UserID.ToString();
                //Unit = frmLogin.UserLocation.ToString();

               // int Unit = 1;
                //string EntryBy = "arif";

                string Shade = cmbShade.Text.Trim();
                string CountGroup = cmbCount.Text.Trim();
                int ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
                int PlanMchId = Convert.ToInt32(cmbPlanMachine.SelectedValue);
                DateTime PlanDate = dtPlanDate.Value;
                int QTY = 0;
                if (txtQTY.Text != "")
                {
                    QTY = Convert.ToInt32(txtQTY.Text.Trim());
                }

                if (Shade == "SELECT")
                {
                    MessageBox.Show("Select Shade..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (CountGroup == "Select")
                {
                    MessageBox.Show("Select Count..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ProductId == 0)
                {
                    MessageBox.Show("Select Product..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (PlanMchId == 0)
                {
                    MessageBox.Show("Select Plan Machine..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (QTY == 0)
                {
                    MessageBox.Show("Enter QTY..!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string[] Cols1 = { "Shade", "CountGroup", "ProductId", "PlanMchId", "PlanDate", "QTY", "Unit", "EntryBy", "EntryDate" };
                string[] Vals1 = { Shade, CountGroup, ProductId.ToString(), PlanMchId.ToString(), PlanDate.ToString(), QTY.ToString(), Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("Stock_Plan", Cols1, Vals1, "INSERT", null, null);

                if (sql != "")
                {
                    dbConCrUser.DBExecuteScalarWithSQL(sql);

                    Get_GridDataLoad();
                    clearField();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save_StockPlan();
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
