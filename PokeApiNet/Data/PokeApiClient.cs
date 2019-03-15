using Newtonsoft.Json;
using PokeApiNet.Directives;
using PokeApiNet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiNet.Data
{
    /// <summary>
    /// Gets data from the PokeAPI service
    /// </summary>
    public class PokeApiClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUri = new Uri("https://pokeapi.co/api/v2/");
        private readonly CacheManager _cacheManager = new CacheManager();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PokeApiClient()
        {
            _client = new HttpClient() { BaseAddress = _baseUri };
        }

        /// <summary>
        /// Constructor with message handler
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        public PokeApiClient(HttpMessageHandler messageHandler)
        {
            _client = new HttpClient(messageHandler) { BaseAddress = _baseUri };
        }

        /// <summary>
        /// Close resources
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        /// <summary>
        /// Send a request to the api and serialize the response into the specified type
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="apiParam">The name or id of the resource</param>
        /// <exception cref="HttpRequestException">Something went wrong with your request</exception>
        /// <returns>An instance of the specified type with data from the request</returns>
        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam) where T : ICanBeCached
        {
            // lowercase the resource name as the API doesn't recognize upper case and lower case as the same
            string sanitizedApiParam = apiParam.ToLowerInvariant();

            ApiEndpointAttribute attribute = typeof(T).GetCustomAttribute(typeof(ApiEndpointAttribute)) as ApiEndpointAttribute;
            string apiEndpoint = attribute.ApiEndpoint;
            HttpResponseMessage response = await _client.GetAsync($"{apiEndpoint}/{sanitizedApiParam}/");        // trailing slash is needed!

            response.EnsureSuccessStatusCode();

            string resp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resp);
        }

        /// <summary>
        /// Gets a resource from a navigation url; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="url">Navigation url</param>
        /// <exception cref="NotSupportedException">Navigation url doesn't contain the resource id</exception>
        /// <returns>The object of the resource</returns>
        internal async Task<T> GetResourceByUrlAsync<T>(string url) where T : class, ICanBeCached
        {
            // need to parse out the id in order to check if it's cached.
            // navigation urls always use the id of the resource
            string trimmedUrl = url.TrimEnd('/');
            string resourceId = trimmedUrl.Substring(trimmedUrl.LastIndexOf('/') + 1);

            if (!int.TryParse(resourceId, out int id))
            {
                // not sure what to do here...
                throw new NotSupportedException($"Navigation url '{url}' is in an unexpected format");
            }

            T resource = _cacheManager.Get<T>(id);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(resourceId);
                _cacheManager.Store<T>(resource);
            }

            return resource;
        }

        /// <summary>
        /// Gets a resource by id; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="id">Id of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(int id) where T : class, ICanBeCached
        {
            T resource = _cacheManager.Get<T>(id);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(id.ToString());
                _cacheManager.Store(resource);
            }

            return resource;
        }

        /// <summary>
        /// Gets a resource by name; resource is retrieved from cache if possible. This lookup
        /// is case insensitive.
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name) where T : class, ICanBeCached
        {
            string sanitizedName = name
                .Replace(" ", "-")      // no resource can have a space in the name; API uses -'s in their place
                .Replace("'", "")       // looking at you, Farfetch'd
                .Replace(".", "");      // looking at you, Mime Jr. and Mr. Mime

            // Nidoran is interesting as the API wants 'nidoran-f' or 'nidoran-m'

            T resource = _cacheManager.Get<T>(sanitizedName);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(sanitizedName);
                _cacheManager.Store(resource);
            }

            return resource;
        }

        /// <summary>
        /// Clears all cached data
        /// </summary>
        public void ClearCache()
        {
            _cacheManager.ClearAll();
        }

        /// <summary>
        /// Clears the cached data for a specific resource
        /// </summary>
        /// <typeparam name="T">The type of cache</typeparam>
        public void ClearCache<T>() where T : ICanBeCached
        {
            _cacheManager.Clear<T>();
        }
    }
}
