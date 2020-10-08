using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Model
{
    public class Customer: BaseEntity
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
    }
}
