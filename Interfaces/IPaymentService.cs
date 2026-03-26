using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto?> GetPaymentByIdAsync(Guid id);
        Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createDto);
        Task<PaymentDto?> UpdatePaymentAsync(Guid id, UpdatePaymentDto updateDto);
        Task<bool> DeletePaymentAsync(Guid id);
        
    }
}