using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Dtos
{
    public class OrderCreatedResponse : Response
    {
        public string OrderId { get; set; }
    }
}
