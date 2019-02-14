using ecommerceApp.web.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceApp.services;
namespace ecommerceApp.web.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Widget
        public ActionResult Produits(bool isLatestProducts , int? CategoryId =0)
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.IsLatestProducts = isLatestProducts;
            if (isLatestProducts)
            {
                pvm.Produits = ProductService.Instance.GetlatestProducts(4);
            }
            else if (CategoryId.HasValue && CategoryId.Value>0)
            {
                pvm.Produits = ProductService.Instance.GetProduitsByCategory(CategoryId.Value);
            }
            else
            {
                pvm.Produits = ProductService.Instance.GetlatestProducts(8);

            }
            ViewBag.categories = CategoriesService.Instance.GetCategories();
            return PartialView(pvm);
        }
    }
}