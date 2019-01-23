using PokeApi.Net.Data;
using PokeApi.Net.Models;
using RichardSzalay.MockHttp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PokeApi.Net.Tests.Data
{
    public class PokeApiClientTests
    {
        [Fact]
        public async Task GetResourceAsyncTest()
        {
            PokeApiClient client = new PokeApiClient();
            var berry = await client.GetResourceAsync<Berry>("cheri");

            //var mockHttp = new MockHttpMessageHandler();
            //mockHttp.When("").Respond("application/json", "{}");

            //PokeApiClient client = new PokeApiClient(mockHttp);
            //await client.GetResourceAsync<Models.Berry>(1);
        }
    }
}
