using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashKardid.Models;

namespace FlashKardid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordPage : ContentPage
    {
        public WordPage()
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
        private void SaveWord(object sender, EventArgs e)
        {
            var friend = (Word)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteWord(object sender, EventArgs e)
        {
            var friend = (Word)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}