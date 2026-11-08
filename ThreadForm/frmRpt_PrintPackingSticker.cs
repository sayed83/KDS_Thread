using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
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
using static KDS_Thread.ThreadForm.frmRpt_RepScheduleBalance;

namespace KDS_Thread.ThreadForm
{
    public partial class frmRpt_PrintPackingSticker : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        private int rowAdd = 0;
        int BookingSubId_glb = 0;
        int RetailerId_glb = 0;
        int CustomerId_glb = 0;
        int Unit = 0;
        public frmRpt_PrintPackingSticker()
        {
            InitializeComponent();
        }

        private void frmRpt_PrintPackingSticker_Load(object sender, EventArgs e)
        {
            dtgridJob.Visible = false;
            Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            //Unit = 1;


            var date = dbConCrUser.QuerySingle<DatePickerConfig>("select * from DatePickerConfig where ControlName = 'frmRpt_PrintPackingSticker'", null,CommandType.Text);
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = date.CustomFormat;
            dtDate.Value = date.UseCurrentDate ? DateTime.Now : DateTime.MinValue;
            dtDate.MinDate = DateTime.Now.AddDays(date.MinDateOffsetDays);

            InitialDataGrid();
            Bind_DataLoad();
            //dbConCrUser.FillDataGridView(gvListData, @"T_Get_PackingCompletedData_Proc '" + dtDate.Value + "','" + txtJob.Text.Trim() + "','" + Unit + "'");
            //dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.ThreadPCK WHERE Unit='" + Unit + "' AND PKDate='"+ dtDate.Value + "'");
            dbConCrUser.FillDataGridView(dtgridJob, @"SELECT DISTINCT OrderId FROM dbo.ThreadPCK WHERE UnitId='" + Unit + "'");
            txtJob.Focus();

            dbConCrUser.FillComboBox(cmbDeliveryAddress, @"T_Get_DeliveryAddressList_Proc '" + txtJob.Text.Trim() + "','" + Unit + "'");
            cmbDeliveryAddress.SelectedValue = 0;

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

                gvListData.Columns.Add("OrderId", "Booking No");
                gvListData.Columns.Add("Customer", "Customer");
                gvListData.Columns.Add("Shade", "Shade");
                gvListData.Columns.Add("Product", "Product");
                gvListData.Columns.Add("Color", "Color");
                gvListData.Columns.Add("PKQty", "Pack QTY");

                gvListData.Columns["OrderId"].Width = 100;
                gvListData.Columns["Customer"].Width = 130;
                gvListData.Columns["Product"].Width = 130;
                gvListData.Columns["Shade"].Width = 80;
                gvListData.Columns["Color"].Width = 100;
                gvListData.Columns["PKQty"].Width = 70;

                gvListData.Columns["OrderId"].ReadOnly = true;
                gvListData.Columns["Customer"].ReadOnly = true;
                gvListData.Columns["Product"].ReadOnly = true;
                gvListData.Columns["Shade"].ReadOnly = true;
                gvListData.Columns["Color"].ReadOnly = true;
                gvListData.Columns["PKQty"].ReadOnly = true;

                ///===================== Invisible columns ======================\\\\\\\\
                gvListData.Columns.Add("Buyer", "Buyer");
                gvListData.Columns.Add("Style", "Style");
                gvListData.Columns.Add("CountGroup", "CountGroup");
                gvListData.Columns.Add("BookingSubId", "BookingSubId");
                //gvListData.Columns.Add("RetailerId", "RetailerId");
                //gvListData.Columns.Add("CustomerId", "CustomerId");

                gvListData.Columns["Buyer"].Visible = false;
                gvListData.Columns["Style"].Visible = false;
                gvListData.Columns["CountGroup"].Visible = false;
                gvListData.Columns["BookingSubId"].Visible = false;
                //gvListData.Columns["RetailerId"].Visible = false;
                //gvListData.Columns["CustomerId"].Visible = false;

                gvListData.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9F, FontStyle.Bold);

