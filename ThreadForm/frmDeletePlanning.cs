using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmDeletePlanning : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;
        public frmDeletePlanning()
        {
            InitializeComponent();
        }
        int Unit = 0;
        private void frmDeletePlanning_Load(object sender, EventArgs e)
        {
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString()); 
            dtgridJob.Visible = false;
            chkAll.Visible = false;

            InitialDataGrid();
            dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.Plan_Schedule WHERE ISNULL(IsDye,0)=0 AND Unit='" + Unit + "'");

        }
        private void InitialDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                gvListData.Rows.Clear();

                checkColumn2.Name = "X";
                checkColumn2.HeaderText = "";
                checkColumn2.Width = 30;
                checkColumn2.ReadOnly = false;
                checkColumn2.FillWeight = 10;
                gvListData.Columns.Add(checkColumn2);

                gvListData.Columns.Add("ProductName", "Product");
                gvListData.Columns.Add("machine_name", "Machine");
                gvListData.Columns.Add("shade", "Shade");
                gvListData.Columns.Add("schedule_date", "Date");
                gvListData.Columns.Add("PlanQty", "QTY");


                gvListData.Columns["ProductName"].Width = 200;
                gvListData.Columns["machine_name"].Width = 80;
                gvListData.Columns["shade"].Width = 100;
                gvListData.Columns["schedule_date"].Width = 110;
                gvListData.Columns["PlanQty"].Width = 100;


                gvListData.Columns.Add("id", "id");
                gvListData.Columns["id"].Visible = false;

                gvListData.Columns.Add("MachineId", "MachineId");
                gvListData.Columns["MachineId"].Visible = false;

                gvListData.Columns.Add("CS_SchId", "CS_SchId");
                gvListData.Columns["CS_SchId"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);
                gvListData.DefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Regular);
                //this.gvData.DefaultCellStyle.SelectionBackColor = this.gvData.DefaultCellStyle.BackColor;

                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                gvListData.ColumnHeadersHeight = 40;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

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
                string OrderId = txtJobNo.Text.Trim();
                dtgridJob.Visible = false;
                //string SchDate = dtFromDate.Text;
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Job_DeletePlanGv_Proc '" + OrderId + "'");

                rowAdd = gvListData.Rows.Count;
                chkAll.Visible = true;

                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
                    gvListData.Rows[rowAdd].Cells["shade"].Value = dr["shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["PlanQty"].Value = dr["PlanQty"].ToString();
                    
                    gvListData.Rows[rowAdd].Cells["MachineId"].Value =Convert.ToInt32(dr["MachineId"].ToString());
                    gvListData.Rows[rowAdd].Cells["id"].Value = dr["Id"].ToString();
                    gvListData.Rows[rowAdd].Cells["CS_SchId"].Value = dr["CS_SchId"].ToString();

                    rowAdd++;
                    //}
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public int Check_IsSelected()
        {
            int count = 0;
            bool checkBoxStatus = false;
            try
            {

                for (int i = 0; i <= gvListData.Rows.Count; i++)
                {
                    if (gvListData.Rows[i].Cells["X"].Value == null)
                    {
                        checkBoxStatus = false;
                    }
                    else
                    {
                        checkBoxStatus = Convert.ToBoolean((gvListData.Rows[i].Cells["X"].Value).ToString());
                    }

                    if (checkBoxStatus)
                    {
                        count++;
                    }
                }//for
            }
            catch { }

            return count;
        }//

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                Bind_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public int Check_IsLotExist_ForSchedule(string LotNo)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT COUNT(*) cnt FROM dbo.Plan_Lot WHERE LotNo='" + LotNo + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    count = Convert.ToInt32(dr["cnt"].ToString());
                }
            }

            dr.Close();
            return count;
        }//
        public string Get_LotNo(int schedule_id)
        {
            string LotNo = "";
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT DISTINCT LotNo FROM dbo.Plan_Lot_Details WHERE PlanSchId='" + schedule_id + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    LotNo = dr["LotNo"].ToString();
                }
            }

            dr.Close();
            return LotNo;
        }//
        public int Get_BookingId(string OrderId)
        {
            int booking_id = 0;
            //SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 booking_id FROM dbo.thread_schedule WHERE OrderId='" + OrderId + "' AND ISNULL(IsPlan,0)=0");
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT DISTINCT BookingId FROM SalesCube..BookingMain WHERE LTRIM(BookingNo)= '" + OrderId + "'");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    booking_id = Convert.ToInt32(dr["BookingId"].ToString());
                }
            }

            dr.Close();
            return booking_id;
        }//
        public void Update_ScheduleIsplan(int CS_SchId)
        {
            int IsPlan = 0;
            string[] Cols = { "IsPlan" };
            string[] Vals = { IsPlan.ToString() };
            string[] WhCols = { "id" };
            string[] WhVals = { CS_SchId.ToString() };
            string sql = dbConCrUser.CreateSQLStatement("thread_schedule", Cols, Vals, "UPDATE", WhCols, WhVals);

            if (sql != "")
            {
                dbConCrUser.DBExecuteScalarWithSQL(sql);
            }

        }//
        public void Delete_Plan_Schedule()
        {
            string OrderId = txtJobNo.Text.Trim();
            //string SchDate = dtFromDate.Text;
            //int Booking_id = Get_BookingId(OrderId);

            bool checkBoxStatus = false;
            int gridRow = 0;
            int Count = 0;
            gridRow = gvListData.Rows.Count;
            for (int i = 0; i < gridRow; i++)
            {
                try
                {
                    if (gvListData.Rows[i].Cells["X"].Value == null)
                    {
                        checkBoxStatus = false;
                    }
                    else
                    {
                        checkBoxStatus = Convert.ToBoolean((gvListData.Rows[i].Cells["X"].Value).ToString());
                    }

                }
                catch { }
                if (checkBoxStatus)
                {
                    int schedule_id = Convert.ToInt32(gvListData.Rows[i].Cells["id"].Value.ToString());
                    int CS_SchId = Convert.ToInt32(gvListData.Rows[i].Cells["CS_SchId"].Value.ToString());
                    //DateTime schedule_date = Convert.ToDateTime(gvListData.Rows[i].Cells["schedule_date"].Value.ToString());
                    int MachineId = Convert.ToInt32(gvListData.Rows[i].Cells["MachineId"].Value.ToString());
                    string LotNo = Get_LotNo(schedule_id);
                    string sql_lot_details = "DELETE FROM dbo.Plan_Lot_Details WHERE PlanSchId='" + schedule_id + "'";
                    if (sql_lot_details != "")
                    {
                        dbConCrUser.DBInsertUpdateDeleteFunction(sql_lot_details);

                        if (Check_IsLotExist_ForSchedule(LotNo) > 0)
                        {
                            string[] pName = { "@schedule_id", "@LotNo" };
                            string[] pVal = { schedule_id.ToString(), LotNo };
                            dbConCrUser.DBInsertUsingSP(@"T_Delete_PlanSchedule_Proc", pName, pVal);
                        }

                        string sql_schedule = "DELETE FROM dbo.Plan_Schedule WHERE Id = '" + schedule_id + "' ";
                        dbConCrUser.DBInsertUpdateDeleteFunction(sql_schedule);

                        Update_ScheduleIsplan(CS_SchId);

                        Count++;
                    }
                }

            }//for
            if(Count > 0)
            {
                clearField();
                InitialDataGrid();
                MessageBox.Show("Delete Successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }//
        public void clearField()
        {
            txtJobNo.Text = "";
            dtgridJob.Visible = false;
            chkAll.Visible = false;

            gvListData.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_IsSelected() == 0)
                {
                    MessageBox.Show("Select minimum one..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete this.??", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Delete_Plan_Schedule();
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private void chkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvListData.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["X"] as DataGridViewCheckBoxCell);
                checkBox.Value = chkAll.Checked;
            }
        }//

        private void txtJobNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgridJob.Focus();
            }
        }

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dtgridJob.Visible = false;
            }
        }

        private void txtJobNo_Enter(object sender, EventArgs e)
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

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            var dataTable = (DataTable)dtgridJob.DataSource;
            //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                var dataView = dataTable.DefaultView;
                dtgridJob.Visible = true;
                dataView.RowFilter = "[" + dtgridJob.Columns[0].Name + "] LIKE '%" + txtJobNo.Text.Trim() + "%'";
            }

            foreach (DataGridViewColumn column in dtgridJob.Columns)
            {
                if (column.Name != "OrderId")
                    column.Visible = false;
            }


            dtgridJob.RowHeadersVisible = false;

            dtgridJob.Columns["OrderId"].Visible = true;

            //// Set the column header text
            dtgridJob.Columns["OrderId"].HeaderText = " Job No.";
            dtgridJob.Columns["OrderId"].ReadOnly = true;
            dtgridJob.Columns["OrderId"].Width = 300;
            dtgridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

        }//
        public void Select_JobGrid_ToTextField()
        {
            if (dtgridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgridJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJobNo.Text = cellValue.ToString();
                    dtgridJob.Visible = false;
                }
                txtJobNo.Focus();
            }
        }//

        private void dtgridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextField();
        }

        private void dtgridJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Select_JobGrid_ToTextField();
            }
        }//
    }
}
