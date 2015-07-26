using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MedicineManager.GUI;
using MedicineManager.Reports;

namespace MedicineManager
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
