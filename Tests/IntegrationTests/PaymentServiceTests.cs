namespace IntegrationTests
{
    using EcomCli;
    using EcomCli.Providers.Payment;
    using EcomCli.Services.Payment;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using NSubstitute;
    using System;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using Xunit;

    public class PaymentServiceTests
    {
        private readonly IPaymentService paymentService;
        private readonly IPaymentProvider paymentProvider;

        public PaymentServiceTests()
        {
            var services = new ServiceCollection();
            Startup.ConfigureServices(services);
            
            services.RemoveAll<IPaymentProvider>();
            this.paymentProvider = Substitute.For<IPaymentProvider>();
            services.AddSingleton<IPaymentProvider>(sp => this.paymentProvider);
            
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                this.paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
            }
        }

        [Fact]
        public void Refuses_NegativeAmounts()
        {
            // Arrange
            var request = new PaymentRequest(-1, "4111-1111-1111-1111");

            // Act
            var ex = Assert.Throws<ArgumentException>(() => this.paymentService.ProcessPayment(request));

            // Assert
            Assert.Equal("Invalid request", ex.Message);
        }

        [Fact]
        public void Refuses_BadCardNumber()
        {
            // Arrange
            var request = new PaymentRequest(1, "4111-1111-1111-1112");

            // Act
            var ex = Assert.Throws<ArgumentException>(() => this.paymentService.ProcessPayment(request));

            // Assert
            Assert.Equal("Invalid request", ex.Message);
        }

        [Fact]
        public void ValidRequest_Refused()
        {
            // Arrange
            var request = new PaymentRequest(1, "4111-1111-1111-1111");
            this.paymentProvider.ProcessPayment(request).Returns(false);

            // Act
            var result = this.paymentService.ProcessPayment(request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidRequest_Accepted()
        {
            // Arrange
            var request = new PaymentRequest(1, "4111-1111-1111-1111");
            this.paymentProvider.ProcessPayment(request).Returns(true);

            // Act
            var result = this.paymentService.ProcessPayment(request);
            // Assert
            Assert.True(result);
        }
    }
}
