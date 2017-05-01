using AutoService.Migrations;
using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if !DEBUG
            try
            {
                var configuration = new Configuration();
                var migrator = new DbMigrator(configuration);
                migrator.Update();
            } catch (Exception)
            {
                MessageBox.Show("Eroare fatala. Contactati suport.");
                return;
            }
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");
            try
            {
                Application.Run(new LoginForm());
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare fatala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
