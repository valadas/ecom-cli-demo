// MIT Licensed.

namespace EcomCli.Services.Cart
{
    using System.Collections.Generic;

    /// <summary>
    /// Data required to process a shopping cart.
    /// </summary>
    internal class Cart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        public Cart()
        {
            this.Products = new List<CartProduct>();
        }

        /// <summary>
        /// Gets or sets the products n the cart.
        /// </summary>
        public List<CartProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer lives far.
        /// </summary>
        public bool LivesFar { get; set; }
    }
}
