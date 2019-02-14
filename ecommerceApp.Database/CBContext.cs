using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ecommerceApp.Entities;
using System.Threading.Tasks;

namespace ecommerceApp.Database
{
    public class CBContext : DbContext, IDisposable
    {
        public CBContext() : base("ecommerceAppConnection")
        {

        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
