using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    public class Card
    {
        public int Value;
        public string Suit;
        public string Name;

        public Card (int _value, string _suit)
        {
            Value = _value; // Lowest value should be 2, Highest should be 14
            Suit = _suit;
            if (_value < 11)
                Name = _value.ToString();
            else if (_value == 11)
                Name = "Jack";
            else if (_value == 12)
                Name = "Queen";
            else if (_value == 13)
                Name = "King";
            else if (_value == 14)
                Name = "Ace";

        }

    }
}