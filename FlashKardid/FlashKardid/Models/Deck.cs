using System;
using System.Collections.Generic;
using System.Text;

namespace FlashKardid.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }
    }
}
