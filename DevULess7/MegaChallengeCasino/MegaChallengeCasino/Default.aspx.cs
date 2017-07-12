using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        //set universal randomizer
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Initialize Money
                ViewState.Add("Player Money", 100.00);
                //Set random initial images and money display
                int[] initialArray = setImages();
                displayMoney();  
            }
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            //verify bid amount and player has money
            double playerBid = 0.0;
            if (!validBid(out playerBid)) return;
            double playerMoney = (double)ViewState["Player Money"];
            if (playerBid > playerMoney) return;
            //get new images
            int[] imageNumberArray = setImages();
            //determine results
            int[] imageFrequencyArray = getResults(imageNumberArray);
            int resultMultiplier = getMultiply(imageFrequencyArray);
            //update players money
           double playerWin = updatePlayerAccount(resultMultiplier, playerBid);
            //print out player's win and money
            displayWinLoss(playerBid, playerWin);
            displayMoney();

        }

        private int[] setImages()
        {
            int[] imageNumberArray = new int[3];
            oneResultImage.ImageUrl = randomImage(out imageNumberArray[0]);
            twoResultImage.ImageUrl = randomImage(out imageNumberArray[1]);
            threeResultImage.ImageUrl = randomImage(out imageNumberArray[2]);
            return imageNumberArray;
        }

        private string randomImage(out int imageNumber)
        {
            string[] imagesArray = new string[12] { "Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png", "Horseshoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png", "Strawberry.png", "Watermelon.png" };
            imageNumber = random.Next(1, 12);
            string randomImage = imagesArray[imageNumber];
            return randomImage;
        }

        private bool validBid(out double playerBid)
        {
            playerBid = 0.0;
            if (betAmountTextBox.Text.Length == 0)
                return false;
            else if (!double.TryParse(betAmountTextBox.Text, out playerBid))
                return false;
            else if (playerBid == 0.0)
                return false;
            else
                return true;
        }

        private int[] getResults(int[] imageNumberArray)
        {
            int numberBars  = getImageFreq(imageNumberArray, 0);
            int numberCherries = getImageFreq(imageNumberArray, 2);
            int numberSeven = getImageFreq(imageNumberArray, 9);
            int[] imageFrequencyArray = new int[3] {numberBars, numberCherries, numberSeven};
            return imageFrequencyArray;
        }

        private int getImageFreq(int[] imageNumberArray, int imageNumber)
        {
            int imageCount = 0;
            for (int i = 0; i < 3; i++)
            {
                if (imageNumberArray[i] == imageNumber)
                    imageCount++;
            }
            return imageCount;
        }

        private int getMultiply(int[] imageFrequencyArray)
        {
            int resultMultiplier;
            if (imageFrequencyArray[0] > 0)
                resultMultiplier = -1;
            else if (imageFrequencyArray[2] == 3)
                resultMultiplier = 100;
            else if (imageFrequencyArray[1] > 0)
                resultMultiplier = imageFrequencyArray[1] + 1;
            else resultMultiplier = -1;

            return resultMultiplier;
        }

        private double updatePlayerAccount(int resultMultiplier, double playerBid)
        {
            double playerMoney = (double)ViewState["Player Money"];
            double playerWin = playerBid * resultMultiplier;
            playerMoney += playerWin;
            ViewState["Player Money"] = playerMoney;
            return playerWin;
        }

        private void displayWinLoss(double playerBid, double playerWin)
        {
            if (playerWin > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", playerBid, playerWin);
            else
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", playerBid);
        }

        private void displayMoney()
        {
            double playerMoney = (double)ViewState["Player Money"];
            moneyLabel.Text = String.Format("Player's Money: {0:C}", playerMoney);
        }
    }
}