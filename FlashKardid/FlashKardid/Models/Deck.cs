using System;
using System.Collections.Generic;
using System.Text;

namespace FlashKardid.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public List<Word> Words { get; set; }
    }
}
