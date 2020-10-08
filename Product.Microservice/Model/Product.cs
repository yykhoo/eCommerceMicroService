using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Model
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)] 
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int Stock_Available { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
    }
}
