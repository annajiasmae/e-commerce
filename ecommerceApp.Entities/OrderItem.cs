using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Qte { get; set; }
        public int  OrderId { get; set; }
        public virtual Order  order { get; set; }
        public int productId { get; set; }
        public virtual Produit produit { get; set; }
    }
}
