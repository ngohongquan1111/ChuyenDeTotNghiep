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
    }
}