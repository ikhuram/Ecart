using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecart.Entities;

namespace Ecart.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> FeaturedCategories{ get; set; }
        public IEnumerable<Product> FeaturedProducts{ get; set; }
    }
}