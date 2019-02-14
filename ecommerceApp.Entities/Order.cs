using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string status { get; set; }
        public DateTime orderDate { get; set; }
        public decimal totalAmount { get; set; }
        public virtual List<OrderItem> orderItems{ get; set; }
    }
}
