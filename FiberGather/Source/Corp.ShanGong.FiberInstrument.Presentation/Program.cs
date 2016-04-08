using System;
using System.Windows.Forms;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppSetting.Container = BootStrap.CreateProjectContainer();
            //Application.Run(new MainForm());
            Application.Run(new FiberMainForm());
        }
    }
}