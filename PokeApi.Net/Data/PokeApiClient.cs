using Newtonsoft.Json;
using PokeApi.Net.Attributes;
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

        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam) where T : class
        {
            ApiEndpointAttribute attribute = typeof(T).GetCustomAttribute(typeof(ApiEndpointAttribute)) as ApiEndpointAttribute;
            string apiEndpoint = attribute.ApiEndpoint;
            HttpResponseMessage response = await _client.GetAsync($"{apiEndpoint}/{apiParam}");

            string resp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resp);
        }

        /// <summary>
        /// Gets a resource by id
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="id">Id of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(int id) where T : class
        {
            return await GetResourcesWithParamsAsync<T>(id.ToString());
        }

        /// <summary>
        /// Gets a resource by name
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name) where T : class
        {
            return await GetResourcesWithParamsAsync<T>(name);
        }
    }
}
