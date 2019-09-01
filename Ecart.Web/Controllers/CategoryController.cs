using Ecart.Entities;
using Ecart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecart.Web.Controllers
{
    //[Authorize]   // Only authorized users can access this
    public class CategoryController : Controller
    {
        private CategoriesService categoryService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }

        #region Create Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.Create(category);

            return View();
        }
        #endregion

        #region Update Category
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.Edit(category);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Category
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoryService.Delete(category.Id);

            return RedirectToAction("Index");
        }
        #endregion
    }
}