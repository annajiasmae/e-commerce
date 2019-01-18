using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ecommerceApp.Entities;
using System.Threading.Tasks;

namespace ecommerceApp.Database
{
    public class CBContext : DbContext
    {
        public CBContext() : base("ecommerceAppConnection")
        {

        }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
    }
}
