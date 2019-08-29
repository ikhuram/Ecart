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
    public class ConfigurationsService
    {
        #region Add Configuration
        public void Create(Config config)
        {
            using (var _context = new EcartContext())
            {
                _context.Configurations.Add(config);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Update Configuration
        public void Edit(Config config)
        {
            using (var _context = new EcartContext())
            {
                _context.Entry(config).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        #endregion

        #region Delete Configuration
        public void Delete(string key)
        {
            using (var _context = new EcartContext())
            {
                var config = _context.Configurations.Find(key);

                _context.Configurations.Remove(config);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Get Configurations List
        public List<Config> GetConfigurations()
        {
            using (var _context = new EcartContext())
            {
                return _context.Configurations.ToList();
            }
        }

        #endregion

        #region Get Single Config
        public Config GetConfig(string key)
        {
            using (var _context = new EcartContext())
            {
                return _context.Configurations.Single(x => x.Key == key);
            }
        }
        #endregion

        

        
    }
}
