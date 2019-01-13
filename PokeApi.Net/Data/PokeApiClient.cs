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
    public class PokeApiClient
    {
        private HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        public PokeApiClient(HttpMessageHandler messageHandler)
        {
            client = new HttpClient(messageHandler) { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };
        }

        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam) where T : class
        {
            ApiEndpointAttribute attribute = typeof(T).GetCustomAttribute(typeof(ApiEndpointAttribute)) as ApiEndpointAttribute;
            string apiEndpoint = attribute.ApiEndpoint;
            HttpResponseMessage response = await client.GetAsync($"{apiEndpoint}/{apiParam}");

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
