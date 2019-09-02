using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecart.Entities;
using Microsoft.Ajax.Utilities;

namespace Ecart.Web.ViewModels
{
    public class ProductSearchViewModel
    {
        public List<Product> Products { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class NewProductViewModel
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public decimal UnitPrice{ get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }

        public int Category_Id { get; set; }
        public List<Category> AvailableCategories { get; set; }


    }

    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

        public int Category_Id { get; set; }

        public List<Category> AvailableCategories { get; set; }
    }

    public class ProductViewModel
    {
        public Product Product { get; set; }
    }
}