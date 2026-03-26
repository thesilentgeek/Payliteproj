using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Dtos;

namespace api.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreateAsync(Payment payment)
        {
             await _context.Payments.AddAsync(payment);
             await _context.SaveChangesAsync();
             return(payment);
            

        }

        public async Task<Payment?> DeleteAsync(Guid id)
        {
            var paymentId = await _context.Payments.FindAsync(id);

            if (paymentId == null)
            {
                return null;
            }
            _context.Remove(paymentId);
            await _context.SaveChangesAsync();
            return paymentId;
            
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(Guid id)
        {
            var paymentid = await _context.Payments.FindAsync(id);
            if (paymentid == null)
            {
                return null;
            }
            return paymentid;

        }

         public async Task<Payment?> UpdateAsync(Guid id, UpdatePaymentDto updateDto)
        {
            var payment = await _context.Payments.FindAsync(id);
            
            if (payment == null)
            {
                return null;
            }
            


            
            
           
            payment.Status = updateDto.Status;
            payment.Description = updateDto.Description;
            payment.UpdatedAt = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();
            return payment;
        }

        // public async Task<(List<Payment> Payments, int TotalCount)> GetAllWithPaginationAsync(int page, int pageSize)
        // {
        //     var totalCount = await _context.Payments.CountAsync();
    
        //     var payments = await _context.Payments
        //     .OrderByDescending(p => p.CreatedAt)
        //     .Skip((page - 1) * pageSize)
        //     .Take(pageSize)
        //     .ToListAsync();
    
        //     return (payments, totalCount);
        // }
    }
}