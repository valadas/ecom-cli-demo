// MIT Licensed.

namespace EcomCli.Data.Entities
{
    /// <summary>
    /// Represents a single product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets how many of this product is in stock.
        /// </summary>
        public int StockQuanitty { get; set; }

        /// <summary>
        /// Gets or sets the weigth.
        /// </summary>
        public decimal Weigth { get; set; }
    }
}
