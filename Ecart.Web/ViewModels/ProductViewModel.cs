using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecart.Web.ViewModels
{
    public class NewProductViewModel
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public decimal UnitPrice{ get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }

        public int CategoryId{ get; set; }

    }
}