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
                    break;
                    //DoBattle (_player1, _player2);
                }
                else
                    GetResults(player1Draw, player2Draw, _player1Win, _player2Win, bounty);

                round++;

            }

            result += String.Format("<br />{0} has {1} cards <br />{2} has {3} cards <br />", _player1Win.Owner.Name, _player1Win.Cards.Count,
                _player2Win.Owner.Name, _player2Win.Cards.Count);

        }

        //NEED TO ADD CODE TO THE WAR!!!

        private void DoBattle(Deck player1, Deck player2)
        {
            List<Card> player1Cards = BattleCards(player1);
            List<Card> player2Cards = BattleCards(player2);

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

        private void moveCards(List<Card> player1Draw, List<Card> player2Draw, Deck _player1, Deck _player2, List<Card> _bounty)
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
            return new List<Card>()
            { DrawCard(_current), DrawCard(_current), DrawCard(_current)};
        }
    }

}