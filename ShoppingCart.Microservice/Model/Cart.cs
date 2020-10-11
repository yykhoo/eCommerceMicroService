using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Microservice.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
