using System;
using System.Threading;
using System.Windows.Forms;

namespace ZipSafe
{
    internal static class Program
    {
        // Mutex to ensure only one instance of the application runs
        private static Mutex mutex;

        [STAThread]
        static void Main()
        {
            // Define a unique mutex name for the application
            const string appName = "ZipSafeApplicationMutex";
            bool createdNew;

            // Attempt to create the mutex
            mutex = new Mutex(true, appName, out createdNew);

            // If the mutex already exists, show a warning and exit
            if (!createdNew)
            {
                MessageBox.Show(
                    "The application is already running.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // Initialize the application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ZipSafe());
            }
            finally
            {
                // Release the mutex when the application closes
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                    mutex.Dispose();
                }
            }
        }
    }
}
