// MIT Licensed.

namespace EcomCli.Services.Catalog
{
    /// <summary>
    /// Represents basic information about a product.
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}