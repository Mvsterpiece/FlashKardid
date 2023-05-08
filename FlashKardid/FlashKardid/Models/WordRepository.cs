using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashKardid.Models
{
    public class WordRepository
    {
        SQLiteConnection database;

        public WordRepository(string databasepath)
        {
            database = new SQLiteConnection(databasepath);
            database.CreateTable<Word>();
        }

        public IEnumerable<Word> GetItems()
        {
            return database.Table<Word>().ToList();
        }
        public Word GetItem(int id)
        {
            return database.Get<Word>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Word>(id);
        }
        public int SaveItem(Word item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}