using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            string age = ageTextBox.Text;
            string cash = cashTextBox.Text;

            string result = "At " + age + " years old, I would have expected you to have more than " + cash + " in your pocket.";

            resultLabel.Text = result;
        }
    }
}