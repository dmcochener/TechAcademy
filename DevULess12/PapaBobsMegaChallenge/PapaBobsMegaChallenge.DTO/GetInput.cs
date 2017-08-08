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
        public string zipEntered;
        public string phoneEntered;


        public Customer GetCustomer()
        {
            Customer _customer = new Customer();
            string _verifiedName;
            string _verifiedAddress;
            int _verifiedZip;
            string _verifiedPhone;


            if (Verification.VerifyData(nameEntered, out _verifiedName))
                _customer.Name = _verifiedName;
            else
                throw new Exception("Please enter your name.");
            if (Verification.VerifyData(addressEntered, out _verifiedAddress))
                _customer.Address = _verifiedAddress;
            else
                throw new Exception("Please enter your address.");
            if (Verification.VerifyZip(zipEntered, out _verifiedZip))
                _customer.Zip = _verifiedZip;
            else
                throw new Exception("Please enter your zip code.");
            if (Verification.VerifyData(phoneEntered, out _verifiedPhone))
                _customer.Phone = _verifiedPhone;
            else
                throw new Exception("Please enter your phone number.");

            return _customer;
        }

        public NewOrder CreateOrder(Pizza PizzaOrder, Customer CustomerInfo, string Payment)
        {
            NewOrder currentOrder = new NewOrder();
            currentOrder.OrderId = Guid.NewGuid();
            currentOrder.PizzaOrdered = PizzaOrder;
            currentOrder.OrderedBy = CustomerInfo;
            currentOrder.Payment = Payment;

            return currentOrder;
        }

        public Pizza BuildPizza()
        {
            Pizza currentPizza = new Pizza();

            if (Verification.VerifySize(sizeSelected, out PizzaProperties.PieSize _size))
                currentPizza.Size = _size;
            else
                throw new Exception("Please select a pie size for your order.");

            if (Verification.VerifyCrust(crustSelected, out PizzaProperties.CrustType _crust))
                currentPizza.Crust = _crust;
            else
                throw new Exception("Please select a crust type for your order");

            if (toppingsSelected != null)
            {
                currentPizza.Toppings = new List<PizzaProperties.Topping>();
                foreach (var topping in toppingsSelected)
                {
                    if (Verification.VerifyTopping(topping, out PizzaProperties.Topping _topping))
                        currentPizza.Toppings.Add(_topping);
                }
            }

            return currentPizza;
        }

    }
}
