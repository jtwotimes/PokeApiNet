namespace PokeApiNet
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

        /// <summary>
        /// Is endpoint case sensitive
        /// </summary>
        public static bool IsApiEndpointCaseSensitive { get; }
    }

    /// <summary>
    /// The base class for API resources that have a name property
    /// </summary>
    public abstract class NamedApiResource : ResourceBase
    {
        /// <summary>
        /// The name of this resource
        /// </summary>
        public abstract string Name { get; set; }
    }

    /// <summary>
    /// The base class for API resources that don't have a name property
    /// </summary>
    public abstract class ApiResource : ResourceBase { }
}
