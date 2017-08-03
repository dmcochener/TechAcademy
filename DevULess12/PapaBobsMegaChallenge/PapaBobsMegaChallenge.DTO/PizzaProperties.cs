using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.DTO
{
    public static class PizzaProperties
    {
        public enum CrustType
        {
            Regular,
            Thin,
            Thick
        }

        public enum PieSize
        {
            Small,
            Medium,
            Large
        }

        public enum Topping
        {
            Sausage,
            Pepperoni,
            Onions,
            Peppers
        }
    }
}
