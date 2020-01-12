namespace PokeApiNet
{
    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class UrlNavigation<T> where T : ResourceBase
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}
