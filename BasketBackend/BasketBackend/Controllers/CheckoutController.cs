using BasketBackend.Models;
using BasketBackend.Services.Basket;
using BasketBackend.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BasketBackend.Controllers
{
    /// <summary>
    /// Checkout controller
    /// </summary>
    
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ICheckoutService _checkoutService;
        private readonly ReceiptService _receiptService;

        public CheckoutController(ILogger<CheckoutController> logger, ICheckoutService checkoutService, ReceiptService receiptService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _receiptService = receiptService;
        }

        /// <summary>
        /// Show the checkout receipt
        /// </summary>
        /// <returns>Receipt object.</returns>
        [HttpPost(Name = "PrintReceipt")]
        public Receipt PrintReceipt(List<BasketItem> itens)
        {
            Receipt receipt = null;

            try
            {
                receipt = _checkoutService.PrintReceipt(itens);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to print receipt!");
            }
            return receipt;
        }

        /// <summary>
        /// Get all saved receipts
        /// </summary>
        /// <returns>All saved receipts, otherwise nothing.</returns>
        [HttpGet(Name = "GetReceipt")]
        public IEnumerable<Receipt> Get()
        {
            try
            {
                string readContents = _receiptService.GetData();

                if (!string.IsNullOrEmpty(readContents))
                {
                    List<Receipt> receipts = JsonSerializer.Deserialize<List<Receipt>>(readContents);
                    return receipts;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to obtain receipts!");
            }
            return Enumerable.Empty<Receipt>();
        }
    }
}
