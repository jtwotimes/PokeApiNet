using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PokeApiNet.Tests
{
    public class PokeApiClientTests
    {
        private readonly MockHttpMessageHandler mockHttp;

        public PokeApiClientTests()
        {
            mockHttp = new MockHttpMessageHandler();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ClearResourceListCacheOfAllTypes()
        {
            // assemble
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*machine")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));
            mockHttp.Expect("*berry")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect("*machine")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));
            mockHttp.Expect("*berry")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));

            // act
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetNamedResourcePageAsync<Berry>();
            sut.ClearResourceListCache();
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetNamedResourcePageAsync<Berry>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ClearResourceListCacheOfSpecificType()
        {
            // assemble
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*machine")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));
            mockHttp.Expect("*berry")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect("*machine")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));

            // act
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetNamedResourcePageAsync<Berry>();
            sut.ClearResourceListCache<Machine>();
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetNamedResourcePageAsync<Berry>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetApiResourcePage_WithSamePaginationParams_CacheHit()
        {
            // assemble
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));
            mockHttp.When("*")
                .Throw(new Exception("Cache miss"));

            // act
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetApiResourcePageAsync<Machine>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetApiResourcePage_WithDifferentPaginationParams_CacheMiss()
        {
            // assemble
            (int limit, int offset) = (30, 2);
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));
            mockHttp.Expect("*")
                .WithExactQueryString(ToPairs(limit, offset))
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeApiResourceList<Machine>()));

            // act
            await sut.GetApiResourcePageAsync<Machine>();
            await sut.GetApiResourcePageAsync<Machine>(limit, offset);

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetNamedApiResourcePage_WithSamePaginationParams_CacheHit()
        {
            // assemble
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.When("*")
                .Throw(new Exception("Cache miss"));

            // act
            await sut.GetNamedResourcePageAsync<Berry>();
            await sut.GetNamedResourcePageAsync<Berry>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetNamedApiResourcePage_WithDifferentPaginationParams_CacheMiss()
        {
            // assemble
            (int limit, int offset) = (30, 2);
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect("*")
                .WithExactQueryString(ToPairs(limit, offset))
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));

            // act
            await sut.GetNamedResourcePageAsync<Berry>();
            await sut.GetNamedResourcePageAsync<Berry>(limit, offset);

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

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
        public async Task GetResourceAsyncByIdAutoCache()
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
        public async Task GetResourceAsyncByNameAutoCache()
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
        public async Task GetResourceAsyncByNameWithPunctuation()
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
        public async Task GetResourceByIdCancellation()
        {
            // assemble
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));
            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetResourceAsync<Berry>(1, cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetResourceByNameCancellation()
        {
            // assemble
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.When("*").Respond("application/json", JsonConvert.SerializeObject(new Berry { Name = "cheri" }));
            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetResourceAsync<Berry>("cheri", cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ClearResourceCacheOfAllTypes()
        {
            // assemble
            Berry berry = new Berry { Name = "test", Id = 1 };
            Machine machine = new Machine { Id = 1 };
            PokeApiClient sut = CreateSut();
            mockHttp.Expect("*machine*")
                .Respond("application/json", JsonConvert.SerializeObject(machine));
            mockHttp.Expect("*berry*")
                .Respond("application/json", JsonConvert.SerializeObject(berry));
            mockHttp.Expect("*machine*")
                .Respond("application/json", JsonConvert.SerializeObject(machine));
            mockHttp.Expect("*berry*")
                 .Respond("application/json", JsonConvert.SerializeObject(berry));

            // act
            await sut.GetResourceAsync<Machine>(machine.Id);
            await sut.GetResourceAsync<Berry>(berry.Id);
            sut.ClearResourceCache();
            await sut.GetResourceAsync<Machine>(machine.Id);
            await sut.GetResourceAsync<Berry>(berry.Id);

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ClearResourceCacheOfSpecificType()
        {
            // assemble
            Berry returnedBerry = new Berry { Id = 1 };
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*").Respond("application/json", JsonConvert.SerializeObject(returnedBerry));

            PokeApiClient client = new PokeApiClient(mockHttp);
            Berry berry = await client.GetResourceAsync<Berry>(1);

            mockHttp.ResetExpectations();

            // act
            client.ClearResourceCache<Berry>();
            mockHttp.Expect("*").Respond("application/json", JsonConvert.SerializeObject(returnedBerry));
            berry = await client.GetResourceAsync<Berry>(1);

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ClearCacheWipesAllCachedData()
        {
            // assemble
            PokeApiClient sut = CreateSut();
            Berry berry = new Berry { Name = "test", Id = 1 };
            mockHttp.Expect($"*berry/{berry.Id}*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect("*berry")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect($"*berry/{berry.Id}*")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));
            mockHttp.Expect("*berry")
                .Respond("application/json", JsonConvert.SerializeObject(CreateFakeNamedResourceList<Berry>()));

            // act
            await sut.GetResourceAsync<Berry>(berry.Id);
            await sut.GetNamedResourcePageAsync<Berry>();
            sut.ClearCache();
            await sut.GetResourceAsync<Berry>(berry.Id);
            await sut.GetNamedResourcePageAsync<Berry>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task ResourceNotFound()
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
        public async Task GetResourceAsyncByNameCase()
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
        public async Task UrlNavigationResolveAsyncSingle()
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
        public async Task UrlNavigationCancellationAsyncSingle()
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
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetResourceAsync(pikachu.Species, cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task UrlNavigationResolveAsyncSingleCached()
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
        public async Task UrlNavigationResolveAllAsync()
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
        public async Task UrlNavigationCancellationAllAsync()
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
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetResourceAsync(item.Attributes, cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetNamedResourcePageAsync()
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
        public async Task GetNamedResourcePageAsyncCancellation()
        {
            // assemble
            NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*berry").Respond("application/json", JsonConvert.SerializeObject(berryPage));

            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetNamedResourcePageAsync<Berry>(cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetNamedResourcePageLimitOffsetAsync()
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
        public async Task GetNamedResourcePageLimitOffsetAsyncCancellation()
        {
            // assemble
            NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*berry?limit=50&offset=2").Respond("application/json", JsonConvert.SerializeObject(berryPage));

            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetNamedResourcePageAsync<Berry>(50, 2, cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetApiResourcePageAsync()
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
        public async Task GetApiResourcePageAsyncCancellation()
        {
            // assemble
            NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*evolution-chain").Respond("application/json", JsonConvert.SerializeObject(berryPage));

            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetApiResourcePageAsync<EvolutionChain>(cancellationToken); });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public async Task GetApiResourcePageLimitOffsetAsync()
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
        public async Task GetApiResourcePageLimitOffsetAsyncCancellation()
        {
            // assemble
            NamedApiResourceList<Berry> berryPage = new NamedApiResourceList<Berry>();

            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*evolution-chain?limit=1&offset=50").Respond("application/json", JsonConvert.SerializeObject(berryPage));

            PokeApiClient client = new PokeApiClient(mockHttp);
            CancellationToken cancellationToken = new CancellationToken(true);

            // act / assert
            await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetApiResourcePageAsync<EvolutionChain>(1, 50, cancellationToken); });
        }

        private PokeApiClient CreateSut() => new PokeApiClient(mockHttp);

        private ApiResourceList<T> CreateFakeApiResourceList<T>()
            where T : ApiResource
        {
            return new ApiResourceList<T>()
            {
                Next = "test-next",
                Previous = "test-previous",
                Results = new List<ApiResource<T>>()
            };
        }

        private NamedApiResourceList<T> CreateFakeNamedResourceList<T>()
            where T : NamedApiResource
        {
            return new NamedApiResourceList<T>()
            {
                Next = "test-next",
                Previous = "test-previous",
                Results = new List<NamedApiResource<T>>()
            };
        }

        private IEnumerable<KeyValuePair<string, string>> ToPairs(int limit, int offset)
            => new KeyValuePair<string, string>[] 
            {
                new KeyValuePair<string, string>(nameof(limit),limit.ToString()),
                new KeyValuePair<string, string>(nameof(offset),offset.ToString())
            };
    }
}
