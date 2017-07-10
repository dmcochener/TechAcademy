using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpies
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                previousCalendar.SelectedDate = DateTime.Now.Date;
                newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            
            }
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            DateTime previousEnd = previousCalendar.SelectedDate;
            DateTime nextStart = newCalendar.SelectedDate;
            DateTime nextEnd = endCalendar.SelectedDate;
            TimeSpan vacation = nextStart - previousEnd;

            if (vacation.TotalDays < 14)
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";
                newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
            }
            else
            {
                TimeSpan newAssignment = nextEnd - nextStart;
                int newBudget;
                if (newAssignment.TotalDays > 21)
                    newBudget = ((int)newAssignment.TotalDays * 500) + 1000;
                else
                    newBudget = (int)newAssignment.TotalDays * 500;

                resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2:C}", spyNameTextBox.Text, assignNameTextBox.Text, newBudget); 

            }

        }
    }
}