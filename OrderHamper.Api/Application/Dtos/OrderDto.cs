using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Dtos
{
    public class OrderDto
    {
        public class OrderItemDto
        {
            [JsonIgnore]
            public int ProductId { get; set; }
            public int Units { get; set; }
            public string Category { get; set; }
            public string ProductName { get; set; }
        }
        public class OrderDetails 
        {
            public int Ordernumber { get; set; }
            public int OrderaddressId { get; set; }
            public DateTime Date { get; set; }
            public int Status { get; set; }
            public string Street { get; set; }
            public string ReceiverName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public List<OrderItemDto> Orderitems { get; set; }
            public decimal Total { get; set; }
        }
    }
}
