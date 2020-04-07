using System;
using System.Windows.Forms;

namespace MediaStore
{
    static class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //How to configure an app to run correctly on a machine with a high DPI setting (e.g. 150%)?
            //https://stackoverflow.com/questions/13228185/how-to-configure-an-app-to-run-correctly-on-a-machine-with-a-high-dpi-setting-e
            //2020-02-05
            if (Environment.OSVersion.Version.Major >= 6)
            {
                NativeMethods.SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MyMediaStore MEGA = new MyMediaStore())
            {
                Application.Run(MEGA);
            }


        }

        #endregion Methods

        #region Classes

        internal class NativeMethods
        {
            #region Methods

            //How to configure an app to run correctly on a machine with a high DPI setting (e.g. 150%)?
            //https://stackoverflow.com/questions/13228185/how-to-configure-an-app-to-run-correctly-on-a-machine-with-a-high-dpi-setting-e
            //2020-02-05
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool SetProcessDPIAware();

            #endregion Methods
        }

        #endregion Classes
    }
}
