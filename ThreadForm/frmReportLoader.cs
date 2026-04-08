using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    public partial class frmReportLoader : Form
    {
        public frmReportLoader()
        {
            InitializeComponent();
        }

        private void frmReportLoader_Load(object sender, EventArgs e)
        {
            MDIMain mm = new MDIMain(true);
            this.Icon = mm.Icon;
            
        }
    }
}
