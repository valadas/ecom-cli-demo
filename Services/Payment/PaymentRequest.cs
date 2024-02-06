// MIT Licensed.

namespace EcomCli.Services.Payment
{
    /// <summary>
    /// The details about a payment request.
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequest"/> class.
        /// </summary>
        /// <param name="amount">The amount to charge.</param>
        /// <param name="creditCard">The credit card number to charge.</param>
        public PaymentRequest(decimal amount, string creditCard)
        {
            this.Amount = amount;
            this.CreditCard = creditCard;
        }

        /// <summary>
        /// Gets or sets the amount to charge.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        public string CreditCard { get; set; }
    }
}