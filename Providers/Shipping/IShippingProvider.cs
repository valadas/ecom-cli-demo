// MIT Licensed.

namespace EcomCli.Providers.Shipping
{
    /// <summary>
    /// Provides shipping facilities.
    /// </summary>
    public interface IShippingProvider
    {
        /// <summary>
        /// Gets the name of the shipping company.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Estimates the shipping cost for a given weight and distance.
        /// </summary>
        /// <param name="shippingWeight">The total shipment weight.</param>
        /// <param name="livesFar">A value indicating weither the customer lives far.</param>
        /// <returns>The estimated shipping cost.</returns>
        decimal EstimateShippingCost(decimal shippingWeight, bool livesFar);

        /// <summary>
        /// Creates the shipping label.
        /// </summary>
        void CreateShippingLabel();
    }
}
