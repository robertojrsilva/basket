using BasketFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BasketFrontend.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ILogger<HistoryModel> _logger;
        private readonly HttpClient _httpClient;

        [BindProperty]
        public List<ReceiptModel> receipts { get; set; } = new ();

        public HistoryModel(ILogger<HistoryModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public void OnGet()
        {
            receipts = GetReceipts().GetAwaiter().GetResult();
        }

        public async Task<List<ReceiptModel>> GetReceipts()
        {
            try
            {
                List<ReceiptModel> receiptList = await _httpClient.GetFromJsonAsync<List<ReceiptModel>>("checkout");
                return receiptList;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to obtain receipts!");
            }
            return Enumerable.Empty<ReceiptModel>().ToList();
        }
    }

}
