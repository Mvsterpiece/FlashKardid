using System;
using System.Collections.Generic;
using System.Text;

namespace FlashKardid.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsMastered { get; set; }
        public DateTime LastStudied { get; set; }
        public int DeckId { get; set; }
    }
}
