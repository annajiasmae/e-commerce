using ecommerceApp.Entities;
using ecommerceApp.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceApp.web.viewModel
{
    public class chekoutViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Produit> CartProduit { get ; set ;}
        public List<int> CartProduitIds { get; set; }
    }

    public class ShopViewModel
    {
        public int? CategoryId { get; set; }
        public string searchTerm { get; set; }
        public int? sortBy  { get; set; }
        public int? MaxPrix { get; set; }
        public List<Categorie> Categories { get; set; }
        public List<Produit> Products { get; set; }
    }

    public class FilterProductViewModel
    {
        public List<Produit> Produitts { get; set; }
    }
}