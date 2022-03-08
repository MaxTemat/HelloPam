using System;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new FrmLogin().Show();
            Application.Run();
        }
    }
}
