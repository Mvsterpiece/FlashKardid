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
    public partial class DeckListPage : ContentPage
    {
        public DeckListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (App.DeckDatabase != null)
            {
                decksList.ItemsSource = App.DeckDatabase.GetItems();
            }
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Deck selectedDeck= (Deck)e.SelectedItem;
            DeckPage deckPage = new DeckPage();
            deckPage.BindingContext = selectedDeck;
            await Navigation.PushAsync(deckPage);
        }
        private async void CreateDeck(object sender, EventArgs e)
        {
            Deck deck = new Deck();
            DeckPage deckPage = new DeckPage();
            deckPage.BindingContext = deck;
            await Navigation.PushAsync(deckPage);
        }


    }
}