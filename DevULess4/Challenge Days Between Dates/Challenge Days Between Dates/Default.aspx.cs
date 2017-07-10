using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_Days_Between_Dates
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            DateTime day1 = firstCalendar.SelectedDate;
            DateTime day2 = secondCalendar.SelectedDate;
            TimeSpan difference;

            if (day1 > day2)
                difference = day1 - day2;
            else
                difference = day2 - day1;

            resultLabel.Text = difference.TotalDays.ToString();
        }
    }
}