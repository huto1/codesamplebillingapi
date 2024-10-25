namespace BillingAPI.Interfaces
{
    public interface IPaymentGateways
    {
        Task<IPaymentGateway> GetPaymentGateway(string gatewayId);
    }
}
