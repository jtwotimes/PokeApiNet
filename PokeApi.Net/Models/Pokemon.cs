using PokeApi.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    [ApiEndpoint("ability")]
    public class Ability
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
        /// Whether or not this ability originated in the main series of the video games.
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The generation this ability originated in.
        /// </summary>
        public NamedApiResource Generation { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages.
        /// </summary>
        public List<Names> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this ability has had across version groups.
        /// </summary>
        public List<AbilityEffectChange> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages.
        /// </summary>
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of Pokémon that could potentially have this ability.
        /// </summary>
        public List<AbilityPokemon> Pokemon { get; set; }
    }

    public class AbilityEffectChange
    {
        /// <summary>
        /// The previous effect of this ability listed in different languages.
        /// </summary>
        public List<Names> EffectEntries { get; set; }

        /// <summary>
        /// The version group in which the previous effect of this ability originated.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }
    }

    public class AbilityFlavorText
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this text resource is in.
        /// </summary>
        public NamedApiResource Language { get; set; }

        /// <summary>
        /// The version group that uses this flavor text.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }
    }

    public class AbilityPokemon
    {
        /// <summary>
        /// Whether or not this a hidden ability for the referenced Pokémon.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Pokémon have 3 ability 'slots' which hold references to possible
        /// abilities they could have. This is the slot of this ability for the
        /// referenced pokemon.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pokémon this ability could belong to.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }
    }

    [ApiEndpoint("characteristic")]
    public class Characteristic
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The remainder of the highest stat/IV divided by 5.
        /// </summary>
        public int GeneModulo { get; set; }

        /// <summary>
        /// The possible values of the highest stat that would result in
        /// a Pokémon recieving this characteristic when divided by 5.
        /// </summary>
        public List<int> PossibleValues { get; set; }
    }

    [ApiEndpoint("egg-group")]
    public class EggGroup
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
        ///	The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of all Pokémon species that are members of this egg group.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }
    }

    [ApiEndpoint("gender")]
    public class Gender
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
        /// A list of Pokémon species that can be this gender and how likely it
        /// is that they will be.
        /// </summary>
        public List<PokemonSpeciesGender> PokemonSpeciesDetails { get; set; }

        /// <summary>
        /// A list of Pokémon species that required this gender in order for a
        /// Pokémon to evolve into them.
        /// </summary>
        public List<NamedApiResource> RequiredForEvolution { get; set; }
    }

    public class PokemonSpeciesGender
    {
        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for
        /// genderless.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// A Pokémon species that can be the referenced gender.
        /// </summary>
        public NamedApiResource PokemonSpecies { get; set; }
    }

    [ApiEndpoint("growth-rate")]
    public class GrowthRate
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
        /// The formula used to calculate the rate at which the Pokémon species
        /// gains level.
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }

        /// <summary>
        /// A list of levels and the amount of experienced needed to atain them
        /// based on this growth rate.
        /// </summary>
        public List<GrowthRateExperienceLevel> Levels { get; set; }

        /// <summary>
        /// A list of Pokémon species that gain levels at this growth rate.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }
    }

    public class GrowthRateExperienceLevel
    {
        /// <summary>
        /// The level gained.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The amount of experience required to reach the referenced level.
        /// </summary>
        public int Experience { get; set; }
    }

    [ApiEndpoint("nature")]
    public class Nature
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
        /// The stat decreased by 10% in Pokémon with this nature.
        /// </summary>
        public NamedApiResource DescreasedStat { get; set; }

        /// <summary>
        /// The stat increased by 10% in Pokémon with this nature.
        /// </summary>
        public NamedApiResource IncreasedStat { get; set; }

        /// <summary>
        /// The flavor hated by Pokémon with this nature.
        /// </summary>
        public NamedApiResource HatesFlavor { get; set; }

        /// <summary>
        /// The flavor liked by Pokémon with this nature.
        /// </summary>
        public NamedApiResource LikesFlavor { get; set; }

        /// <summary>
        /// A list of Pokéathlon stats this nature effects and how much it
        /// effects them.
        /// </summary>
        public List<NatureStatChange> PokeathlonStatChanges { get; set; }

        /// <summary>
        /// A list of battle styles and how likely a Pokémon with this nature is
        /// to use them in the Battle Palace or Battle Tent.
        /// </summary>
        public List<MoveBattleStylePreference> MoveBattleStylePreferences { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    public class NatureStatChange
    {
        /// <summary>
        /// The amount of change.
        /// </summary>
        public int MaxChange { get; set; }

        /// <summary>
        /// The stat being affected.
        /// </summary>
        public NamedApiResource PokeathlonStat { get; set; }
    }

    public class MoveBattleStylePreference
    {
        /// <summary>
        /// Chance of using the move, in percent, if HP is under one half.
        /// </summary>
        public int LowHpPreference { get; set; }

        /// <summary>
        /// Chance of using the move, in percent, if HP is over one half.
        /// </summary>
        public int HighHpPreference { get; set; }

        /// <summary>
        /// The move battle style.
        /// </summary>
        public NamedApiResource MoveBattleStyle { get; set; }
    }

    [ApiEndpoint("pokeathlon-stat")]
    public class PokeathlonStat
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
        /// A detail of natures which affect this Pokéathlon stat positively
        /// or negatively.
        /// </summary>
        public NaturePokeathlonStatAffectSets AffectingNatures { get; set; }
    }

    public class NaturePokeathlonStatAffectSets
    {
        /// <summary>
        /// A list of natures and how they change the referenced Pokéathlon stat.
        /// </summary>
        public List<NaturePokeathlonStatAffect> Increase { get; set; }

        /// <summary>
        /// A list of natures and how they change the referenced Pokéathlon stat.
        /// </summary>
        public List<NaturePokeathlonStatAffect> Decrease{ get; set; }
    }

    public class NaturePokeathlonStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced Pokéathlon stat.
        /// </summary>
        public int MaxChange { get; set; }

        /// <summary>
        /// The nature causing the change.
        /// </summary>
        public NamedApiResource Nature { get; set; }
    }

    [ApiEndpoint("pokemon")]
    public class Pokemon
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
        /// The base experience gained for defeating this Pokémon.
        /// </summary>
        public int BaseExperience { get; set; }

        /// <summary>
        /// The height of this Pokémon in decimetres.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Set for exactly one Pokémon used as the default for each species.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Order for sorting. Almost national order, except families
        /// are grouped together.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The weight of this Pokémon in hectograms.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// A list of abilities this Pokémon could potentially have.
        /// </summary>
        public List<PokemonAbility> Abilities { get; set; }

        /// <summary>
        /// A list of forms this Pokémon can take on.
        /// </summary>
        public List<NamedApiResource> Forms { get; set; }

        /// <summary>
        /// A list of game indices relevent to Pokémon item by generation.
        /// </summary>
        public List<VersionGameIndex> GameIndicies { get; set; }

        /// <summary>
        /// A list of items this Pokémon may be holding when encountered.
        /// </summary>
        public List<PokemonHeldItem> HeldItems { get; set; }

        /// <summary>
        /// A link to a list of location areas, as well as encounter
        /// details pertaining to specific versions.
        /// </summary>
        public string LocationAreaEncounters { get; set; }

        /// <summary>
        /// A list of moves along with learn methods and level
        /// details pertaining to specific version groups.
        /// </summary>
        public List<PokemonMove> Moves { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon in the game.
        /// </summary>
        public PokemonSprites Sprites { get; set; }

        /// <summary>
        /// The species this Pokémon belongs to.
        /// </summary>
        public NamedApiResource Species { get; set; }

        /// <summary>
        /// A list of base stat values for this Pokémon.
        /// </summary>
        public List<PokemonStat> Stats { get; set; }

        /// <summary>
        /// A list of details showing types this Pokémon has.
        /// </summary>
        public List<PokemonType> Types { get; set; }
    }

    public class PokemonAbility
    {
        /// <summary>
        /// Whether or not this is a hidden ability.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// The slot this ability occupies in this Pokémon species.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The ability the Pokémon may have.
        /// </summary>
        public NamedApiResource Ability { get; set; }
    }

    public class PokemonType
    {
        /// <summary>
        /// The order the Pokémon's types are listed in.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The type the referenced Pokémon has.
        /// </summary>
        public NamedApiResource Type { get; set; }
    }

    public class PokemonHeldItem
    {
        /// <summary>
        /// The item the referenced Pokémon holds.
        /// </summary>
        public NamedApiResource Item { get; set; }

        /// <summary>
        /// The details of the different versions in which the item is held.
        /// </summary>
        public List<PokemonHeldItemVersion> VersionDetails { get; set; }
    }

    public class PokemonHeldItemVersion
    {
        /// <summary>
        /// The version in which the item is held.
        /// </summary>
        public NamedApiResource Version { get; set; }

        /// <summary>
        /// How often the item is held.
        /// </summary>
        public int Rarity { get; set; }
    }

    public class PokemonMove
    {
        /// <summary>
        /// The move the Pokémon can learn.
        /// </summary>
        public NamedApiResource Move { get; set; }

        /// <summary>
        /// The details of the version in which the Pokémon can learn the move.
        /// </summary>
        public List<PokemonMoveVersion> VersionGroupDetails { get; set; }
    }

    public class PokemonMoveVersion
    {
        /// <summary>
        /// The method by which the move is learned.
        /// </summary>
        public NamedApiResource MoveLearnMethod { get; set; }

        /// <summary>
        /// The version group in which the move is learned.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }

        /// <summary>
        /// The minimum level to learn the move.
        /// </summary>
        public int LevelLearnedAt { get; set; }
    }

    public class PokemonStat
    {
        /// <summary>
        /// The stat the Pokémon has.
        /// </summary>
        public NamedApiResource Stat { get; set; }

        /// <summary>
        /// The effort points (EV) the Pokémon has in the stat.
        /// </summary>
        public int Effort { get; set; }

        /// <summary>
        /// The base value of the stat.
        /// </summary>
        public int BaseStat { get; set; }
    }

    public class PokemonSprites
    {
        /// <summary>
        /// The default depiction of this Pokémon from the front in battle.
        /// </summary>
        public string FrontDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon from the front in battle.
        /// </summary>
        public string FrontShiny { get; set; }

        /// <summary>
        /// The female depiction of this Pokémon from the front in battle.
        /// </summary>
        public string FrontFemale { get; set; }

        /// <summary>
        /// The shiny female depiction of this Pokémon from the front in battle.
        /// </summary>
        public string FrontShinyFemale { get; set; }

        /// <summary>
        /// The default depiction of this Pokémon from the back in battle.
        /// </summary>
        public string BackDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon from the back in battle.
        /// </summary>
        public string BackShiny { get; set; }

        /// <summary>
        /// The female depiction of this Pokémon from the back in battle.
        /// </summary>
        public string BackFemale { get; set; }

        /// <summary>
        /// The shiny female depiction of this Pokémon from the back in battle.
        /// </summary>
        public string BackShinyFemale { get; set; }
    }

    public class LocationAreaEncounter
    {
        /// <summary>
        /// The location area the referenced Pokémon can be encountered in.
        /// </summary>
        public NamedApiResource LocationArea { get; set; }

        /// <summary>
        /// A list of versions and encounters with the referenced Pokémon
        /// that might happen.
        /// </summary>
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    [ApiEndpoint("pokemon-color")]
    public class PokemonColor
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
        /// A list of the Pokémon species that have this color.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }
    }

    [ApiEndpoint("pokemon-form")]
    public class PokemonForm
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
        /// The order in which forms should be sorted within all forms.
        /// Multiple forms may have equal order, in which case they should
        /// fall back on sorting by name.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The order in which forms should be sorted within a species' forms.
        /// </summary>
        public int FormOrder { get; set; }

        /// <summary>
        /// True for exactly one form used as the default for each Pokémon.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Whether or not this form can only happen during battle.
        /// </summary>
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// Whether or not this form requires mega evolution.
        /// </summary>
        public bool IsMega { get; set; }

        /// <summary>
        /// The name of this form.
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// The Pokémon that can take on this form.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon form in the game.
        /// </summary>
        public PokemonFormSprites Sprites { get; set; }

        /// <summary>
        /// The version group this Pokémon form was introduced in.
        /// </summary>
        public NamedApiResource VersionGroup { get; set; }

        /// <summary>
        /// The form specific full name of this Pokémon form, or empty if
        /// the form does not have a specific name.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The form specific form name of this Pokémon form, or empty if the
        /// form does not have a specific name.
        /// </summary>
        public List<Names> FormNames { get; set; }
    }

    public class PokemonFormSprites
    {
        /// <summary>
        /// The default depiction of this Pokémon form from the front in battle.
        /// </summary>
        public string FrontDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the front in battle.
        /// </summary>
        public string FrontShiny { get; set; }

        /// <summary>
        /// The default depiction of this Pokémon form from the back in battle.
        /// </summary>
        public string BackDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the back in battle.
        /// </summary>
        public string BackShiny { get; set; }
    }

    [ApiEndpoint("pokemon-habitat")]
    public class PokemonHabitat
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
        /// A list of the Pokémon species that can be found in this habitat.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }
    }

    [ApiEndpoint("pokemon-shape")]
    public class PokemonShape
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
        /// The "scientific" name of this Pokémon shape listed in
        /// different languages.
        /// </summary>
        public List<AwesomeNames> AwesomeNames { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of the Pokémon species that have this shape.
        /// </summary>
        public List<PokemonSpecies> PokemonSpecies { get; set; }
    }

    public class AwesomeNames
    {
        /// <summary>
        /// The localized "scientific" name for an API resource in a
        /// specific language.
        /// </summary>
        public string AwesomeName { get; set; }

        /// <summary>
        /// The language this "scientific" name is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    [ApiEndpoint("pokemon-species")]
    public class PokemonSpecies
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
        /// The order in which species should be sorted. Based on National Dex
        /// order, except families are grouped together and sorted by stage.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for
        /// genderless.
        /// </summary>
        public int GenderRate { get; set; }

        /// <summary>
        /// The base capture rate; up to 255. The higher the number, the easier 
        /// the catch.
        /// </summary>
        public int CaptureRate { get; set; }

        /// <summary>
        /// The happiness when caught by a normal Pokéball; up to 255. The higher
        /// the number, the happier the Pokémon.
        /// </summary>
        public int BaseHappiness { get; set; }

        /// <summary>
        /// Whether or not this is a baby Pokémon.
        /// </summary>
        public bool IsBaby { get; set; }

        /// <summary>
        /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps
        /// before this Pokémon's egg hatches, unless utilizing bonuses like
        /// Flame Body's.
        /// </summary>
        public int HatchCounter { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has visual gender differences.
        /// </summary>
        public bool HasGenderDifferences { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has multiple forms and can switch between
        /// them.
        /// </summary>
        public bool FormsSwitchable { get; set; }

        /// <summary>
        /// The rate at which this Pokémon species gains levels.
        /// </summary>
        public NamedApiResource GrowthRate { get; set; }

        /// <summary>
        /// A list of Pokedexes and the indexes reserved within them for this
        /// Pokémon species.
        /// </summary>
        public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }

        /// <summary>
        /// A list of egg groups this Pokémon species is a member of.
        /// </summary>
        public List<NamedApiResource> EggGroups { get; set; }

        /// <summary>
        /// The color of this Pokémon for Pokédex search.
        /// </summary>
        public NamedApiResource Color { get; set; }

        /// <summary>
        /// The shape of this Pokémon for Pokédex search.
        /// </summary>
        public NamedApiResource Shape { get; set; }

        /// <summary>
        /// The Pokémon species that evolves into this Pokemon_species.
        /// </summary>
        public NamedApiResource EvolvesFromSpecies { get; set; }

        /// <summary>
        /// The evolution chain this Pokémon species is a member of.
        /// </summary>
        public ApiResource EvolutionChain { get; set; }

        /// <summary>
        /// The habitat this Pokémon species can be encountered in.
        /// </summary>
        public NamedApiResource Habitat { get; set; }

        /// <summary>
        /// The generation this Pokémon species was introduced in.
        /// </summary>
        public NamedApiResource Generation { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of encounters that can be had with this Pokémon species in
        /// pal park.
        /// </summary>
        public List<PalParkEncounterArea> PalParkEncounters { get; set; }

        /// <summary>
        /// A list of flavor text entries for this Pokémon species.
        /// </summary>
        public List<FlavorTexts> FlavorTextEntries { get; set; }

        /// <summary>
        /// Descriptions of different forms Pokémon take on within the Pokémon
        /// species.
        /// </summary>
        public List<Descriptions> FormDescriptions { get; set; }

        /// <summary>
        /// The genus of this Pokémon species listed in multiple languages.
        /// </summary>
        public List<Genuses> Genera { get; set; }

        /// <summary>
        /// A list of the Pokémon that exist within this Pokémon species.
        /// </summary>
        public List<PokemonSpeciesVariety> Varieties { get; set; }
    }

    public class Genuses
    {
        /// <summary>
        /// The localized genus for the referenced Pokémon species
        /// </summary>
        public string Genus { get; set; }

        /// <summary>
        /// The language this genus is in.
        /// </summary>
        public NamedApiResource Language { get; set; }
    }

    public class PokemonSpeciesDexEntry
    {
        /// <summary>
        /// The index number within the Pokédex.
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokédex the referenced Pokémon species can be found in.
        /// </summary>
        public NamedApiResource Pokedex { get; set; }
    }

    public class PalParkEncounterArea
    {
        /// <summary>
        /// The base score given to the player when the referenced Pokémon is
        /// caught during a pal park run.
        /// </summary>
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering the referenced Pokémon in this pal
        /// park area.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The pal park area where this encounter happens.
        /// </summary>
        public NamedApiResource Area { get; set; }
    }

    public class PokemonSpeciesVariety
    {
        /// <summary>
        /// Whether this variety is the default variety.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// The Pokémon variety.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }
    }

    [ApiEndpoint("stat")]
    public class Stat
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
        /// ID the games use for this stat.
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// Whether this stat only exists within a battle.
        /// </summary>
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// A detail of moves which affect this stat positively or negatively.
        /// </summary>
        public MoveStatAffectSets AffectingMoves { get; set; }

        /// <summary>
        /// A detail of natures which affect this stat positively or negatively.
        /// </summary>
        public NatureStatAffectSets AffectingNatures { get; set; }

        /// <summary>
        /// A list of characteristics that are set on a Pokémon when its highest
        /// base stat is this stat.
        /// </summary>
        public ApiResource Characteristics { get; set; }

        /// <summary>
        /// The public class of damage this stat is directly related to.
        /// </summary>
        public NamedApiResource MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    public class MoveStatAffectSets
    {
        /// <summary>
        /// A list of moves and how they change the referenced stat.
        /// </summary>
        public MoveStatAffect Increase { get; set; }

        /// <summary>
        /// A list of moves and how they change the referenced stat.
        /// </summary>
        public MoveStatAffect Decrease { get; set; }
    }

    public class MoveStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced stat.
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The move causing the change.
        /// </summary>
        public NamedApiResource Move { get; set; }
    }

    public class NatureStatAffectSets
    {
        /// <summary>
        /// A list of natures and how they change the referenced stat.
        /// </summary>
        public List<NamedApiResource> Increase { get; set; }

        /// <summary>
        /// A list of natures and how they change the referenced stat.
        /// </summary>
        public List<NamedApiResource> Decrease { get; set; }
    }

    [ApiEndpoint("type")]
    public class Type
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
        /// A detail of how effective this type is toward others and vice versa.
        /// </summary>
        public TypeRelations DamageRelations { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation.
        /// </summary>
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// The generation this type was introduced in.
        /// </summary>
        public NamedApiResource Generation { get; set; }

        /// <summary>
        /// The public class of damage inflicted by this type.
        /// </summary>
        public NamedApiResource MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of details of Pokémon that have this type.
        /// </summary>
        public List<TypePokemon> Pokemon { get; set; }

        /// <summary>
        /// A list of moves that have this type.
        /// </summary>
        public List<NamedApiResource> Moves { get; set; }
    }

    public class TypePokemon
    {
        /// <summary>
        /// The order the Pokémon's types are listed in.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pokémon that has the referenced type.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }
    }

    public class TypeRelations
    {
        /// <summary>
        /// A list of types this type has no effect on.
        /// </summary>
        public List<NamedApiResource> NoDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is not very effect against.
        /// </summary>
        public List<NamedApiResource> HalfDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is very effect against.
        /// </summary>
        public List<NamedApiResource> DoubleDamageTo { get; set; }

        /// <summary>
        /// A list of types that have no effect on this type.
        /// </summary>
        public List<NamedApiResource> NoDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are not very effective against this type.
        /// </summary>
        public List<NamedApiResource> HalfDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are very effective against this type.
        /// </summary>
        public List<NamedApiResource> DoubleDamageFrom { get; set; }
    }
}
