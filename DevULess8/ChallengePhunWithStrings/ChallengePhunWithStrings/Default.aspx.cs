using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            string name = "Deanna Cochener";
            // In my case (Bob Tabor), the result would be:
            // robaT boB

            string newString = "";
            for (int i = (name.Length-1); i >= 0; i--)
            {
                newString += name[i];
            }
            resultLabelBT.Text = newString;


            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke

            string newNames = "";
            string[] nameArray = names.Split(',');
            for (int i = (nameArray.Length - 1); i >= 0; i--)
            {
                newNames += nameArray[i] + ",";
            }
            newNames = newNames.Remove(newNames.Length - 1); //removes last comma
            resultLabelSW.Text = newNames;



            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***

            string finalArt = "";
            for (int i = 0; i < nameArray.Length; i++)
            {
                int nameLength = nameArray[i].Length;
                int padLength = (14 - nameLength) / 2;
                string nameArt = nameArray[i].PadLeft(nameLength + padLength, '*');
                nameArt = nameArt.PadRight(14, '*');

                finalArt += nameArt + "<br />";
            }

            resultLabelArt.Text = finalArt;




            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            string remove = "remove-me";
            int removeIndex = puzzle.IndexOf(remove);
            string puzzleFixed = puzzle.Remove(removeIndex, remove.Length);
            puzzleFixed = puzzleFixed.Replace("Z", "T");
            puzzleFixed = puzzleFixed.ToLower();
            puzzleFixed = puzzleFixed.Remove(0, 1);
            puzzleFixed = puzzleFixed.Insert(0, "N");
            
            resultLabelFix.Text = puzzleFixed;
 
        }
    }
}