using Newtonsoft.Json;
using PokeApi.Net.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Net.Data
{
    /// <summary>
    /// Gets data from the PokeAPI service
    /// </summary>
    class PokeApiClient
    {
        private HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        public PokeApiClient(HttpMessageHandler messageHandler)
        {
            client = new HttpClient(messageHandler);
        }

        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam) where T : Resource
        {
            string apiEndpoint = typeof(T).GetField("ApiEndpoint").GetValue(null).ToString();
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
        public async Task<T> GetResourceAsync<T>(int id) where T : Resource
        {
            return await GetResourcesWithParamsAsync<T>(id.ToString());
        }

        /// <summary>
        /// Gets a resource by name
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name) where T : Resource
        {
            return await GetResourcesWithParamsAsync<T>(name);
        }
    }
}
