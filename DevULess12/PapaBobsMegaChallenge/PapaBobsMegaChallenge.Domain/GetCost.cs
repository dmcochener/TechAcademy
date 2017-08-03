using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.Domain
{
    public class GetCost
    {
        public double totalCost;
        double thisCrustCost;
        double thisPieCost;
        double thisToppingCost;

        public void FindCost(Pizza _currentPizza)
        {
            SetCost _prices = new SetCost();
            thisCrustCost = FindCrustCost(_currentPizza.Crust, _prices.crustCost);
            thisPieCost = FindPieCost(_currentPizza.Size, _prices.sizeCost);
            thisToppingCost = FindToppingCost(_currentPizza.Toppings, _prices.toppingCost);
            totalCost = thisCrustCost + thisPieCost + thisToppingCost;
        }


        public static double FindCrustCost(PizzaProperties.CrustType _crust, Dictionary<PizzaProperties.CrustType, double> _crustCost)
        {
            double _thisCrustCost = 0;
            switch (_crust) { 
            
               case PizzaProperties.CrustType.Regular:
                    if (_crustCost.TryGetValue(PizzaProperties.CrustType.Regular, out _thisCrustCost))
                        break;
                    else
                        throw new Exception();
                case PizzaProperties.CrustType.Thin:
                    if (_crustCost.TryGetValue(PizzaProperties.CrustType.Thin, out _thisCrustCost))
                        break;
                    else
                        throw new Exception();
                case PizzaProperties.CrustType.Thick:
                    if (_crustCost.TryGetValue(PizzaProperties.CrustType.Thick, out _thisCrustCost))
                        break;
                    else
                        throw new Exception();
            }
            return _thisCrustCost;
        }

        public static double FindPieCost(PizzaProperties.PieSize _pieSize, Dictionary<PizzaProperties.PieSize, double> _pieCost)
        {
            double _thisPieCost = 0;
            switch (_pieSize)
            {

                case PizzaProperties.PieSize.Small:
                    if (_pieCost.TryGetValue(PizzaProperties.PieSize.Small, out _thisPieCost))
                        break;
                    else
                        throw new Exception();
                case PizzaProperties.PieSize.Medium:
                    if (_pieCost.TryGetValue(PizzaProperties.PieSize.Medium, out _thisPieCost))
                        break;
                    else
                        throw new Exception();
                case PizzaProperties.PieSize.Large:
                    if (_pieCost.TryGetValue(PizzaProperties.PieSize.Large, out _thisPieCost))
                        break;
                    else
                        throw new Exception();
            }

            return _thisPieCost;
        }

        public static double FindToppingCost(List<PizzaProperties.Topping> _toppings, Dictionary<PizzaProperties.Topping, double> _toppingCost)
        {
            double _thisToppingCost = 0;
            if (_toppings != null)
            {
                foreach (var topping in _toppings)
                {
                    double currentToppingCost = 0;
                    switch (topping)
                    {

                        case PizzaProperties.Topping.Sausage:
                            if (_toppingCost.TryGetValue(PizzaProperties.Topping.Sausage, out currentToppingCost))
                                break;
                            else
                                throw new Exception();
                        case PizzaProperties.Topping.Pepperoni:
                            if (_toppingCost.TryGetValue(PizzaProperties.Topping.Pepperoni, out currentToppingCost))
                                break;
                            else
                                throw new Exception();
                        case PizzaProperties.Topping.Onions:
                            if (_toppingCost.TryGetValue(PizzaProperties.Topping.Onions, out currentToppingCost))
                                break;
                            else
                                throw new Exception();
                        case PizzaProperties.Topping.Peppers:
                            if (_toppingCost.TryGetValue(PizzaProperties.Topping.Peppers, out currentToppingCost))
                                break;
                            else
                                throw new Exception();
                    }

                    _thisToppingCost += currentToppingCost;
                }
            }
            return _thisToppingCost;
        }
    }
}
