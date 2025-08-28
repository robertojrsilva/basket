namespace BasketBackend.Models
{
    /// <summary>
    /// Represents a real life Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Price of Product
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Currency of Price
        /// </summary>
        public string Currency { get; }

        /// <summary>
        /// Create an instance of Product
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <param name="price">Product Price</param>
        /// <param name="currency">Price Currency</param>

        public Product(string name, decimal price, string currency)
        {
            Name = name;
            Price = price;
            Currency = currency;
        }
    }
}
