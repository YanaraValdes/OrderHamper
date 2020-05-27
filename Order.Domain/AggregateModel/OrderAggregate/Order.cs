using OrderHamper.Domain.Exceptions;
using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public class Order : IEntity, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;
        public OrderAddress Address { get; private set; }
        public int _receivedId { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime ModifiedOn { get; private set; }

        public string Id { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public OrderStatus OrderStatus { get; private set; }

        private int _orderStatusId;

        private string _description;

        public Order(string id, int receiverId, OrderAddress address)
        {
            var timeSpan = DateTime.Now;
            _receivedId = receiverId;
            CreatedOn = timeSpan;
            ModifiedOn = timeSpan;
            Id = id;
            Address = address;
            _orderStatusId = OrderStatus.Submitted.Id;

        }

        internal void Touch()
        {
            ModifiedOn = DateTime.UtcNow;
        }

        // DDD Patterns comment
        // This Order AggregateRoot's method "AddOrderitem()" should be the only way to add Items to the Order,
        // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
        // in order to maintain consistency between the whole Aggregate. 
        public void AddOrderItem(int productId, string productName, string category, int units = 1)
        {
            var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingOrderForProduct != null)
            {      
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                //add validated new order item
                var orderItem = new OrderItem(productId, productName, category, units);
                _orderItems.Add(orderItem);
            }
        }

        public void SetAwaitingValidationStatus()
        {
            if (_orderStatusId == OrderStatus.Submitted.Id)
            {
                _orderStatusId = OrderStatus.AwaitingValidation.Id;
            }
        }

        public void SetStockConfirmedStatus()
        {
            if (_orderStatusId == OrderStatus.AwaitingValidation.Id)
            {       
                _orderStatusId = OrderStatus.StockConfirmed.Id;
                _description = "All the items were confirmed with available stock.";
            }
        }

        public void SetBuyerId(int id)
        {
            _receivedId = id;
        }

        public void SetShippedStatus()
        {
            if (_orderStatusId != OrderStatus.Paid.Id)
            {
                StatusChangeException(OrderStatus.Shipped);
            }

            _orderStatusId = OrderStatus.Shipped.Id;
            _description = "The order was shipped.";            
        }

        public void SetCancelledStatus()
        {
            if (_orderStatusId == OrderStatus.Paid.Id ||
                _orderStatusId == OrderStatus.Shipped.Id)
            {
                StatusChangeException(OrderStatus.Cancelled);
            }

            _orderStatusId = OrderStatus.Cancelled.Id;
            _description = $"The order was cancelled.";
            
        }

        private void StatusChangeException(OrderStatus orderStatusToChange)
        {
            throw new OrderingDomainException($"Is not possible to change the order status from {OrderStatus.Name} to {orderStatusToChange.Name}.");
        }

        public decimal GetTotal()
        {
            return _orderItems.Sum(o => o.GetUnits());
        }      

    }
}
