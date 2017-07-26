using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void warButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            //Initialize Deck 

            /*List<Card> basicCards = new List<Card>()
            { new Card(2,"Hearts"), new Card(3, "Hearts"), new Card(4, "Hearts"), new Card(5, "Hearts"), new Card(6, "Hearts"),
                new Card(7,"Hearts"), new Card(8,"Hearts"), new Card(9,"Hearts"),new Card(10,"Hearts"),
                new Card(11,"Hearts"), new Card(12,"Hearts"), new Card(13,"Hearts"), new Card(14,"Hearts"),
                new Card(2,"Clubs"), new Card(3, "Clubs"), new Card(4, "Clubs"), new Card(5, "Clubs"), new Card(6, "Clubs"),
                new Card(7,"Clubs"), new Card(8,"Clubs"), new Card(9,"Clubs"),new Card(10,"Clubs"),
                new Card(11,"Clubs"), new Card(12,"Clubs"), new Card(13,"Clubs"), new Card(14,"Clubs"),
                new Card(2,"Diamonds"), new Card(3, "Diamonds"), new Card(4, "Diamonds"), new Card(5, "Diamonds"), new Card(6, "Diamonds"),
                new Card(7,"Diamonds"), new Card(8,"Diamonds"), new Card(9,"Diamonds"),new Card(10,"Diamonds"),
                new Card(11,"Diamonds"), new Card(12,"Diamonds"), new Card(13,"Diamonds"), new Card(14,"Diamonds"),
                new Card(2,"Spades"), new Card(3, "Spades"), new Card(4, "Spades"), new Card(5, "Spades"), new Card(6, "Spades"),
                new Card(7,"Spades"), new Card(8,"Spades"), new Card(9,"Spades"),new Card(10,"Spades"),
                new Card(11,"Spades"), new Card(12,"Spades"), new Card(13,"Spades"), new Card(14,"Spades"),
            };*/

            Deck dealerDeck = new Deck();
            Deck player1Deck = new Deck(new Player("Player 1"));
            Deck player2Deck = new Deck(new Player("Player 2"));

            //Divide up deck
            Deal(dealerDeck, player1Deck, player2Deck);

            //Play game
            Game game = new Game();
            game.MatchUp(player1Deck, player2Deck);
            resultLabel.Text += game.result;

     
        }

        public void Deal(Deck _start, Deck _first, Deck _second)
        {
            Random random = new Random();
            while (_start.Cards.Count > 0)
            {
                int next = random.Next(_start.Cards.Count);
                Card nextDeal = _start.Cards.ElementAt(next);
                _first.Cards.Add(nextDeal);
                resultLabel.Text += String.Format("{0} is dealt the {1} of {2} <br />", _first.Owner.Name, nextDeal.Name, nextDeal.Suit);
                _start.Cards.Remove(nextDeal);
                next = random.Next(_start.Cards.Count);
                nextDeal = _start.Cards.ElementAt(next);
                _second.Cards.Add(nextDeal);
                _start.Cards.Remove(nextDeal);
                resultLabel.Text += String.Format("{0} is dealt the {1} of {2} <br />", _second.Owner.Name, nextDeal.Name, nextDeal.Suit);
            }
        }
    }
}