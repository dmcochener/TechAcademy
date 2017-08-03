using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.DTO
{
    public class GetInput
    {
        public string sizeSelected;
        public string crustSelected;
        public List<string> toppingsSelected;
        public string nameEntered;
        public string addressEntered;
        public int zipEntered;
        public string phoneEntered;

        /*public Order CreateOrder(out Customer currentCustomer)
        {
            Order currentOrder = new Order();
            currentCustomer = new Customer();
            FormData currentForm = new FormData();
            if (toppingsSelected != null)
            {
                currentOrder = currentForm.getOrder(sizeSelected, crustSelected, toppingsSelected);
            }
            else
            {
                currentOrder = currentForm.getOrder(sizeSelected, crustSelected);
            }
            currentOrder.OrderId = new Guid();
            
            currentCustomer = currentForm.getCustomer(nameEntered, addressEntered, zipEntered, phoneEntered);
            currentOrder.OrderedBy = currentCustomer;

            return currentOrder;
        }*/

        public Pizza BuildPizza()
        {
            Pizza currentPizza = new Pizza(); 
            Verification verifyPizza = new Verification();

            if (verifyPizza.VerifySize(sizeSelected, out PizzaProperties.PieSize _size))
                currentPizza.Size = _size;

            if (verifyPizza.VerifyCrust(crustSelected, out PizzaProperties.CrustType _crust))
                currentPizza.Crust = _crust;

            if (toppingsSelected != null)
            {
                currentPizza.Toppings = new List<PizzaProperties.Topping>();
                foreach (var topping in toppingsSelected)
                {
                    if (verifyPizza.VerifyTopping(topping, out PizzaProperties.Topping _topping))
                        currentPizza.Toppings.Add(_topping);
                }
            }

            return currentPizza;
        }

    }
}
