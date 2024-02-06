using EcomCli.Services.Payment;
using FluentValidation;
using Xunit;

namespace UnitTests.Services.Payment
{
    public class PaymentRequestValidatorTests
    {
        private readonly IValidator<PaymentRequest> validator;

        public PaymentRequestValidatorTests()
        {
            this.validator = new PaymentRequestValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1000)]
        [InlineData(-0.01)]
        [InlineData(-0.00001)]
        public void RequiresPositiveAmount(decimal amount)
        {
            // Arrange
            var request = new PaymentRequest(amount, "1234123412341234");

            // Act
            var result = this.validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.PropertyName == "Amount");
        }

        [Theory]
        [InlineData("1234123412341234")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234")]
        [InlineData(" ")]
        [InlineData("abc")]
        public void Refuses_Invalid_CreditCard(string creditCard)
        {
            // Arrange
            var request = new PaymentRequest(123.45m, creditCard);

            // Act
            var result = this.validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.PropertyName == "CreditCard");
        }

        [Theory]
        [InlineData(1.23, "4111111111111111")] // Visa valid test card
        [InlineData(2.34, "4111-1111-1111-1111")] // Should work with dashes too
        [InlineData(3.45, "4111 1111 1111 1111")] // Spaces should work too
        [InlineData(123.00, "5555555555554444")] // MasterCard valid test card
        [InlineData(1999.99, "378282246310005")] // American Express valid test card
        public void ValidPayment_PassesValidation(decimal amount, string creditCard)
        {
            // Arrange
            var request = new PaymentRequest(amount, creditCard);

            // Act
            var result = this.validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
