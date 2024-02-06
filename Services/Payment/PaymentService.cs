// MIT Licensed.

namespace EcomCli.Services.Payment
{
    using System;
    using EcomCli.Providers.Payment;
    using FluentValidation;

    /// <inheritdoc cref="IPaymentService"/>
    internal class PaymentService : IPaymentService
    {
        private readonly IValidator<PaymentRequest> paymentRequestValidator;
        private readonly IPaymentProvider paymentProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        /// <param name="paymentRequestValidator">Used to validate payment requests.</param>
        /// <param name="paymentProvider">Used to process payments.</param>
        public PaymentService(IValidator<PaymentRequest> paymentRequestValidator, IPaymentProvider paymentProvider)
        {
            this.paymentRequestValidator = paymentRequestValidator;
            this.paymentProvider = paymentProvider;
        }

        /// <inheritdoc/>
        public bool ProcessPayment(PaymentRequest request)
        {
            var validationResult = this.paymentRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid request");
            }

            return this.paymentProvider.ProcessPayment(request);
        }
    }
}
