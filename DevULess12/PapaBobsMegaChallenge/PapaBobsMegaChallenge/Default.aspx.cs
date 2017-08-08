using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsMegaChallenge.DTO;
using PapaBobsMegaChallenge.Domain;
using PapaBobsMegaChallenge.Persistence;

namespace PapaBobsMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        GetInput InputData = new GetInput();

        protected void Page_Load(object sender, EventArgs e)
        {
            var ex = Server.GetLastError(); 
            if (ex != null)
                errorLabel.Text = ex.InnerException.Message;
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            try
            { 
                GetOrderInProcess();
                Pizza OrderedPizza = InputData.BuildPizza();
                GetUserInfo();
                Customer CustomerInfo = InputData.GetCustomer();
                string Payment = GetPaymentInfo();
                NewOrder CurrentOrder = InputData.CreateOrder(OrderedPizza, CustomerInfo, Payment);
                OrderProcess.AddOrder(CurrentOrder);
                Server.Transfer("success.aspx");
            }

            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }

        }

        private string GetPaymentInfo()
        {
            string payment;
            if (cashRadioButton.Checked)
                payment = "Cash";
            else if (creditRadioButton.Checked)
                payment = "Credit";
            else
                throw new Exception("Please select a method of payment");

            return payment;

        }

        public void GetUserInfo()
        {
            InputData.nameEntered = nameTextBox.Text;
            InputData.addressEntered = addressTextBox.Text;
            InputData.zipEntered = zipTextBox.Text;
            InputData.phoneEntered = phoneTextBox.Text;
        }

        public void GetOrderInProcess()
        {
            InputData.sizeSelected = sizeDropDownList.SelectedValue;
            InputData.crustSelected = crustDropDownList.SelectedValue;
            InputData.toppingsSelected = new List<string>();
            foreach (ListItem topping in toppingsCheckBoxList.Items)
            {
                if (topping.Selected)
                {
                    InputData.toppingsSelected.Add(topping.Value);
                }
            }

        }

        protected void Ordering(object sender, EventArgs e)
        {
            if ((sizeDropDownList.SelectedValue != "") && (crustDropDownList.SelectedValue != ""))
            {
                GetOrderInProcess();
                Pizza currentPizza = InputData.BuildPizza();
                GetCost CurrentCost = new GetCost();
                CurrentCost.FindCost(currentPizza);
                costLabel.Text = String.Format("{0:C}", CurrentCost.totalCost);
            }
        }

        public void DisplayError(string _message)
        {
            errorLabel.Text = _message;
           
        }

    }
}