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
    public partial class frmLoader : Form
    {
        public frmLoader()
        {
            InitializeComponent();
        }

        private void frmLoader_Load(object sender, EventArgs e)
        {
            MDIMain md = new MDIMain(true);
            this.Icon = md.Icon;
        }
    }
}
