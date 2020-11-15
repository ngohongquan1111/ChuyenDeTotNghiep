using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using SimpleEcommerceWebsite.SimpleEcomerceDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SimpleEcommerceWebsite.Service
{
    public class ProductService
    {
        public dynamic Get { get; internal set; }

        public Product GetProductById(int productId)
        {
            Product product = new Product();

            using (var context = new EcommerceDbContext())
            {
                product = context.Products.Find(productId);
            }

            return product?.ProductStatusId != (int)ProductEnum.Status.Deleted ? product : new Product();
        }

        public int UpdateProduct(Product product)
        {
            int totalChanges = 0;

            using (var context = new EcommerceDbContext())
            {
                context.Products.Attach(product);

                context.Entry(product).State = EntityState.Modified;

                totalChanges = context.SaveChanges();
            }

            return totalChanges;
        }

        public Product InsertProduct(Product product)
        {
            int totalChanges = 0;

            using (var context = new EcommerceDbContext())
            {
                context.Products.Add(product);

                totalChanges = context.SaveChanges();
            }

            return product;
        }

        public List<Product> GetProductByExpression(Expression<Func<Product, bool>> expression)
        {
            List<Product> products = new List<Product>();

            using (var context = new EcommerceDbContext())
            {
                products = context.Products.Where(expression.Compile()).ToList();
            }

            return products;
        }
    }
}