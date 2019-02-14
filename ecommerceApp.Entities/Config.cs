using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class Config
    {
        [Key]
        public string key  { get; set; }
        public string value { get; set; }
    }
}
