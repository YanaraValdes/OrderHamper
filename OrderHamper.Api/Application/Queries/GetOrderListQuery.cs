using MediatR;
using OrderHamper.Api.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Application.Queries
{
    public class GetOrderListQuery: IRequest<List<OrderDetails>>
    {        
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }      
        
        public string City { get; set; }
        
    }
}
