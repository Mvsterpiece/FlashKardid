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

        public TrainingPage()
        {
            InitializeComponent();
            words = App.Database.GetItems().ToList();
            wordsList.ItemsSource = words;
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

            foreach (Word word in selectedWords)
            {
                bool isTranslationCorrect = await TranslateAndCheck(word.Name, word.Tolgi);

                if (isTranslationCorrect)
                {

                    await DisplayAlert("Translation Correct", $"The translation of '{word.Name}' is correct.", "OK");
                }
                else
                {

                    await DisplayAlert("Translation Incorrect", $"The translation of '{word.Name}' is incorrect.", "OK");
                }
            }

            foreach (Word word in selectedWords)
            {
                word.IsSelected = false;
            }
        }

        private async Task<bool> TranslateAndCheck(string word, string translation)
        {
            string enteredTranslation = await DisplayPromptAsync("Translation", $"Translate the word '{word}' to Tolgi:");

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
    }
}