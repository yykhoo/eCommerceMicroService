using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Product.Microservice;

namespace Order.Microservice.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order order { get; set; }

        [ForeignKey("Product.Microservice.Model.Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
