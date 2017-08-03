using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.DTO
{
    public class FormData
    {
        public Pizza _newOrder;
        public Customer _newCustomer;

        public Customer getCustomer(string _name, string _address, int _zip, string _phone)
        {
            Customer _customer = new Customer();
            string _verifiedName;
            string _verifiedAddress;
            int _verifiedZip;
            string _verifiedPhone;

            Verification _verify = new Verification();

            if (_verify.VerifyData(_name, out _verifiedName))
                _customer.Name = _verifiedName;
            else
                throw new Exception();
            if (_verify.VerifyData(_address, out _verifiedAddress))
                _customer.Address = _verifiedAddress;
            else
                throw new Exception();
            if (_verify.VerifyData(_zip, out _verifiedZip))
                _customer.Zip = _verifiedZip;
            else
                throw new Exception();
            if (_verify.VerifyData(_phone, out _verifiedPhone))
                _customer.Phone = _verifiedPhone;
            else
                throw new Exception();

            return _customer;
        }

        public Pizza getPizza(string _sizeEntry, string _crustEntry, List<string> _toppingEntry)
        {
            Pizza _newPizza = new Pizza();

            Verification _verify = new Verification();

            if (_verify.VerifySize(_sizeEntry, out PizzaProperties.PieSize _orderSize))
                _newPizza.Size = _orderSize;
            else
                throw new Exception();
            if (_verify.VerifyCrust(_crustEntry, out PizzaProperties.CrustType _orderCrust))
                _newPizza.Crust = _orderCrust;
            else
                throw new Exception();
            foreach (var topping in _toppingEntry)
            {
                PizzaProperties.Topping _currentTopping;
                if (_verify.VerifyTopping(topping, out _currentTopping))
                    _newPizza.Toppings.Add(_currentTopping);
                else
                    throw new Exception();
            }

            return _newPizza;

        }


    }
}
