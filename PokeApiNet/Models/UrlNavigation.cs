using PokeApiNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class UrlNavigation<T> where T : class, ICanBeCached
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Get the resource of a url navigation property
        /// </summary>
        /// <param name="client">The client object</param>
        /// <returns>The value of the navigation property</returns>
        public async Task<T> ResolveAsync(PokeApiClient client)
        {
            return await client.GetResourceByUrlAsync<T>(Url);
        }
    }
}
