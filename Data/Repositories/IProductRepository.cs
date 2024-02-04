// MIT Licensed.

namespace EcomCli.Data.Repositories
{
    using System.Collections.Generic;
    using EcomCli.Data.Entities;

    /// <summary>
    /// Provides data-access to products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the available products (in stock).
        /// </summary>
        /// <returns>A collection of <see cref="Product"/>.</returns>
        IReadOnlyCollection<Product> GetAvailableProducts();

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="id">The identifier for the product to get.</param>
        /// <returns><see cref="Product"/>.</returns>
        Product GetProduct(int id);
    }
}