using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public class OrderAddress
    {
        public int OrderAddressId { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public OrderAddress() 
        {
        }

        public OrderAddress(int orderAdrressId, string street, string city, string state, string country, string zipcode)
        {
            OrderAddressId = orderAdrressId;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
       
    }
}
