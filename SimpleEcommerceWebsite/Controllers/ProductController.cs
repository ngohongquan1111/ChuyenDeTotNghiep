using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SimpleEcommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult ListProduct()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewDetail(int? productId)
        {
            var productService = new ProductService();

            Product product = productService.GetProductById(productId.Value);

            product.ImageURL = product.ImageURL.Replace("\\", "/");

            return View(product);
        }

        [HttpGet]
        public ActionResult UpdateProduct(int productId)
        {
            var productService = new ProductService();

            var targetProduct = productService.GetProductById(productId);

            return View(targetProduct);
        }

        [HttpPost]
        public ActionResult UpdateProductInfomation(Product product)
        {
            var productService = new ProductService();

            var targetProduct = productService.UpdateProduct(productId);

            return View(targetProduct);
        }

        [HttpPost]
        public int AddNewProduct(Product product)
        {
            var productService = new ProductService();

            product.LastModified = DateTime.Now;

            product.CreatedDate = DateTime.Now;

            if (product.ImageUpload != null && product.ImageUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(product.ImageUpload.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/upload"), fileName);

                product.ImageUpload.SaveAs(path);

                int IndexOfFile = path.IndexOf("Content");

                product.ImageURL = "\\" + path.Substring(IndexOfFile);
            }

            var isSuccess = productService.InsertProduct(product).ProductID;

            return isSuccess;
        }

        [HttpPost]
        public bool DeleteProduct(int? productId)
        {
            var productService = new ProductService();

            var product = productService.GetProductById(productId.Value);

            var isSuccess = false;

            if (product != null)
            {
                product.ProductStatusId = (int) ProductEnum.Status.Deleted;

                isSuccess = productService.UpdateProduct(product) > 0;
            }

            return isSuccess;
        }

        [HttpPost]
        public ActionResult SearchProduct(Product product)
        {
            var productService = new ProductService();

            Expression<Func<Product, bool>> predicate = products => products.ProductName.Contains(product.ProductName.Trim()) ||
                                                                    products.ProductStatusId == product.ProductStatusId ||
                                                                    products.ProductTypeId == product.ProductTypeId ||
                                                                    products.ProductID == product.ProductID;

            ViewBag.SearchResult = productService.GetProductByExpression(predicate);

            return View();
        }
    }
}