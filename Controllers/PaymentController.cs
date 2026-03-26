using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace api.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController: ControllerBase
    {
        
        private readonly IPaymentService _paymentService;
        public PaymentController( IPaymentService paymentService)
        {
            
            _paymentService = paymentService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPayment()
        {
           var payment = await _paymentService.GetAllPaymentsAsync();
            
            return Ok(payment);
            

        }

        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            } 
            return Ok(payment);
           
        }

        [HttpPost]

        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto paymentDto)
        {
            
            var response = await _paymentService.CreatePaymentAsync(paymentDto);
            return Ok(response);
            
            

            
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task <IActionResult> Delete([FromRoute] Guid id)
        {
            var payment = await _paymentService.DeletePaymentAsync(id);
            if (payment == false)
            {
               
            
                return NotFound();
            }

            return NoContent();
        }

         [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePaymentDto updateDto)
        {
            var payment = await _paymentService.UpdatePaymentAsync(id, updateDto);
            
            if (payment == null)
            {
                return NotFound();
            }
            
            return Ok(payment);
        }
    }

}