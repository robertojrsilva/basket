namespace BasketBackend.Models
{
    /// <summary>
    /// Represents an applicable discount
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Value of discount
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// Discount description
        /// </summary>
        public string Description { get; }

        public Discount(decimal value, string description)
        {
            Value = value; 
            Description = description;
        }
    }
}
