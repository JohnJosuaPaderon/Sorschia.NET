using Sorschia;
using System;
using System.Windows.Forms;

namespace Sample.WindowsFormsApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SorschiaApp.BuildApp(new Bootstrapper());
            Application.Run(new Form1());
        }
    }
}
