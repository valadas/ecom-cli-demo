// MIT Licensed.

namespace EcomCli.Services.Payment
{
    using FluentValidation;

    /// <summary>
    /// Validates <see cref="PaymentRequest"/>.
    /// </summary>
    internal class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequestValidator"/> class.
        /// </summary>
        public PaymentRequestValidator()
        {
            this.RuleFor(x => x.Amount)
                .GreaterThan(0);
            this.RuleFor(x => x.CreditCard)
                .NotEmpty()
                .CreditCard();
        }
    }
}
