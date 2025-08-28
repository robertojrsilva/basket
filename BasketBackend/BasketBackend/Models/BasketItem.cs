namespace BasketBackend.Models
{
    /// <summary>
    /// Represents a basket item
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// Product on a basket
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// Quantity of Product
        /// </summary>
        public int Quantity { get; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;        
        }
    }
}
