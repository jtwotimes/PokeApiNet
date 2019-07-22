using Newtonsoft.Json;
using PokeApiNet.Data;
using PokeApiNet.Models;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class PokeApiClientTests
{
    [Fact]
    [Trait("Category", "Unit")]
    public async Task DefaultUserAgentHeaderIsSet()
    {
        // assemble
        ProductHeaderValue userAgent = PokeApiClient.DefaultUserAgent;
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*")
            .WithHeaders("User-Agent", userAgent.ToString())
            .Respond("application/json", JsonConvert.SerializeObject(new Berry { Id = 1 }));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        Berry berry = await client.GetResourceAsync<Berry>(1);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task CustomUserAgentHeaderIsSet()
    {
        // assemble
        ProductHeaderValue userAgent = ProductHeaderValue.Parse("CustomUserAgent/2.0");
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*")
            .WithHeaders("User-Agent", userAgent.ToString())
            .Respond("application/json", JsonConvert.SerializeObject(new Berry { Id = 1 }));

        PokeApiClient client = new PokeApiClient(mockHttp, userAgent);

        // act
        Berry berry = await client.GetResourceAsync<Berry>(1);
        
        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceAsyncByIdAutoCacheTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Id = 1 }));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Berry berry = await client.GetResourceAsync<Berry>(1);

        mockHttp.ResetBackendDefinitions();
        mockHttp.When("*").Throw(new Exception("Should not be thrown if cache system is in place"));

        // act
        Berry cachedBerry = await client.GetResourceAsync<Berry>(1);

        // assert
        Assert.Same(berry, cachedBerry);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceAsyncByNameAutoCacheTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Berry berry = await client.GetResourceAsync<Berry>("cheri");

        mockHttp.ResetBackendDefinitions();
        mockHttp.When("*").Throw(new Exception("Should not be thrown if cache system is in place"));

        // act
        Berry cachedBerry = await client.GetResourceAsync<Berry>("cheri");

        // assert
        Assert.Same(berry, cachedBerry);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceAsyncByNameWithPunctuationTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*hi-im-a-berry*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        Berry cleanNamedBerry = await client.GetResourceAsync<Berry>("hi I'm a berry.");

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceByIdCancellationTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));
        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetResourceAsync<Berry>(1, cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceByNameCancellationTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));
        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetResourceAsync<Berry>("cheri", cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task ClearCacheTypedTest()
    {
        // assemble
        Berry returnedBerry = new Berry { Id = 1 };
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*").Respond("application/json", JsonConvert.SerializeObject(returnedBerry));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Berry berry = await client.GetResourceAsync<Berry>(1);

        mockHttp.ResetExpectations();

        // act
        client.ClearCache<Berry>();
        mockHttp.Expect("*").Respond("application/json", JsonConvert.SerializeObject(returnedBerry));
        berry = await client.GetResourceAsync<Berry>(1);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task ClearCacheTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry/1/").Respond("application/json", JsonConvert.SerializeObject(new Berry { Id = 1 }));
        mockHttp.Expect("*pokemon/1/").Respond("application/json", JsonConvert.SerializeObject(new Pokemon { Id = 1 }));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Berry berry = await client.GetResourceAsync<Berry>(1);
        Pokemon pokemon = await client.GetResourceAsync<Pokemon>(1);

        mockHttp.ResetExpectations();

        // act
        client.ClearCache();
        mockHttp.Expect("*berry/1/").Respond("application/json", JsonConvert.SerializeObject(new Berry { Id = 1 }));
        berry = await client.GetResourceAsync<Berry>(1);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task ResourceNotFoundTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.When("*").Respond(HttpStatusCode.NotFound);
        PokeApiClient client = new PokeApiClient(mockHttp);

        // act / assert
        await Assert.ThrowsAsync<HttpRequestException>(async () => { await client.GetResourceAsync<Berry>("i am not a berry name"); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetResourceAsyncByNameCaseTest()
    {
        // assemble
        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry/cheri/").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));
        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        Berry retrievedBerry = await client.GetResourceAsync<Berry>("CHERI");

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task UrlNavigationResolveAsyncSingleTest()
    {
        // assemble
        Pokemon responsePikachu = new Pokemon
        {
            Name = "pikachu",
            Id = 25,
            Species = new NamedApiResource<PokemonSpecies>
            {
                Name = "pikachu",
                Url = "https://pokeapi.co/api/v2/pokemon-species/25/"
            }
        };
        PokemonSpecies responseSpecies = new PokemonSpecies { Name = "pikachu" };

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*pokemon/pikachu/").Respond("application/json", JsonConvert.SerializeObject(responsePikachu));
        mockHttp.Expect("*pokemon-species/25/").Respond("application/json", JsonConvert.SerializeObject(responseSpecies));
        PokeApiClient client = new PokeApiClient(mockHttp);

        Pokemon pikachu = await client.GetResourceAsync<Pokemon>("pikachu");

        // act
        PokemonSpecies species = await client.GetResourceAsync(pikachu.Species);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task UrlNavigationCancellationAsyncSingleTest()
    {
        // assemble
        Pokemon responsePikachu = new Pokemon
        {
            Name = "pikachu",
            Id = 25,
            Species = new NamedApiResource<PokemonSpecies>
            {
                Name = "pikachu",
                Url = "https://pokeapi.co/api/v2/pokemon-species/25/"
            }
        };
        PokemonSpecies responseSpecies = new PokemonSpecies { Name = "pikachu" };

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*pokemon/pikachu/").Respond("application/json", JsonConvert.SerializeObject(responsePikachu));
        mockHttp.Expect("*pokemon-species/25/").Respond("application/json", JsonConvert.SerializeObject(responseSpecies));
        PokeApiClient client = new PokeApiClient(mockHttp);

        Pokemon pikachu = await client.GetResourceAsync<Pokemon>("pikachu");
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assemble
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetResourceAsync(pikachu.Species, cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task UrlNavigationResolveAsyncSingleCachedTest()
    {
        // assemble
        Pokemon responsePikachu = new Pokemon
        {
            Name = "pikachu",
            Id = 25,
            Species = new NamedApiResource<PokemonSpecies>
            {
                Name = "pikachu",
                Url = "https://pokeapi.co/api/v2/pokemon-species/25/"
            }
        };
        PokemonSpecies responseSpecies = new PokemonSpecies { Name = "pikachu", Id = 25 };

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*pokemon/pikachu/").Respond("application/json", JsonConvert.SerializeObject(responsePikachu));
        mockHttp.Expect("*pokemon-species/25/").Respond("application/json", JsonConvert.SerializeObject(responseSpecies));
        PokeApiClient client = new PokeApiClient(mockHttp);

        Pokemon pikachu = await client.GetResourceAsync<Pokemon>("pikachu");
        PokemonSpecies species = await client.GetResourceAsync(pikachu.Species);

        mockHttp.ResetExpectations();
        mockHttp.Expect("*pokemon-species/25/").Respond("application/json", JsonConvert.SerializeObject(responseSpecies));

        // act
        species = await client.GetResourceAsync(pikachu.Species);

        // assert
        Assert.Throws<InvalidOperationException>(() => mockHttp.VerifyNoOutstandingExpectation());
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task UrlNavigationResolveAllAsyncTest()
    {
        // assemble
        ItemAttribute holdable = new ItemAttribute { Name = "holdable", Id = 1 };
        ItemAttribute consumable = new ItemAttribute { Name = "consumable", Id = 2 };
        Item hyperPotion = new Item
        {
            Attributes = new List<NamedApiResource<ItemAttribute>>
            {
                new NamedApiResource<ItemAttribute>
                {
                    Name = "holdable",
                    Url = "https://pokeapi.co/api/v2/item-attribute/5/"
                },
                new NamedApiResource<ItemAttribute>
                {
                    Name = "consumable",
                    Url = "https://pokeapi.co/api/v2/item-attribute/2/"
                }
            }
        };

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*item/hyper-potion/").Respond("application/json", JsonConvert.SerializeObject(hyperPotion));
        mockHttp.Expect("*item-attribute/5/").Respond("application/json", JsonConvert.SerializeObject(holdable));
        mockHttp.Expect("*item-attribute/2/").Respond("application/json", JsonConvert.SerializeObject(consumable));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Item item = await client.GetResourceAsync<Item>("hyper-potion");

        // act
        List<ItemAttribute> attributes = await client.GetResourceAsync(item.Attributes);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task UrlNavigationCancellationAllAsyncTest()
    {
        // assemble
        ItemAttribute holdable = new ItemAttribute { Name = "holdable", Id = 1 };
        ItemAttribute consumable = new ItemAttribute { Name = "consumable", Id = 2 };
        Item hyperPotion = new Item
        {
            Attributes = new List<NamedApiResource<ItemAttribute>>
            {
                new NamedApiResource<ItemAttribute>
                {
                    Name = "holdable",
                    Url = "https://pokeapi.co/api/v2/item-attribute/5/"
                },
                new NamedApiResource<ItemAttribute>
                {
                    Name = "consumable",
                    Url = "https://pokeapi.co/api/v2/item-attribute/2/"
                }
            }
        };

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*item/hyper-potion/").Respond("application/json", JsonConvert.SerializeObject(hyperPotion));
        mockHttp.Expect("*item-attribute/5/").Respond("application/json", JsonConvert.SerializeObject(holdable));
        mockHttp.Expect("*item-attribute/2/").Respond("application/json", JsonConvert.SerializeObject(consumable));

        PokeApiClient client = new PokeApiClient(mockHttp);
        Item item = await client.GetResourceAsync<Item>("hyper-potion");

        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetResourceAsync(item.Attributes, cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetNamedResourcePageAsyncTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        NamedApiResourceList<Berry> page = await client.GetNamedResourcePageAsync<Berry>();

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetNamedResourcePageAsyncCancellationTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetNamedResourcePageAsync<Berry>(cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetNamedResourcePageLimitOffsetAsyncTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry?limit=50&offset=2").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        NamedApiResourceList<Berry> page = await client.GetNamedResourcePageAsync<Berry>(50, 2);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetNamedResourcePageLimitOffsetAsyncCancellationTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*berry?limit=50&offset=2").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetNamedResourcePageAsync<Berry>(50, 2, cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetApiResourcePageAsyncTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*evolution-chain").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        ApiResourceList<EvolutionChain> page = await client.GetApiResourcePageAsync<EvolutionChain>();

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetApiResourcePageAsyncCancellationTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*evolution-chain").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetApiResourcePageAsync<EvolutionChain>(cancellationToken); });
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetApiResourcePageLimitOffsetAsyncTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*evolution-chain?limit=1&offset=50").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);

        // act
        ApiResourceList<EvolutionChain> page = await client.GetApiResourcePageAsync<EvolutionChain>(1, 50);

        // assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetApiResourcePageLimitOffsetAsyncCancellationTest()
    {
        // assemble
        NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

        MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        mockHttp.Expect("*evolution-chain?limit=1&offset=50").Respond("application/json", JsonConvert.SerializeObject(berryPage));

        PokeApiClient client = new PokeApiClient(mockHttp);
        CancellationToken cancellationToken = new CancellationToken(true);

        // act / assert
        await Assert.ThrowsAsync<OperationCanceledException>(async () => { await client.GetApiResourcePageAsync<EvolutionChain>(1, 50, cancellationToken); });
    }
}
