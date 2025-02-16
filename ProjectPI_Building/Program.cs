using System.Globalization;
using ProjectPI_Building.Forms_Register;
using ProjectPI_Building.Forms_Reportes;
using ProjectPI_Building.Forms_Search;

namespace ProjectPI_Building
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Frm_home());
        }
    }
}