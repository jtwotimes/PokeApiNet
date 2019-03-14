using PokeApiNet.Data;
using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Container class for extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Resolves all navigation properties in a collection
        /// </summary>
        /// <typeparam name="T">Navigation type</typeparam>
        /// <param name="collection">The collection of navigation objects</param>
        /// <param name="client">PokeApiClient object to make requests</param>
        /// <returns>A list of resolved objects</returns>
        public static async Task<List<T>> ResolveAll<T>(this IEnumerable<UrlNavigation<T>> collection, PokeApiClient client)
            where T : class, ICanBeCached
        {
            return (await Task.WhenAll(collection.Select(m => m.ResolveAsync(client)))).ToList();
        }
    }
}
