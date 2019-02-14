using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerceApp.Database;
using ecommerceApp.Entities;
using System.Data.Entity;

namespace ecommerceApp.services
{
    public class ProductService
    {
        #region Singleton
        public static ProductService Instance
        {
            get
            {
                if (instance == null) instance = new ProductService();
                return instance;
            }
        }

        private static ProductService instance { get; set; }
        private ProductService() { }
        #endregion

        public List<Produit> GetProduitsByCategory(int Id)
        {
            using (var context = new CBContext())
            {
                return context.Produits.Where(c => c.Id == Id).ToList();
            }

        }

        public int GetMaxPrix()
        {
            using (var context = new CBContext())
            {
                return (int)(context.Produits.Max(x => x.prix));
            }
        }
        public List<Produit> SearchProducts(int? minPrix , int? maxPrix, string searchTerm , int? catId, int? sortBy)
        {
            using (var context = new CBContext())
            {
                var products = context.Produits.ToList();
                if(catId.HasValue)
                {
                    products = products.Where(x => x.IdCat == catId.Value).ToList();
                }
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(c => c.nom.Contains(searchTerm)).ToList();
                }
                if (minPrix.HasValue)
                {
                    products = products.Where(x => x.prix >= minPrix.Value).ToList();
                }
                if (maxPrix.HasValue)
                {
                    products = products.Where(x => x.prix <= maxPrix.Value).ToList();
                }
                if (sortBy.HasValue)
                {
                    var sort = sortBy.Value;
                    switch (sort)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.Id).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.prix).ToList();
                            break;
                        Default :
                            products = products.OrderByDescending(x => x.prix).ToList();
                            break;
                    }
                }
                return products;
            }

        }


        public int searchProductsCount(int? minPrix, int? maxPrix, string searchTerm, int? catId)
        {
            using (var context = new CBContext())
            {
                var products = context.Produits.ToList();
                if (catId.HasValue)
                {
                    products = products.Where(x => x.IdCat == catId.Value).ToList();
                }
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(c => c.nom.Contains(searchTerm)).ToList();
                }
                if (minPrix.HasValue)
                {
                    products = products.Where(x => x.prix >= minPrix.Value).ToList();
                }
                if (maxPrix.HasValue)
                {
                    products = products.Where(x => x.prix <= maxPrix.Value).ToList();
                }
                return products.Count();
            }

        }


        public Produit GetProduit(int Id)
        {
            using (var context = new CBContext())
            {
                return context.Produits.Find(Id);
            }

        }

        public List<Produit> GetProduits(List<int> Ids)
        {
            using (var context = new CBContext())
            {
                return context.Produits.Where(p => Ids.Contains(p.Id)).ToList();
            }

        }

        public List<Produit> GetProduits()
        {
            using (var context = new CBContext())
            {
                return context.Produits.ToList();
                //return context.Produits.Include("categorie").ToList();
                //return context.Produits.Include("categorie.Produits").ToList();
            }

        }


        public List<Produit> GetlatestProducts(int n)
        {
            using (var context = new CBContext())
            {
                return context.Produits.OrderByDescending(p => p.Id).Take(n).ToList();
            }

        }


        public void SaveProduit(Produit c)
        {
            using (var context = new CBContext())
            {
                context.Produits.Add(c);
                context.SaveChanges();
            }
        }

        public void EditProduit(Produit cat)
        {
            using (var context = new CBContext())
            {
                context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                
                context.SaveChanges();
            }
        }

        public void DeleteProduit(int p)
        {
            using (var context = new CBContext())
            {
                //context.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
                var produit = context.Produits.Find(p);
                context.Produits.Remove(produit);
                context.SaveChanges();
               
            }

        }
    }
}

