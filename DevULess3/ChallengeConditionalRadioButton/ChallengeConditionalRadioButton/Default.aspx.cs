using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeConditionalRadioButton
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";

            if (pencilRadioButton.Checked)
            {resultImage.ImageUrl = "~/pencil.png";}

            else if (penRadioButton.Checked)
            {resultImage.ImageUrl = "~/pen.png";}

            else if (phoneRadioButton.Checked)
            {resultImage.ImageUrl = "~/phone.png";}

            else if (tabletRadioButton.Checked)
            {resultImage.ImageUrl = "~/tablet.png";}

            else
            {resultLabel.Text = "Please select an option";}
        }
    }
}