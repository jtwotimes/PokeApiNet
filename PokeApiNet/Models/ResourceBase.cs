namespace PokeApiNet.Models
{
    /// <summary>
    /// The base class for classes that have an API endpoint. These
    /// classes can also be cached with their id value.
    /// </summary>
    public abstract class ResourceBase
    {
        /// <summary>
        /// The identifier for this resource
        /// </summary>
        public abstract int Id { get; set; }

        /// <summary>
        /// The endpoint string for this resource
        /// </summary>
        public static string ApiEndpoint { get; }
    }
}
