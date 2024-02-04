// MIT Licensed.

namespace EcomCli.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Entities;

    /// <summary>
    /// Provides data-access to products.
    /// </summary>
    internal class ProductRepository
    {
        /// <summary>
        /// Gets the available products (in stock).
        /// </summary>
        /// <returns>A collection of <see cref="Product"/>.</returns>
        public IReadOnlyCollection<Product> GetAvailableProducts()
        {
            using (var dataContext = new EcomContext())
            {
                dataContext.Database.EnsureCreated();
                return dataContext.Products
                    .Where(p => p.StockQuanitty > 0)
                    .OrderBy(p => p.Id)
                    .ToList();
            }
        }

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="id">The identifier for the product to get.</param>
        /// <returns><see cref="Product"/>.</returns>
        public Product GetProduct(int id)
        {
            using (var dataContext = new EcomContext())
            {
                dataContext.Database.EnsureCreated();
                return dataContext.Products
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