                gvListData.Columns["PKQty"].DefaultCellStyle.BackColor = Color.HotPink;
                gvListData.Columns["PKQty"].DefaultCellStyle.Font = new Font("Calibri", 12F, FontStyle.Bold);

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
                string OrderId = txtJob.Text.Trim();
                dr = dbConCrUser.DBRetrieveFunction(@"EXEC T_Get_PackingCompletedData_Proc '" + dtDate.Value + "','" + txtJob.Text.Trim() + "','" + Unit + "'");

                rowAdd = gvListData.Rows.Count;
                while (dr.Read())
                {
                    gvListData.Rows.Add();

                    gvListData.Rows[rowAdd].Cells["OrderId"].Value = dr["OrderId"].ToString();
                    gvListData.Rows[rowAdd].Cells["Customer"].Value = dr["Customer"].ToString();
                    gvListData.Rows[rowAdd].Cells["Product"].Value = dr["Product"].ToString();
                    gvListData.Rows[rowAdd].Cells["Shade"].Value = dr["Shade"].ToString();
                    gvListData.Rows[rowAdd].Cells["Color"].Value = dr["Color"].ToString();
                    gvListData.Rows[rowAdd].Cells["PKQty"].Value = dr["PKQty"].ToString();
                    
                    gvListData.Rows[rowAdd].Cells["Buyer"].Value = dr["Buyer"].ToString();
                    gvListData.Rows[rowAdd].Cells["Style"].Value = dr["Style"].ToString();
                    gvListData.Rows[rowAdd].Cells["CountGroup"].Value = dr["CountGroup"].ToString();
                    gvListData.Rows[rowAdd].Cells["BookingSubId"].Value = dr["BookingSubId"].ToString();
                    //gvListData.Rows[rowAdd].Cells["RetailerId"].Value = dr["RetailerId"].ToString();
                    //gvListData.Rows[rowAdd].Cells["CustomerId"].Value = dr["CustomerId"].ToString();

                    rowAdd++;
                }

