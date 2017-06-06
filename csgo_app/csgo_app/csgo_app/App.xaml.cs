using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;
using csgo_app.Database;

namespace csgo_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // new csgo_app.MainPage()
            MainPage = new NavigationPage(new csgo_app.MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static ItemDatabase _database;

        public static ItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("SQLite.db3"));
                }
                return _database;
            }
        }
    }
}
