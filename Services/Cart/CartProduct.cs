// MIT Licensed.

namespace EcomCli.Services.Cart
{
    /// <summary>
    /// Represents a product in the shoppint cart.
    /// </summary>
    public class CartProduct
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the given product in the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}