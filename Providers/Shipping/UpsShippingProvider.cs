// MIT Licensed.

namespace EcomCli.Providers.Shipping
{
    using System;

    /// <summary>
    /// Provides shipping features for UPS.
    /// </summary>
    internal class UpsShippingProvider : IShippingProvider
    {
        private const decimal BaseCost = 10.00m;
        private const decimal PerPoundCost = 0.25m;
        private const decimal FuelSurcharge = 1.05m;

        /// <inheritdoc/>
        public string Name => "UPS";

        /// <inheritdoc/>
        public void CreateShippingLabel()
        {
            Console.WriteLine("UPS Label printed.");
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
