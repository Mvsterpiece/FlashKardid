﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashKardid.Models
{
    public class Deck
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
