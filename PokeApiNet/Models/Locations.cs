using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Locations that can be visited within the games. Locations make
    /// up sizable portions of regions, like cities or routes.
    /// </summary>
    public class Location : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "location";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource<Region> Region { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of game indices relevent to this location by generation.
        /// </summary>
        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// Areas that can be found within this location
        /// </summary>
        public List<NamedApiResource<LocationArea>> Areas { get; set; }
    }

    /// <summary>
    /// Location areas are sections of areas, such as floors in a building
    /// or cave. Each area has its own set of possible Pokémon encounters.
    /// </summary>
    public class LocationArea : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "location-area";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The internal id of an API resource within game data.
        /// </summary>
        [JsonProperty("game_index")]
        public int GameIndex { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon may be encountered in this
        /// area and how likely the method will occur depending on the version
        /// of the game.
        /// </summary>
        [JsonProperty("encounter_method_rates")]
        public List<EncounterMethodRate> EncounterMethodRates { get; set; }

        /// <summary>
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource<Location> Location { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon that can be encountered in this area along with
        /// version specific details about the encounter.
        /// </summary>
        [JsonProperty("pokemon_encounters")]
        public List<PokemonEncounter> PokemonEncounters { get; set; }
    }

    /// <summary>
    /// A mapping between an encounter method and the version that applies
    /// </summary>
    public class EncounterMethodRate
    {
        /// <summary>
        /// The method in which Pokémon may be encountered in an area.
        /// </summary>
        [JsonProperty("encounter_method")]
        public NamedApiResource<EncounterMethod> EncounterMethod { get; set; }

        /// <summary>
        /// The chance of the encounter to occur on a version of the game.
        /// </summary>
        [JsonProperty("version_details")]
        public List<EncounterVersionDetails> VersionDetails { get; set; }
    }

    /// <summary>
    /// The details for an encounter with the version
    /// </summary>
    public class EncounterVersionDetails
    {
        /// <summary>
        /// The chance of an encounter to occur.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The version of the game in which the encounter can occur with
        /// the given chance.
        /// </summary>
        public NamedApiResource<Version> Version { get; set; }
    }

    /// <summary>
    /// A Pokémon encounter and the version that encounter can happen
    /// </summary>
    public class PokemonEncounter
    {
        /// <summary>
        /// The Pokémon being encountered.
        /// </summary>
        public NamedApiResource<Pokemon> Pokemon { get; set; }

        /// <summary>
        /// A list of versions and encounters with Pokémon that might happen
        /// in the referenced location area.
        /// </summary>
        [JsonProperty("version_details")]
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    /// <summary>
    /// Areas used for grouping Pokémon encounters in Pal Park. They're like
    /// habitats that are specific to Pal Park.
    /// </summary>
    public class PalParkArea : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pal-park-area";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon encountered in thi pal park area along with
        /// details.
        /// </summary>
        [JsonProperty("pokemon_encounters")]
        public List<PalParkEncounterSpecies> PokemonEncounters { get; set; }
    }

    /// <summary>
    /// Information for an encounter in PalPark
    /// </summary>
    public class PalParkEncounterSpecies
    {
        /// <summary>
        /// The base score given to the player when this Pokémon is caught
        /// during a pal park run.
        /// </summary>
        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering this Pokémon in this pal park area.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The Pokémon species being encountered.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// A region is an organized area of the Pokémon world. Most often,
    /// the main difference between regions is the species of Pokémon
    /// that can be encountered within them.
    /// </summary>
    public class Region : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "region";

        /// <summary>
        /// A list of locations that can be found in this region.
        /// </summary>
        public List<NamedApiResource<Location>> Locations { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The generation this region was introduced in.
        /// </summary>
        [JsonProperty("main_generation")]
        public NamedApiResource<Generation> MainGeneration { get; set; }

        /// <summary>
        /// A list of pokédexes that catalogue Pokémon in this region.
        /// </summary>
        public List<NamedApiResource<Pokedex>> Pokedexes { get; set; }

        /// <summary>
        /// A list of version groups where this region can be visited.
        /// </summary>
        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }
}
