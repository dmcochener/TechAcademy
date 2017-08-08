using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.DTO

{
    public static class Verification
    {

        public static bool VerifyData(string _dataEntry, out string _dataFormatted)
        {
            if (_dataEntry.Trim().Length == 0)
            {
                _dataFormatted = "";
                return false;
            }
            else
            {
                _dataFormatted = _dataEntry.Trim();
                return true;
            }

        }

        public static bool VerifyZip(string _zipEntry, out int _zipFormatted)
        {
            _zipFormatted = 0;
            try
            {
                _zipFormatted = int.Parse(_zipEntry);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool VerifyCrust(string _crustEntry,  out PizzaProperties.CrustType _crust)
        {
            PizzaProperties.CrustType _crustData;
            if (Enum.TryParse(_crustEntry, out _crustData))
            {
                _crust = _crustData;
                return true;
            }
            else
            {
                _crust = _crustData;
                return false;   
            }

        }

        public static bool VerifySize(string _sizeEntry, out PizzaProperties.PieSize _size)
        {
            PizzaProperties.PieSize _sizeData;
            if (Enum.TryParse(_sizeEntry, out _sizeData))
            {
                _size = _sizeData;
                return true;
            }
            else
            {
                _size = _sizeData;
                return false;
            }

        }

        public static bool VerifyTopping(string _toppingEntry, out PizzaProperties.Topping _topping)
        {
            PizzaProperties.Topping _toppingData;
            if (Enum.TryParse(_toppingEntry, out _toppingData))
            {
                _topping = _toppingData;
                return true;
            }
            else
            {
                _topping = _toppingData;
                return false;
            }

        }
    }

}
