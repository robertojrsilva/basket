namespace BasketBackend.Models
{
    /// <summary>
    /// Represents a real life Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Customer email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Customer password
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Customer Vat
        /// </summary>
        public string Vat { get; }

        /// <summary>
        /// Customer billing address
        /// </summary>
        public Address BillingAddress { get; }

        /// <summary>
        /// Customer shipping address
        /// </summary>
        public Address ShippingAddress { get; }

        public Customer() { }

        public Customer(string name, string email, string password, string vat, Address billingAddress, Address shippingAddress)
        {
            Name = name;
            Email = email;
            Password = password;
            Vat = vat;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
        }
    }
}
