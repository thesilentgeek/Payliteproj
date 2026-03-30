using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using api.Enums;

namespace api.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentDto ToPaymentDto(this Payment payment)
        {
            return new PaymentDto
            {
                 Id = payment.Id,
                 Amount = payment.Amount,
                 Currency = payment.Currency,
                 Status = payment.Status,
                 Description = payment.Description,
                 CreatedAt = payment.CreatedAt,
                 UpdatedAt = payment.UpdatedAt
                
            };
            
        }

        public static Payment ToPaymentFromCreateDto(this CreatePaymentDto createDto)
        {
            return new Payment
            {
                Id = Guid.NewGuid(),                  
                Currency = createDto.Currency,
                Status = PaymentEnum.PENDING,         
                Description = createDto.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow,          
                UpdatedAt = DateTime.UtcNow           
            };
        }

    
    }
}