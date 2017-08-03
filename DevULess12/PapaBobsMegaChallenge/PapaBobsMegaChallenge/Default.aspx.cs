using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsMegaChallenge.DTO;
using PapaBobsMegaChallenge.Domain;

namespace PapaBobsMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        GetInput InputData = new GetInput();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void sizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            Ordering();
            
        }

        protected void crustDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordering();
        }


        protected void toppingsCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordering();
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            GetOrderInProcess();
            Pizza OrderedPizza = InputData.BuildPizza();
            GetUserInfo();
            Customer CustomerInfo = InputData.GetCustomer();
            Order CurrentOrder = InputData.CreateOrder(OrderedPizza, CustomerInfo);

        }

        public void GetUserInfo()
        {
            InputData.nameEntered = nameTextBox.Text;
            InputData.addressEntered = addressTextBox.Text;
            InputData.zipEntered = int.Parse(zipTextBox.Text);
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

        private void Ordering()
        {
            GetOrderInProcess();
            Pizza currentPizza = InputData.BuildPizza();
            GetCost CurrentCost = new GetCost();
            CurrentCost.FindCost(currentPizza);
            costLabel.Text = String.Format("{0:C}", CurrentCost.totalCost);
        }

    }
}