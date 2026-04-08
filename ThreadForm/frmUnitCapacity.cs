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
using static System.Windows.Forms.AxHost;

namespace KDS_Thread.ThreadForm
{
    public partial class frmUnitCapacity : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public int rowAdd = 0;
        public frmUnitCapacity()
        {
            InitializeComponent();
        }

        int Unit = 0;
        private void frmUnitCapacity_Load(object sender, EventArgs e)
        {
            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'Select' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cmbUnit.SelectedValue = 0;
            txtCapacity.Text = "0";

            InitialDataGrid();
            Get_GridDataLoad();
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


                gvListData.Columns.Add("Unit", "Unit");
                gvListData.Columns.Add("Capacity", "Capacity");


                gvListData.Columns["Unit"].Width = 100;
                gvListData.Columns["Capacity"].Width = 100;

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
                //int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
                dr = dbConCrUser.DBRetrieveFunction(@"T_Get_UnitCapacity_Proc '" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();
                    gvListData.Rows[rowAdd].Cells["Unit"].Value = dr["Unit"].ToString();
                    gvListData.Rows[rowAdd].Cells["Capacity"].Value = dr["Capacity"].ToString();
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
        public int Bind_Unit_Capacity()
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            int QTY = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT CapacityQty FROM dbo.Unit_Capacity WHERE Unit='" + Unit + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    QTY = Convert.ToInt32(dr["CapacityQty"].ToString());
                }
            }

            dr.Close();
            return QTY;
        }//
        public void Update_UnitCapacity()
        {
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            int EntryBy = Convert.ToInt32(frmLogin.UserID.ToString());
            int Capacity = Convert.ToInt32(txtCapacity.Text);
            if (txtCapacity.Text == "0" || txtCapacity.Text == "")
            {
                MessageBox.Show("Enter capacity qty..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] Cols = { "Unit", "CapacityQty", "EntryBy", "EntryDate" };
            string[] Vals = { Unit.ToString(), Capacity.ToString(), EntryBy.ToString(), DateTime.UtcNow.ToString() };
            string[] WhCols = { "Unit" };
            string[] WhVals = { Unit.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("Unit_Capacity", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
                cmbUnit.SelectedIndex = 0;
                txtCapacity.Text = "0";
                MessageBox.Show("Save Successfully.", "Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Get_GridDataLoad();
            }

        }//
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cmbUnit.SelectedValue) > 0)
                {
                    Update_UnitCapacity();
                }
                else
                {
                    MessageBox.Show("Select Unit..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCapacity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtCapacity.Text = txtCapacity.Text.Remove(txtCapacity.Text.Length - 1);
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string UnitText = cmbUnit.Text.Trim();
                if (UnitText != "0" && UnitText.Length < 12)
                {
                    txtCapacity.Text = Bind_Unit_Capacity().ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
