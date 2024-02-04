// MIT Licensed.

namespace EcomCli.Providers.Shipping
{
    using EcomCli.Services.Cart;

    /// <summary>
    /// Selects a shipping method.
    /// </summary>
    internal interface IShippingProviderFactory
    {
        /// <summary>
        /// Selects the cheapest shipping provider based on cart conditions.
        /// </summary>
        /// <param name="cart">The cart to base the decision on.</param>
        /// <returns>An instance of an <see cref="IShippingProvider"/>.</returns>
        IShippingProvider SelectCheapestShippingProvider(Cart cart);
    }
}
