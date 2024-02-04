// MIT Licensed.

namespace EcomCli.Services.Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data;
    using EcomCli.Data.Entities;

    /// <summary>
    /// Provides services related to the product catalog.
    /// </summary>
    internal class CatalogService
    {
        /// <summary>
        /// Gets all the products.
        /// </summary>
        /// <returns>A collection of <see cref="ProductInfo"/>.</returns>
        public IReadOnlyCollection<ProductInfo> GetAllProducts()
        {
            using (var dataContext = new EcomContext())
            {
                dataContext.Database.EnsureCreated();
                return dataContext.Products
                    .Where(p => p.StockQuanitty > 0)
                    .OrderBy(p => p.Id)
                    .Select(p => new ProductInfo
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                    }).ToList();
            }
        }

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns><see cref="Product"/>.</returns>
        public Product GetProduct(int productId)
        {
            using (var datacontext = new EcomContext())
            {
                datacontext.Database.EnsureCreated();
                return datacontext.Products
                    .Where(p => p.Id == productId)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="productId">The product identifier of the product to get.</param>
        /// <returns><see cref="ProductInfo"/>.</returns>
        public ProductInfo GetProductInfo(int productId)
        {
            using (var dataContext = new EcomContext())
            {
                dataContext.Database.EnsureCreated();
                return dataContext.Products
                    .Where(p => p.Id == productId)
                    .Select(p => new ProductInfo
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                    }).FirstOrDefault();
            }
        }
    }
}
