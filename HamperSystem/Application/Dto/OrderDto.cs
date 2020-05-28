using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Dto
{
    public class OrderDto
    {
        public class Orderitem
        {
            public int Units { get; set; }
            public string Productname { get; set; } 
            public string Category { get; set; }

        }

        public class Order
        {
            public int Ordernumber { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public List<Orderitem> Orderitems { get; set; }
            public decimal Total { get; set; }
        }

        public class OrderSummary
        {
            public int Ordernumber { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
            public double Total { get; set; }
        }        
        
    }
}
