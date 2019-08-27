using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

    }
}
