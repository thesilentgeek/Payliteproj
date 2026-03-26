using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using api.Dtos;

namespace api.Validators
{
    public class UpdatePaymentRequestDtoValidator: AbstractValidator<UpdatePaymentDto>
    {
        public UpdatePaymentRequestDtoValidator()
        {
            RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid payment status");

            RuleFor(x => x.Description)
            .MaximumLength(200);
            
        }
        
    }
}