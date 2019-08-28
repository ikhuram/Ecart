using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecart.Entities;
using Ecart.Services;
using Ecart.Web.ViewModels;

namespace Ecart.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductsService productService = new ProductsService();


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTable(string search)
        {
            var products = productService.GetProducts();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            
            return PartialView(products);
        }

        #region Create Product
        [HttpGet]
        public ActionResult Create()
        {
            CategoriesService categoryService = new CategoriesService();
            var categories = categoryService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel product)
        {
            CategoriesService categoryService = new CategoriesService();

            var newProduct = new Product();

            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.UnitPrice = product.UnitPrice;
            newProduct.ImageUrl = product.ImageUrl;
            newProduct.IsFeatured = product.IsFeatured;

            newProduct.Category = categoryService.GetCategory(product.CategoryId);

            productService.Create(newProduct);

            return RedirectToAction("ProductTable");
        }
        #endregion

        #region Edit Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.Edit(product);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Product
        [HttpPost]
        public ActionResult Delete(int id)
        {
            productService.Delete(id);

            return RedirectToAction("ProductTable");
        }
        #endregion
    }
}