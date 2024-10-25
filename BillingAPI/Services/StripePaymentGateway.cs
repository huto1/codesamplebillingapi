using BillingAPI.Interfaces;
using BillingDataModels;

namespace BillingAPI.Services
{
    public class StripePaymentGateway : IPaymentGateway
    {
        public string GatewayId => "stripe";

        public Task<bool> ProcessPaymentAsync(Order order)
        {  
            return Task.FromResult(true);
        }
    }
}
