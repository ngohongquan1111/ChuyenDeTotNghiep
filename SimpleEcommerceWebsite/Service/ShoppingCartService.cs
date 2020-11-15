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
        public ShoppingCart RetrieveShoppingCart()
        {
            List<Product> products = new List<Product>();

            if (SessionManager.GetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart) == null)
            {
                SessionManager.SetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart, new ShoppingCart(products));
            }

            return SessionManager.GetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart) as ShoppingCart;
        }

        public void AddToCard(List<Product> products)
        {
           var carts = RetrieveShoppingCart();

            if (carts != null)
            {
                foreach (var item in products)
                {
                    carts.AddCart(item);
                }
            }
        }

        public void RemoveOrder(Product product)
        {
            var carts = RetrieveShoppingCart();

            if (carts != null)
            {
                carts.RemoveCart(product);
            }
        }

        public int GetTotalItemInCart()
        {
            var carts = RetrieveShoppingCart();

            return carts.GetCurrentNumberOfItem();
        }
    }
}