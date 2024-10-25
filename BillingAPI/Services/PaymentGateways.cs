using BillingAPI.Interfaces;

namespace BillingAPI.Services
{
    public class PaymentGateways : IPaymentGateways
    {
        private readonly IEnumerable<IPaymentGateway> _gateways;

        public PaymentGateways(IEnumerable<IPaymentGateway> gateways)
        {
            _gateways = gateways;
        }

        public Task<IPaymentGateway> GetPaymentGateway(string gatewayId)
        {
            var gateway = _gateways.FirstOrDefault(g => g.GatewayId == gatewayId);
            if (gateway == null)
            {
                throw new ArgumentException($"unable to  find '{gatewayId}' ");
            }
            return Task.FromResult(gateway);
        }
    }
}
