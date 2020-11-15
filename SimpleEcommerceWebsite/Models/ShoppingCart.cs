using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEcommerceWebsite.Models
{
    public class ShoppingCart
    {
        private List<Order> _orders = new List<Order>();

        public ShoppingCart(List<Order> orders)
        {
            this._orders = orders;
        }

        public void AddCart(Order order)
        {
            this._orders.Add(order);
        }

        public void RemoveCart(Order order)
        {
            this._orders.Remove(order);
        }
    }
}