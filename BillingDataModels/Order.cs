using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingDataModels
{
    public class Order
    {
        public string OrderNumber { get; set; } 
        public string UserId { get; set; } 
        public decimal PayableAmount { get; set; }
        public string PaymentGatewayId { get; set; } 
        public string? Description { get; set; }
    }
}
