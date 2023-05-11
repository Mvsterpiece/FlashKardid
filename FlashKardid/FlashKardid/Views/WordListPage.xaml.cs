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
            Word selectedWord = (Word)e.SelectedItem;
            WordPage wordPage = new WordPage();
            wordPage.BindingContext = selectedWord;
            await Navigation.PushAsync(wordPage);
        }
        private async void CreateWord(object sender, EventArgs e)
        {
            Word word = new Word();
            WordPage wordPage = new WordPage();
            wordPage.BindingContext = word;
            await Navigation.PushAsync(wordPage);
        }
    }
}