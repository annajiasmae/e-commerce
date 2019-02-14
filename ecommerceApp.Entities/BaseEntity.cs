using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceApp.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }

    }
}
