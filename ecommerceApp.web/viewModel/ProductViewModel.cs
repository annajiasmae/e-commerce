using ecommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceApp.web.viewModel
{
    public class ProductViewModel
    {
        public List<Produit> Produits { get; set; }
        public bool IsLatestProducts { get; set; }
        public Produit Product { get; set; }

    }
}