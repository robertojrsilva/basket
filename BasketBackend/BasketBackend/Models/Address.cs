namespace BasketBackend.Models
{
    /// <summary>
    /// Represents an address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Name of address
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// PostalCode of address
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// City of address
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Country of address
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Phone of address
        /// </summary>
        public string Phone { get; }

        public Address(string name, string postalCode, string city, string country, string phone)
        {
            Name = name;
            PostalCode = postalCode;
            City = city;
            Country = country;
            Phone = phone;
        }
    }
}
