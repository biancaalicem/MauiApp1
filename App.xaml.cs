using System;
using MauiApp1.Data;
using System.IO;
namespace MauiApp1
{
    public partial class App : Application
    {
        static PensiuneDatabase database;
        public static PensiuneDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PensiuneDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pensiune.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
