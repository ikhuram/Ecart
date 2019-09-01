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
        CategoriesService categoryService = new CategoriesService();
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
            //var categories = categoryService.GetCategories();
            //return PartialView(categories);

            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = categoryService.GetCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel product)
        {
            

            var newProduct = new Product();

            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.UnitPrice = product.UnitPrice;
            newProduct.ImageUrl = product.ImageUrl;
            newProduct.IsFeatured = product.IsFeatured;

            newProduct.Category = categoryService.GetCategory(product.Category_Id);

            productService.Create(newProduct);
            //ProductsService.Instance.Create(newProduct);

            return RedirectToAction("ProductTable");
        }
        #endregion

        #region Update Product
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var product = ProductsService.Instance.GetProduct(id);
            //var product = productService.GetProduct(id);


            EditProductViewModel model = new EditProductViewModel();

            var product = productService.GetProduct(id);

            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.UnitPrice = product.UnitPrice;
            model.Category_Id = product.Category != null ? product.Category.Id : 0;
            model.ImageUrl = product.ImageUrl;

            model.AvailableCategories = categoryService.GetCategories();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            var existingProduct = productService.GetProduct(model.Id);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.UnitPrice = model.UnitPrice;

            existingProduct.Category = null; //mark it null. Because the referncy key is changed below
            existingProduct.Category_Id = model.Category.Id;

            //dont update imageURL if its empty
            if (!string.IsNullOrEmpty(model.ImageUrl))
            {
                existingProduct.ImageUrl = model.ImageUrl;
            }

            productService.Update(existingProduct);

            return RedirectToAction("ProductTable");

            //productService.Update(product);

            //return RedirectToAction("Index");
        }
        #endregion

        #region Delete Product
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //ProductsService.Instance.Delete(id);
            productService.Delete(id);

            return RedirectToAction("ProductTable");
        }
        #endregion
    }
}