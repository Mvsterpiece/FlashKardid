using FlashKardid.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashKardid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void WordList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordLisatPage());
        }

        private async void CollectionWords(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeckListPage());
        }
    }
}
