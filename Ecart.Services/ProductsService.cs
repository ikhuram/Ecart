using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Ecart.Database;
using Ecart.Entities;

namespace Ecart.Services
{
    
    public class ProductsService
    {
        #region Get Products List
        public List<Product> GetProducts()
        {
            using (var _context = new EcartContext())
            {
                return _context.Products.Include(p => p.Category).ToList();
            }            
        }

        #endregion

        #region Get Single Product
        public Product GetProduct(int id)
        {
            using (var _context = new EcartContext())
            {
                return _context.Products.Find(id);
            }
            
        }
        #endregion

        #region Create Product
        public void Create(Product product)
        {
            using (var _context = new EcartContext())
            {
                _context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;

                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Update Product
        public void Edit(Product product)
        {
            using (var _context = new EcartContext())
            {
                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        #endregion

        #region Delete Product
        public void Delete(int id)
        {
            using (var _context = new EcartContext())
            {
                var product = _context.Products.Find(id);

                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        #endregion

    }
}
