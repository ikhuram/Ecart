using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Web;
using Ecart.Entities;

namespace Ecart.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts{ get; set; }
        public List<int> CartProductIds{ get; set; }
    }

    public class ShopViewModel
    {

        public List<Category> FeaturedCategories{ get; set; }
        public List<Product> Products { get; set; }
        public int MaxPrice{ get; set; }
        public int? SortBy { get; set; }
        public int? CategoryId { get; set; }

        public Pager Pager { get; set; }
        public string SearchTerm { get; set; }
    }

    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }

        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryId { get; set; }
        public string SearchTerm { get; set; }
    }
}