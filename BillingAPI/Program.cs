using BillingAPI.Interfaces;
using BillingAPI.Services;
using BillingDataModels;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IBillingService, BillingService>();
builder.Services.AddTransient<IPaymentGateway, StripePaymentGateway>();
builder.Services.AddTransient<IPaymentGateways, PaymentGateways>(); 
 
var app = builder.Build();
 
app.UseHttpsRedirection();
 

app.MapPost("/api/billing/handleorder", async (Order order, IBillingService billingService) =>
{
    try
    {
        var receipt = await billingService.ProcessOrderAsync(order);
        return Results.Ok(receipt);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();
 