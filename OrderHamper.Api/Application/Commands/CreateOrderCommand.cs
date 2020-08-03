using MediatR;
using OrderHamper.Api.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Application.Commands
{
    public class CreateOrderCommand: IRequest<OrderCreatedResponse>
    {
        [JsonIgnore]
        public int Ordernumber { get; set; }
        [JsonIgnore]
        public int OrderaddressId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Street { get; set; }
        public string ReceiverName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
