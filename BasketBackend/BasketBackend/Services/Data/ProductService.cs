namespace BasketBackend.Services.Data
{
    /// <summary>
    /// Service for product manipulation - Get and Save
    /// </summary>
    public class ProductService : DataService
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger) : base(logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public override string GetData(string entity = "Product")
        {
            return base.GetData(entity);
        }

        /// <inheritdoc/>
        public override bool SaveData(object obj, string entity = "Product")
        {
            return base.SaveData(obj, entity);
        }
    }
}
