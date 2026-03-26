using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos
{
    public class UpdatePaymentDto
    {
        public  PaymentEnum Status { get; set; }
        public string? Description { get; set; }
    }
}