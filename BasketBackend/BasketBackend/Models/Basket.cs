namespace BasketBackend.Models
{
    /// <summary>
    /// Represents a basket
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// The id of basket
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The associated customer of basket
        /// </summary>
        public Customer Customer { get; set; } = new();

        /// <summary>
        /// Basket items
        /// </summary>
        public List<BasketItem> Items { get; set; } = new();

        public Basket() { }
    }
}
