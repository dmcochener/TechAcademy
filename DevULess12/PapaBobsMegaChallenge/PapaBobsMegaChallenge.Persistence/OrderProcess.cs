using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.DTO;


namespace PapaBobsMegaChallenge.Persistence
{
    public class OrderProcess
    {
        public static void AddOrder(NewOrder _newOrder)
        {
            PizzaOrdersEntities db = new PizzaOrdersEntities();
            var dbOrders = db.Orders;


            Order _order = new Order();
            _order.OrderId = _newOrder.OrderId;
            _order.Size = _newOrder.PizzaOrdered.Size.ToString();
            _order.Crust = _newOrder.PizzaOrdered.Crust.ToString();
            // Switch case descending to add in all toppings, without null indexes
            switch (_newOrder.PizzaOrdered.Toppings.Count)
            {
                case 4:
                    _order.Fourth_Topping = _newOrder.PizzaOrdered.Toppings[3].ToString();
                    goto case 3;
                case 3:
                    _order.Third_Topping = _newOrder.PizzaOrdered.Toppings[2].ToString();
                    goto case 2;
                case 2:
                    _order.Second_Topping = _newOrder.PizzaOrdered.Toppings[1].ToString();
                    goto case 1;
                case 1:
                    _order.First_Topping = _newOrder.PizzaOrdered.Toppings[0].ToString();
                    break;
            }
            _order.Name = _newOrder.OrderedBy.Name;
            _order.Address = _newOrder.OrderedBy.Address;
            _order.Zip = _newOrder.OrderedBy.Zip;
            _order.Phone = _newOrder.OrderedBy.Phone;
            _order.Payment = _newOrder.Payment;

            dbOrders.Add(_order);
            db.SaveChanges();

        }

        public static void CompleteOrder(Guid orderId)
        {
            PizzaOrdersEntities db = new PizzaOrdersEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Complete = true;
            db.SaveChanges();
        }

    }

}