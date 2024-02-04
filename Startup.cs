// MIT Licensed.

namespace EcomCli
{
    using EcomCli.Data;
    using EcomCli.Data.Repositories;
    using EcomCli.Providers.Shipping;
    using EcomCli.Services.Cart;
    using EcomCli.Services.Catalog;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Fires upon application startup.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Configures the services that will be used for dependency injextion.
        /// </summary>
        /// <param name="services">The services to add to.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IEcomContext>(serviceProvider =>
            {
                var context = new EcomContext();
                context.Database.EnsureCreated();
                return context;
            });
            services.AddScoped<IShippingProvider, UpsShippingProvider>();
            services.AddScoped<IShippingProvider, UspsShippingProvider>();
            services.AddScoped<IShippingProviderFactory, ShippingProviderFactory>();
        }
    }
}
