using Newtonsoft.Json;
using PokeApi.Net.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PokeApi.Net.Data
{
    /// <summary>
    /// Gets data from the PokeAPI service
    /// </summary>
    class PokeApiClient
    {
        private HttpClient client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageHandler"></param>
        public PokeApiClient(HttpMessageHandler messageHandler)
        {
            client = new HttpClient(messageHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<T> GetResourceAsync<T>() where T : Resource
        {
            string apiEndpoint = typeof(T).GetField("ApiEndpoint").GetValue(null).ToString();
            HttpResponseMessage response = await client.GetAsync(apiEndpoint);

            string resp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resp);
        }
    }
}
