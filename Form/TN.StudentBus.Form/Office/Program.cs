using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Windows.Forms;

namespace TN.StudentBus.Office
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
          //  IsVersionOK();
            var mutex = new System.Threading.Mutex(true, "UniqueAppId", out bool result);
            if (!result)
            {
                MessageBox.Show("Ứng dụng này hiện đang chạy rồi.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}