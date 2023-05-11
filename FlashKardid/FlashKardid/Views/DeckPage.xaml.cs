using FlashKardid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FlashKardid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckPage : ContentPage
    {
        public DeckPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            var tableName = deckNameEntry.Text;
            using (var db = new SQLiteConnection(App.DatabasePath))
            {
                db.CreateTable<Deck>();
                db.CreateTable<Word>();

                db.Execute($"CREATE TABLE IF NOT EXISTS {tableName} (Id INTEGER PRIMARY KEY, Word TEXT, Translation TEXT)");
            }
        }


    }
}