using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerceApp.Entities;
using ecommerceApp.Database;
using System.Data.Entity;

namespace ecommerceApp.services
{
    public class OrdersService
    {
        # region Singleton
        public static OrdersService Instance
        {
            get
            {
                if (instance == null) instance = new OrdersService();
                return instance;
            }
        }

        private static OrdersService instance { get; set; }
        private OrdersService() { }
        #endregion

        public List<Order> SearchOrders(string userId, string status)
        {
            using (var context = new CBContext())
            {
                var orders = context.Orders.ToList();
                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(x => x.userId.Contains(userId)).ToList();
                }
                if (!string.IsNullOrEmpty(status))
                {
                    orders = context.Orders.Where(c => c.status.Contains(status)).ToList();
                }

                return orders;
            }
        }

        public int SearchOrderCount(string userId, string status)
        {
            using (var context = new CBContext())
            {
                var orders = context.Orders.ToList();
                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(x => x.userId.Contains(userId)).ToList();
                }
                if (!string.IsNullOrEmpty(status))
                {
                    orders = context.Orders.Where(c => c.status.Contains(status)).ToList();
                }
                return orders.Count();
            }
        }

        public Order getOrderById(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Orders.Where(x => x.Id == ID).Include(x => x.orderItems).Include("OrderItems.produit").FirstOrDefault();
            }
        }
    }
}
