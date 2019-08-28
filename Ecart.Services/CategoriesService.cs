using Ecart.Database;
using Ecart.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Services
{
    public class CategoriesService
    {
        #region Create Product
        public void Create(Category category)
        {
            using (var _context = new EcartContext())
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Update Product
        public void Edit(Category category)
        {
            using (var _context = new EcartContext())
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        #endregion

        #region Delete Product
        public void Delete(int id)
        {
            using (var _context = new EcartContext())
            {
                var category = _context.Categories.Find(id);

                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Get Categories List
        public List<Category> GetCategories()
        {
            using (var _context = new EcartContext())
            {
                return _context.Categories.ToList();
            }
        }

        #endregion

        #region Get Single Category
        public Category GetCategory(int id)
        {
            using (var _context = new EcartContext())
            {
                return _context.Categories.Find(id);
            }
        }
        #endregion

        #region Get Featured Categories List
        public List<Category> GetFeaturedCategories()
        {
            using (var _context = new EcartContext())
            {
                return _context.Categories.Where(c => c.IsFeatured).Take(4).ToList();
            }
        }

        #endregion

        
    }
}
