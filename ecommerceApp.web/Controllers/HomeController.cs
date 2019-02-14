using ecommerceApp.services;
using ecommerceApp.web.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceApp.web.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Categories = CategoriesService.Instance.GetCategories();
            model.Produits = ProductService.Instance.GetProduits(); 
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}