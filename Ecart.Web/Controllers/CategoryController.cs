using Ecart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecart.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            return View();
        }
    }
}