using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    public class Game
    {
        Random draw = new Random();
        public string result = "";


        public void MatchUp(Deck _player1, Deck _player2)
        {
            int round = 1;

            Deck _player1Win = new Deck(_player1.Owner);
            Deck _player2Win = new Deck(_player2.Owner);
            List<Card> bounty = new List<Card>();

            while ((_player1.Cards.Count > 0) && (_player2.Cards.Count > 0))
            {
                result += String.Format("<h4>Round {0}</h4>", round);
                Card player1Draw = DrawCard(_player1);
                Card player2Draw = DrawCard(_player2);
                result += String.Format("Battle Cards: {0} of {1} versus {2} of {3}<br/>",
                    player1Draw.Name, player1Draw.Suit, player2Draw.Name, player2Draw.Suit);
                bounty = moveCards(player1Draw, player2Draw, _player1, _player2);


                if (player1Draw.Value == player2Draw.Value)
                {
                    result += "This means WAR!<br />";
                    Card player1Contender;
                    Card player2Contender;
                    do
                    {
                        Deck battleDeck1 = StartBattle(_player1);
                        battleDeck1.Cards.Add(player1Draw);
                        Deck battleDeck2 = StartBattle(_player2);
                        battleDeck2.Cards.Add(player2Draw);
                        bounty = moveCards(battleDeck1, battleDeck2, _player1, _player2);
                        player1Contender = battleDeck1.Cards[1];
                        player2Contender = battleDeck2.Cards[1];
                    }
                    while (player1Contender.Value == player2Contender.Value);

                    GetResults(player1Contender, player2Contender, _player1Win, _player2Win, bounty);
                }
                else
                    GetResults(player1Draw, player2Draw, _player1Win, _player2Win, bounty);

                round++;

            }

            result += String.Format("<br /><br />{0} has {1} cards <br />{2} has {3} cards <br />", _player1Win.Owner.Name, _player1Win.Cards.Count,
                _player2Win.Owner.Name, _player2Win.Cards.Count);

        }

        private Deck StartBattle(Deck _current)
        {
            List<Card> playerCards = BattleCards(_current);
            result += String.Format("{0} draws a {1} of {2}, a {3} of {4}, and a {5} of {6}<br />",
                _current.Owner.Name, playerCards[0].Name, playerCards[0].Suit, playerCards[1].Name, playerCards[1].Suit,
                playerCards[2].Name, playerCards[2].Suit);
            return new Deck(_current.Owner, playerCards);
        }

        private void GetResults(Card player1Draw, Card player2Draw, Deck _player1Win, Deck _player2Win, List<Card> bounty)
        {

           if (player1Draw.Value > player2Draw.Value)
            {
                AddBounty(_player1Win, bounty);
                result += String.Format("{0} Wins!", _player1Win.Owner.Name);
            }
            else
            {
                AddBounty(_player2Win, bounty);
                result += String.Format("{0} Wins!", _player2Win.Owner.Name);
            }

        }

        private List<Card> moveCards(Card player1Draw, Card player2Draw, Deck _player1, Deck _player2)
        {
            _player1.Cards.Remove(player1Draw);
            _player2.Cards.Remove(player2Draw);

            List<Card> bounty = new List<Card> { player1Draw, player2Draw };

            return bounty;
        }

        private List<Card> moveCards(Deck _battleDeck1, Deck _battleDeck2, Deck _player1, Deck _player2)
        {
            List<Card> bounty = new List<Card>();
            foreach (var card in _battleDeck1.Cards)
            {
                _player1.Cards.Remove(card);
                bounty.Add(card);
            }
            foreach (var card in _battleDeck2.Cards)
            {
                _player2.Cards.Remove(card);
                bounty.Add(card);
            }

            return bounty;
        }

        private List<Card> moveCards(List<Card> player1Draw, List<Card> player2Draw, Deck _player1, Deck _player2, List<Card> _bounty)
        {
            foreach (var card in player1Draw)
            {
                _player1.Cards.Remove(card);
                _bounty.Add(card);
            };
            foreach (var card in player2Draw)
            {
                _player2.Cards.Remove(card);
                _bounty.Add(card);
            }

            return _bounty;
        }

        private void AddBounty(Deck _winner, List<Card> bounty)
        {
            foreach (var card in bounty)
            {
                _winner.Cards.Add(card);
            }
        }

        private Card DrawCard(Deck _current)
        {
            return _current.Cards.ElementAt(draw.Next(_current.Cards.Count));

        }

        private List<Card> BattleCards(Deck _current)
        {
            Card card1;
            Card card2;
            Card card3;
            do
            {
                card1 = DrawCard(_current);
                card2 = DrawCard(_current);
                card3 = DrawCard(_current);
            }
            while ((card1 == card2) || (card2 == card3) || (card1 == card3));

            return new List<Card>()
            { card1, card2, card3};
        }
    }

}