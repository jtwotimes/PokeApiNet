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
            PokeApiNet.Version version = await client.GetResourceAsync<PokeApiNet.Version>(1);

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

        [Theory]
        [MemberData(nameof(GenerateIds), 1, 1)]
        [MemberData(nameof(GenerateIds), 10_016, 3)]
        [Trait("Category", "Integration")]
        public async Task GetMoveResourceAsyncIntegrationTest(int id)
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            Move move = await client.GetResourceAsync<Move>(id);

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
        public async Task GetPokemonSpeciesResolveAllAsyncIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();
            PokemonSpecies pokemonSpecies = await client.GetResourceAsync<PokemonSpecies>(1);

            // act
            List<EggGroup> eggGroups = await client.GetResourceAsync(pokemonSpecies.EggGroups);

            // assert
            Assert.True(eggGroups.Any());
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
            PokeApiNet.Type type = await client.GetResourceAsync<PokeApiNet.Type>(1);

            // assert
            Assert.True(type.Id != default(int));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Berry> page = await client.GetNamedResourcePageAsync<Berry>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFirmnessPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<BerryFirmness> page = await client.GetNamedResourcePageAsync<BerryFirmness>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetBerryFlavorPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<BerryFlavor> page = await client.GetNamedResourcePageAsync<BerryFlavor>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLanguagePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Language> page = await client.GetNamedResourcePageAsync<Language>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestTypePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<ContestType> page = await client.GetNamedResourcePageAsync<ContestType>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetContestEffectPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ApiResourceList<ContestEffect> page = await client.GetApiResourcePageAsync<ContestEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetSuperContestEffectPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ApiResourceList<SuperContestEffect> page = await client.GetApiResourcePageAsync<SuperContestEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterMethodPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<EncounterMethod> page = await client.GetNamedResourcePageAsync<EncounterMethod>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<EncounterCondition> page = await client.GetNamedResourcePageAsync<EncounterCondition>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEncounterConditionValuePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<EncounterConditionValue> page = await client.GetNamedResourcePageAsync<EncounterConditionValue>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionChainPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ApiResourceList<EvolutionChain> page = await client.GetApiResourcePageAsync<EvolutionChain>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEvolutionTriggerPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<EvolutionTrigger> page = await client.GetNamedResourcePageAsync<EvolutionTrigger>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenerationPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Generation> page = await client.GetNamedResourcePageAsync<Generation>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokedexPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Pokedex> page = await client.GetNamedResourcePageAsync<Pokedex>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Version> page = await client.GetNamedResourcePageAsync<Version>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetVersionGroupPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<VersionGroup> page = await client.GetNamedResourcePageAsync<VersionGroup>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Item> page = await client.GetNamedResourcePageAsync<Item>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemAttributePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<ItemAttribute> page = await client.GetNamedResourcePageAsync<ItemAttribute>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemCategoryPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<ItemCategory> page = await client.GetNamedResourcePageAsync<ItemCategory>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemFlingEffectPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<ItemFlingEffect> page = await client.GetNamedResourcePageAsync<ItemFlingEffect>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetItemPocketPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<ItemPocket> page = await client.GetNamedResourcePageAsync<ItemPocket>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Location> page = await client.GetNamedResourcePageAsync<Location>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetLocationAreaPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<LocationArea> page = await client.GetNamedResourcePageAsync<LocationArea>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPalParkAreaPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PalParkArea> page = await client.GetNamedResourcePageAsync<PalParkArea>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetRegionPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Region> page = await client.GetNamedResourcePageAsync<Region>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMachinePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ApiResourceList<Machine> page = await client.GetApiResourcePageAsync<Machine>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMovePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Move> page = await client.GetNamedResourcePageAsync<Move>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveAilmentPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveAilment> page = await client.GetNamedResourcePageAsync<MoveAilment>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveBattleStylePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveBattleStyle> page = await client.GetNamedResourcePageAsync<MoveBattleStyle>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveCategoryPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveCategory> page = await client.GetNamedResourcePageAsync<MoveCategory>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveDamageClassPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveDamageClass> page = await client.GetNamedResourcePageAsync<MoveDamageClass>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveLearnMethodPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveLearnMethod> page = await client.GetNamedResourcePageAsync<MoveLearnMethod>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetMoveTargetPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<MoveTarget> page = await client.GetNamedResourcePageAsync<MoveTarget>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAbilityPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Ability> page = await client.GetNamedResourcePageAsync<Ability>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCharacteristicPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            ApiResourceList<Characteristic> page = await client.GetApiResourcePageAsync<Characteristic>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetEggGroupPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<EggGroup> page = await client.GetNamedResourcePageAsync<EggGroup>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGenderPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Gender> page = await client.GetNamedResourcePageAsync<Gender>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetGrowthRatePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<GrowthRate> page = await client.GetNamedResourcePageAsync<GrowthRate>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetNaturePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Nature> page = await client.GetNamedResourcePageAsync<Nature>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokeathlonStatPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokeathlonStat> page = await client.GetNamedResourcePageAsync<PokeathlonStat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Pokemon> page = await client.GetNamedResourcePageAsync<Pokemon>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonColorPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokemonColor> page = await client.GetNamedResourcePageAsync<PokemonColor>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonFormPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokemonForm> page = await client.GetNamedResourcePageAsync<PokemonForm>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonHabitatPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokemonHabitat> page = await client.GetNamedResourcePageAsync<PokemonHabitat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonShapePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokemonShape> page = await client.GetNamedResourcePageAsync<PokemonShape>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetPokemonSpeciesPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<PokemonSpecies> page = await client.GetNamedResourcePageAsync<PokemonSpecies>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetStatPagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Stat> page = await client.GetNamedResourcePageAsync<Stat>();

            // assert
            Assert.True(page.Results.Any());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetTypePagedResourceIntegrationTest()
        {
            // assemble
            PokeApiClient client = new PokeApiClient();

            // act
            NamedApiResourceList<Type> page = await client.GetNamedResourcePageAsync<Type>();

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
