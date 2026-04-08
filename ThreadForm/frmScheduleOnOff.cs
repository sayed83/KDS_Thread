using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace KDS_Thread.ThreadForm
{
    public partial class frmScheduleOnOff : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();

        public frmScheduleOnOff()
        {
            InitializeComponent();
        }

        private void frmScheduleOnOff_Load(object sender, EventArgs e)
        {
            cmbOnOff.SelectedItem = "Select";

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MM-yyyy";
            dtDate.Value = DateTime.Now.AddDays(1);
            dtDate.MinDate = DateTime.Now.AddDays(1);

            dbConCrUser.FillComboBox(cmbUnit, @"SELECT 0 as Id,'Select' as Loc_Name
                                          UNION ALL
                                          SELECT Id,Loc_Name FROM dbo.location_info");

            int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());
            cmbUnit.SelectedValue = Unit;


        }
        public void clearField()
        {
            cmbUnit.SelectedIndex = 0;
            cmbOnOff.SelectedIndex = 0;

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MM-yyyy";
            dtDate.Value = DateTime.Now.AddDays(1);
            dtDate.MinDate = DateTime.Now.AddDays(1);
        }
        public int Check_IsExist(string sch_date)
        {
            int count = 0;
            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            SqlDataReader dr = dbConCrUser.DBRetrieveFunction("SELECT COUNT(*) cnt FROM dbo.Schedule_OnOff WHERE Unit='"+ Unit + "' AND schedule_date='" + sch_date + "'");

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
        public void Save()
        {
            string EntryBy = frmLogin.UserID.ToString();

            int Unit = Convert.ToInt32(cmbUnit.SelectedValue);
            string sch_date = dtDate.Text.Trim();
            DateTime sch_date_formated = dtDate.Value;
            //string sch_date = dtDate.CustomFormat = "yyyy-MM-dd";
            string status = cmbOnOff.SelectedItem.ToString();
            
            if (Unit == 0)
            {
                MessageBox.Show("Select Unit..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (status == "Select")
            {
                MessageBox.Show("Select Status..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Check_IsExist(sch_date) == 0)
            {
                string[] Cols = { "schedule_date", "sch_status","Unit", "entryby", "entrydate" };
                string[] Vals = { sch_date_formated.ToString(), status, Unit.ToString(), EntryBy, DateTime.Now.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("Schedule_OnOff", Cols, Vals, "INSERT", null, null);

                if (sql != "")
                {
                    dbConCrUser.DBExecuteScalarWithSQL(sql);
                    clearField();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string[] Cols = { "sch_status", "entryby", "entrydate" };
                string[] Vals = { status, EntryBy, DateTime.Now.ToString() };
                string[] WhCols = { "Unit", "schedule_date" };
                string[] WhVals = { Unit.ToString(), sch_date_formated.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("Schedule_OnOff", Cols, Vals, "UPDATE", WhCols, WhVals);

                if (sql != "")
                {
                    dbConCrUser.DBExecuteScalarWithSQL(sql);
                    clearField();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }//
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to save this schedule date?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//
    }
}
