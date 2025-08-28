using BasketBackend.Models;

namespace BasketBackend.Services.Basket
{
    /// <summary>
    /// Checkout service actions
    /// </summary>
    
    public interface ICheckoutService
    {
        /// <summary>
        /// Print Receipt of a basket items
        /// </summary>
        /// <returns>A receipt</returns>
        
        public Receipt PrintReceipt(List<BasketItem> basket);
    }
}
