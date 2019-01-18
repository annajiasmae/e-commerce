using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class Produit : BaseEntity
    {
        public Categorie categorie { get; set; }
        public decimal prix { get; set; }
    }
}
