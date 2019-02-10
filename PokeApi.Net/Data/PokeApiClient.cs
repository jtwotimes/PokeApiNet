using Newtonsoft.Json;
using PokeApi.Net.Directives;
using PokeApi.Net.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Net.Data
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

        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam) where T : ICanBeCached
        {
            ApiEndpointAttribute attribute = typeof(T).GetCustomAttribute(typeof(ApiEndpointAttribute)) as ApiEndpointAttribute;
            string apiEndpoint = attribute.ApiEndpoint;
            HttpResponseMessage response = await _client.GetAsync($"{apiEndpoint}/{apiParam}/");        // trailing slash is needed!

            string resp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resp);
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
        /// Gets a resource by name; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name) where T : class, ICanBeCached
        {
            T resource = _cacheManager.Get<T>(name);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(name);
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
