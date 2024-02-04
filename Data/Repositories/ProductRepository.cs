// MIT Licensed.

namespace EcomCli.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Entities;

    /// <inheritdoc cref="IProductRepository"/>
    internal class ProductRepository : IProductRepository
    {
        private readonly IEcomContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dataContext">The underlying data context to use.</param>
        public ProductRepository(IEcomContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<Product> GetAvailableProducts()
        {
            return this.dataContext.Products
                .Where(p => p.StockQuanitty > 0)
                .OrderBy(p => p.Id)
                .ToList();
        }

        /// <inheritdoc/>
        public Product GetProduct(int id)
        {
            return this.dataContext.Products
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }
    }
}
