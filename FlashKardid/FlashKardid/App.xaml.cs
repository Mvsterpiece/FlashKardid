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

        public const string DECK_DATABASE_NAME = "decks.db";
        public static DeckRepository DeckDatabase;

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

        public static void CreateNewDeckTable(string tableName)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DECK_DATABASE_NAME);

                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.CreateTable<Deck>();
                    // Here you can create a new table with the specified name
                    // using the CreateTable<T>() method and passing a type 
                    // parameter with the name of the table.
                    // Example: connection.CreateTable<YourModelClass>(tableName);
                }
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
