using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashKardid.Models
{
    public class DeckRepository
    {
        SQLiteConnection database;
        string tableName;

        public DeckRepository(string databasepath, string tableName)
        {
            this.tableName = tableName;
            database = new SQLiteConnection(databasepath);
            CreateTableIfNotExists();
        }

        void CreateTableIfNotExists()
        {
            var tableInfo = database.GetTableInfo(tableName);
            if (tableInfo.Any())
                return; 

            database.CreateTable<Deck>();
        }

        public IEnumerable<Deck> GetItems()
        {
            return database.Table<Deck>().ToList();
        }

        public Deck GetItem(int id)
        {
            return database.Get<Deck>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Deck>(id);
        }

        public int SaveItem(Deck item)
        {
            CreateTableIfNotExists();

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
