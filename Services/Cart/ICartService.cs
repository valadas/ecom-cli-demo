// MIT Licensed.

namespace EcomCli.Services.Cart
{
    /// <summary>
    /// Provides services related to the shopping cart.
    /// </summary>
    internal interface ICartService
    {
        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="cart">The cart to add to.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity to add.</param>
        void AddProduct(Cart cart, int productId, int quantity);

        /// <summary>
        /// Checkouts the specified cart.
        /// </summary>
        /// <param name="cart">The cart to checkout.</param>
        void Checkout(Cart cart);
    }
}