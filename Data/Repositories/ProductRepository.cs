// MIT Licensed.

namespace EcomCli.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Entities;

    /// <inheritdoc cref="IProductRepository"/>
    internal class ProductRepository : IProductRepository
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
