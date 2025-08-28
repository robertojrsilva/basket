using BasketFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BasketFrontend.Pages
{
    public class BasketModel : PageModel
    {
        private readonly ILogger<BasketModel> _logger;
        private readonly HttpClient _httpClient;

        public ReceiptModel receipt;

        [BindProperty]
        public List<BasketItemModel> basketItems { get; set; } = new ();

        public BasketModel(ILogger<BasketModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public void OnGet()
        {
            basketItems = GetProducts().GetAwaiter().GetResult();
        }

        public IActionResult OnPost()
        {
            try
            {
                /*List<BasketItemModel> itens = new List<BasketItemModel>();

                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    var quantity = quantities[i];
                    itens.Add(new BasketItemModel(product, quantity));
                }*/

                string json = JsonConvert.SerializeObject(basketItems);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = _httpClient.PostAsync("checkout", httpContent).ConfigureAwait(false).GetAwaiter().GetResult();
                receipt = responseMessage.Content.ReadFromJsonAsync<ReceiptModel>().Result;

                basketItems = receipt.Items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to obtain products!");
            }

            return Page();
        }

        public async Task<List<BasketItemModel>> GetProducts()
        {
            try
            {
                List<ProductModel> productList = await _httpClient.GetFromJsonAsync<List<ProductModel>>("product");
                List<BasketItemModel> basketItens = productList.Select(p => new BasketItemModel()
                {
                    Product = p,
                    Quantity = 0
                }).ToList();
                return basketItens;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to obtain products!");
            }
            return Enumerable.Empty<BasketItemModel>().ToList();
        }
    }

}
