using BillingDataModels;

namespace BillingAPI.Interfaces
{
    public interface IBillingService
    {
        Task<Receipt> ProcessOrderAsync(Order order);
    }
}
