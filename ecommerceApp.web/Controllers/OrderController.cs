using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerceApp.web.viewModel;
using ecommerceApp.services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace ecommerceApp.web.Controllers
{
    public class OrderController : Controller
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

        // GET: Order
        public ActionResult Index(string userId , string status)
        {
            OrderViewModel model = new OrderViewModel();
            model.userId = userId;
            model.status = status;
            model.Orders = OrdersService.Instance.SearchOrders(userId, status);
            var totalRecords = OrdersService.Instance.SearchOrderCount(userId, status);
            return View(model);
        }

        public ActionResult Detail(int ID)
        {
            OrderDetailsViewModel model = new OrderDetailsViewModel();
           
            model.order = OrdersService.Instance.getOrderById(ID);
            if(model.order != null)
            {
                model.OrderBy = UserManager.FindById(User.Identity.GetUserId());
            }

            model.statusDisp = new  List<string>(){ "en cour d'envoi","envoyé","en attendant"};
            return View(model);
        }
    }
}