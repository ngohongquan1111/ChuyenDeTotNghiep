using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service;
using SimpleEcommerceWebsite.Service.EmailService;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace SimpleEcommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productService = new ProductService();

            Expression<Func<Product, bool>> predicate = products => products.ProductStatusId != (int)ProductEnum.Status.Deleted;

            ViewBag.Products = productService.GetProductByExpression(predicate);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SiteManager()
        {
            return View();
        }

        public ActionResult CheckOutCart()
        {
            var cartService = new ShoppingCartService();

            var cart = cartService.RetrieveShoppingCart();

            ViewBag.ItemsInCart = cart.GetProductsInCart();

            return View();
        }

        [HttpPost]
        public int GetDraftCarts()
        {
            var shoppingCartService = new ShoppingCartService();

            return shoppingCartService.GetTotalItemInCart();
        }

        [HttpPost]
        public bool AddToCartProduct(int productId, int numberOfProduct)
        {
            try
            {
                var productService = new ProductService();

                var shoppingCartService = new ShoppingCartService();

                var product = productService.GetProductById(productId);

                if (product != null)
                {
                    List<Product> products = new List<Product>();

                    for (int i = 0; i < numberOfProduct; i++)
                    {
                        products.Add(product);
                    }

                    shoppingCartService.AddToCard(products);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public decimal GetTotalAmount()
        {
            var shoppingCartService = new ShoppingCartService();

            var cart = shoppingCartService.RetrieveShoppingCart();

            return cart.GetTotalAmount();
        }


        [HttpPost]
        public ActionResult AcceptPayment()
        {
            var shoppingCartService = new ShoppingCartService();

            List<Product> products = new List<Product>();

            SessionManager.SetSessionObject(SessionObjectEnum.SessionEnum.ShoppingCart, new ShoppingCart(products));

            return Json(new { success = "true", messages = "Check out successfull" });
        }

        [HttpPost]
        public bool RemoveProduct(int productId)
        {
            var shoppingCartService = new ShoppingCartService();

            var productService = new ProductService();

            var product = productService.GetProductById(productId);

            if (product != null)
            {
                shoppingCartService.RemoveOrder(product);

                return true;
            }

            return false;
        }

        [HttpPost]
        public bool CheckIsLogin(int productId)
        {
            var shoppingCartService = new ShoppingCartService();

            var productService = new ProductService();

            var product = productService.GetProductById(productId);

            if (product != null)
            {
                shoppingCartService.RemoveOrder(product);

                return true;
            }

            return false;
        }

        [HttpPost]
        public ActionResult LogOutAccount()
        {
            SessionManager.Dispose();

            return Json(new { success = "true", messages = "Log out success" });
        }

        [HttpPost]
        public ActionResult SearchProduct(SearchModel searchInfo)
        {
            var productService = new ProductService();

            Expression<Func<Product, bool>> predicate = products => products.ProductStatusId != (int)ProductEnum.Status.Deleted;

            var productsInfo = productService.GetProductByExpression(predicate);

            if (!string.IsNullOrEmpty(searchInfo.ProductName))
            {
                productsInfo = productsInfo.Where(p => p.ProductName.Contains(searchInfo.ProductName)).ToList();
            }

            if (searchInfo.ProductTypeId > 0)
            {
                productsInfo = productsInfo.Where(p => p.ProductTypeId == searchInfo.ProductTypeId ).ToList();
            }

            ViewBag.Products = searchInfo.OrderBy == (int)PriceOrderEnum.Increase ? productsInfo.OrderBy(x => x.Price).ToList() :
                                                                                    productsInfo.OrderByDescending(x => x.Price).ToList();

            return PartialView("~/Views/Home/PatitalView/ProductIndex.cshtml");
        }
    }
}