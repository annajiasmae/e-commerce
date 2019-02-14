using ecommerceApp.Database;
using ecommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.services
{
    public class ShopeService
    {
        #region Singleton
        public static ShopeService Instance
        {
            get
            {
                if (instance == null) instance = new ShopeService();
                return instance;
            }
        }

        private static ShopeService instance { get; set; }
        private ShopeService() { }
        #endregion

        public int SaveOrder(Order p)
        {
            using (var context = new CBContext())
            {
                //context.Entry(p.IdCat).State = System.Data.Entity.EntityState.Unchanged;
                context.Orders.Add(p);
                return context.SaveChanges();
            }
        }

    }
}
