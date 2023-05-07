using FlashKardid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Extensions;


namespace FlashKardid.ViewModels
{
    public class DeckListViewModel
    {
        public ObservableCollection<Deck> Decks { get; set; }

        public DeckListViewModel()
        {
            // Load the list of decks from the database
            Decks = new ObservableCollection<Deck>(App.Database.GetDecks());
        }
    }
}
