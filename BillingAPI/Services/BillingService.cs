using BillingAPI.Interfaces;
using BillingDataModels;

namespace BillingAPI.Services
{
    public class BillingService : IBillingService
    {
        private readonly IPaymentGateways _gateways;

        public BillingService(IPaymentGateways gateways)
        {
            _gateways = gateways;
        }

        public async Task<Receipt> ProcessOrderAsync(Order order)
        {
            IPaymentGateway gateway = await _gateways.GetPaymentGateway(order.PaymentGatewayId);
            var paymentResult = await gateway.ProcessPaymentAsync(order);

            if (!paymentResult)
            {
                throw new Exception("Payment failed");
            }

            return new Receipt() { ReceiptNumber = Guid.NewGuid().ToString() , OrderNumber =  order.OrderNumber, Amount = order.PayableAmount };
        }
    }
}
