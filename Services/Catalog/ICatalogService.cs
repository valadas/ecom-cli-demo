// MIT Licensed.

namespace EcomCli.Services.Catalog
{
    using System.Collections.Generic;
    using EcomCli.Data.Entities;

    /// <summary>
    /// Provides services related to the product catalog.
    /// </summary>
    internal interface ICatalogService
    {
        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>A collection of <see cref="ProductInfo"/>.</returns>
        IReadOnlyCollection<ProductInfo> GetAllProducts();

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns><see cref="Product"/>.</returns>
        Product GetProduct(int productId);

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier of the product to get.</param>
        /// <returns><see cref="ProductInfo"/>.</returns>
        ProductInfo GetProductInfo(int productId);
    }
}