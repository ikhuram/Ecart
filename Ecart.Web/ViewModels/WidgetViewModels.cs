using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecart.Entities;

namespace Ecart.Web.ViewModels
{
    public class ProductsWidgetViewModel
    {
        public List<Product> Products { get; set; }
        public bool IsLatestProducts{ get; set; }
        public bool ShowRelatedProducts { get; set; }

    }
}