using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEcommerceWebsite.Service
{
    public class ShoppingCartService
    {
        private ShoppingCart RetrieveShoppingCart()
        {
            List<Order> orders = new List<Order>();

            if (SessionManager.GetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart) == null)
            {
                SessionManager.SetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart, new ShoppingCart(orders));
            }

            return SessionManager.GetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart) as ShoppingCart;
        }

        public void AddToCard(Order order)
        {
           var carts = RetrieveShoppingCart();

            if (carts != null)
            {
                carts.AddCart(order);
            }
        }

        public void RemoveOrder(Order order)
        {
            var carts = RetrieveShoppingCart();

            if (carts != null)
            {
                carts.RemoveCart(order);
            }
        }
    }
}