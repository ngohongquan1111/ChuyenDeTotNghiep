using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SimpleEcommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult ListProduct()
        {
            var productService = new ProductService();

            Expression<Func<Product, bool>> predicate = products => products.ProductStatusId != (int)ProductEnum.Status.Deleted;

            ViewBag.Products = productService.GetProductByExpression(predicate);

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

            product.ImageURL = product.ImageURL != null ? product.ImageURL.Replace("\\", "/") : string.Empty;

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
        public int UpdateProductInfomation(Product product)
        {
            var productService = new ProductService();

            var productId = product.ProductID;

            if (product.ImageUpload != null && product.ImageUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(product.ImageUpload.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/upload"), fileName);

                product.ImageUpload.SaveAs(path);

                int IndexOfFile = path.IndexOf("Content");

                product.ImageURL = "\\" + path.Substring(IndexOfFile);
            }
            var totalChanges = productService.UpdateProduct(product);

            return totalChanges > 0 ? productId : 0 ;
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
        public int DeleteProduct(int? productId)
        {
            var productService = new ProductService();

            var product = productService.GetProductById(productId.Value);

            var isSuccess = 0;

            if (product != null)
            {
                product.ProductStatusId = (int) ProductEnum.Status.Deleted;

                isSuccess = productService.UpdateProduct(product);
            }

            return isSuccess;
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
                productsInfo = productsInfo.Where(p => p.ProductTypeId == searchInfo.ProductTypeId).ToList();
            }

            ViewBag.Products = searchInfo.OrderBy == (int)PriceOrderEnum.Increase ? productsInfo.OrderBy(x => x.Price).ToList() :
                                                                                    productsInfo.OrderByDescending(x => x.Price).ToList();

            return PartialView("~/Views/Product/TableListProducts.cshtml");
        }
    }
}