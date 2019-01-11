using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    class Location : Resource
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
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource Region { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of game indices relevent to this location by generation.
        /// </summary>
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// Areas that can be found within this location
        /// </summary>
        public List<NamedApiResource> Areas { get; set; }

        public override string ApiEndpoint => "location";
    }

    class LocationArea : Resource
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
        /// The internal id of an API resource within game data.
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon may be encountered in this
        /// area and how likely the method will occur depending on the version
        /// of the game.
        /// </summary>
        public List<EncounterMethodRate> EncounterMethodRates { get; set; }

        /// <summary>
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource Location { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon that can be encountered in this area along with
        /// version specific details about the encounter.
        /// </summary>
        public List<PokemonEncounter> PokemonEncounters { get; set; }

        public override string ApiEndpoint => "location-area";
    }

    class EncounterMethodRate
    {
        /// <summary>
        /// The method in which Pokémon may be encountered in an area.
        /// </summary>
        public NamedApiResource EncounterMethod { get; set; }

        /// <summary>
        /// The chance of the encounter to occur on a version of the game.
        /// </summary>
        public List<EncounterVersionDetails> VersionDetails { get; set; }
    }

    class EncounterVersionDetails
    {
        /// <summary>
        /// The chance of an encounter to occur.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The version of the game in which the encounter can occur with
        /// the given chance.
        /// </summary>
        public NamedApiResource Version { get; set; }
    }

    class PokemonEncounter
    {
        /// <summary>
        /// The Pokémon being encountered.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }

        /// <summary>
        /// A list of versions and encounters with Pokémon that might happen
        /// in the referenced location area.
        /// </summary>
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    class PalParkArea : Resource
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
        /// A list of Pokémon encountered in thi pal park area along with
        /// details.
        /// </summary>
        public List<PalParkEncounterSpecies> PokemonEncounters { get; set; }

        public override string ApiEndpoint => "pal-park-area";
    }

    class PalParkEncounterSpecies
    {
        /// <summary>
        /// The base score given to the player when this Pokémon is caught
        /// during a pal park run.
        /// </summary>
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering this Pokémon in this pal park area.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The Pokémon species being encountered.
        /// </summary>
        public NamedApiResource PokemonSpecies { get; set; }
    }

    class Region : Resource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A list of locations that can be found in this region.
        /// </summary>
        public List<NamedApiResource> Locations { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The generation this region was introduced in.
        /// </summary>
        public NamedApiResource MainGeneration { get; set; }

        /// <summary>
        /// A list of pokédexes that catalogue Pokémon in this region.
        /// </summary>
        public List<NamedApiResource> Pokedexes { get; set; }

        /// <summary>
        /// A list of version groups where this region can be visited.
        /// </summary>
        public List<NamedApiResource> VersionGroups { get; set; }

        public override string ApiEndpoint => "region";
    }
}
