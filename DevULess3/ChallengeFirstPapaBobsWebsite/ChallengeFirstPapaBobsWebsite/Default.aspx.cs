using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            totalLabel.Text = "0.00";
        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            double total = 0;
            sizeselectLabel.Text = "";
            crustselectLabel.Text = "";

            //First check size and add to total
            if (babyRB.Checked)
                total = total + 10;
            else if (mamaRB.Checked)
                total = total + 13;
            else if(papaRB.Checked)
                total = total + 16;
            else
                sizeselectLabel.Text = "Please select a size!";

            //Next check crust size
            if (deepRB.Checked)
                total = total + 2;
            else if (!thinRB.Checked)
                crustselectLabel.Text = "Please select a crust!";

            //Next get toppings prices 
            total = (pepperoniCB.Checked) ? total + 1.5: total;
            total = (onionsCB.Checked) ? total + .75 : total;
            total = (greenpepCB.Checked) ? total + .5 : total;
            total = (redpepCB.Checked) ? total + .75 : total;
            total = (anchoviesCB.Checked) ? total + 2 : total;

            //Check for Deal

            if ((pepperoniCB.Checked && greenpepCB.Checked && anchoviesCB.Checked) 
                || (pepperoniCB.Checked && redpepCB.Checked && onionsCB.Checked))
            {
                total = total - 2;
            }

            totalLabel.Text = total.ToString();
                
        }
    }
}