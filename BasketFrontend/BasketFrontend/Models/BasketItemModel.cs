namespace BasketFrontend.Models
{
    /// <summary>
    /// Represents a basket item
    /// </summary>
    public class BasketItemModel
    {
        /// <summary>
        /// Product on a basket
        /// </summary>
        public ProductModel Product { get; set; } = new ProductModel();

        /// <summary>
        /// Quantity of Product
        /// </summary>
        public int Quantity { get; set; }

        public BasketItemModel()
        {
            Product = new ProductModel();
        }

        
    }
}
