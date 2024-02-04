// MIT Licensed.

namespace EcomCli.Services.Catalog
{
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Entities;
    using EcomCli.Data.Repositories;

    /// <summary>
    /// Provides services related to the product catalog.
    /// </summary>
    internal class CatalogService
    {
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to use.</param>
        public CatalogService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>A collection of <see cref="ProductInfo"/>.</returns>
        public IReadOnlyCollection<ProductInfo> GetAllProducts()
        {
            var availableProducts = this.productRepository.GetAvailableProducts();
            return availableProducts.Select(p => new ProductInfo
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            }).ToList();
        }

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns><see cref="Product"/>.</returns>
        public Product GetProduct(int productId)
        {
            return this.productRepository.GetProduct(productId);
        }

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier of the product to get.</param>
        /// <returns><see cref="ProductInfo"/>.</returns>
        public ProductInfo GetProductInfo(int productId)
        {
            var product = this.GetProduct(productId);
            return new ProductInfo
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}
