using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleCalculator
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(firstTextBox.Text);
            int y = int.Parse(secondTextBox.Text);

            int result = x + y;
            resultLabel.Text = result.ToString();
        }

        protected void subButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(firstTextBox.Text);
            int y = int.Parse(secondTextBox.Text);

            int result = x - y;
            resultLabel.Text = result.ToString();
        }

        protected void multButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(firstTextBox.Text);
            int y = int.Parse(secondTextBox.Text);

            int result = x * y;
            resultLabel.Text = result.ToString();
        }

        protected void divButton_Click(object sender, EventArgs e)
        {
            double x = double.Parse(firstTextBox.Text);
            double y = double.Parse(secondTextBox.Text);

            double result = x / y;
            resultLabel.Text = result.ToString();
        }
    }
}