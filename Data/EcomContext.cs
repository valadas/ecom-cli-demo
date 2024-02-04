// MIT Licensed.

namespace EcomCli.Data
{
    using EcomCli.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc <see cref="IEcomContext" />./>
    internal class EcomContext : DbContext, IEcomContext
    {
        /// <inheritdoc/>
        public DbSet<Product> Products { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EcomCli");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Widget", Price = 10.00m, StockQuanitty = 100, Weigth = 1.0m },
                    new Product { Id = 2, Name = "Gadget", Price = 20.00m, StockQuanitty = 50, Weigth = 2.0m },
                    new Product { Id = 3, Name = "Gizmo", Price = 30.00m, StockQuanitty = 25, Weigth = 3.0m });
        }
    }
}
