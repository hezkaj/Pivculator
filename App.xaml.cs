using System;
using Xamarin.Forms;
using System.IO;

namespace Pivculator
{
    public partial class App : Application
    {

        //создание базы данных в проекте:
        public static Repository db;
        public static Repository Db
        {
            get //если база еще не создана то создаем новую базу, запускаем ее
            {
                if (db == null)
                {
                    db = new Repository(Path.Combine
                        (Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "baza.bd"));
                }
                return db;
            }
        }
        //

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
