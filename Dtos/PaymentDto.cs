using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos
{
    public class PaymentDto
    {

        public Guid Id { get; set; }
        public decimal Amount { get;  set; }
        public string Currency { get; set; } = String.Empty;
        public PaymentEnum Status { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}