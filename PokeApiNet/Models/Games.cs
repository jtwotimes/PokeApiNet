using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// A generation is a grouping of the Pokémon games that separates
    /// them based on the Pokémon they include. In each generation, a new
    /// set of Pokémon, Moves, Abilities and Types that did not exist in
    /// the previous generation are released.
    /// </summary>
    public class Generation : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "generation";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of abilities that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource<Ability>> Abilities { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The main region travelled in this generation.
        /// </summary>
        [JsonProperty("main_region")]
        public NamedApiResource<Region> MainRegion { get; set; }

        /// <summary>
        /// A list of moves that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }

        /// <summary>
        /// A list of Pokemon species that were introduced in this
        /// generation.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }

        /// <summary>
        /// A list of types that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource<Type>> Types { get; set; }

        /// <summary>
        /// A list of version groups that were introduced in this
        /// generation.
        /// </summary>
        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    /// <summary>
    /// A Pokédex is a handheld electronic encyclopedia device; one which
    /// is capable of recording and retaining information of the various
    /// Pokémon in a given region with the exception of the national dex
    /// and some smaller dexes related to portions of a region.
    /// </summary>
    public class Pokedex : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokedex";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Whether or not this Pokédex originated in the main series of the video games.
        /// </summary>
        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon catalogued in this Pokédex and their indexes.
        /// </summary>
        [JsonProperty("pokemon_entries")]
        public List<PokemonEntry> PokemonEntries { get; set; }

        /// <summary>
        /// The region this Pokédex catalogues Pokémon for.
        /// </summary>
        public NamedApiResource<Region> Region { get; set; }

        /// <summary>
        /// A list of version groups this Pokédex is relevant to.
        /// </summary>
        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    /// <summary>
    /// The entry information
    /// </summary>
    public class PokemonEntry
    {
        /// <summary>
        /// The index of this Pokémon species entry within the Pokédex.
        /// </summary>
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokémon species being encountered.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Versions of the games, e.g., Red, Blue or Yellow.
    /// </summary>
    public class Version : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "version";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The version group this version belongs to.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    /// <summary>
    /// Version groups categorize highly similar versions of the games.
    /// </summary>
    public class VersionGroup : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "version-group";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Order for sorting. Almost by date of release,
        /// except similar versions are grouped together.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The generation this version was introduced in.
        /// </summary>
        public NamedApiResource<Generation> Generation { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon can learn moves in
        /// this version group.
        /// </summary>
        [JsonProperty("move_learn_methods")]
        public List<NamedApiResource<MoveLearnMethod>> MoveLearnMethods { get; set; }

        /// <summary>
        /// A list of Pokédexes introduces in this version group.
        /// </summary>
        public List<NamedApiResource<Pokedex>> Pokedexes { get; set; }

        /// <summary>
        /// A list of regions that can be visited in this version group.
        /// </summary>
        public List<NamedApiResource<Region>> Regions { get; set; }

        /// <summary>
        /// The versions this version group owns.
        /// </summary>
        public List<NamedApiResource<Version>> Versions { get; set; }
    }
}
