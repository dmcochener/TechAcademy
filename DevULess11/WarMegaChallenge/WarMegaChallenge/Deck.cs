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


        public Deck ()
        {
            string[] _suits = new string[] { "Hearts", "Clubs", "Diamonds", "Spades" };
            List<Card> _cards = new List<Card>();

            foreach (var suit in _suits)
            {
                for (int i = 2; i < 15; i++)
                {
                    _cards.Add(new Card(i, suit));
                }
            }

            Owner = new Player("Dealer");
            Cards = _cards;

        }
    }
}