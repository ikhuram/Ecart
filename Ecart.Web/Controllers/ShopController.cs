using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Ecart.Services;
using Ecart.Web.ViewModels;

namespace Ecart.Web.Controllers
{
    public class ShopController : Controller
    {

        public ActionResult Index(string searchTerm, int? minPrice, int? maxPrice, int? categoryId, int?sortBy, int? pageNo)
        {
            var pageSize = ConfigurationsService.Instance.ShopPageSize();

            ShopViewModel model = new ShopViewModel();

            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            model.MaxPrice = ProductsService.Instance.GetMaximumPrice();
            
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.SortBy = sortBy;
            model.CategoryId = categoryId;

            int totalCount = ProductsService.Instance.SearchProductsCount(searchTerm, minPrice, maxPrice, categoryId, sortBy);
            model.Products = ProductsService.Instance.SearchProducts(searchTerm, minPrice, maxPrice, categoryId, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return View(model);
        }

        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = ConfigurationsService.Instance.ShopPageSize();

            FilterProductsViewModel model = new FilterProductsViewModel();

            model.SearchTerm = searchTerm;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryId = categoryID;

            int totalCount = ProductsService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductsService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return PartialView(model);
        }

        public ActionResult Checkout()
        {
            var cartProductsCookie = Request.Cookies["cartProducts"];
            CheckoutViewModel model = new CheckoutViewModel();

            if (cartProductsCookie != null)
            {
                //var cartProducts = cartProductsCookie.Value;
                //var productIds = cartProducts.Split('-');
                //List<int> ids = productIds.Select(x => int.Parse(x)).ToList();

                model.CartProductIds = cartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductsService.Instance.GetProduct(model.CartProductIds);
                //model.CartProducts = ProductsService.Instance.GetProduct(model.CartProductIds);

            }

            return View(model);
        }
    }
}