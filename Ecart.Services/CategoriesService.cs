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
        private EcartContext _context = new EcartContext();

        #region Get Categories List
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        #endregion

        #region Get Single Category
        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }
        #endregion

        #region Create Product
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        #endregion

        #region Update Product
        public void Edit(Category category)
        {
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion

        #region Delete Product
        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        #endregion
    }
}
