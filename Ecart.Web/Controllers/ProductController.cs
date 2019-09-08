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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTable(string search, int? pageNo)
        {
            //var products = ProductsService.Instance.GetProducts();

            //if (!string.IsNullOrEmpty(search))
            //{
            //    products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            //}

            //return PartialView(products);
    
            var pageSize = ConfigurationsService.Instance.PageSize();

            ProductSearchViewModel model = new ProductSearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalRecords = ProductsService.Instance.GetProductsCount(search);
            model.Products = ProductsService.Instance.GetProducts(search, pageNo.Value, pageSize);

            model.Pager = new Pager(totalRecords, pageNo, pageSize);

            return PartialView(model);
        }

        #region Create Product
        [HttpGet]
        public ActionResult Create()
        {

            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = CategoriesService.Instance.GetCategories();

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

            newProduct.Category = CategoriesService.Instance.GetCategory(product.Category_Id);

            ProductsService.Instance.Create(newProduct);
   
            return RedirectToAction("ProductTable");
        }
        #endregion

        #region Update Product
        [HttpGet]
        public ActionResult Edit(int id)
        {

            EditProductViewModel model = new EditProductViewModel();

            var product = ProductsService.Instance.GetProduct(id);

            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.UnitPrice = product.UnitPrice;
            model.Category_Id = product.Category != null ? product.Category.Id : 0;
            model.ImageUrl = product.ImageUrl;

            model.AvailableCategories = CategoriesService.Instance.GetCategories();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.Id);
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

            ProductsService.Instance.Update(existingProduct);

            return RedirectToAction("ProductTable");

            //ProductsService.Instance.Update(product);

            //return RedirectToAction("Index");
        }
        #endregion

        #region Delete Product
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //ProductsService.Instance.Delete(id);
            ProductsService.Instance.Delete(id);

            return RedirectToAction("ProductTable");
        }
        #endregion

        [HttpGet]
        public ActionResult Details(int id)
        {

            ProductViewModel model = new ProductViewModel();

            model.Product = ProductsService.Instance.GetProduct(id);

            
            return View(model);
        }
    }
}