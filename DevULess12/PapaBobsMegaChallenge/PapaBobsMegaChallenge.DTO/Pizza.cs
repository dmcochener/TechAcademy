using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PapaBobsMegaChallenge.DTO
{
    public class Pizza
    {
        public PizzaProperties.CrustType Crust;
        public PizzaProperties.PieSize Size;
        public List<PizzaProperties.Topping> Toppings;

    }
}
