using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// The base class for all resource lists
    /// </summary>
    public abstract class ResourceList<T> where T : ResourceBase
    {
        /// <summary>
        /// The total number of resources available from this API
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The URL for the next page in the list.
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The URL for the previous page in the list.
        /// </summary>
        public string Previous { get; set; }
    }

    /// <summary>
    /// The paging object for un-named resources
    /// </summary>
    /// <typeparam name="T">The type of the paged resource</typeparam>
    public class ApiResourceList<T> : ResourceList<T> where T : ApiResource
    {
        /// <summary>
        /// A list of un-named API resources.
        /// </summary>
        public List<ApiResource<T>> Results { get; set; }
    }

    /// <summary>
    /// The paging object for named resources
    /// </summary>
    /// <typeparam name="T">The type of the paged resource</typeparam>
    public class NamedApiResourceList<T> : ResourceList<T> where T : NamedApiResource
    {
        /// <summary>
        /// A list of named API resources.
        /// </summary>
        public List<NamedApiResource<T>> Results { get; set; }
    }
}
