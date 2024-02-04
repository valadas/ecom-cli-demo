// MIT Licensed.

namespace EcomCli
{
    using System;
    using System.Runtime.CompilerServices;
    using EcomCli.Services.Cart;
    using EcomCli.Services.Catalog;

    /// <summary>
    /// The main program entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments optionally passed in the cli command.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE FIRST EVER CLI ECOMMERCE");
            Console.WriteLine();
            Console.WriteLine("Please choose a product");

            var catalogService = new CatalogService();
            var prodcuts = catalogService.GetAllProducts();

            foreach (var product in prodcuts)
            {
                Console.WriteLine($"{product.Id}: {product.Name} - {product.Price:C}");
            }

            int selectedProductId = AskForOption();

            Console.WriteLine("How many would you like to buy?");
            var quantity = AskForAmount();

            var cart = new Cart();
            var cartService = new CartService();
            cartService.AddProduct(cart, selectedProductId, quantity);

            Console.WriteLine("Do you live far ?");
            var far = GetBooleanInput();
            cart.LivesFar = far;

            cartService.Checkout(cart);

            Console.ReadLine();
        }

        private static int AskForOption()
        {
            var keyinfo = Console.ReadKey();
            Console.WriteLine();

            if (int.TryParse(keyinfo.KeyChar.ToString(), out int selectedOption))
            {
                return selectedOption;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again");
                return AskForOption();
            }
        }

        private static int AskForAmount()
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int quantity))
            {
                return quantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity, please try again");
                return AskForAmount();
            }
        }

        private static bool GetBooleanInput()
        {
            Console.Write("Y/N: ");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again");
                return GetBooleanInput();
            }
        }
    }
}
