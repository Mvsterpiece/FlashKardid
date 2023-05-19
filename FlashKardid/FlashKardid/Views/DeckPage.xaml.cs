using FlashKardid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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


        public const string DECK_DATABASE_NAME = "decks.db";
        public static DeckRepository DeckDatabase;

        public DeckPage()
        {
            InitializeComponent();
        }

        private void SaveDeck(object sender, EventArgs e)
        {
            string tableName = deckNameEntry.Text;

            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DECK_DATABASE_NAME);

                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.CreateTable<Deck>();

                    deckNameEntry.Text = tableName;
                }
            }
        }
        private void DeleteDeck(object sender, EventArgs e)
        {
            var deck = (Deck)BindingContext;
            App.Database.DeleteItem(deck.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }


    }
}