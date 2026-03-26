using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(Guid id);
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> UpdateAsync(Guid id, UpdatePaymentDto updateDto);
        Task<Payment?> DeleteAsync(Guid id);
        // Task<(List<Payment> Payments, int TotalCount)> GetAllWithPaginationAsync(int page, int pageSize);  
    }
}