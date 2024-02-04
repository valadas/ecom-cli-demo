// MIT Licensed.

namespace EcomCli.Data
{
    using EcomCli.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Data context for the EcomCli application.
    /// </summary>
    internal interface IEcomContext
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        DbSet<Product> Products { get; set; }
    }
}