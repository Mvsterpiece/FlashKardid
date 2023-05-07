using FlashKardid.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Extensions;


namespace FlashKardid.ViewModels
{
    public class WordViewModel
    {
        public Word Word { get; set; }

        public WordViewModel(Word word)
        {
            // Set the current word
            Word = word;
        }

        public void Save()
        {
            // Save the word to the database
            App.Database.SaveWord(Word);
        }

        public void Delete()
        {
            // Delete the word from the database
            App.Database.DeleteWord(Word);
        }
    }
}