                dr.Close();

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
                Bind_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dtgridJob.Focus();
            }
        }
        private void txtJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Tab)
            {
                dtgridJob.Visible = false;
            }
        }
        private void txtJob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtJob.Text.Trim() != "")
                {
                    var dataTable = (DataTable)dtgridJob.DataSource;
                    //dataTable.Columns[1].ColumnMapping = MappingType.Hidden;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        var dataView = dataTable.DefaultView;
                        dtgridJob.Visible = true;
                        dataView.RowFilter = "[" + dtgridJob.Columns[0].Name + "] LIKE '%" + txtJob.Text.Trim() + "%'";
                    }

                    dtgridJob.RowHeadersVisible = false;
                    dtgridJob.Columns["OrderId"].Visible = true;

                    //// Set the column header text
                    dtgridJob.Columns["OrderId"].HeaderText = " Order ID";
                    dtgridJob.Columns["OrderId"].ReadOnly = true;
                    dtgridJob.Columns["OrderId"].Width = 300;
                    dtgridJob.Columns["OrderId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtgridJob.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                    dtgridJob.ColumnHeadersHeight = 60;
                    dtgridJob.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11F, FontStyle.Bold);
                    dtgridJob.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        public void Select_JobGrid_ToTextFiled()
        {
            if (dtgridJob.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                object cellValue = dtgridJob.SelectedCells[0].Value;

                // Check if the cell value is not null
                if (cellValue != null)
                {
                    // Convert the cell value to string and assign it to the TextBox
                    txtJob.Text = cellValue.ToString();
                    dtgridJob.Visible = false;
                }
                txtJob.Focus();

            }
        }//

        private void txtJob_Enter(object sender, EventArgs e)
        {
            if (txtJob.Text.Trim() != "")
            {
                Bind_DataLoad();
            }
        }

        private void dtgridJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select_JobGrid_ToTextFiled();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gvListData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvListData.SelectedCells.Count > 0)
                {
                    txtCartonPack.Text = "";
                    txtLeftOverQty.Text = "0";
                    txtTotalCarton.Text = "";
                    chkAddCarton.Checked = false;

                    txtJobNoPrint.Text = gvListData.SelectedCells[0].Value.ToString();
                    txtCustomer.Text = gvListData.SelectedCells[1].Value.ToString();
                    txtShade.Text = gvListData.SelectedCells[2].Value.ToString();
                    // txtProduct.Text = gvListData.SelectedCells[3].Value.ToString();
                    txtColor.Text = gvListData.SelectedCells[4].Value.ToString();
                    txtPKQty.Text = gvListData.SelectedCells[5].Value.ToString();
                    txtBuyer.Text = gvListData.SelectedCells[6].Value.ToString();
                    txtStyle.Text = gvListData.SelectedCells[7].Value.ToString();
                    txtCount.Text = gvListData.SelectedCells[8].Value.ToString();

                    BookingSubId_glb = Convert.ToInt32(gvListData.SelectedCells[9].Value.ToString());
                    //RetailerId_glb = Convert.ToInt32(gvListData.SelectedCells[10].Value.ToString());
                    //CustomerId_glb = Convert.ToInt32(gvListData.SelectedCells[11].Value.ToString());
                    dbConCrUser.FillComboBox(cmbDeliveryAddress, @"T_Get_DeliveryAddressList_Proc '" + txtJobNoPrint.Text.Trim() + "','" + Unit + "'");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCartonPack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtCartonPack.Text != "")
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txtCartonPack.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter only numbers.");
                        txtCartonPack.Text = txtCartonPack.Text.Remove(txtCartonPack.Text.Length - 1);
                    }
                    else
                    {
                        int PackQty = Convert.ToInt32(txtPKQty.Text);
                        int CartonPack = Convert.ToInt32(txtCartonPack.Text);
                        int TotalCarton = PackQty / CartonPack;
                        int LeftOverQty = PackQty % CartonPack;

                        txtLeftOverQty.Text = LeftOverQty.ToString();
                        txtTotalCarton.Text = TotalCarton.ToString();
                        chkAddCarton.Checked = false;
                    }
                }
                else
                {
                    txtLeftOverQty.Text = "0";
                    txtTotalCarton.Text = "0";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAddCarton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txtLeftOverQty.Text) > 0)
                {
                    if (chkAddCarton.Checked == true)
                    {
                        int TotalCarton = Convert.ToInt32(txtTotalCarton.Text);
                        int addedCarton = TotalCarton + 1;
                        txtTotalCarton.Text = addedCarton.ToString();
                    }
                    else
                    {
                        int PackQty = Convert.ToInt32(txtPKQty.Text);
                        int CartonPack = Convert.ToInt32(txtCartonPack.Text);
                        int TotalCarton = PackQty / CartonPack;
                        txtTotalCarton.Text = TotalCarton.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("There is no leftover qty.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
        public void Print_PackingSticker_Report()
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = new ReportDocument();
            frmReportLoader rptForm = new frmReportLoader();
            SqlDataReader dtRdr;
            int Row = 0;

            string OrderID = txtJobNoPrint.Text.Trim();
            string Retailer = txtBuyer.Text.Trim();
            string Customer = txtCustomer.Text.Trim();
            string Shade = txtShade.Text.Trim();
            string Count = txtCount.Text.Trim();
            string Color = txtColor.Text.Trim();
            string Style = txtStyle.Text.Trim();
            int DelAddressId = Convert.ToInt32(cmbDeliveryAddress.SelectedValue);
            int PerCartonQty = Convert.ToInt32(txtCartonPack.Text);
            int LeftoverQty = Convert.ToInt32(txtLeftOverQty.Text);
            int TotalCarton = Convert.ToInt32(txtTotalCarton.Text);

            int IsAdd1C = 0;
            if (chkAddCarton.Checked == true)
            {
                IsAdd1C = 1;
            }

            try
            {
                load.Show();
                load.TopMost = true;

                dtRdr = dbConCrUser.DBRetrieveFunction("EXEC T_Rpt_PrintPackingSticker_Proc '" + OrderID + "','" + Count + "','" + PerCartonQty + "','" + LeftoverQty + "','" + IsAdd1C + "','" + TotalCarton + "','" + dtDate.Value + "','" + Unit + "','" + BookingSubId_glb + "','"+ DelAddressId + "'");
                while (dtRdr.Read())
                {
                    Row++;
                }

                if (Row == 0)
                {
                    MessageBox.Show("There are no data available to show report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load.Close();
                    return;
                }
                cryReport.Load(Application.StartupPath + @"\Report\PrintPackingSticker.rpt");

                cryReport.SetParameterValue("@OrderID", OrderID);
                cryReport.SetParameterValue("@Count", Count);
                cryReport.SetParameterValue("@PerCartonQty", PerCartonQty);
                cryReport.SetParameterValue("@LeftoverQty", LeftoverQty);
                cryReport.SetParameterValue("@IsAdd1C", IsAdd1C);
                cryReport.SetParameterValue("@TotalCarton", TotalCarton);
                cryReport.SetParameterValue("@Date", dtDate.Value);
                cryReport.SetParameterValue("@Unit", Unit);
                cryReport.SetParameterValue("@BookingSubId", BookingSubId_glb);
                cryReport.SetParameterValue("@DelAddressId", DelAddressId);


                dbConCrUser.SetReportLogon(cryReport);
                rptForm.crViewer.ReportSource = cryReport;


                rptForm.Text = "Packing Sticker";
                rptForm.crViewer.DisplayGroupTree = false;
                //rptForm.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                rptForm.Show();
                load.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Close();
            }
        }//
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txtTotalCarton.Text) > 0)
                {
                    int IsAdded1c = 0;
                    int LeftOverQty = Convert.ToInt32(txtLeftOverQty.Text);
                    if(LeftOverQty > 0)
                    {
                        if(chkAddCarton.Checked ==true)
                        {
                            IsAdded1c = 1;
                        }
                        if(IsAdded1c == 0)
                        {
                            MessageBox.Show("You didn't add carton for leftover qty.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }// left over
                    int DeliveryAddress = Convert.ToInt32(cmbDeliveryAddress.SelectedValue);
                    if( DeliveryAddress == 0 )
                    {
                        MessageBox.Show("Select Delivery Address.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Print_PackingSticker_Report();
                }
                else
                {
                    MessageBox.Show("Enter quantity per carton.!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//

        private DateTime GetServerDate()
        {
            DateTime serverTime = DateTime.Now; // Fallback to local time if DB fails

            // Replace this with your actual database connection string
            string connString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT GETDATE()", conn))
                {
                    try
                    {
                        conn.Open();
                        serverTime = Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not fetch server date. Using local time. Error: " + ex.Message);
                    }
                }
            }
            return serverTime;
        }

        private void txtPKQty_TextChanged(object sender, EventArgs e)
        {
            txtCartonPack.Text = "";
            txtLeftOverQty.Text = "0";
            txtTotalCarton.Text = "";
            chkAddCarton.Checked = false;
        }

        private void txtPKQty_Enter(object sender, EventArgs e)
        {
            txtCartonPack.Text = "";
            txtLeftOverQty.Text = "0";
            txtTotalCarton.Text = "";
            chkAddCarton.Checked = false;
        }

        public class DatePickerConfig
        {
            public int Id { get; set; }
            public string ControlName { get; set; }
            public string CustomFormat { get; set; }
            public int MinDateOffsetDays { get; set; }
            public bool UseCurrentDate { get; set; }
        }
    }
}
