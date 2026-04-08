using KDS_Thread.ThreadForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KDS_Thread
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //bool createdNew;
            //Mutex m = new Mutex(true, "KDS_Thread", out createdNew);

            //if (!createdNew)
            //{
            //    // myApp is already running...
            //    MessageBox.Show("Thread Application is already running!", "Multiple Instances");
            //    return;
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

    }
}
