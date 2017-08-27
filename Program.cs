using AutoService.Migrations;
using AutoService.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    static class Program
    {
        public static ILogger Log;
        public static Process mysql;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile(@"logs\autoservice-{Date}.txt")
                .CreateLogger();
            // start mysql
/*#if !DEBUG
            mysql = new Process();
            var startinfo = new ProcessStartInfo();
            startinfo.WindowStyle = ProcessWindowStyle.Hidden;
            startinfo.FileName = ConfigurationManager.AppSettings["mysql"] + "\\bin\\mysqld";
            startinfo.Arguments = "--defaults-file=" + ConfigurationManager.AppSettings["mysql"] + "\\bin\\my.ini" 
                + " --standalone --console";
            mysql.StartInfo = startinfo;
            
            mysql.Start();
            Thread.Sleep(1000);
#endif 

#if !DEBUG
            try
            {
                var configuration = new Migrations.Configuration();
                var migrator = new DbMigrator(configuration);
                migrator.Update();
            } catch (Exception)
            {
                MessageBox.Show("Eroare fatala. Contactati suport.");
                return;
            }
#endif */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            try
            {
                Application.Run(new LoginForm());
                Log.Information("Program Started");

            }
            catch (Exception e)
            {
                Log.Error(e, "Eroare fatala");
                MessageBox.Show(e.Message, "Eroare fatala contactati support", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception,"Eroare fatala");
            MessageBox.Show("Eroare de utilizare, contactati support");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error(e.ExceptionObject.ToString());
        }
    }
}
