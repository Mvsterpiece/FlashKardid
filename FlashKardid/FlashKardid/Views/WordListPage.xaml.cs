using FlashKardid.Models;
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
    public partial class WordLisatPage : ContentPage
    {
        public WordLisatPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            wordsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Word selectedFriend = (Word)e.SelectedItem;
            WordPage friendPage = new WordPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
        private async void CreateWord(object sender, EventArgs e)
        {
            Word friend = new Word();
            WordPage friendPage = new WordPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
    }
}