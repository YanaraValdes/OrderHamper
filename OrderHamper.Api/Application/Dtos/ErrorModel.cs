using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Dtos
{
    public class ErrorModel
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
