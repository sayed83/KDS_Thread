using KDS_Thread.ThreadForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread
{
    public partial class MDIMain : Form
    {
        private clsCommonFunctions dbConCrUser = new clsCommonFunctions();
        public DateTime cTime;
        private bool isLogin = true;
        public MDIMain(bool isLoggedin)
        {
            InitializeComponent();
            isLogin = isLoggedin;
        }
        
        private frmBookingCSView _BookingCSView_;
        private frmDeletePlanning _DeletePlanning_;
        private frmDeleteSchedule _DeleteSchedule_;

        private frmDespatchEntry _DespatchEntry_;
        private frmDuePlanBalance _DuePlanBalance_;
        private frmDyeEntry _DyeEntry_;
        private frmMachineBreakdown _MachineBreakdown_;
        private frmMachineCapacity _MachineCapacity_;
        private frmPackingEntry _PackingEntry_;

        private frmPasswordChange _PasswordChange_;
        private frmPlanningSchedule _PlanningSchedule_;
        
        private frmRpt_Backlog _Rpt_Backlog_;
        private frmRpt_CurrentProduction _Rpt_CurrentProduction_;
        private frmRpt_CurrentStock _Rpt_CurrentStock_;
        private frmRpt_ExcessProduction _Rpt_ExcessProduction_;

        private frmRpt_LotCapacityStatus _Rpt_LotCapacityStatus_;
        private frmRpt_MchBreakdown _Rpt_MchBreakdown_;
        private frmRpt_PrintDyelotCard _Rpt_PrintDyelotCard_;
        private frmRpt_PrintPackingSticker _Rpt_PrintPackingSticker_;
        private frmRpt_ProductionSchedule _Rpt_ProductionSchedule_;
        private frmRpt_RepScheduleBalance _Rpt_RepScheduleBalance_;
        private frmRpt_ScheduleRegister _Rpt_ScheduleRegister_;

        private frmRpt_ScheduleSummary _Rpt_ScheduleSummary_;
        private frmRpt_SpecificJobStatus _Rpt_SpecificJobStatus_;
        private frmRpt_StatusDyelot _Rpt_StatusDyelot_;
        private frmRpt_StatusPlanning _Rpt_StatusPlanning_;
        private frmRpt_UsedLotRepJob _Rpt_UsedLotRepJob_;
        private frmRpt_Wastage _Rpt_Wastage_;


        private frmScheduleEntry _ScheduleEntry_;
        private frmScheduleOnOff _ScheduleOnOff_;
        private frmStockEntry _StockEntry_;
        private frmStockPlan _StockPlan_;
        private frmStockSchDelivery _StockSchDelivery_;
        private frmWhiteSchedule _WhiteSchedule_;
        private frmStockScheduleView _StockScheduleView_;

        private frmUnitCapacity _UnitCapacity_;
        private frmUnitMchLotSet _UnitMchLotSet_;
        private frmUpdateSchedule _UpdateSchedule_;
        private frmUserAdd _UserAdd_;
        private frmViewScheduledData _ViewScheduledData_;
        private frmWastageEntry _WastageEntry_;
        private frmWindingEntry _WindingEntry_;
        private frmRpt_DyelotDetails _DyelotDetail_;

        private frmRpt_SupplyChain _SupplyChain_;
        private frmOTEntry _OTEntry_;
        private frmRpt_JobStatus _JobStatus_;

        private frmRpt_BookingReport _booking;

        private void MDIMain_Load(object sender, EventArgs e)
        {

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Normal; // Ensure it's not maximized
            //this.Bounds = Screen.PrimaryScreen.WorkingArea; // Fit within working area
            //this.ControlBox = true;
            //x v this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;

            this.Location = new Point();

            this.StartPosition = FormStartPosition.Manual;


            tslblUserFullName.Text = " User: " + frmLogin.LoginID;
            cTime = dbConCrUser.GetServerCurrentDateTime();
            timer1.Enabled = true;
            tslblVersion.Text = " Version: " + frmLogin.GetPublishedVersion().ToString();
            usedLotStatusJobRepWiseToolStripMenuItem.Visible = false;

            RoleWiseEnabledMenu();

        }
        public void RoleWiseEnabledMenu()
        {
            /////---- Role setup

            int UserRole = Convert.ToInt32(frmLogin.RoleId.ToString());


            if (UserRole == 1) //-- Admin (IT)
            {
                AdminUserToolStripMenuItem.Enabled = true;
            }
            else
            {
                AdminUserToolStripMenuItem.Enabled = false;
            }

            if (UserRole == 1 || UserRole == 2) //-- Admin(IT) & CS
            {
                ConfigurationToolStripMenuItem.Enabled = true;
                customerServiceScheduleToolStripMenuItem.Enabled = true;
                stockScheduleToolStripMenuItem.Enabled = true;

                updateScheduleToolStripMenuItem.Enabled = true;
                deleteScheduleToolStripMenuItem.Enabled = true;

            }
            else
            {
                ConfigurationToolStripMenuItem.Enabled = false;
                customerServiceScheduleToolStripMenuItem.Enabled = false;
                stockScheduleToolStripMenuItem.Enabled = false;

                updateScheduleToolStripMenuItem.Enabled = false;
                deleteScheduleToolStripMenuItem.Enabled = false;
            }


            //if (UserRole == 1 || UserRole == 3) //-- Admin(IT) & Planning
            //{
            //    planningScheduleToolStripMenuItem.Enabled = true;
            //    stockDeliveryToolStripMenuItem.Enabled = true;
            //    deletePlanScheduleToolStripMenuItem.Enabled = true;
            //}
            //else
            //{
            //    planningScheduleToolStripMenuItem.Enabled = false;
            //    stockDeliveryToolStripMenuItem.Enabled = false;
            //    deletePlanScheduleToolStripMenuItem.Enabled = false;
            //}

            if (UserRole == 1 || UserRole == 4) //-- Admin(IT) & Production
            {
                productionToolStripMenuItem.Enabled = true;

                planningScheduleToolStripMenuItem.Enabled = true;
                stockDeliveryToolStripMenuItem.Enabled = true;
                deletePlanScheduleToolStripMenuItem.Enabled = true;
            }
            else
            {
                productionToolStripMenuItem.Enabled = false;

                planningScheduleToolStripMenuItem.Enabled = false;
                stockDeliveryToolStripMenuItem.Enabled = false;
                deletePlanScheduleToolStripMenuItem.Enabled = false;
            }


        }//
        private void timer1_Tick(object sender, EventArgs e)
        {
            cTime = cTime.AddMilliseconds(timer1.Interval);
            tslblCurrentDateTime.Text = " Today is: " + cTime.ToString("dddd, dd-MMM-yyyy hh:mm:ss tt");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                DialogResult result = MessageBox.Show("Would you like to close the application", "Exit?",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    isLogin = false;
                    Application.Exit();
                }
            }
        }//

        private void setLotWiseCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_MachineCapacity_ == null || _MachineCapacity_.IsDisposed)
            {
                _MachineCapacity_ = new frmMachineCapacity();
                _MachineCapacity_.MdiParent = this;
                _MachineCapacity_.Show();
            }
            else
            {
                _MachineCapacity_.Focus(); // bring it to front if already open
            }

        }//

        private void addNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_UserAdd_ == null || _UserAdd_.IsDisposed)
            {
                _UserAdd_ = new frmUserAdd();
                _UserAdd_.MdiParent = this;
                _UserAdd_.Show();
            }
            else
            {
                _UserAdd_.Focus(); // bring it to front if already open
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_PasswordChange_ == null || _PasswordChange_.IsDisposed)
            {
                _PasswordChange_ = new frmPasswordChange();
                _PasswordChange_.MdiParent = this;
                _PasswordChange_.Show();
            }
            else
            {
                _PasswordChange_.Focus(); // bring it to front if already open
            }
        }

        private void scheduleDayOnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ScheduleOnOff_ == null || _ScheduleOnOff_.IsDisposed)
            {
                _ScheduleOnOff_ = new frmScheduleOnOff();
                _ScheduleOnOff_.MdiParent = this;
                _ScheduleOnOff_.Show();
            }
            else
            {
                _ScheduleOnOff_.Focus(); // bring it to front if already open
            }

        }//
        private void setUnitLotCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UnitMchLotSet_ == null || _UnitMchLotSet_.IsDisposed)
            {
                _UnitMchLotSet_ = new frmUnitMchLotSet();
                _UnitMchLotSet_.MdiParent = this;
                _UnitMchLotSet_.Show();
            }
            else
            {
                _UnitMchLotSet_.Focus(); // bring it to front if already open
            }
        }//

        private void updateScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UpdateSchedule_ == null || _UpdateSchedule_.IsDisposed)
            {
                _UpdateSchedule_ = new frmUpdateSchedule();
                _UpdateSchedule_.MdiParent = this;
                _UpdateSchedule_.Show();
            }
            else
            {
                _UpdateSchedule_.Focus(); // bring it to front if already open
            }
        }
        private void deleteScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeleteSchedule_ == null || _DeleteSchedule_.IsDisposed)
            {
                _DeleteSchedule_ = new frmDeleteSchedule();
                _DeleteSchedule_.MdiParent = this;
                _DeleteSchedule_.Show();
            }
            else
            {
                _DeleteSchedule_.Focus(); // bring it to front if already open
            }
        }
        private void deletePlanScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DeletePlanning_ == null || _DeletePlanning_.IsDisposed)
            {
                _DeletePlanning_ = new frmDeletePlanning();
                _DeletePlanning_.MdiParent = this;
                _DeletePlanning_.Show();
            }
            else
            {
                _DeletePlanning_.Focus(); // bring it to front if already open
            }
        }
        private void specificJobStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_SpecificJobStatus_ == null || _Rpt_SpecificJobStatus_.IsDisposed)
            {
                _Rpt_SpecificJobStatus_ = new frmRpt_SpecificJobStatus();
                _Rpt_SpecificJobStatus_.MdiParent = this;
                _Rpt_SpecificJobStatus_.Show();
            }
            else
            {
                _Rpt_SpecificJobStatus_.Focus(); // bring it to front if already open
            }
        }
        private void scheduleSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_ScheduleSummary_ == null || _Rpt_ScheduleSummary_.IsDisposed)
            {
                _Rpt_ScheduleSummary_ = new frmRpt_ScheduleSummary();
                _Rpt_ScheduleSummary_.MdiParent = this;
                _Rpt_ScheduleSummary_.Show();
            }
            else
            {
                _Rpt_ScheduleSummary_.Focus(); // bring it to front if already open
            }
        }

        private void threadCapacityStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_LotCapacityStatus_ == null || _Rpt_LotCapacityStatus_.IsDisposed)
            {
                _Rpt_LotCapacityStatus_ = new frmRpt_LotCapacityStatus();
                _Rpt_LotCapacityStatus_.MdiParent = this;
                _Rpt_LotCapacityStatus_.Show();
            }
            else
            {
                _Rpt_LotCapacityStatus_.Focus(); // bring it to front if already open
            }
        }

        private void backlogReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_Backlog_ == null || _Rpt_Backlog_.IsDisposed)
            {
                _Rpt_Backlog_ = new frmRpt_Backlog();
                _Rpt_Backlog_.MdiParent = this;
                _Rpt_Backlog_.Show();
            }
            else
            {
                _Rpt_Backlog_.Focus(); // bring it to front if already open
            }
        }

        private void excessProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_ExcessProduction_ == null || _Rpt_ExcessProduction_.IsDisposed)
            {
                _Rpt_ExcessProduction_ = new frmRpt_ExcessProduction();
                _Rpt_ExcessProduction_.MdiParent = this;
                _Rpt_ExcessProduction_.Show();
            }
            else
            {
                _Rpt_ExcessProduction_.Focus(); // bring it to front if already open
            }
        }

        private void stockPlanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_StockPlan_ == null || _StockPlan_.IsDisposed)
            {
                _StockPlan_ = new frmStockPlan();
                _StockPlan_.MdiParent = this;
                _StockPlan_.Show();
            }
            else
            {
                _StockPlan_.Focus(); // bring it to front if already open
            }
        }

        private void stockEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_StockEntry_ == null || _StockEntry_.IsDisposed)
            {
                _StockEntry_ = new frmStockEntry();
                _StockEntry_.MdiParent = this;
                _StockEntry_.Show();
            }
            else
            {
                _StockEntry_.Focus(); // bring it to front if already open
            }
        }

        private void planningDueBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DuePlanBalance_ == null || _DuePlanBalance_.IsDisposed)
            {
                _DuePlanBalance_ = new frmDuePlanBalance();
                _DuePlanBalance_.MdiParent = this;
                _DuePlanBalance_.Show();
            }
            else
            {
                _DuePlanBalance_.Focus(); // bring it to front if already open
            }
        }

        private void mCBreakdownEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_MachineBreakdown_ == null || _MachineBreakdown_.IsDisposed)
            {
                _MachineBreakdown_ = new frmMachineBreakdown();
                _MachineBreakdown_.MdiParent = this;
                _MachineBreakdown_.Show();
            }
            else
            {
                _MachineBreakdown_.Focus(); // bring it to front if already open
            }
        }

        private void currentProductionStatusBasedOnScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_CurrentProduction_ == null || _Rpt_CurrentProduction_.IsDisposed)
            {
                _Rpt_CurrentProduction_ = new frmRpt_CurrentProduction();
                _Rpt_CurrentProduction_.MdiParent = this;
                _Rpt_CurrentProduction_.Show();
            }
            else
            {
                _Rpt_CurrentProduction_.Focus(); // bring it to front if already open
            }
        }

        private void dyeingEntryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_DyeEntry_ == null || _DyeEntry_.IsDisposed)
            {
                _DyeEntry_ = new frmDyeEntry();
                _DyeEntry_.MdiParent = this;
                _DyeEntry_.Show();
            }
            else
            {
                _DyeEntry_.Focus(); // bring it to front if already open
            }
        }

        private void windingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_WindingEntry_ == null || _WindingEntry_.IsDisposed)
            {
                _WindingEntry_ = new frmWindingEntry();
                _WindingEntry_.MdiParent = this;
                _WindingEntry_.Show();
            }
            else
            {
                _WindingEntry_.Focus(); // bring it to front if already open
            }
        }

        private void packingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_PackingEntry_ == null || _PackingEntry_.IsDisposed)
            {
                _PackingEntry_ = new frmPackingEntry();
                _PackingEntry_.MdiParent = this;
                _PackingEntry_.Show();
            }
            else
            {
                _PackingEntry_.Focus(); // bring it to front if already open
            }
        }

        private void despatchEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DespatchEntry_ == null || _DespatchEntry_.IsDisposed)
            {
                _DespatchEntry_ = new frmDespatchEntry();
                _DespatchEntry_.MdiParent = this;
                _DespatchEntry_.Show();
            }
            else
            {
                _DespatchEntry_.Focus(); // bring it to front if already open
            }
        }

        private void planningScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_PlanningSchedule_ == null || _PlanningSchedule_.IsDisposed)
            {
                _PlanningSchedule_ = new frmPlanningSchedule();
                _PlanningSchedule_.MdiParent = this;
                _PlanningSchedule_.Show();
            }
            else
            {
                _PlanningSchedule_.Focus(); // bring it to front if already open
            }
        }

        private void representativeWiseScheduleBalanceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_RepScheduleBalance_ == null || _Rpt_RepScheduleBalance_.IsDisposed)
            {
                _Rpt_RepScheduleBalance_ = new frmRpt_RepScheduleBalance();
                _Rpt_RepScheduleBalance_.MdiParent = this;
                _Rpt_RepScheduleBalance_.Show();
            }
            else
            {
                _Rpt_RepScheduleBalance_.Focus(); // bring it to front if already open
            }
        }

        private void planningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Rpt_StatusPlanning_ == null || _Rpt_StatusPlanning_.IsDisposed)
            {
                _Rpt_StatusPlanning_ = new frmRpt_StatusPlanning();
                _Rpt_StatusPlanning_.MdiParent = this;
                _Rpt_StatusPlanning_.Show();
            }
            else
            {
                _Rpt_StatusPlanning_.Focus(); // bring it to front if already open
            }
        }

        private void productionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (_Rpt_StatusDyelot_ == null || _Rpt_StatusDyelot_.IsDisposed)
            {
                _Rpt_StatusDyelot_ = new frmRpt_StatusDyelot();
                _Rpt_StatusDyelot_.MdiParent = this;
                _Rpt_StatusDyelot_.Show();
            }
            else
            {
                _Rpt_StatusDyelot_.Focus(); // bring it to front if already open
            }
        }

        private void customerServiceScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ScheduleEntry_ == null || _ScheduleEntry_.IsDisposed)
            {
                _ScheduleEntry_ = new frmScheduleEntry();
                _ScheduleEntry_.MdiParent = this;
                _ScheduleEntry_.Show();
            }
            else
            {
                _ScheduleEntry_.Focus(); // bring it to front if already open
            }
        }

        private void deliveryScheduleRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_ScheduleRegister_ == null || _Rpt_ScheduleRegister_.IsDisposed)
            {
                _Rpt_ScheduleRegister_ = new frmRpt_ScheduleRegister();
                _Rpt_ScheduleRegister_.MdiParent = this;
                _Rpt_ScheduleRegister_.Show();
            }
            else
            {
                _Rpt_ScheduleRegister_.Focus(); // bring it to front if already open
            }
        }

        private void bookingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BookingCSView_ == null || _BookingCSView_.IsDisposed)
            {
                _BookingCSView_ = new frmBookingCSView();
                _BookingCSView_.MdiParent = this;
                _BookingCSView_.Show();
            }
            else
            {
                _BookingCSView_.Focus(); // bring it to front if already open
            }
        }

        private void scheduleForPlanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ViewScheduledData_ == null || _ViewScheduledData_.IsDisposed)
            {
                _ViewScheduledData_ = new frmViewScheduledData();
                _ViewScheduledData_.MdiParent = this;
                _ViewScheduledData_.Show();
            }
            else
            {
                _ViewScheduledData_.Focus(); // bring it to front if already open
            }
        }

        private void whiteScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_StockScheduleView_ == null || _StockScheduleView_.IsDisposed)
            {
                _StockScheduleView_ = new frmStockScheduleView();
                _StockScheduleView_.MdiParent = this;
                _StockScheduleView_.Show();
            }
            else
            {
                _StockScheduleView_.Focus(); // bring it to front if already open
            }
        }

        private void stockScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_WhiteSchedule_ == null || _WhiteSchedule_.IsDisposed)
            {
                _WhiteSchedule_ = new frmWhiteSchedule();
                _WhiteSchedule_.MdiParent = this;
                _WhiteSchedule_.Show();
            }
            else
            {
                _WhiteSchedule_.Focus(); // bring it to front if already open
            }
        }

        private void stockDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_StockSchDelivery_ == null || _StockSchDelivery_.IsDisposed)
            {
                _StockSchDelivery_ = new frmStockSchDelivery();
                _StockSchDelivery_.MdiParent = this;
                _StockSchDelivery_.Show();
            }
            else
            {
                _StockSchDelivery_.Focus(); // bring it to front if already open
            }
        }

        private void productionScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_ProductionSchedule_ == null || _Rpt_ProductionSchedule_.IsDisposed)
            {
                _Rpt_ProductionSchedule_ = new frmRpt_ProductionSchedule();
                _Rpt_ProductionSchedule_.MdiParent = this;
                _Rpt_ProductionSchedule_.Show();
            }
            else
            {
                _Rpt_ProductionSchedule_.Focus(); // bring it to front if already open
            }
        }

        private void currentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_CurrentStock_ == null || _Rpt_CurrentStock_.IsDisposed)
            {
                _Rpt_CurrentStock_ = new frmRpt_CurrentStock();
                _Rpt_CurrentStock_.MdiParent = this;
                _Rpt_CurrentStock_.Show();
            }
            else
            {
                _Rpt_CurrentStock_.Focus(); // bring it to front if already open
            }
        }

        private void printPAckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_PrintPackingSticker_ == null || _Rpt_PrintPackingSticker_.IsDisposed)
            {
                _Rpt_PrintPackingSticker_ = new frmRpt_PrintPackingSticker();
                _Rpt_PrintPackingSticker_.MdiParent = this;
                _Rpt_PrintPackingSticker_.Show();
            }
            else
            {
                _Rpt_PrintPackingSticker_.Focus(); // bring it to front if already open
            }
        }

        private void printTravelCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_PrintDyelotCard_ == null || _Rpt_PrintDyelotCard_.IsDisposed)
            {
                _Rpt_PrintDyelotCard_ = new frmRpt_PrintDyelotCard();
                _Rpt_PrintDyelotCard_.MdiParent = this;
                _Rpt_PrintDyelotCard_.Show();
            }
            else
            {
                _Rpt_PrintDyelotCard_.Focus(); // bring it to front if already open
            }
        }

        private void setCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UnitCapacity_ == null || _UnitCapacity_.IsDisposed)
            {
                _UnitCapacity_ = new frmUnitCapacity();
                _UnitCapacity_.MdiParent = this;
                _UnitCapacity_.Show();
            }
            else
            {
                _UnitCapacity_.Focus(); // bring it to front if already open
            }
        }

        private void wastageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_WastageEntry_ == null || _WastageEntry_.IsDisposed)
            {
                _WastageEntry_ = new frmWastageEntry();
                //_WastageEntry_.FormClosed += (s, args) => _WastageEntry_ = null;
                _WastageEntry_.MdiParent = this;
                _WastageEntry_.Show();
            }
            else
            {
                _WastageEntry_.Focus(); // bring it to front if already open
            }
            //frmWastageEntry frm= new frmWastageEntry();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void wastageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_Wastage_ == null || _Rpt_Wastage_.IsDisposed)
            {
                _Rpt_Wastage_ = new frmRpt_Wastage();
                _Rpt_Wastage_.MdiParent = this;
                _Rpt_Wastage_.Show();
            }
            else
            {
                _Rpt_Wastage_.Focus(); // bring it to front if already open
            }
        }

        private void mCBreakdownReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_MchBreakdown_ == null || _Rpt_MchBreakdown_.IsDisposed)
            {
                _Rpt_MchBreakdown_ = new frmRpt_MchBreakdown();
                _Rpt_MchBreakdown_.MdiParent = this;
                _Rpt_MchBreakdown_.Show();
            }
            else
            {
                _Rpt_MchBreakdown_.Focus(); // bring it to front if already open
            }
        }

        private void usedLotStatusJobRepWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Rpt_UsedLotRepJob_ == null || _Rpt_UsedLotRepJob_.IsDisposed)
            {
                _Rpt_UsedLotRepJob_ = new frmRpt_UsedLotRepJob();
                _Rpt_UsedLotRepJob_.MdiParent = this;
                _Rpt_UsedLotRepJob_.Show();
            }
            else
            {
                _Rpt_UsedLotRepJob_.Focus(); // bring it to front if already open
            }
        }

        private void dyelotDetailsStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DyelotDetail_ == null || _DyelotDetail_.IsDisposed)
            {
                _DyelotDetail_ = new frmRpt_DyelotDetails();
                _DyelotDetail_.MdiParent = this;
                _DyelotDetail_.Show();
            }
            else
            {
                _DyelotDetail_.Focus(); // bring it to front if already open
            }
        }

        private void threadSupplyChainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SupplyChain_ == null || _SupplyChain_.IsDisposed)
            {
                _SupplyChain_ = new frmRpt_SupplyChain();
                _SupplyChain_.MdiParent = this;
                _SupplyChain_.Show();
            }
            else
            {
                _SupplyChain_.Focus(); // bring it to front if already open
            }
        }

        private void oTEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_OTEntry_ == null || _OTEntry_.IsDisposed)
            {
                _OTEntry_ = new frmOTEntry();
                _OTEntry_.MdiParent = this;
                _OTEntry_.Show();
            }
            else
            {
                _OTEntry_.Focus(); // bring it to front if already open
            }
        }

        private void jobStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_JobStatus_ == null || _JobStatus_.IsDisposed)
            {
                _JobStatus_ = new frmRpt_JobStatus();
                _JobStatus_.MdiParent = this;
                _JobStatus_.Show();
            }
            else
            {
                _JobStatus_.Focus(); // bring it to front if already open
            }
        }

        private void dropUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_booking == null || _booking.IsDisposed)
            {
                _booking = new frmRpt_BookingReport();
                _booking.MdiParent = this;
                _booking.Show();
            }
            else
            {
                _booking.Focus();
            }
        }
    }
}
