using Finance_Tracker.Forms;
using Finance_Tracker.Helpers;
using SQLitePCL;
namespace Finance_Tracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLitePCL.Batteries.Init();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            Application.SetDefaultFont(new Font("Shabnam", 10f, FontStyle.Regular));
            var db = new DatabaseHelper();
            db.InitialiseDatabase();
            Application.Run(new LoginForm(db));
        }
    }
}