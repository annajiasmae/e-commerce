using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceApp.Entities;
using ecommerceApp.services;
using ecommerceApp.web.viewModel;

namespace ecommerceApp.web.Controllers
{
    public class ProduitController : Controller
    {
       

        // GET: Produit
        public ActionResult Index()
        {
            var products = ProductService.Instance.GetProduits();

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var list = CategoriesService.Instance.GetCategories();
            return PartialView(list);//PartialView();
        }

        [HttpPost]
        public ActionResult Create(Produit p)
        { 
              //p.Id = ps.GetProduits().Count() + 1;
            ProductService.Instance.SaveProduit(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = ProductService.Instance.GetProduit(Id);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Produit p)
        {
            ProductService.Instance.EditProduit(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {

            ProductViewModel model = new ProductViewModel();
            model.Product = ProductService.Instance.GetProduit(Id);
            ViewBag.categories = CategoriesService.Instance.GetCategories();
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Delete(int Id)
        //{
        //    var product = produitService.GetProduit(Id);

        //    return View(product);
        //}

        [HttpPost]
        public ActionResult Delete (int Id)
        {
           ProductService.Instance.DeleteProduit(Id);
            ViewBag.categories = CategoriesService.Instance.GetCategories();
        
            return RedirectToAction("Index");
        }

        public ActionResult ListProduit(string search)
        {
            var produits = ProductService.Instance.GetProduits();
            ViewBag.products = produits;
            var categories = CategoriesService.Instance.GetCategories();
            ViewBag.categories = categories;
            if(string.IsNullOrEmpty(search) == false)
            {
                produits = produits.Where(p => p.nom != null && p.nom.Contains(search)).ToList();
            }
            return PartialView(produits);
        }

    }
}