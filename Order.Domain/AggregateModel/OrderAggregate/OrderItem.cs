using OrderHamper.Domain.Exceptions;
using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public class OrderItem: Entity
    {
        public  string ProductName { get; private set; }
        public  string Category { get; private set; }
        public int Units { get; private set; }

        public int ProductId { get; private set; }

        protected OrderItem() { }
        public OrderItem(int productId, string productName, string category, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }           

            ProductId = productId;
            ProductName = productName;          
            Units = units;
            Category = category;
        }

        

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            Units += units;
        }
    }
   
}
