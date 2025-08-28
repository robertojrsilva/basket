namespace BasketBackend.Services.Data
{
    /// <summary>
    /// Service for receipt manipulation - Get and Save
    /// </summary>
    public class ReceiptService : DataService
    {
        private readonly ILogger<ReceiptService> _logger;

        public ReceiptService(ILogger<ReceiptService> logger) : base(logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public override string GetData(string entity = "Receipt")
        {
            return base.GetData(entity);
        }

        /// <inheritdoc/>
        public override bool SaveData(object obj, string entity = "Receipt")
        {
            return base.SaveData(obj, entity);
        }
    }
}
