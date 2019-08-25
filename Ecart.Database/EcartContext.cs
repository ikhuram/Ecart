using Ecart.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Database
{
    public class EcartContext : DbContext, IDisposable
    {
        public EcartContext() : base("EcartConnection")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
