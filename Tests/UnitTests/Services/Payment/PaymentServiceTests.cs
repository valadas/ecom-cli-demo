using Xunit;
using EcomCli.Services.Payment;
using FluentValidation;
using NSubstitute;
using FluentValidation.Results;
using System;
using EcomCli.Providers.Payment;
namespace UnitTests.Services.Payment
{
    public class PaymentServiceTests
    {
        private readonly IPaymentService paymentService;
        private readonly IValidator<PaymentRequest> paymentRequestValidator;
        private readonly IPaymentProvider paymentProvider;

        public PaymentServiceTests()
        {
            this.paymentRequestValidator = Substitute.For<IValidator<PaymentRequest>>();
            this.paymentProvider = Substitute.For<IPaymentProvider>();
            this.paymentService = new PaymentService(
                paymentRequestValidator,
                paymentProvider);
        }

        [Fact]
        public void PaymentService_ProcessPayment_ValidatesCreditCard()
        {
            // Arrange
            var request = new PaymentRequest(123.45m, "1234123412341234");
            this.paymentRequestValidator.Validate(request)
                .Returns(new ValidationResult());

            // Act
            this.paymentService.ProcessPayment(request);

            // Assert
            this.paymentRequestValidator.Received().Validate(request);
        }

        [Fact]
        public void InvalidPaymentRequest_ThrowsException()
        {
            // Arrange
            var request = new PaymentRequest(123.45m, "1234123412341234");
            this.paymentRequestValidator
                .Validate(request)
                .Returns(new ValidationResult(new[] { new ValidationFailure("CreditCard", "Invalid credit card number.") }));

            // Act
            var ex = Assert.Throws<ArgumentException>(() => this.paymentService.ProcessPayment(request));

            // Assert
            Assert.NotEmpty(ex.Message);
        }

        [Fact]
        public void ValidPaymentRequest_ProcessesPayment()
        {
            // Arrange
            var request = new PaymentRequest(123.45m, "1234123412341234");
            this.paymentRequestValidator
                .Validate(request)
                .Returns(new ValidationResult());

            // Act
            this.paymentService.ProcessPayment(request);

            // Assert
            this.paymentProvider.Received().ProcessPayment(request);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void ProcessPayment_ReturnsResult(bool providerResponse, bool expectedResponse)
        {
            // Arrange
            var request = new PaymentRequest(123.45m, "1234123412341234");
            this.paymentRequestValidator
                .Validate(request)
                .Returns(new ValidationResult());
            this.paymentProvider
                .ProcessPayment(request)
                .Returns(providerResponse);
            
            // Act
            var result = this.paymentService.ProcessPayment(request);
            
            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
