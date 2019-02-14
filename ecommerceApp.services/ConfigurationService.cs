using ecommerceApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerceApp.Entities;
namespace ecommerceApp.services
{
    public  class ConfigurationService
    {
        #region Singleton
        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null) instance = new ConfigurationService();
                return instance;
            }
        }

        private static ConfigurationService instance { get; set; }
        private ConfigurationService() { }
        #endregion

        public Config GetConfig(string key)
        {
            using (var context = new CBContext())
            {
                return context.Configs.Find(key);
            }
        }

    }

}
