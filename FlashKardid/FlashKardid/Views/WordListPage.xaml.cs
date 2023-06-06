using FlashKardid.Models;
using System;
using System.Collections.Generic;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadWords();
        }

        private void LoadWords()
        {
            var words = App.Database.GetItems();

            foreach (var word in words)
            {
                var stackLayout = new StackLayout
                {
                    Margin = new Thickness(10, 20, 10, 0),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                var frame = new Frame
                {
                    BorderColor = Color.Gray,
                    CornerRadius = 5,
                    Padding = 10,
                    WidthRequest = 40,
                    HeightRequest = 180,
                    HasShadow = true
                };

                var wordLabel = new Label
                {
                    Text = word.Name,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                var translationLabel = new Label
                {
                    Text = word.Tolgi,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    IsVisible = false 
                };

                var labelLayout = new StackLayout
                {
                    Padding = new Thickness(0, 10, 0, 0),
                    Children = { wordLabel, translationLabel }
                };

                frame.Content = labelLayout;

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    wordLabel.IsVisible = !wordLabel.IsVisible;
                    translationLabel.IsVisible = !translationLabel.IsVisible;
                };
                frame.GestureRecognizers.Add(tapGestureRecognizer);

                var buttonStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End,
                    Spacing = 10
                };

                var addButton = new Button
                {
                    Text = "Lisa uue sõna",
                    Command = new Command(AddNewWord),
                    WidthRequest = 100,
                    HeightRequest = 60
                };

                var changeButton = new Button
                {
                    Text = "Muuda sõna",
                    CommandParameter = word,
                    Command = new Command(ChangeWord),
                    WidthRequest = 100,
                    HeightRequest = 60
                };

                buttonStackLayout.Children.Add(addButton);
                buttonStackLayout.Children.Add(changeButton);

                stackLayout.Children.Add(frame);
                stackLayout.Children.Add(buttonStackLayout);

                var page = new ContentPage
                {
                    Content = stackLayout
                };

                Children.Add(page);
            }
        }

        private async void AddNewWord()
        {
            Word word = new Word();
            WordPage wordPage = new WordPage();
            wordPage.BindingContext = word;
            await Navigation.PushAsync(wordPage);
        }

        private async void ChangeWord(object parameter)
        {
            Word word = parameter as Word;
            WordPage wordPage = new WordPage();
            wordPage.BindingContext = word;
            await Navigation.PushAsync(wordPage);
        }
    }
}
