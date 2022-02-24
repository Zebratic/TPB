using System;
using System.Diagnostics;
using System.Windows.Forms;
using HTX_NINJA.Views.Forms;

namespace HTX_NINJA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Starts a process outside the app
        /// </summary>
        public static void Start(string arg)
        {
            try
            {
                Process.Start(arg);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }
}
