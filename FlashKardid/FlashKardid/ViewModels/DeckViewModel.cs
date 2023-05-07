using FlashKardid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Data.SQLite;



namespace FlashKardid.ViewModels
{
    public class DeckViewModel
    {
        public Deck Deck { get; set; }
        public ObservableCollection<Word> Words { get; set; }

        public DeckViewModel(Deck deck)
        {
            // Set the current deck
            Deck = deck;

            // Load the list of words for the current deck from the database
            Words = new ObservableCollection<Word>(App.Database.GetWordsForDeck(Deck.Id));
        }

        public void AddWord(Word word)
        {
            // Add the word to the database
            App.Database.SaveWord(word);

            // Add the word to the list of words for the current deck
            Words.Add(word);
        }

        public void RemoveWord(Word word)
        {
            // Remove the word from the database
            App.Database.DeleteWord(word);

            // Remove the word from the list of words for the current deck
            Words.Remove(word);
        }

        public void UpdateWord(Word word)
        {
            // Update the word in the database
            App.Database.SaveWord(word);

            // Refresh the list of words for the current deck
            Words = new ObservableCollection<Word>(App.Database.GetWordsForDeck(Deck.Id));
        }
    }

}
