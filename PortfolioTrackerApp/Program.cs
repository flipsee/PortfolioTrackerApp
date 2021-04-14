using PortfolioTrackerApp.Helper;
using System;
using System.Windows.Forms;
using Unity;

namespace PortfolioTrackerApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = UnityConfig.BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(container.Resolve<MDIMain>());
        }

        
    }
}
