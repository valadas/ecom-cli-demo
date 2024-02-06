// MIT Licensed.

namespace EcomCli.Services.Payment
{
    /// <summary>
    /// Provides payment related services.
    /// </summary>
    internal interface IPaymentService
    {
        /// <summary>
        /// Processes the payment.
        /// </summary>
        /// <param name="request">The details about the payment.</param>
        /// <returns>True if the payment succeeded, false otherwhise.</returns>
        bool ProcessPayment(PaymentRequest request);
    }
}
