using ecommerceApp.Entities;
using ecommerceApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceApp.web.Controllers
{
    //[Authorize(Roles = "annaji.asmae@gmail.com")]
    public class CategoryController : Controller
    {
        //CategoriesService categorieService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoriesService.Instance.GetCategories();
            return View(categories);
        }

        #region Creation
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Categorie categorie)
        {
            CategoriesService.Instance.SaveCategorie(categorie);
            return RedirectToAction("Index");
        }
        #endregion

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var categorie = CategoriesService.Instance.GetCategorie(Id);

            return View(categorie);
        }
        
        [HttpPost]
        public ActionResult Edit(Categorie categorie)
        {
            CategoriesService.Instance.EditCategorie(categorie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var categorie = CategoriesService.Instance.GetCategorie(Id);

            return View(categorie);
        }

        [HttpPost]
        public ActionResult Delete(Categorie categorie)
        {
            CategoriesService.Instance.DeleteCategorie(categorie);
            return RedirectToAction("Index");
        }

        public ActionResult ListCategories(string search)
        {
            //var ps = new ProductService();
            var categories = CategoriesService.Instance.GetCategories();
            ViewBag.products = ProductService.Instance.GetProduits();
            if (string.IsNullOrEmpty(search) == false)
            {
                categories = categories.Where(p => p.nom != null && p.nom.Contains(search)).ToList();
            }
            return PartialView(categories);
        }

    }
}