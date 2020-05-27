using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public abstract class OrderAddress: ValueObject
    {
        public String Street { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; }
        public String ZipCode { get; private set; }

        public OrderAddress() 
        {
        }

        public OrderAddress(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
