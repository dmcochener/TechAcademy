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


        /*public void GetUserInfo(GetInput _inputData)
        {
            sizeDropDownList.SelectedValue = _inputData.sizeSelected;
            crustDropDownList.SelectedValue = _inputData.crustSelected;
            string newTopping = toppingsCheckBoxList.SelectedValue;
            if (newTopping != "")
            {
              _inputData.toppingsSelected.Add(newTopping);
            }
            //_inputData.nameEntered = nameTextBox.Text;
            //_inputData.addressEntered = addressTextBox.Text;
            //_inputData.zipEntered = int.Parse(zipTextBox.Text);
            //_inputData.phoneEntered = phoneTextBox.Text;
        }*/

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