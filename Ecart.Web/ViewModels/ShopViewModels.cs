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
}