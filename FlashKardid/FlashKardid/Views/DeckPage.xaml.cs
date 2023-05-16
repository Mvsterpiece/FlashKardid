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

        private void SaveWord(object sender, EventArgs e)
        {
            var deck = (Deck)BindingContext;
            if (!String.IsNullOrEmpty(deck.Name))
            {
                App.DeckDatabase.SaveItem(deck);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteWord(object sender, EventArgs e)
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