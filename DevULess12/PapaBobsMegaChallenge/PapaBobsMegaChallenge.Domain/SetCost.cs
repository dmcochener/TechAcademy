using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.Domain
{
    public class SetCost
    {
        public Dictionary<PizzaProperties.CrustType, double> crustCost;
        public Dictionary<PizzaProperties.PieSize, double> sizeCost;
        public Dictionary<PizzaProperties.Topping, double> toppingCost;

        public SetCost()
        {
            crustCost = new Dictionary<PizzaProperties.CrustType, double>();
            sizeCost = new Dictionary<PizzaProperties.PieSize, double>();
            toppingCost = new Dictionary<PizzaProperties.Topping, double>();
            SetCrustCost(crustCost);
            SetPieCost(sizeCost);
            SetToppingCost(toppingCost);
        }


        private void SetCrustCost(Dictionary <PizzaProperties.CrustType, double> crustCost)
        {
            crustCost.Add(PizzaProperties.CrustType.Regular, 0.00);
            crustCost.Add(PizzaProperties.CrustType.Thin, 0.0);
            crustCost.Add(PizzaProperties.CrustType.Thick, 2.0);
        }

        private void SetPieCost(Dictionary<PizzaProperties.PieSize, double> sizeCost)
        {
            sizeCost.Add(PizzaProperties.PieSize.Small, 12.0);
            sizeCost.Add(PizzaProperties.PieSize.Medium, 14.0);
            sizeCost.Add(PizzaProperties.PieSize.Large, 16.0);
        }

        private void SetToppingCost(Dictionary<PizzaProperties.Topping, double> toppingCost)
        {
            toppingCost.Add(PizzaProperties.Topping.Sausage, 2.0);
            toppingCost.Add(PizzaProperties.Topping.Pepperoni, 1.5);
            toppingCost.Add(PizzaProperties.Topping.Onions, 1.0);
            toppingCost.Add(PizzaProperties.Topping.Peppers, 1.0);
        }
    }
}
