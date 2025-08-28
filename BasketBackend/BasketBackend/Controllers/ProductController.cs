using BasketBackend.Models;
using BasketBackend.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BasketBackend.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
   
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Get all saved products
        /// </summary>
        /// <returns>All saved products, otherwise nothing.</returns>
        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            try
            {
                string readContents = _productService.GetData();
                
                if (!string.IsNullOrEmpty(readContents))
                {
                    List<Product> products = JsonSerializer.Deserialize<List<Product>>(readContents);
                    return products;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Failed to obtain products!");
            }
            return Enumerable.Empty<Product>();
        }

        /// <summary>
        /// Save a product object
        /// </summary>
        /// <returns>Succeeded or not.</returns>
        [HttpPost(Name = "SaveProduct")]
        public IEnumerable<Product> Save(Product product)
        {
            try
            {
                bool result = _productService.SaveData(product);

                if (result)
                {
                    return Get();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to obtain products!");
            }
            return Enumerable.Empty<Product>();
        }
    }
}
