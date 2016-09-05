namespace DomainClasses
{
    /// <summary>
    /// A Address model
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets Pin code.
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public int UserId { get; set; }
    }
}
