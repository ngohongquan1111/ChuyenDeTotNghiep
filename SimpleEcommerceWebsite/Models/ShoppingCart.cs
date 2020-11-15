using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEcommerceWebsite.Models
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();

        public ShoppingCart(List<Product> product)
        {
            this._products = product;
        }

        public void AddCart(Product product)
        {
            this._products.Add(product);
        }

        public void RemoveCart(Product product)
        {
            var targetProduct = this._products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();

            this._products.Remove(targetProduct);
        }

        public int GetCurrentNumberOfItem()
        {
            return this._products.Any() ? this._products.Count() : 0;
        }

        public decimal GetTotalAmount()
        {
            return this._products.Any() ? this._products.Sum(p => p.Price) : 0;
        }

        public List<Product> GetProductsInCart()
        {
            return this._products;
        }
    }
}