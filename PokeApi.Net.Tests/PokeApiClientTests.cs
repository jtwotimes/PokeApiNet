using PokeApi.Net.Data;
using RichardSzalay.MockHttp;
using System;
using Xunit;

namespace PokeApi.Net.Tests.Data
{
    public class PokeApiClientTests
    {
        [Fact]
        public async void GetResourceAsyncTest()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("").Respond("application/json", "{}");

            PokeApiClient client = new PokeApiClient(mockHttp);

            await client.GetResourceAsync<Models.Berry>(1);
        }
    }
}
