using BillingDataModels;

namespace BillingAPI.Interfaces
{
    public interface IPaymentGateway
    {
        string GatewayId { get; }
        Task<bool> ProcessPaymentAsync(Order order);
    }
}
