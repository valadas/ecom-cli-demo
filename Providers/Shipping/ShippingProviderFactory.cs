// MIT Licensed.

namespace EcomCli.Providers.Shipping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Repositories;
    using EcomCli.Extensions;
    using EcomCli.Services.Cart;
    using EcomCli.Services.Catalog;

    /// <inheritdoc cref="IShippingProviderFactory"/>
    internal class ShippingProviderFactory : IShippingProviderFactory
    {
        private readonly IEnumerable<IShippingProvider> shippingProviders;
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingProviderFactory"/> class.
        /// </summary>
        /// <param name="shippingProviders">The shipping providers registered in the system.</param>
        /// <param name="productRepository">The product repository to use.</param>
        public ShippingProviderFactory(
            IEnumerable<IShippingProvider> shippingProviders,
            IProductRepository productRepository)
        {
            this.shippingProviders = shippingProviders;
            this.productRepository = productRepository;
        }

        /// <inheritdoc/>
        public IShippingProvider SelectCheapestShippingProvider(Cart cart)
        {
            List<(decimal cost, IShippingProvider provider)> providers = this.shippingProviders
                .Select(sp => (sp.EstimateShippingCost(cart.GetTotalWeight(this.productRepository), cart.LivesFar), sp))
                .ToList();
            foreach (var provider in providers)
            {
                Console.WriteLine($"{provider.provider.Name}: {provider.cost:C}");
            }

            var cheapest = providers.OrderBy(p => p.cost).First();

            return cheapest.provider;
        }
    }
}
