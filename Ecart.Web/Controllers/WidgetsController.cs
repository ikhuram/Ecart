using Ecart.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecart.Services;

namespace Ecart.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts, bool showRelatedProducts, int? categoryId = 0)
        {
            ProductsWidgetViewModel model = new ProductsWidgetViewModel();

            model.IsLatestProducts = isLatestProducts;
            model.ShowRelatedProducts = showRelatedProducts;

            if (isLatestProducts)
            {
                model.Products = ProductsService.Instance.GetLatestProducts(4);
            }
            else if (categoryId.HasValue && categoryId.Value > 0)
            {
                model.Products = ProductsService.Instance.GetProductsByCategory(categoryId.Value, 4);
            }
            else
            {
                model.Products = ProductsService.Instance.GetProducts(1, 8);
            }

            return PartialView(model);
        }
    }
}