using PokeApi.Net.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    /// <summary>
    /// A generation is a grouping of the Pokémon games that separates
    /// them based on the Pokémon they include. In each generation, a new
    /// set of Pokémon, Moves, Abilities and Types that did not exist in
    /// the previous generation are released.
    /// </summary>
    [ApiEndpoint("generation")]
    public class Generation : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of abilities that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource> Abilities { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The main region travelled in this generation.
        /// </summary>
        public NamedApiResource MainRegion { get; set; }

        /// <summary>
        /// A list of moves that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource> Moves { get; set; }

        /// <summary>
        /// A list of Pokemon species that were introduced in this
        /// generation.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }

        /// <summary>
        /// A list of types that were introduced in this generation.
        /// </summary>
        public List<NamedApiResource> Types { get; set; }

        /// <summary>
        /// A list of version groups that were introduced in this
        /// generation.
        /// </summary>
        public List<NamedApiResource> VersionGroups { get; set; }
    }

    /// <summary>
    /// A Pokédex is a handheld electronic encyclopedia device; one which
    /// is capable of recording and retaining information of the various
    /// Pokémon in a given region with the exception of the national dex
    /// and some smaller dexes related to portions of a region.
    /// </summary>
    [ApiEndpoint("pokedex")]
    public class Pokedex : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not this Pokédex originated in the main series of the video games.
        /// </summary>
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
        public List<PokemonEntry> PokemonEntries { get; set; }

        /// <summary>
        /// The region this Pokédex catalogues Pokémon for.
        /// </summary>
        public NamedApiResource Region { get; set; }

        /// <summary>
        /// A list of version groups this Pokédex is relevant to.
        /// </summary>
        public List<NamedApiResource> VersionGroups { get; set; }
    }

    public class PokemonEntry
    {
        /// <summary>
        /// The index of this Pokémon species entry within the Pokédex.
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokémon species being encountered.
        /// </summary>
        public NamedApiResource PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Versions of the games, e.g., Red, Blue or Yellow.
    /// </summary>
    [ApiEndpoint("version")]
    public class Version : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The version group this version belongs to.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }
    }

    /// <summary>
    /// Version groups categorize highly similar versions of the games.
    /// </summary>
    [ApiEndpoint("version-group")]
    public class VersionGroup : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Order for sorting. Almost by date of release,
        /// except similar versions are grouped together.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The generation this version was introduced in.
        /// </summary>
        public NamedApiResource Generation { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon can learn moves in
        /// this version group.
        /// </summary>
        public List<NamedApiResource> MoveLearnMethod { get; set; }

        /// <summary>
        /// A list of Pokédexes introduces in this version group.
        /// </summary>
        public List<NamedApiResource> Pokedexes { get; set; }

        /// <summary>
        /// A list of regions that can be visited in this version group.
        /// </summary>
        public List<NamedApiResource> Regions { get; set; }

        /// <summary>
        /// The versions this version group owns.
        /// </summary>
        public List<NamedApiResource> Versions { get; set; }
    }
}
