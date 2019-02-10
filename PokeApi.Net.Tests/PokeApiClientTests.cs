using Newtonsoft.Json;
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
        [Trait("Category", "Integration")]
        public async Task GetBerryResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Berry berry = await client.GetResourceAsync<Berry>(1);

            // assert
            Assert.True(berry.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFirmnessResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            BerryFirmness berryFirmness = await client.GetResourceAsync<BerryFirmness>(1);

            // assert
            Assert.True(berryFirmness.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFlavorResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            BerryFlavor berryFlavor = await client.GetResourceAsync<BerryFlavor>(1);

            // assert
            Assert.True(berryFlavor.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLanguageResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Language language = await client.GetResourceAsync<Language>(1);

            // assert
            Assert.True(language.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestTypeResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ContestType contestType = await client.GetResourceAsync<ContestType>(1);

            // assert
            Assert.True(contestType.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestEffectResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ContestEffect contestEffect = await client.GetResourceAsync<ContestEffect>(1);

            // assert
            Assert.True(contestEffect.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetSuperContestEffectResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            SuperContestEffect superContestEffect = await client.GetResourceAsync<SuperContestEffect>(1);

            // assert
            Assert.True(superContestEffect.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterMethodResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EncounterMethod evolutionMethod = await client.GetResourceAsync<EncounterMethod>(1);

            // assert
            Assert.True(evolutionMethod.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EncounterCondition encounterCondition = await client.GetResourceAsync<EncounterCondition>(1);

            // assert
            Assert.True(encounterCondition.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionValueResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EncounterConditionValue encounterConditionValue = await client.GetResourceAsync<EncounterConditionValue>(1);

            // assert
            Assert.True(encounterConditionValue.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionChainResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EvolutionChain evolutionChain = await client.GetResourceAsync<EvolutionChain>(1);

            // assert
            Assert.True(evolutionChain.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionTriggerResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EvolutionTrigger evolutionTrigger = await client.GetResourceAsync<EvolutionTrigger>(1);

            // assert
            Assert.True(evolutionTrigger.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenerationResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Generation generation = await client.GetResourceAsync<Generation>(1);

            // assert
            Assert.True(generation.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokedexResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Pokedex pokedex = await client.GetResourceAsync<Pokedex>(1);

            // assert
            Assert.True(pokedex.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Models.Version version = await client.GetResourceAsync<Models.Version>(1);

            // assert
            Assert.True(version.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionGroupResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            VersionGroup versionGroup = await client.GetResourceAsync<VersionGroup>(1);

            // assert
            Assert.True(versionGroup.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Item item = await client.GetResourceAsync<Item>(1);

            // assert
            Assert.True(item.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemAttributeResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ItemAttribute itemAttribute = await client.GetResourceAsync<ItemAttribute>(1);

            // assert
            Assert.True(itemAttribute.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemCategoryResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ItemCategory itemCategory = await client.GetResourceAsync<ItemCategory>(1);

            // assert
            Assert.True(itemCategory.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemFlingEffectResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ItemFlingEffect itemFlingEffect = await client.GetResourceAsync<ItemFlingEffect>(1);

            // assert
            Assert.True(itemFlingEffect.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPocketResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ItemPocket itemPocket = await client.GetResourceAsync<ItemPocket>(1);

            // assert
            Assert.True(itemPocket.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Location location = await client.GetResourceAsync<Location>(1);

            // assert
            Assert.True(location.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationAreaResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            LocationArea locationArea = await client.GetResourceAsync<LocationArea>(1);

            // assert
            Assert.True(locationArea.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPalParkAreaResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PalParkArea palParkArea = await client.GetResourceAsync<PalParkArea>(1);

            // assert
            Assert.True(palParkArea.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetRegionResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Region region = await client.GetResourceAsync<Region>(1);

            // assert
            Assert.True(region.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMachineResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Machine machine = await client.GetResourceAsync<Machine>(1);

            // assert
            Assert.True(machine.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Move move = await client.GetResourceAsync<Move>(1);

            // assert
            Assert.True(move.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveAilmentResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveAilment moveAilment = await client.GetResourceAsync<MoveAilment>(1);

            // assert
            Assert.True(moveAilment.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveBattleStyleResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveBattleStyle moveBattleStyle = await client.GetResourceAsync<MoveBattleStyle>(1);

            // assert
            Assert.True(moveBattleStyle.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveCategoryResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveCategory moveCategory = await client.GetResourceAsync<MoveCategory>(1);

            // assert
            Assert.True(moveCategory.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveDamageClassResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveDamageClass moveDamageClass = await client.GetResourceAsync<MoveDamageClass>(1);

            // assert
            Assert.True(moveDamageClass.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveLearnMethodResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveLearnMethod moveLearnMethod = await client.GetResourceAsync<MoveLearnMethod>(1);

            // assert
            Assert.True(moveLearnMethod.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveTargetResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            MoveTarget moveTarget = await client.GetResourceAsync<MoveTarget>(1);

            // assert
            Assert.True(moveTarget.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAbilityResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Ability ability = await client.GetResourceAsync<Ability>(1);

            // assert
            Assert.True(ability.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCharacteristicResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Characteristic characteristic = await client.GetResourceAsync<Characteristic>(1);

            // assert
            Assert.True(characteristic.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEggGroupResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            EggGroup eggGroup = await client.GetResourceAsync<EggGroup>(1);

            // assert
            Assert.True(eggGroup.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenderResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Gender gender = await client.GetResourceAsync<Gender>(1);

            // assert
            Assert.True(gender.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGrowthRateResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            GrowthRate growthRate = await client.GetResourceAsync<GrowthRate>(1);

            // assert
            Assert.True(growthRate.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetNatureResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Nature nature = await client.GetResourceAsync<Nature>(1);

            // assert
            Assert.True(nature.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokeathlonStatResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokeathlonStat pokeathlonStat = await client.GetResourceAsync<PokeathlonStat>(1);

            // assert
            Assert.True(pokeathlonStat.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Pokemon pokemon = await client.GetResourceAsync<Pokemon>(1);

            // assert
            Assert.True(pokemon.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonColorResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokemonColor pokemonColor = await client.GetResourceAsync<PokemonColor>(1);

            // assert
            Assert.True(pokemonColor.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonFormResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokemonForm pokemonForm = await client.GetResourceAsync<PokemonForm>(1);

            // assert
            Assert.True(pokemonForm.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonHabitatResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokemonHabitat pokemonHabitat = await client.GetResourceAsync<PokemonHabitat>(1);

            // assert
            Assert.True(pokemonHabitat.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonShapeResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokemonShape pokemonShape = await client.GetResourceAsync<PokemonShape>(1);

            // assert
            Assert.True(pokemonShape.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonSpeciesResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            PokemonSpecies pokemonSpecies = await client.GetResourceAsync<PokemonSpecies>(1);

            // assert
            Assert.True(pokemonSpecies.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetStatResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Stat stat = await client.GetResourceAsync<Stat>(1);

            // assert
            Assert.True(stat.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetTypeResourceAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Models.Type type = await client.GetResourceAsync<Models.Type>(1);

            // assert
            Assert.True(type.Id != default(int));
        }
    }
}
