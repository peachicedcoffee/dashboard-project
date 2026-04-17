using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.LinqTest;
using WindowsFormsApplication1.Helper;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogHelper.Default.LogProgramStart();
            try
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form4());
            }
            finally
            {
                LogHelper.Default.LogProgramEnd();
            }
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            LogHelper.Default.WriteLogEntry(new StateLog() { Status = "End", DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Message = "ApplicationExit triggered" });
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            LogHelper.Default.WriteLogEntry(new StateLog() { Status = "End", DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Message = "ProcessExit triggered" });
        }

    }
}
