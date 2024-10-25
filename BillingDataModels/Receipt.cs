using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingDataModels
{
    public class Receipt
    {
        public string ReceiptNumber { get; set; }
        public string OrderNumber { get;  set; }
        public decimal Amount { get;  set; }
        public DateTime ProcessedAt { get;  set; }
    }
}
