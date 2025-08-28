using BasketBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketBackend.Controllers
{
    /// <summary>
    /// Customer Controller
    /// </summary>
    
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>A enumerable of customer.</returns>
        [HttpGet(Name = "GetCustomer")]
        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }
    }
}
