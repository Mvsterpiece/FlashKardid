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
    public partial class TrainingPage : ContentPage
    {
        private List<Word> words;
        private AnswerStatistic answerStatistic;

        public TrainingPage()
        {
            InitializeComponent();
            words = App.Database.GetItems().ToList();
            wordsList.ItemsSource = words;

            answerStatistic = new AnswerStatistic();


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

        private async void CreateWord(object sender, EventArgs e)
        {
            Word word = new Word();
            WordPage wordPage = new WordPage();
            wordPage.BindingContext = word;
            await Navigation.PushAsync(wordPage);
        }

        private void ToggleWordSelection(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Word selectedWord = checkBox.BindingContext as Word;
            if (selectedWord != null)
            {
                selectedWord.IsSelected = checkBox.IsChecked;
            }
        }

        private async void StartLearningClicked(object sender, EventArgs e)
        {
            List<Word> selectedWords = words.Where(w => w.IsSelected).ToList();

            int trueCount = 0;
            int falseCount = 0;

            foreach (Word word in selectedWords)
            {
                bool isTranslationCorrect = await TranslateAndCheck(word.Name, word.Tolgi);

                if (isTranslationCorrect)
                {
                    trueCount++;
                    await DisplayAlert("Tõlgi on õige", $"Sõna tõlge '{word.Name}' on õige.", "OK");
                }
                else
                {
                    falseCount++;
                    await DisplayAlert("Tõlgi on vale", $"Sõna tõlge '{word.Name}' on vale.", "OK");
                }
            }

            answerStatistic.TrueCount += trueCount;
            answerStatistic.FalseCount += falseCount; 

            foreach (Word word in selectedWords)
            {
                word.IsSelected = false;
            }
        }

        private async Task<bool> TranslateAndCheck(string word, string translation)
        {
            string enteredTranslation = await DisplayPromptAsync("Tõlgimine", $"Tõlgi sõna: '{word}'");

            if (enteredTranslation != null)
            {
                enteredTranslation = enteredTranslation.Trim().ToLower();

                if (enteredTranslation == translation.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private async void ShowStatistics(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatisticsPage(answerStatistic));
        }
    }
}
