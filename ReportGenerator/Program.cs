using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportGenerator.Models;
using ReportGenerator.Views;
using ReportGenerator.Presenters;
using ReportGenerator._Repositories;
using System.Configuration;

namespace ReportGenerator
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            IActivityView view = new ActivityView();
            IActivityRepository repository = new ActivityRepository(sqlConnectionString);
            new ActivityPresenter(view,repository);
            Application.Run((Form)view);
        }
    }
}
