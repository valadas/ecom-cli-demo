// MIT Licensed.

namespace EcomCli.Services.Cart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EcomCli.Providers.Shipping;
    using EcomCli.Services.Catalog;

    /// <summary>
    /// Provides services related to the shopping cart.
    /// </summary>
    internal class CartService
    {
        private readonly CatalogService catalogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        public CartService()
        {
            this.catalogService = new CatalogService();
        }

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="cart">The cart to add to.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity to add.</param>
        public void AddProduct(Cart cart, int productId, int quantity)
        {
            var existing = cart.Products.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
                return;
            }

            var product = this.catalogService.GetProductInfo(productId);
            cart.Products.Add(new CartProduct
            {
                ProductId = productId,
                Quantity = quantity,
            });
        }

        /// <summary>
        /// Checkouts the specified cart.
        /// </summary>
        /// <param name="cart">The cart to checkout.</param>
        public void Checkout(Cart cart)
        {
            Console.WriteLine();
            Console.WriteLine("=== PROCESSING CHECKOUT ===");

            var totalProductPrice = 0m;
            foreach (var product in cart.Products)
            {
                var productData = this.catalogService.GetProductInfo(product.ProductId);
                var productPrice = productData.Price * product.Quantity;
                totalProductPrice += productPrice;
                Console.WriteLine($"{productData.Name}: {product.Quantity} * {productData.Price:C} = ${productPrice}");
            }

            Console.WriteLine($"Total product cost: {totalProductPrice}");

            var totalWeight = 0m;
            foreach (var product in cart.Products)
            {
                var productData = this.catalogService.GetProduct(product.ProductId);
                totalWeight += productData.Weigth * product.Quantity;
            }

            // Get all the shipping providers through reflection.
            var shippingProviders = typeof(IShippingProvider).Assembly.GetTypes()
                .Where(t => typeof(IShippingProvider).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (IShippingProvider)Activator.CreateInstance(t))
                .ToList();
            List<(decimal cost, IShippingProvider provider)> providers = shippingProviders
                .Select(sp => (sp.EstimateShippingCost(totalWeight, cart.LivesFar), sp))
                .ToList();
            foreach (var provider in providers)
            {
                Console.WriteLine($"{provider.provider.Name}: {provider.cost:C}");
            }

            var cheapest = providers.OrderBy(p => p.cost).First();
            Console.WriteLine($"Picked {cheapest.provider.Name} at {cheapest.cost:C}");
            cheapest.provider.CreateShippingLabel();
        }
    }
}
