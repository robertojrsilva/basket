namespace BasketFrontend.Models
{
    /// <summary>
    /// Represents a real life Product
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of Product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Currency of Price
        /// </summary>
        public string Currency { get; set; }

        public ProductModel() { }

        
    }
}
