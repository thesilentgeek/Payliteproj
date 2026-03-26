using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos
{
    public class CreatePaymentDto
    {
        
        public decimal Amount { get;  set; }
        public required string Currency { get; set; }
        
        public string? Description { get; set; }
        
    }
}