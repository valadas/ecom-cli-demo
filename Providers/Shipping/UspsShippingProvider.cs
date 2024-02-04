// MIT Licensed.

namespace EcomCli.Providers.Shipping
{
    using System;

    /// <summary>
    /// Provides shipping features for USPS.
    /// </summary>
    internal class UspsShippingProvider : IShippingProvider
    {
        private const decimal BaseCost = 5.00m;
        private const decimal PerPoundCost = 0.5m;
        private const decimal FuelSurcharge = 1.1m;

        /// <inheritdoc/>
        public string Name => "USPS";

        /// <inheritdoc/>
        public void CreateShippingLabel()
        {
            Console.WriteLine("USPS Label printed.");
        }

        /// <inheritdoc/>
        public decimal EstimateShippingCost(decimal shippingWeight, bool livesFar)
        {
            var totalCost = BaseCost;
            totalCost += shippingWeight * PerPoundCost;
            if (livesFar)
            {
                totalCost *= FuelSurcharge;
            }

            return totalCost;
        }
    }
}
