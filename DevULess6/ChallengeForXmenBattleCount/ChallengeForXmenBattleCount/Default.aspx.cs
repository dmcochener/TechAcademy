using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";

            // Your Code Here!
            int highest = numbers.Max();
            int lowest = numbers.Min();

            for (int index = 0; index < names.Length; index++)
            {
                if (numbers[index] == highest)
                {
                    result += String.Format("Most battles belong to: {0} (Value: {1}) <br />", names[index], highest);
                }

                if (numbers[index] == lowest)
                {
                    result += String.Format("Least battles belong to: {0} (Value: {1}) <br />", names[index], lowest);
                }
            }

            resultLabel.Text = result;
        }
    }
}