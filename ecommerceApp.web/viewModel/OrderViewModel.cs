using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ecommerceApp.Entities;
using ecommerceApp.web.Models;

namespace ecommerceApp.web.viewModel
{
    public class OrderViewModel
    {
        public string userId { get; set; }
        public string status { get; set; }
        public List<Order> Orders { get; set; }
       
    }

    public class OrderDetailsViewModel
    {
        public List<string> statusDisp { get; set; }
        public Order order { get; set; }
        public ApplicationUser OrderBy { get; set; }
    }
}