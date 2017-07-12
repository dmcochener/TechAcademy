using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void formChanged(object sender, EventArgs e)
        {
            goPostage();
        }

        private void goPostage()
        {
            if (priceReady())
            {
                double volume = getVolume();
                if (volume == 0.0)
                    return;
                double multipler = getMultiplier();
                double price = getCost(multipler, volume);
                resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", price);
            }

            else
                return;
        }

        private bool priceReady()
        {
            if ((widthTextBox.Text.Trim().Length == 0) ||
                (heightTextBox.Text.Trim().Length == 0))
                return false;
            else if ((!groundRadioButton.Checked)
                && (!airRadioButton.Checked)
                && (!nextDayRadioButton.Checked))
                return false;
            else
                return true;
        }

        private double getVolume()
        {
            double width = 0.0;
            double height = 0.0;
            double length = 0.0;
            double volume = 0.0;
            if ((Double.TryParse(widthTextBox.Text, out width))
                &&(Double.TryParse(heightTextBox.Text, out height)))
            {
                if ((Double.TryParse(lengthTextBox.Text, out length)) && (length != 0))
                    volume = width * height * length;
                else
                    volume = width * height;
            }
            return volume;
        }

        private double getMultiplier()
        {
            double multiplier = 0.0;
            if (groundRadioButton.Checked)
                multiplier = .15;
            else if (airRadioButton.Checked)
                multiplier = .25;
            else if (nextDayRadioButton.Checked)
                multiplier = .45;
            return multiplier;
        }

        private double getCost(double multipler, double volume)
        {
            double cost = multipler * volume;
            return cost;
        }

    }
}