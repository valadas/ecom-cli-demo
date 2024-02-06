// MIT Licensed.

namespace EcomCli.Providers.Payment
{
    using EcomCli.Services.Payment;

    /// <summary>
    /// A provider cappable of processing payments.
    /// </summary>
    public interface IPaymentProvider
    {
        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <returns>A value indicating whether the payment was successful.</returns>
        bool ProcessPayment(PaymentRequest request);
    }
}
