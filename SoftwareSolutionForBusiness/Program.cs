using Npgsql;
using SoftwareSolutionForBusiness.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness
{
    internal static class Program
    {
        internal static IScreenFactory Navigator;
        internal static string ProjectPath;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connections.SoftwareSolutionForBusiness))
            {
                IDI di = new DI(connection);
                Navigator = new ScreenFactory(di);
                ProjectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Navigator.MakeMainForm());
            }
        }
    }
}
