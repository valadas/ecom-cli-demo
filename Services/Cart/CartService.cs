// MIT Licensed.

namespace EcomCli.Services.Cart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Data.Repositories;
    using EcomCli.Providers.Shipping;

    /// <inheritdoc cref="ICartService"/>
    internal class CartService : ICartService
    {
        private readonly IProductRepository productRepository;
        private readonly IShippingProviderFactory shippingProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository to use.</param>
        /// <param name="shippingProviderFactory">The shipping provider factory.</param>
        public CartService(
            IProductRepository productRepository,
            IShippingProviderFactory shippingProviderFactory)
        {
            this.productRepository = productRepository;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        /// <inheritdoc/>
        public void AddProduct(Cart cart, int productId, int quantity)
        {
            var existing = cart.Products.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
                return;
            }

            var product = this.productRepository.GetProduct(productId);
            cart.Products.Add(new CartProduct
            {
                ProductId = productId,
                Quantity = quantity,
            });
        }

        /// <inheritdoc/>
        public void Checkout(Cart cart)
        {
            Console.WriteLine();
            Console.WriteLine("=== PROCESSING CHECKOUT ===");

            var totalProductPrice = 0m;
            foreach (var cartProduct in cart.Products)
            {
                var product = this.productRepository.GetProduct(cartProduct.ProductId);
                var productPrice = product.Price * cartProduct.Quantity;
                totalProductPrice += productPrice;
                Console.WriteLine($"{product.Name}: {cartProduct.Quantity} * {product.Price:C} = ${productPrice}");
            }

            Console.WriteLine($"Total product cost: {totalProductPrice}");

            var cheapestShippingProvider = this.shippingProviderFactory.SelectCheapestShippingProvider(cart);
            var totalWeight = 0m;
            foreach (var cartProduct in cart.Products)
            {
                var productData = this.productRepository.GetProduct(cartProduct.ProductId);
                totalWeight += productData.Weigth * cartProduct.Quantity;
            }

            Console.WriteLine($"Picked {cheapestShippingProvider.Name} at {cheapestShippingProvider.EstimateShippingCost(totalWeight, cart.LivesFar):C}");
            cheapestShippingProvider.CreateShippingLabel();
        }
    }
}
