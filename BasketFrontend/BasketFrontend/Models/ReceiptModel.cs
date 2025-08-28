namespace BasketFrontend.Models
{
    /// <summary>
    /// Represents a real life Receipt
    /// </summary>
    public class ReceiptModel
    {
        /// <summary>
        /// Itens of Receipt
        /// </summary>
        public List<BasketItemModel> Items { get; }

        /// <summary>
        /// Receipt subtotal, with the sum of all line itens values
        /// </summary>
        public decimal Subtotal { get; }

        /// <summary>
        /// All applicable discounts
        /// </summary>
        public List<DiscountModel> Discounts { get; }

        /// <summary>
        /// Receipt total, discounts included
        /// </summary>
        public decimal Total { get; }

        public ReceiptModel(List<BasketItemModel> items, decimal subtotal, decimal total, List<DiscountModel> discounts)
        {
            Items = items;
            Subtotal = subtotal;
            Total = total;
            Discounts = discounts;
        }
    }
}
