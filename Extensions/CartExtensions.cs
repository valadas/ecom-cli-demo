// MIT Licensed.

namespace EcomCli.Extensions
{
    using EcomCli.Data.Repositories;
    using EcomCli.Services.Cart;
    using EcomCli.Services.Catalog;

    /// <summary>
    /// Extensions methods for <see cref="Cart"/>.
    /// </summary>
    public static class CartExtensions
    {
        /// <summary>
        /// Gets the total weight of all the products in the cart.
        /// </summary>
        /// <param name="cart">The cart to use to calculate the weight.</param>
        /// <param name="productRepository">The catalog service to get product information from.</param>
        /// <returns>The total weight of the products in the cart.</returns>
        public static decimal GetTotalWeight(this Cart cart, IProductRepository productRepository)
        {
            decimal totalWeight = 0;
            foreach (var productInfo in cart.Products)
            {
                var product = productRepository.GetProduct(productInfo.ProductId);
                totalWeight += product.Weigth * productInfo.Quantity;
            }

            return totalWeight;
        }
    }
}
