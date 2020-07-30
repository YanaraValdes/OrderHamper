using FluentValidation;
using OrderHamper.Api.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Validators
{
    public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>      
    {
        public CreateOrderCommandValidator()
        {            
            RuleFor(field => field.OrderItems).NotEmpty();
        }
    }
}
