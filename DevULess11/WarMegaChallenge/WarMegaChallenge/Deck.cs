using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    public class Deck
    {
        public Player Owner;
        public List<Card> Cards;

        public Deck (Player _owner)
        {
            Owner = _owner;
            Cards = new List<Card>();
        }

        public Deck (Player _owner, List<Card> _cards)
        {
            Owner = _owner;
            Cards = _cards;
        }
    }
}