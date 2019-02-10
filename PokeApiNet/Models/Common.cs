using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Languages for translations of API resource information.
    /// </summary>
    [ApiEndpoint("language")]
    public class Language : ICanBeCached
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
        /// Whether or not the games are published in this language.
        /// </summary>
        public bool Official { get; set; }

        /// <summary>
        /// The two-letter code of the country where this language
        /// is spoken. Note that it is not unique.
        /// </summary>
        public string Iso639 { get; set; }

        /// <summary>
        /// The two-letter code of the language. Note that it is not
        /// unique.
        /// </summary>
        public string Iso3166 { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    public class ApiResource
    {
        /// <summary>
        /// The URL of the referenced resource.
        /// </summary>
        public string Url { get; set; }
    }

    public class Descriptions
    {
        /// <summary>
        /// The localized description for an API resource in a
        /// specific language.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class Effects
    {
        /// <summary>
        /// The localized effect text for an API resource in a
        /// specific language.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class Encounter
    {
        /// <summary>
        /// The lowest level the Pokémon could be encountered at.
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// The highest level the Pokémon could be encountered at.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// A list of condition values that must be in effect for this
        /// encounter to occur.
        /// </summary>
        public List<NamedApiResource> ConditionValues { get; set; }

        /// <summary>
        /// Percent chance that this encounter will occur.
        /// </summary>
        public int Chance { get; set; }

        /// <summary>
        /// The method by which this encounter happens.
        /// </summary>
        public NamedApiResource Method { get; set; }
    }

    public class FlavorTexts
    {
        /// <summary>
        /// The localized flavor text for an API resource in a specific language.
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class GenerationGameIndex
    {
        /// <summary>
        /// The internal id of an API resource within game data.
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The generation relevent to this game index.
        /// </summary>
        public NamedApiResource Generation { get; set; }
    }

    public class MachineVersionDetail
    {
        /// <summary>
        /// The machine that teaches a move from an item.
        /// </summary>
        public ApiResource Machine { get; set; }

        /// <summary>
        /// The version group of this specific machine.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }
    }

    public class Names
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class NamedApiResource
    {
        /// <summary>
        /// The name of the referenced resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL of the referenced resource.
        /// </summary>
        public string Url { get; set; }
    }

    public class VerboseEffect
    {
        /// <summary>
        /// The localized effect text for an API resource in a
        /// specific language.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The localized effect text in brief.
        /// </summary>
        public string ShortEffect { get; set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class VersionEncounterDetail
    {
        /// <summary>
        /// The game version this encounter happens in.
        /// </summary>
        public NamedApiResource Version { get; set; }

        /// <summary>
        /// The total percentage of all encounter potential.
        /// </summary>
        public int MaxChance { get; set; }

        /// <summary>
        /// A list of encounters and their specifics.
        /// </summary>
        public List<Encounter> EncounterDetails { get; set; }
    }

    public class VersionGameIndex
    {
        /// <summary>
        /// The internal id of an API resource within game data.
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The version relevent to this game index.
        /// </summary>
        public NamedApiResource Version { get; set; }
    }

    public class VersionGroupFlavorText
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource Language { get; set; }

        /// <summary>
        /// The version group which uses this flavor text.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }
    }

    abstract public class ReferTo<T>
    {
        string Url { get; set; }

        //T GetReferencedResource()
        //{

        //}
    }
}
