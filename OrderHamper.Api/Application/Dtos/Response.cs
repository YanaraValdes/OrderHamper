using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Dtos
{
    public class Response
    {
        public string OrderId { get; set; }
        public List<ErrorModel> Error { get; set; }
    }
}
