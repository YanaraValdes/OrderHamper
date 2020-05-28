using OrderHamper.Domain.Exceptions;
using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public class OrderItem
    {
        private readonly string _productName;
        private readonly string _category;
        private int _units;

        public int ProductId { get; private set; }

        protected OrderItem() { }
        public OrderItem(int productId, string productName, string category, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }           

             ProductId = productId;
            _productName = productName;          
            _units = units;
            _category = category;
        }

        public int GetUnits()
        {
            return _units;
        }

        public string GetOrderItemProductName() => _productName;

        public string GetOrderItemCategory() => _category;

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            _units += units;
        }
    }
   
}
