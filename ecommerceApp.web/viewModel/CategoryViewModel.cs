using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceApp.web.viewModel
{
    public class NewCategoryViewModel
    {
        public NewCategoryViewModel() { }
        public int CategoryId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        
    }
}