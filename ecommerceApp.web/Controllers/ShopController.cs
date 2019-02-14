using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceApp.services;
using ecommerceApp.web.viewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ecommerceApp.web.code;
using ecommerceApp.Entities;

namespace ecommerceApp.web.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index(int? minPrix, int? maxPrix, string searchTerm, int? catId , int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();
            model.Categories = CategoriesService.Instance.GetCategories().ToList();
            model.MaxPrix = ProductService.Instance.GetMaxPrix();
            model.Products = ProductService.Instance.SearchProducts(minPrix, maxPrix, searchTerm, catId,sortBy);

            return View(model);
        }
        
        public ActionResult FilterProducts(int? minPrix, int? maxPrix, string searchTerm, int? catId, int? sortBy)
        {
            FilterProductViewModel model = new FilterProductViewModel();

            model.Produitts = ProductService.Instance.SearchProducts(minPrix, maxPrix, searchTerm, catId, sortBy);
            return PartialView(model);
        }

        public JsonResult PostOrder(string prodId)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (!string.IsNullOrEmpty(prodId))
            {
                var qtes = prodId.Split('-').Select(x => int.Parse(x)).ToList();
                var prodAchat = ProductService.Instance.GetProduits(qtes.Distinct().ToList());
                Order newOrder = new Order();
                newOrder.userId = User.Identity.GetUserId();
                newOrder.orderDate = DateTime.Now;
                newOrder.status = "En attendant";
                newOrder.orderItems = new List<OrderItem>();
                newOrder.orderItems.AddRange(prodAchat.Select(s => new OrderItem() { productId = s.Id }));

                var lignesEffected = ShopeService.Instance.SaveOrder(newOrder);
                newOrder.totalAmount = prodAchat.Sum(x => x.prix * qtes.Where(p => p == x.Id).Count());
                result.Data = new { Success = true  ,Rows = lignesEffected };

            }
            else result.Data = new { Success = false };

            return result;
        }

        // GET: Shop
        
        public ActionResult Checkout()
        {
            chekoutViewModel model = new chekoutViewModel();
            var CartProductCookie = Request.Cookies["Cart"];

            if(CartProductCookie != null && !string.IsNullOrEmpty(CartProductCookie.Value))
            {
                model.CartProduitIds = CartProductCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProduit = ProductService.Instance.GetProduits(model.CartProduitIds);
                model.User = UserManager.FindById(User.Identity.GetUserId());
            }

            return View(model);
        }
    }
}