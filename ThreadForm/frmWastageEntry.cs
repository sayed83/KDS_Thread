using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KDS_Thread.ThreadForm
{
    public partial class frmWastageEntry : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public frmWastageEntry()
        {
            InitializeComponent();
        }

        private void frmWastageEntry_Load(object sender, EventArgs e)
        {
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "dd-MMM-yyyy";
            dtDate.Value = DateTime.Now;

            txtYarnCons.Text = "0";
            txtSoftWin.Text = "0";
            txtDyeing.Text = "0";
            txtFinishing.Text = "0";
            txtLabDyeingTest.Text = "0";
            txtSales.Text = "0";
            txtDeviation.Text = "0";

        }
        private void txtDeviation_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtDeviation.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtDeviation.Text = "0";
            }
        }

        private void txtLabDyeingTest_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtLabDyeingTest.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtLabDyeingTest.Text = "0";
            }
        }

        private void txtYarnCons_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtYarnCons.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtYarnCons.Text = "0";
            }
        }

        private void txtDyeing_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtDyeing.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtDyeing.Text = "0";
            }
        }

        private void txtSoftWin_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtSoftWin.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtSoftWin.Text = "0";
            }
        }

        private void txtFinishing_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtFinishing.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtFinishing.Text = "0";
            }
        }

        private void txtSales_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d*\.?\d+$");
            if (!regex.IsMatch(txtSales.Text))
            {
                MessageBox.Show("Please enter a valid decimal number.");
                txtSales.Text = "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal YarnCon = 0;
                decimal SoftWin = 0;
                decimal Dyeing = 0;
                decimal Finishing = 0;
                decimal LabDyeingTest = 0;
                decimal Sales = 0;
                decimal Deviation = 0;

                if (txtYarnCons.Text != "")
                {
                    YarnCon = Convert.ToDecimal(txtYarnCons.Text);
                }
                else
                {
                    MessageBox.Show("Yarn consumption value empty..!");
                    return;
                }
                if (txtSoftWin.Text != "")
                {
                    SoftWin = Convert.ToDecimal(txtSoftWin.Text);
                }
                else
                {
                    MessageBox.Show("Soft winding value empty..!");
                    return;
                }
                if (txtDyeing.Text != "")
                {
                    Dyeing = Convert.ToDecimal(txtDyeing.Text);
                }
                else
                {
                    MessageBox.Show("Dyeing value empty..!");
                    return;
                }
                if (txtFinishing.Text != "")
                {
                   Finishing = Convert.ToDecimal(txtFinishing.Text);
                }
                else
                {
                    MessageBox.Show("Finishing value empty..!");
                    return;
                }
                if (txtLabDyeingTest.Text != "")
                {
                    LabDyeingTest = Convert.ToDecimal(txtLabDyeingTest.Text);
                }
                else
                {
                    MessageBox.Show("Lab Dyeing & Testing value empty..!");
                    return;
                }
                if (txtSales.Text != "")
                {
                    Sales = Convert.ToDecimal(txtSales.Text);
                }
                else
                {
                    MessageBox.Show("Sales value empty..!");
                    return;
                }
                if (txtDeviation.Text != "")
                {
                    Deviation = Convert.ToDecimal(txtDeviation.Text);
                }
                else
                {
                    MessageBox.Show("Deviation value empty..!");
                    return;
                }
                DateTime WDate = Convert.ToDateTime(dtDate.Text);
                string WastageDate = WDate.ToString("yyyy-MM-dd");
                string EntryBy = frmLogin.UserID.ToString();
                int Unit = Convert.ToInt32(frmLogin.UserLocation.ToString());

                string[] Cols = { "YarnConsumption", "SoftWinding", "Dyeing", "Finishing", "LabDyeTesting", "Sales", "Deviation", "WastageDate", "Unit", "EntryBy", "EntryDate" };
                string[] Vals = { YarnCon.ToString(), SoftWin.ToString(), Dyeing.ToString(), Finishing.ToString(), LabDyeingTest.ToString(), Sales.ToString(), Deviation.ToString(), WastageDate, Unit.ToString(), EntryBy, DateTime.UtcNow.ToString() };
                string sql = dbConCrUser.CreateSQLStatement("WastageInfo", Cols, Vals, "INSERT", null, null);

                if (sql != "")
                {
                    dbConCrUser.DBExecuteScalarWithSQL(sql);

                    txtYarnCons.Text = "0";
                    txtSoftWin.Text = "0";
                    txtDyeing.Text = "0";
                    txtFinishing.Text = "0";
                    txtLabDyeingTest.Text = "0";
                    txtSales.Text = "0";
                    txtDeviation.Text = "0";

                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
