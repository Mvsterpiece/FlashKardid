using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System.Data.Common;
using FlashKardid.Models;
using FlashKardid.Views;


namespace FlashKardid
{
    public partial class App : Application
    {
        public static string DatabasePath { get; set; }

        public const string DATABASE_NAME = "words.db";
        public static WordRepository database;


        public static WordRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new WordRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));


                }
                return database;
            }
        }



        public App()
        {
            InitializeComponent();



            MainPage = new NavigationPage(new MainPage());
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
