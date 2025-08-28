using BasketBackend.Models;

namespace BasketBackend.Services.Discounts
{
    /// <summary>
    /// Apple Discount actions
    /// </summary>
    public class AppleDiscount : IApplyDiscount
    {
        private readonly ILogger<AppleDiscount> _logger;

        public AppleDiscount()
        {

        }

        public AppleDiscount(ILogger<AppleDiscount> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Apply discount method for apple
        /// </summary>
        /// <returns>A discount</returns>

        public Discount ApplyDiscount(List<BasketItem> items)
        {
            Discount discount = new Discount(0, "No discount");

            try
            {
                if (items != null && items.Count > 0)
                {
                    BasketItem appleItem = items.FirstOrDefault(i => i.Product.Name == "Apples");
                    if (appleItem != null)
                    {
                        decimal value = appleItem.Quantity * appleItem.Product.Price * 0.10m;
                        string description = $"Apples 10% off their normal price this week.: -{value:F2} {appleItem.Product.Currency}";
                        discount = new Discount(value, description);
                        return discount;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to apply apple discount!");
            }
            return discount;
        }
    }
}
