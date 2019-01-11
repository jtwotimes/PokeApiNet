namespace PokeApi.Net.Models
{
    /// <summary>
    /// Base class for all classes that are "getable" via the PokeAPI
    /// </summary>
    public abstract class Resource
    {
        /// <summary>
        /// Api endpoint string for the resource
        /// </summary>
        public abstract string ApiEndpoint { get; }
    }
}
