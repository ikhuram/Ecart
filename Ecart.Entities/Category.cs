using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

        public List<Product> Products { get; set; }
    }
}
