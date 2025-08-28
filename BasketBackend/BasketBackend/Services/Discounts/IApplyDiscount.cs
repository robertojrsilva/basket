using BasketBackend.Models;

namespace BasketBackend.Services.Discounts
{
    /// <summary>
    /// Apply discount actions
    /// </summary>
    public interface IApplyDiscount
    {
        /// <summary>
        /// Apply discount method
        /// </summary>
        /// <returns>A discount</returns>
        Discount ApplyDiscount(List<BasketItem> items);
    }
}
