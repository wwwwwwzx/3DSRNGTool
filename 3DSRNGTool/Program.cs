using System;
using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    static class Program
    {
        public static MainForm mainform;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainform = new MainForm();
            Application.Run(mainform);
        }
    }
}
