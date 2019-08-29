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
        ProductsService productsService = new ProductsService();

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
                model.CartProducts = productsService.GetProduct(model.CartProductIds);

            }

            return View(model);
        }
    }
}