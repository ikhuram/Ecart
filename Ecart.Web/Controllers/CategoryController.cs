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

        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoriesService.Instance.GetCategories();
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
            CategoriesService.Instance.Create(category);

            return View();
        }
        #endregion

        #region Update Category
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoriesService.Instance.Edit(category);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Category
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            CategoriesService.Instance.Delete(category.Id);

            return RedirectToAction("Index");
        }
        #endregion
    }
}