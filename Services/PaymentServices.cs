using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IPaymentRepository paymentRepo, ILogger<PaymentService> logger)
        {
            _paymentRepo = paymentRepo;
            _logger = logger;
        }

        public async Task<List<PaymentDto>> GetAllPaymentsAsync()
        {
            _logger.LogInformation("Retrieving all payments");
            var payments = await _paymentRepo.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} payments", payments.Count);
            return payments.Select(p => p.ToPaymentDto()).ToList();
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving payment with ID: {PaymentId}", id);
            var payment = await _paymentRepo.GetByIdAsync(id);
            
            if (payment == null)
            {
                _logger.LogWarning("Payment not found: {PaymentId}", id);
                return null;
            }
            
            _logger.LogInformation("Successfully retrieved payment: {PaymentId}", id);
            return payment.ToPaymentDto();
        }

        public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto createDto)
        {
            _logger.LogInformation("Creating payment with amount: {Amount} {Currency}", createDto.Amount, createDto.Currency);
            var payment = createDto.ToPaymentFromCreateDto();
            await _paymentRepo.CreateAsync(payment);
            _logger.LogInformation("Payment created successfully with ID: {PaymentId}", payment.Id);
            return payment.ToPaymentDto();
        }

        public async Task<PaymentDto?> UpdatePaymentAsync(Guid id, UpdatePaymentDto updateDto)
        {
            _logger.LogInformation("Updating payment {PaymentId} to status: {Status}", id, updateDto.Status);
          
            var payment = await _paymentRepo.UpdateAsync(id, updateDto);
            
            if (payment == null)
            {
                _logger.LogWarning("Cannot update - payment not found: {PaymentId}", id);
                return null;
            }
            
            _logger.LogInformation("Payment {PaymentId} updated successfully", id);
            return payment.ToPaymentDto();
        }

        public async Task<bool> DeletePaymentAsync(Guid id)
        {
            _logger.LogInformation("Deleting payment: {PaymentId}", id);
            var payment = await _paymentRepo.DeleteAsync(id);
            
            if (payment == null)
            {
                _logger.LogWarning("Cannot delete - payment not found: {PaymentId}", id);
                return false;
            }
            
            _logger.LogInformation("Payment {PaymentId} deleted successfully", id);
            return true;
        }

        // public async Task<(List<PaymentDto> Payments, int TotalCount)> GetAllPaymentsWithPaginationAsync(int page, int pageSize)
        // {
        //     _logger.LogInformation("Retrieving payments - Page: {Page}, PageSize: {PageSize}", page, pageSize);
            
        //     var (payments, totalCount) = await _paymentRepo.GetAllWithPaginationAsync(page, pageSize);
            
        //     _logger.LogInformation("Retrieved {Count} of {Total} payments", payments.Count, totalCount);
            
        //     return (payments.Select(p => p.ToPaymentDto()).ToList(), totalCount);
        // }
    }
}