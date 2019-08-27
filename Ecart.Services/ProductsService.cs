using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecart.Database;
using Ecart.Entities;

namespace Ecart.Services
{
    
    public class ProductsService
    {
        private EcartContext _context = new EcartContext();

        #region Get Products List
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        #endregion

        #region Get Single Product
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
        #endregion

        #region Create Product
        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        #endregion

        #region Update Product
        public void Edit(Product product)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion

        #region Delete Product
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        #endregion

    }
}
