using ecommerceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceApp.web.viewModel
{
    public class HomeViewModel
    {
        public List<Categorie> Categories { get; set; }
        public List<Produit> Produits { get; set; }

    }
}