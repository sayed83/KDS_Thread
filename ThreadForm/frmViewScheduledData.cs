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
    public partial class frmViewScheduledData : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
        DataGridViewImageColumn SelectBtn = new DataGridViewImageColumn();
        private int rowAdd = 0;
        public frmViewScheduledData()
        {
            InitializeComponent();
        }

        private void frmViewScheduledData_Load(object sender, EventArgs e)
        {
            dtgvJob.Visible = false;
            dtgvShade.Visible = false;

            dtFromDate.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = "dd-MM-yyyy";
            dtFromDate.Value = DateTime.Now.AddDays(1);

            dtToDate.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = "dd-MM-yyyy";
            dtToDate.Value = DateTime.Now.AddDays(1);

            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");
            cmbSchMachine.SelectedItem = "Select";


            dbConCrUser.FillDataGridView(dtgvJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");
            dbConCrUser.FillDataGridView(dtgvShade, @"SELECT DISTINCT Shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");

            InitDataGrid();
            Get_GridDataLoad();
        }
        private void InitDataGrid()
        {
            try
            {
                gvListData.Columns.Clear();
                //gvListData.Rows.Clear();
                gvListData.AllowUserToAddRows = false;

                //================================= Second DataGrid View ===========================
                this.gvListData.EnableHeadersVisualStyles = false;
                this.gvListData.ColumnHeadersHeight = 50;
                gvListData.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;

                chkColumn.Name = "X";
                chkColumn.HeaderText = "";
                chkColumn.Width = 30;
                chkColumn.ReadOnly = false;
                chkColumn.FillWeight = 10;
                gvListData.Columns.Add(chkColumn);

                gvListData.Columns.Add("schedule_date", "Sch. Date");
                gvListData.Columns.Add("OrderId", "Booking No");
                gvListData.Columns.Add("Customer", "Customer");
                gvListData.Columns.Add("Rep", "Rep.Name");
                gvListData.Columns.Add("Product", "Product");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Color", "Color");
                //gvListData.Columns.Add("WashType", "WashType");
                gvListData.Columns.Add("cone_per_pack", "Cone Pack");
                gvListData.Columns.Add("Machine", "Mch.");
                gvListData.Columns.Add("schedule_qty", "Sch. Qty");
                gvListData.Columns.Add("PlanQty", "Plan Qty");
                gvListData.Columns.Add("BalQty", "Balance Qty");
                gvListData.Columns.Add("PKG", "PKG");

                gvListData.Columns["schedule_date"].Width = 90;
                gvListData.Columns["OrderId"].Width = 100;
                gvListData.Columns["Customer"].Width = 120;
                gvListData.Columns["Rep"].Width = 100;
                gvListData.Columns["Product"].Width = 150;
                gvListData.Columns["Shade"].Width = 80;
                gvListData.Columns["Color"].Width = 100;
                //gvListData.Columns["WashType"].Width = 80;
                gvListData.Columns["cone_per_pack"].Width = 50;
                gvListData.Columns["PKG"].Width = 50;
                gvListData.Columns["Machine"].Width = 50;
                gvListData.Columns["schedule_qty"].Width = 60;
                gvListData.Columns["PlanQty"].Width = 60;
                gvListData.Columns["BalQty"].Width = 60;

                gvListData.Columns["schedule_date"].ReadOnly = true;
                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["Rep"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                //gvListData.Columns["WashType"].ReadOnly = true;
                gvListData.Columns["cone_per_pack"].ReadOnly = true;
                gvListData.Columns["PKG"].ReadOnly = true;
                gvListData.Columns["Machine"].ReadOnly = true;
                gvListData.Columns["schedule_qty"].ReadOnly = true;
                gvListData.Columns["PlanQty"].ReadOnly = true;
                gvListData.Columns["BalQty"].ReadOnly = true;
                gvListData.Columns["PKG"].ReadOnly = true;

                SelectBtn.Image = Properties.Resources.right_arrow1;
                SelectBtn.HeaderText = "";
                SelectBtn.Name = "btnSelect";
                gvListData.Columns.Add(SelectBtn);
                gvListData.Columns["btnSelect"].Width = 50;

                gvListData.Columns["btnSelect"].Visible = false;

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
            SqlDataReader dr;
            try
            {
                gvListData.Rows.Clear();
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
                //int Unit = 1;
                DateTime FromDate = dtFromDate.Value;
                DateTime ToDate = dtToDate.Value;
                string OrderID = txtJob.Text.Trim();
                string Shade = txtShade.Text.Trim();
                int MachineId = Convert.ToInt32(cmbSchMachine.SelectedValue);

                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_ViewScheduledForPlan_Proc '" + FromDate + "','" + ToDate + "','" + OrderID + "','" + Shade + "','" + MachineId + "' ,'" + Unit + "'");
                // gvListData.ReadOnly = true;
                rowAdd = gvListData.Rows.Count;
                int TotalSchQty = 0;
                int TotalPlanQty = 0;
                int TotalBalanceQty = 0;
                while (dr.Read())
                {
                    //dgvListData.ClearSelection();
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["schedule_date"].Value = dr["schedule_date"].ToString();
                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["Rep"].Value = dr["Rep"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();
                    //gvListData.Rows[rowAdd].Cells["WashType"].Value = dr["WashType"].ToString();
                    gvListData.Rows[rowAdd].Cells["cone_per_pack"].Value = dr["cone_per_pack"].ToString();
                    gvListData.Rows[rowAdd].Cells["Machine"].Value = dr["Machine"].ToString();

                    gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = Convert.ToInt32(dr["schedule_qty"]);
                    gvListData.Rows[rowAdd].Cells["PlanQty"].Value = Convert.ToInt32(dr["PlanQty"]);
                    gvListData.Rows[rowAdd].Cells["BalQty"].Value = Convert.ToInt32(dr["BalQty"]);
                    gvListData.Rows[rowAdd].Cells["PKG"].Value = Convert.ToDecimal(dr["PKG"]);

                    rowAdd++;
                    TotalSchQty += Convert.ToInt32(dr["schedule_qty"]);
                    TotalPlanQty += Convert.ToInt32(dr["PlanQty"]);
                    TotalBalanceQty += Convert.ToInt32(dr["BalQty"]);
                }
                // for total sum
                gvListData.Rows.Add();
                gvListData.Rows[rowAdd].DefaultCellStyle.BackColor = System.Drawing.Color.HotPink;
                gvListData.Rows[rowAdd].DefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);
                gvListData.Rows[rowAdd].Cells["schedule_qty"].Value = TotalSchQty;
                gvListData.Rows[rowAdd].Cells["PlanQty"].Value = TotalPlanQty;
                gvListData.Rows[rowAdd].Cells["BalQty"].Value = TotalBalanceQty;
                gvListData.Rows[rowAdd].Cells["X"].ReadOnly = true;

                dr.Close();
                gvListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;

            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");
            dbConCrUser.FillDataGridView(dtgvJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");
            dbConCrUser.FillDataGridView(dtgvShade, @"SELECT DISTINCT Shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");

        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //int Unit = 1;
            DateTime FromDate = dtFromDate.Value;
            DateTime ToDate = dtToDate.Value;
           
            dbConCrUser.FillComboBox(cmbSchMachine, @"T_Get_MachineList_OnScheduleDate_Proc '" + FromDate + "','" + ToDate + "','" + Unit + "'");
            dbConCrUser.FillDataGridView(dtgvJob, @"SELECT DISTINCT OrderId FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");
            dbConCrUser.FillDataGridView(dtgvShade, @"SELECT DISTINCT Shade FROM dbo.thread_schedule WHERE Unit='" + Unit + "' AND schedule_date BETWEEN '" + FromDate + "' AND '" + ToDate + "'");

        }


        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvJob.Focus();
            }
        }

        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvJob.Visible = false;
            }
        }

        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() != "")
                {
                    dtgvShade.Visible = false;
                    var dataTable = (DataTable)dtgvJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvJob.Visible = true;
                        dataView.RowFilter = "[" + dtgvJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";
                    }

                    dtgvJob.RowHeadersVisible = false;
                    //// Show the "shade_name" column
                    dtgvJob.Columns["OrderId"].Visible = true;
                    //dtgvJob.Columns["id"].Visible = false;

                    //// Set the column header text
                    dtgvJob.Columns["OrderId"].HeaderText = " Order ID";
                    //dtgvJob.Columns["OrderId"].ReadOnly = true;
                    dtgvJob.Columns["OrderId"].Width = 300;
                    dtgvJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvJob.ColumnHeadersHeight = 60;
                    dtgvJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public void Select_JobGrid_ToTextfield()
        {
            if (dtgvJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    dtgvJob.Visible = false;
                }
                txtJob.Focus();
            }
        }//

        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Select_JobGrid_ToTextfield();
            }
            dtgvShade.Visible = false;
        }
        private void dtgvJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextfield();
        }
        private void txtShade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgvShade.Focus();
            }
        }

        private void txtShade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgvShade.Visible = false;
            }
        }

        private void txtShade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtShade.Text.Trim() != "")
                {
                    dtgvJob.Visible = false;
                    var dataTable = (DataTable)dtgvShade.DataSource;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgvShade.Visible = true;
                        dataView.RowFilter = "[" + dtgvShade.Columns[0].Name + "] LIKE '%" + txtShade.Text.Trim() + "%'";

                        for (int i = 0; i < dtgvShade.Rows.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                dtgvShade.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                            }

                        }
                    }
                    foreach (DataGridViewColumn column in dtgvShade.Columns)
                    {
                        //column.Visible = false;
                        if (column.Name != "Shade")
                            column.Visible = false;
                    }

                    //Hide row header
                    dtgvShade.RowHeadersVisible = false;
                    // Show the "shade_name" column
                    dtgvShade.Columns["Shade"].Visible = true;

                    // Set the column header text
                    dtgvShade.Columns["Shade"].HeaderText = " Shade";
                   // dtgvShade.Columns["Shade"].ReadOnly = true;
                    dtgvShade.Columns["Shade"].Width = 200;
                    dtgvShade.Columns["Shade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgvShade.Columns["Shade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgvShade.ColumnHeadersHeight = 60;
                    dtgvShade.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgvShade.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        public void Select_ShadeGrid_ToTextfield()
        {
            if (dtgvShade.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgvShade.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtShade.Text = cellValue.ToString();
                    dtgvShade.Visible = false;
                }
                txtShade.Focus();
            }
        }//

        private void txtShade_Enter(object sender, EventArgs e)
        {
            if (txtShade.Text.Trim() != "")
            {
                Select_ShadeGrid_ToTextfield();
            }
            dtgvJob.Visible = false;
        }

        private void dtgvShade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_ShadeGrid_ToTextfield();
        }
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
        public void Sum_TotalSchQTY_KG()
        {
            decimal sumQTY = 0;
            decimal SumPack_KG = 0;
            int count = 0;
            for (int c = 0; c < gvListData.Rows.Count; c++)
            {
                if (c >= 0)
                {
                    try
                    {
                        bool checkBoxStatus = Convert.ToBoolean(gvListData.Rows[c].Cells["X"].Value);
                        if (checkBoxStatus)
                        {
                            if (Convert.ToDecimal(gvListData.Rows[c].Cells["BalQty"].Value) > 0)
                            {
                                count++;

                                decimal QTY = Convert.ToDecimal(gvListData.Rows[c].Cells["BalQty"].Value.ToString());
                                sumQTY += QTY;
                                lblTotalQty.Text = sumQTY.ToString();

                                decimal conePack = Convert.ToDecimal(gvListData.Rows[c].Cells["PKG"].Value);
                                SumPack_KG += conePack;
                                lblTotalPack.Text = SumPack_KG.ToString();
                            }
                        }

                        if (count == 0)
                        {
                            lblTotalQty.Text = "0";
                            lblTotalPack.Text = "0";
                        }


                    }
                    catch { }
                }

            }// for
        }//
        private void gvListData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //gvListData.BeginEdit(true);
                if (e.ColumnIndex == 0)
                {
                    gvListData.EndEdit();

                    // DataGridViewRow selectedRow = gvListData.SelectedRows[0];
                    DataGridViewRow row = gvListData.Rows[e.RowIndex];
                    // Get the value of the checkbox cell in the selected row

                    bool checkBoxStatus = Convert.ToBoolean(row.Cells["X"].Value);
                    if (checkBoxStatus)
                    {
                        Sum_TotalSchQTY_KG();

                    }// if checkbox
                    else
                    {
                        Sum_TotalSchQTY_KG();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public string _get_OrderId
        {
            get { return lblJob_Transfer.Text; }
        }
        public string _get_Shade
        {
            get { return lblShade_Transfer.Text; }
        }
        public int _get_NotSamePage
        {
            get { return 1; }
        }
        private void gvListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                lblShade_Transfer.Text = "";
                DataGridViewRow row = gvListData.Rows[e.RowIndex];
                string OrderId = row.Cells["OrderId"].Value.ToString();
                string Shade = row.Cells["Shade"].Value.ToString();
                lblJob_Transfer.Text = OrderId;
                lblShade_Transfer.Text = Shade;

                frmPlanningSchedule frm = new frmPlanningSchedule();
                frm._set_Is_NotSamePage = _get_NotSamePage;
                frm._set_OrderId = _get_OrderId;
                frm._set_Shade = _get_Shade;
                //frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
