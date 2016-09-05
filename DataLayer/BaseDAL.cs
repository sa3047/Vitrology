namespace DataLayer
{
    /// <summary>
    /// Base class for DAL classes
    /// </summary>
    public class BaseDAL
    {
        /// <summary>
        /// Gets or sets Connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets Store Procedure Name.
        /// </summary>
        public string StoreProcName { get; set; }
    }
}
