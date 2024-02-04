// MIT Licensed.

namespace EcomCli.Services.Catalog
{
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Entities;
    using EcomCli.Data.Repositories;

    /// <inheritdoc cref="ICatalogService"/>
    internal class CatalogService : ICatalogService
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public Product GetProduct(int productId)
        {
            return this.productRepository.GetProduct(productId);
        }

        /// <inheritdoc/>
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
