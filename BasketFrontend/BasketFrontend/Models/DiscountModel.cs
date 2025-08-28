namespace BasketFrontend.Models
{
    /// <summary>
    /// Represents an applicable discount
    /// </summary>
    public class DiscountModel
    {
        /// <summary>
        /// Value of discount
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// Discount description
        /// </summary>
        public string Description { get; }

        public DiscountModel(decimal value, string description)
        {
            Value = value;
            Description = description;
        }
    }
}
