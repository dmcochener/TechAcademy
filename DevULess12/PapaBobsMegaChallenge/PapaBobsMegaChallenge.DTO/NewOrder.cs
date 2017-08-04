using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.DTO
{
    public class NewOrder
    {
        public Guid OrderId;
        public Pizza PizzaOrdered;
        public Customer OrderedBy;
        public string Payment;

    }

}
