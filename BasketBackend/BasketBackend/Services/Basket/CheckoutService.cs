using BasketBackend.Models;
using BasketBackend.Services.Data;
using BasketBackend.Services.Discounts;

namespace BasketBackend.Services.Basket
{
    /// <summary>
    /// Checkout service actions
    /// </summary>
    public class CheckoutService : ICheckoutService
    {

        /// <summary>
        /// Applicable discounts = apple discount + soup/bread
        /// This should be configured in a different way...
        /// </summary>
        public readonly List<IApplyDiscount> _discounts = 
            new List<IApplyDiscount>
            {
                new AppleDiscount(),
                new SoupBreadDiscount()
            };

        private readonly ILogger<CheckoutService> _logger;
        private readonly ReceiptService _receiptService;

        public CheckoutService() { }

        public CheckoutService(ILogger<CheckoutService> logger, ReceiptService receiptService)
        {
            _logger = logger;
            _receiptService = receiptService;
        }

        /// <summary>
        /// Print Receipt of a basket items
        /// </summary>
        /// <returns>A receipt</returns>
        public Receipt PrintReceipt(List<BasketItem> basket)
        {
            Receipt receipt = null;
            try
            {
                // subtotal
                decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);

                // discounts
                decimal totalDiscount = 0;
                List<Discount> discountList = new List<Discount>();

                foreach (var rule in _discounts)
                {
                    var discount = rule.ApplyDiscount(basket);
                    totalDiscount += discount.Value;
                    discountList.Add(discount);
                }

                // total
                decimal total = subtotal - totalDiscount;

                receipt = new Receipt(basket, subtotal, total, discountList);

                // save receipt, but remove the lines with 0 quantity and 0 discounts
                Receipt newReceipt = new Receipt(receipt.Items.Where(f => f.Quantity != 0).ToList(), subtotal, total, discountList.Where(f => f.Value != 0).ToList());
                if (_receiptService != null) _receiptService.SaveData(newReceipt, "Receipt");
            }
            catch (Exception ex)
            {
                receipt = null;
                _logger.LogError(ex, "Failed to print receipt!");
            }

            return receipt;
        }
    }
}
