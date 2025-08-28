using BasketBackend.Models;

namespace BasketBackend.Services.Discounts
{
    /// <summary>
    /// SoupBread Discount actions
    /// </summary>
    public class SoupBreadDiscount : IApplyDiscount
    {
        private readonly ILogger<SoupBreadDiscount> _logger;

        public SoupBreadDiscount()
        {

        }

        public SoupBreadDiscount(ILogger<SoupBreadDiscount> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Apply discount method for soup and break
        /// </summary>
        /// <returns>A discount</returns>
        /// 
        public Discount ApplyDiscount(List<BasketItem> items)
        {
            Discount discount = new Discount(0, "No discount");

            try
            {
                if (items != null && items.Count > 0)
                {
                    var soupItem = items.FirstOrDefault(i => i.Product.Name == "Soup");
                    var breadItem = items.FirstOrDefault(i => i.Product.Name == "Bread");
                    if (soupItem != null && breadItem != null)
                    {
                        int eligibleDiscounts = soupItem.Quantity / 2;
                        // if you get less breads than discounts, then min between both
                        int discountedBreads = Math.Min(eligibleDiscounts, breadItem.Quantity);

                        decimal value = discountedBreads * breadItem.Product.Price * 0.50m;
                        string description = $"Buy 2 tins of soup and get a loaf of bread for half price: -{value:F2} {breadItem.Product.Currency}";
                        discount = new Discount(value, description);
                        return discount;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to apply soup bread discount!");
            }
            return discount;
        }
    }
}
