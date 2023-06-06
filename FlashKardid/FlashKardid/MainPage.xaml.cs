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


            var titleLabel = new Label
            {
                Text = "Sõna-tõlk",
                FontSize = 20,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var customTitleView = new ContentView
            {
                Content = titleLabel,
                Padding = new Thickness(10, 0)
            };


            NavigationPage.SetTitleView(this, customTitleView);


        }


        private async void WordList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordLisatPage());
        }

        private async void CollectionWords(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainingPage());
        }
    }
}
