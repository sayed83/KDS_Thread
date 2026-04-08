using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmDeleteSchedule : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
        private int rowAdd = 0;
        public frmDeleteSchedule()
        {
            InitializeComponent();
        }

        private void frmDeleteSchedule_Load(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            dtgridJob.Visible = false;
            //label1.Visible = false;
            //lblTotalQty.Visible = false;
            chkAll.Visible = false;

            InitialDataGrid();
            //dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE  ISNULL(IsPlan,0)=0 AND Unit='" + Unit + "' GROUP BY OrderId");
            dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE  ISNULL(IsPlan,0)=0 GROUP BY OrderId");

        }
        private void InitialDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                gvListData.Rows.Clear();

                //this.gvData.EnableHeadersVisualStyles = false;
                //this.gvData.ColumnHeadersHeight = 50;

                // this.gvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

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
                gvListData.Columns.Add("schedule_qty", "QTY");


                gvListData.Columns["ProductName"].Width = 200;
                gvListData.Columns["machine_name"].Width = 80;
                gvListData.Columns["shade"].Width = 100;
                gvListData.Columns["schedule_date"].Width = 110;
                gvListData.Columns["schedule_qty"].Width = 100;

                gvListData.Columns["ProductName"].ReadOnly = true;
                gvListData.Columns["machine_name"].ReadOnly = true;
                gvListData.Columns["shade"].ReadOnly = true;
                gvListData.Columns["schedule_date"].ReadOnly = true;
                gvListData.Columns["schedule_qty"].ReadOnly = true;

                gvListData.Columns.Add("id", "id");
               // gvListData.Columns.Add("process_id", "process_id");
                gvListData.Columns.Add("booking_sub_id", "booking_sub_id");
                gvListData.Columns.Add("product_id", "product_id");
                gvListData.Columns["id"].Visible = false;
                //gvListData.Columns["process_id"].Visible = false;
                gvListData.Columns["booking_sub_id"].Visible = false;
                gvListData.Columns["product_id"].Visible = false;

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
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_Job_ForSchDeleteGV_Proc '" + OrderId + "'");

                rowAdd = gvListData.Rows.Count;
                chkAll.Visible = true;

                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["ProductName"].Value = dr["ProductName"].ToString();
                    gvListData.Rows[rowAdd].Cells["machine_name"].Value = dr["machine_name"].ToString();
                    gvListData.Rows[rowAdd].Cells["shade"].Value = dr["shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = dr["schedule_qty"].ToString();

                    gvListData.Rows[rowAdd].Cells["id"].Value = dr["id"].ToString();
                    //gvListData.Rows[rowAdd].Cells["process_id"].Value = dr["process_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["booking_sub_id"].Value = dr["booking_sub_id"].ToString();
                    gvListData.Rows[rowAdd].Cells["product_id"].Value = dr["product_id"].ToString();

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
        public void Sum_Selected_Lot()
        {
            DataGridViewCheckBoxCell cell = this.gvListData.CurrentCell as DataGridViewCheckBoxCell;

            if (cell != null && !cell.ReadOnly)
            {
                cell.Value = cell.Value == null || !((bool)cell.Value);
                gvListData.CurrentCell.Value = true;
                gvListData.NotifyCurrentCellDirty(true);
                decimal sumQTY = 0;
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
                            decimal qty = Convert.ToDecimal(gvListData.Rows[i].Cells["used_cone"].Value.ToString());
                            sumQTY = sumQTY + qty;
                            //lblTotalQty.Text = sumQTY.ToString();
                        }
                    }//for




                }
                catch { }
            }

            //return sumQTY;
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

        decimal SumQ = 0;

        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /// DataGridViewCheckBoxCell cell = this.gvListData.CurrentCell as DataGridViewCheckBoxCell;

            //if (cell != null && !cell.ReadOnly)
            //{
            //    cell.Value = cell.Value == null || !((bool)cell.Value);
            //    gvListData.CurrentCell.Value = true;
            //    gvListData.NotifyCurrentCellDirty(true);

            //    //DataGridViewRow row = gvListData.Rows[e.RowIndex];
            //    DataGridViewRow selectedRow = gvListData.SelectedRows[0];
            //    bool checkBoxStatus = Convert.ToBoolean(selectedRow.Cells["X"].Value);
            //    Sum_Selected_Lot();

            //    //bool checkBoxStatus_2 = Convert.ToBoolean(selectedRow.Cells["X"].Value);
            //    //try
            //    //{
            //    //    if (gvListData.Rows[e.RowIndex].Cells["X"].Value == null)
            //    //    {
            //    //        checkBoxStatus_2 = false;
            //    //    }
            //    //    else
            //    //    {
            //    //        checkBoxStatus_2 = Convert.ToBoolean((gvListData.Rows[e.RowIndex].Cells["X"].Value).ToString());
            //    //        //checkBoxStatus_2 = true;
            //    //    }

            //    //}
            //    //catch { }

            //    //try
            //    //{
            //    //    if (checkBoxStatus_2)
            //    //    {
            //    //        decimal qty = Convert.ToDecimal(gvListData.Rows[e.RowIndex].Cells["used_cone"].Value.ToString());
            //    //        SumQ += qty;
            //    //        lblTotalQty.Text = SumQ.ToString();
            //    //    }
            //    //}
            //    //catch { }

            //}
        }

        public int Check_IsLotMultipleJob(string lot_no)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT COUNT(*) cnt FROM dbo.thread_lot_details WHERE lot_no='" + lot_no + "'");

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
        public int Check_IsLotExist_ForSchedule(int schedule_id)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT COUNT(*) cnt FROM dbo.thread_lot WHERE schedule_id='" + schedule_id + "'");

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
        public int CheckJob_IsDeleteAllLot(string OrderId)
        {
            int count = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_CheckJob_IsDeleteAllLot_Proc '" + OrderId + "'");

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
        public int Get_BookingId(string OrderId)
        {
            int booking_id = 0;
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction(@"SELECT TOP 1 booking_id FROM dbo.thread_schedule WHERE OrderId='" + OrderId + "' AND ISNULL(IsPlan,0)=0");

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    booking_id = Convert.ToInt32(dr["booking_id"].ToString());
                }
            }

            dr.Close();
            return booking_id;
        }//

        public void Delete_Schedule_Lot()
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

                    string sql_lot_details = "DELETE FROM dbo.thread_lot_details WHERE schedule_id='" + schedule_id + "'";
                    if (sql_lot_details != "")
                    {
                        dbConCrUser.DBInsertUpdateDeleteFunction(sql_lot_details);

                        if (Check_IsLotExist_ForSchedule(schedule_id) > 0)
                        {

                            //string sql_lot = "DELETE FROM dbo.thread_lot WHERE schedule_id = '" + schedule_id + "' ";
                            //dbConCrUser.DBInsertUpdateDeleteFunction(sql_lot);

                            string[] pName = { "@schedule_id" };
                            string[] pVal = { schedule_id.ToString() };
                            dbConCrUser.DBInsertUsingSP(@"T_Delete_ScheduleLot_Proc", pName, pVal);
                        }

                        string sql_schedule = "DELETE FROM dbo.thread_schedule WHERE id = '" + schedule_id + "' ";
                        dbConCrUser.DBInsertUpdateDeleteFunction(sql_schedule);

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
            //lblTotalQty.Text = "0";
            chkAll.Visible = false;

            gvListData.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check_IsSelected() == 0)
                {
                    MessageBox.Show("Select minimum..!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete this.??", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Delete_Schedule_Lot();
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtJobNo.Text.Trim() != "")
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
                    //dtgridJob.Columns["OrderId"].ReadOnly = true;
                    dtgridJob.Columns["OrderId"].Width = 300;
                    dtgridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                    dtgridJob.ColumnHeadersHeight = 60;
                    dtgridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//

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

        private void chkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvListData.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["X"] as DataGridViewCheckBoxCell);
                checkBox.Value = chkAll.Checked;
            }
        }

       
    }
}
