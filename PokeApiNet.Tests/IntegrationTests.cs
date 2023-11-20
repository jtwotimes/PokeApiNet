using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PokeApiNet.Tests
{
    public class IntegrationTests
    {
        public static IEnumerable<object[]> GenerateIds(int start, int count) =>
            Enumerable.Range(start, count).Select(index => new object[] { index });

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var berry = await client.GetResourceAsync<Berry>(1);

            // assert
            Assert.True(berry.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFirmnessResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var berryFirmness = await client.GetResourceAsync<BerryFirmness>(1);

            // assert
            Assert.True(berryFirmness.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFlavorResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var berryFlavor = await client.GetResourceAsync<BerryFlavor>(1);

            // assert
            Assert.True(berryFlavor.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLanguageResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var language = await client.GetResourceAsync<Language>(1);

            // assert
            Assert.True(language.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestTypeResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var contestType = await client.GetResourceAsync<ContestType>(1);

            // assert
            Assert.True(contestType.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestEffectResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var contestEffect = await client.GetResourceAsync<ContestEffect>(1);

            // assert
            Assert.True(contestEffect.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetSuperContestEffectResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var superContestEffect = await client.GetResourceAsync<SuperContestEffect>(1);

            // assert
            Assert.True(superContestEffect.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterMethodResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var evolutionMethod = await client.GetResourceAsync<EncounterMethod>(1);

            // assert
            Assert.True(evolutionMethod.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var encounterCondition = await client.GetResourceAsync<EncounterCondition>(1);

            // assert
            Assert.True(encounterCondition.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionValueResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var encounterConditionValue = await client.GetResourceAsync<EncounterConditionValue>(1);

            // assert
            Assert.True(encounterConditionValue.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionChainResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var evolutionChain = await client.GetResourceAsync<EvolutionChain>(1);

            // assert
            Assert.True(evolutionChain.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionTriggerResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var evolutionTrigger = await client.GetResourceAsync<EvolutionTrigger>(1);

            // assert
            Assert.True(evolutionTrigger.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenerationResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var generation = await client.GetResourceAsync<Generation>(1);

            // assert
            Assert.True(generation.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokedexResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokedex = await client.GetResourceAsync<Pokedex>(1);

            // assert
            Assert.True(pokedex.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var version = await client.GetResourceAsync<PokeApiNet.Version>(1);

            // assert
            Assert.True(version.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionGroupResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var versionGroup = await client.GetResourceAsync<VersionGroup>(1);

            // assert
            Assert.True(versionGroup.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var item = await client.GetResourceAsync<Item>(1);

            // assert
            Assert.True(item.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemAttributeResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var itemAttribute = await client.GetResourceAsync<ItemAttribute>(1);

            // assert
            Assert.True(itemAttribute.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemCategoryResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var itemCategory = await client.GetResourceAsync<ItemCategory>(1);

            // assert
            Assert.True(itemCategory.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemFlingEffectResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var itemFlingEffect = await client.GetResourceAsync<ItemFlingEffect>(1);

            // assert
            Assert.True(itemFlingEffect.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPocketResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var itemPocket = await client.GetResourceAsync<ItemPocket>(1);

            // assert
            Assert.True(itemPocket.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var location = await client.GetResourceAsync<Location>(1);

            // assert
            Assert.True(location.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationAreaResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var locationArea = await client.GetResourceAsync<LocationArea>(1);

            // assert
            Assert.True(locationArea.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPalParkAreaResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var palParkArea = await client.GetResourceAsync<PalParkArea>(1);

            // assert
            Assert.True(palParkArea.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetRegionResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var region = await client.GetResourceAsync<Region>(1);

            // assert
            Assert.True(region.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMachineResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var machine = await client.GetResourceAsync<Machine>(1);

            // assert
            Assert.True(machine.Id != default);
        }

        [Theory]
        [MemberData(nameof(GenerateIds), 1, 1)]
        [MemberData(nameof(GenerateIds), 10_016, 3)]
        [Trait("Category", "Integration")]
        public async Task GetMoveResourceAsyncIntegrationTest(int id)
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var move = await client.GetResourceAsync<Move>(id);

            // assert
            Assert.True(move.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveAilmentResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveAilment = await client.GetResourceAsync<MoveAilment>(1);

            // assert
            Assert.True(moveAilment.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveBattleStyleResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveBattleStyle = await client.GetResourceAsync<MoveBattleStyle>(1);

            // assert
            Assert.True(moveBattleStyle.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveCategoryResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveCategory = await client.GetResourceAsync<MoveCategory>(1);

            // assert
            Assert.True(moveCategory.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveDamageClassResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveDamageClass = await client.GetResourceAsync<MoveDamageClass>(1);

            // assert
            Assert.True(moveDamageClass.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveLearnMethodResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveLearnMethod = await client.GetResourceAsync<MoveLearnMethod>(1);

            // assert
            Assert.True(moveLearnMethod.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveTargetResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var moveTarget = await client.GetResourceAsync<MoveTarget>(1);

            // assert
            Assert.True(moveTarget.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAbilityResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var ability = await client.GetResourceAsync<Ability>(1);

            // assert
            Assert.True(ability.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCharacteristicResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var characteristic = await client.GetResourceAsync<Characteristic>(1);

            // assert
            Assert.True(characteristic.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEggGroupResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var eggGroup = await client.GetResourceAsync<EggGroup>(1);

            // assert
            Assert.True(eggGroup.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenderResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var gender = await client.GetResourceAsync<Gender>(1);

            // assert
            Assert.True(gender.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGrowthRateResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var growthRate = await client.GetResourceAsync<GrowthRate>(1);

            // assert
            Assert.True(growthRate.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetNatureResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var nature = await client.GetResourceAsync<Nature>(1);

            // assert
            Assert.True(nature.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokeathlonStatResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokeathlonStat = await client.GetResourceAsync<PokeathlonStat>(1);

            // assert
            Assert.True(pokeathlonStat.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemon = await client.GetResourceAsync<Pokemon>(1);

            // assert
            Assert.True(pokemon.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonColorResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemonColor = await client.GetResourceAsync<PokemonColor>(1);

            // assert
            Assert.True(pokemonColor.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonFormResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemonForm = await client.GetResourceAsync<PokemonForm>(1);

            // assert
            Assert.True(pokemonForm.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonHabitatResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemonHabitat = await client.GetResourceAsync<PokemonHabitat>(1);

            // assert
            Assert.True(pokemonHabitat.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonShapeResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemonShape = await client.GetResourceAsync<PokemonShape>(1);

            // assert
            Assert.True(pokemonShape.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonSpeciesResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var pokemonSpecies = await client.GetResourceAsync<PokemonSpecies>(1);

            // assert
            Assert.True(pokemonSpecies.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonSpeciesResolveAllAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();
            var pokemonSpecies = await client.GetResourceAsync<PokemonSpecies>(1);

            // act
            var eggGroups = await client.GetResourceAsync(pokemonSpecies.EggGroups);

            // assert
            Assert.True(eggGroups.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetStatResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var stat = await client.GetResourceAsync<Stat>(1);

            // assert
            Assert.True(stat.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetTypeResourceAsyncIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var type = await client.GetResourceAsync<PokeApiNet.Type>(1);

            // assert
            Assert.True(type.Id != default);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Berry>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFirmnessPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<BerryFirmness>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFlavorPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<BerryFlavor>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLanguagePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Language>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestTypePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<ContestType>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestEffectPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetApiResourcePageAsync<ContestEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetSuperContestEffectPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetApiResourcePageAsync<SuperContestEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterMethodPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<EncounterMethod>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<EncounterCondition>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionValuePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<EncounterConditionValue>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionChainPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetApiResourcePageAsync<EvolutionChain>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionTriggerPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<EvolutionTrigger>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenerationPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Generation>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokedexPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Pokedex>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Version>();


            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionGroupPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<VersionGroup>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Item>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemAttributePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<ItemAttribute>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemCategoryPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<ItemCategory>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemFlingEffectPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<ItemFlingEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPocketPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<ItemPocket>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Location>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationAreaPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<LocationArea>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPalParkAreaPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PalParkArea>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetRegionPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Region>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMachinePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetApiResourcePageAsync<Machine>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMovePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Move>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveAilmentPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveAilment>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveBattleStylePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveBattleStyle>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveCategoryPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveCategory>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveDamageClassPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveDamageClass>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveLearnMethodPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveLearnMethod>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveTargetPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<MoveTarget>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAbilityPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Ability>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCharacteristicPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetApiResourcePageAsync<Characteristic>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEggGroupPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<EggGroup>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenderPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Gender>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGrowthRatePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<GrowthRate>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetNaturePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Nature>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokeathlonStatPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokeathlonStat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Pokemon>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonColorPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokemonColor>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonFormPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokemonForm>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonHabitatPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokemonHabitat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonShapePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokemonShape>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonSpeciesPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<PokemonSpecies>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetStatPagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Stat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetTypePagedResourceIntegrationTest()
        {
            // assemble
            using PokeApiClient client = new();

            // act
            var page = await client.GetNamedResourcePageAsync<Type>();

            // assert
            Assert.True(page.Results.Any());
        }

        /// <summary>
        /// Verifies that Pokemon with past types data have theirs fetched correctly.
        /// </summary>
        [Theory]
        [InlineData(35, 5, 1, 1)]
        [InlineData(36, 5, 1, 1)]
        [InlineData(39, 5, 1, 1)]
        [InlineData(40, 5, 1, 1)]
        [InlineData(81, 1, 13, 1)]
        [InlineData(82, 1, 13, 1)]
        [InlineData(122, 5, 14, 1)]
        [InlineData(173, 5, 1, 1)]
        [InlineData(174, 5, 1, 1)]
        [InlineData(175, 5, 1, 1)]
        [InlineData(176, 5, 1, 1)] [InlineData(176, 5, 3, 2)]
        [InlineData(183, 5, 11, 1)]
        [InlineData(184, 5, 11, 1)]
        [InlineData(209, 5, 1, 1)]
        [InlineData(210, 5, 1, 1)]
        [InlineData(280, 5, 14, 1)]
        [InlineData(281, 5, 14, 1)]
        [InlineData(282, 5, 14, 1)]
        [InlineData(298, 5, 1, 1)]
        [InlineData(303, 5, 9, 1)]
        [InlineData(439, 5, 14, 1)]
        [InlineData(468, 5, 1, 1)] [InlineData(468, 5, 3, 2)]
        [InlineData(546, 5, 12, 1)]
        [InlineData(10008, 4, 13, 1)] [InlineData(10008, 4, 8, 2)]
        [InlineData(10009, 4, 13, 1)] [InlineData(10009, 4, 8, 2)]
        [InlineData(10010, 4, 13, 1)] [InlineData(10010, 4, 8, 2)]
        [InlineData(10011, 4, 13, 1)] [InlineData(10011, 4, 8, 2)]
        [InlineData(10012, 4, 13, 1)] [InlineData(10012, 4, 8, 2)]
        public static async Task GetPastTypesTest_HasPastTypes(int pokemonID, int generation, int type, int slot)
        {
            // assemble
            using (var client = new PokeApiClient())
            {
                // act
                var pokemon = await client.GetResourceAsync<Pokemon>(pokemonID);

                // assert
                var pastTypes = pokemon.PastTypes;
                Assert.NotNull(pastTypes);
                Assert.NotEmpty(pastTypes);

                // verify this pokemon has past type data for the given generation
                var generations = await client.GetResourceAsync(pastTypes.Select(p => p.Generation));
                var generationObj = generations.SingleOrDefault(g => g.Id == generation);
                Assert.NotNull(generationObj);

                // verify that this generation's past type data has an entry for the given slot
                var types = pastTypes.Single(p => p.Generation.Name == generationObj.Name).Types;
                var typeObj = types.SingleOrDefault(t => t.Slot == slot);
                Assert.NotNull(typeObj);

                // verify that this slot's type is correct
                var typeRes = await client.GetResourceAsync(typeObj.Type);
                Assert.Equal(typeRes.Id, type);
            }
        }

        /// <summary>
        /// Verifies that a Pokemon with no past types data
        /// has an empty list as its PastTypes property.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public static async Task GetPastTypesTest_NoPastTypes(int pokemonID)
        {
            // assemble
            using (var client = new PokeApiClient())
            {
                // act
                var pokemon = await client.GetResourceAsync<Pokemon>(pokemonID);

                // assert
                var pastTypes = pokemon.PastTypes;
                Assert.Empty(pastTypes);
            }
        }
    } 
}
