using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Darts;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Dart gameDart = new Dart();
            Game newGame = new Game();
            int winner = newGame.PlayTo300(gameDart, player1, player2, resultLabel);
            DisplayResults(player1, player2, winner);
        }

        public void DisplayResults(Player player1, Player player2, int winner)
        {
            resultLabel.Text += String.Format("{0} Score: {1} <br /> {2} Score: {3}<br />", player1.Name, player1.Score, player2.Name, player2.Score);
            if (winner == 1)
                resultLabel.Text += "Winner: " + player1.Name + "<br />";
            else if (winner == 2)
                resultLabel.Text += "Winner: " + player2.Name + "<br />";
            else
                return;
        }

    }

    public class Game
    {
        public int PlayTo300(Dart dart, Player player1, Player player2, Label resultLabel)
        {
            while ((player1.Score < 300) && (player2.Score < 300))
            {
                PlayRound(dart, player1);
                PlayRound(dart, player2);
            }

            if (player1.Score >= 300) return 1;
            else return 2;

        }

        public void PlayRound(Dart dart, Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                dart.Throw();
                player.Score += Score.DartGame(dart);
            }
        }

    }


    public static class Score
    {
        public static int DartGame(Dart dart)
        {
            int result = 0;

            if (dart.Score == 0)
                result = (25 * dart.Ring);
            else
                result = (dart.Score * dart.Ring);

            return result;
        }
    }

    public class Player
    {
        public string Name;
        public int Score;

        public Player(string _name)
        {
            this.Name = _name;
            this.Score = 0;
        }
    }
}