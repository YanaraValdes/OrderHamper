using OrderHamper.Domain.Exceptions;
using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public List<OrderItem> _orderItems;
        public OrderAddress Address { get; private set; }
        public int OrderAddressId { get; set; }
        public string ReceiverName { get; private set; }        

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public OrderStatus OrderStatus { get; private set; }
        public int OrderStatusId { get; set; }       

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(int id, string receiverName, OrderAddress address)
        {
            ReceiverName = receiverName;
            Id = id;
            Address = address;
            OrderStatusId = OrderStatus.Submitted.OrderStatusId;

        }

        internal void Touch()
        {
            ModifiedOn = DateTime.UtcNow;
        }

        // DDD Patterns comment
        // This Order AggregateRoot's method "AddOrderitem()" should be the only way to add Items to the Order,
        // so any behavior and validations are controlled by the AggregateRoot 
        // in order to maintain consistency between the whole Aggregate. 
        public void AddOrderItem(int productId, string productName, string category, int units = 1)
        {
            _orderItems = new List<OrderItem>();
            //var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
            //    .SingleOrDefault();

            //if (existingOrderForProduct != null)
            //{      
            //    existingOrderForProduct.AddUnits(units);
            //}
            //else
            //{
                //add validated new order item
                var orderItem = new OrderItem(productId, productName, category, units);
                _orderItems.Add(orderItem);
            //}
        }     

           

        private void StatusChangeException(OrderStatus orderStatusToChange)
        {
            throw new OrderingDomainException($"Is not possible to change the order status from {OrderStatus.Name} to {orderStatusToChange.Name}.");
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(o => o.Units);
        }      

    }
}
