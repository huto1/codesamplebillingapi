using BillingAPI.Interfaces;
using BillingAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingAPITests
{
    public class BillingServiceTests
    {
        [Fact]
        public async void GetPaymentGateway_ExistingGateway_ReturnsGateway()
        { 
            var mockGateway = new Mock<IPaymentGateway>();
            mockGateway.Setup(g => g.GatewayId).Returns("stripe");

            var factory = new PaymentGateways(new[] { mockGateway.Object });
             
            var gateway = await factory.GetPaymentGateway("stripe");
             
            Assert.NotNull(gateway);
            Assert.Equal("stripe", gateway.GatewayId);
        }

        [Fact]
        public async void GetPaymentGateway_NonExistingGateway_ThrowsException()
        { 
            var factory = new PaymentGateways(Array.Empty<IPaymentGateway>());
             
            await Assert.ThrowsAsync<ArgumentException>(async () => await factory.GetPaymentGateway("n/a"));
        }
    }
}
