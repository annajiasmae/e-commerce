using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class Categorie :BaseEntity
    {
        
        public List<Produit> produits { get; set; }
    }
}
