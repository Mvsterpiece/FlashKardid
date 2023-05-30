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
    public partial class WordLisatPage : CarouselPage
    {
        public WordLisatPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadWords();
        }

        private void LoadWords()
        {
            var words = App.Database.GetItems();

            Button btn = new Button
            {
                Text = "Lisa uue sõna",
            };
            btn.Clicked += CreateWord;


            foreach (var word in words)
            {
                var page = new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label { Text = word.Name, FontSize = 20, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                            btn
                        }
                    }
                };

                Children.Add(page);
            }
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
