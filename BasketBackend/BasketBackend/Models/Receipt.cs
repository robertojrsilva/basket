using BasketBackend.Services.Discounts;

namespace BasketBackend.Models
{
    /// <summary>
    /// Represents a real life Receipt
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Itens of Receipt
        /// </summary>
        public List<BasketItem> Items { get; }

        /// <summary>
        /// Receipt subtotal, with the sum of all line itens values
        /// </summary>
        public decimal Subtotal { get; }

        /// <summary>
        /// All applicable discounts
        /// </summary>
        public List<Discount> Discounts { get; }

        /// <summary>
        /// Receipt total, discounts included
        /// </summary>
        public decimal Total { get; }

        public Receipt(List<BasketItem> items, decimal subtotal, decimal total, List<Discount> discounts)
        {
            Items = items;
            Subtotal = subtotal;
            Total = total;
            Discounts = discounts;
        }
    }
}
