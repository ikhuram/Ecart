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
        #region Singleton
        public static ProductsService Instance
        {
            get
            {
                if (instance == null) instance = new ProductsService();

                return instance;
            }
        }
        private static ProductsService instance { get; set; }

        private ProductsService()
        {
        }

        #endregion

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
                return _context.Products.Where(p => p.Id == id).Include(c => c.Category).FirstOrDefault();
            }
            
        }
        #endregion

        #region Get List of Product
        public List<Product> GetProduct(List<int> ids)
        {
            using (var _context = new EcartContext())
            {
                return _context.Products.Where(p => ids.Contains(p.Id)).ToList();
            }

        }
        #endregion

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;// int.Parse(ConfigurationsService.Instance.GetConfig("ListingPageSize").Value);

            using (var context = new EcartContext())
            {
                return context.Products.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new EcartContext())
            {
                return context.Products.OrderByDescending(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProducts(string search, int pageNo, int pageSize)
        {
            using (var context = new EcartContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Products.Where(product => product.Name != null &&
                                                             product.Name.ToLower().Contains(search.ToLower()))
                        .OrderBy(x => x.Id)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Category)
                        .ToList();
                }
                else
                {
                    return context.Products
                        .OrderBy(x => x.Id)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Category)
                        .ToList();
                }
            }
        }
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
        public void Update(Product product)
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

        #region GetProductsCount
        public int GetProductsCount(string search)
        {
            using (var context = new EcartContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Products.Where(product => product.Name != null &&
                                                             product.Name.ToLower().Contains(search.ToLower()))
                        .Count();
                }
                else
                {
                    return context.Products.Count();
                }
            }
        }
        #endregion


    }
}
