using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using api.Dtos;

namespace api.Validators
{
    public class CreatePaymentRequestDtoValidator: AbstractValidator<CreatePaymentDto>
    {
       public CreatePaymentRequestDtoValidator()
       {

            RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero")
            .PrecisionScale(18, 2, true).WithMessage("Amount cannot exceed 2 decimal places");

            RuleFor(x => x.Currency)
            .IsInEnum().WithMessage("Inavlid Currency");

            RuleFor(x => x.Description)
            .MaximumLength(200);

            
            
                
            



       }
    }
}