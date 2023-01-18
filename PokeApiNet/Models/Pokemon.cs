using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Abilities provide passive effects for Pokémon in battle or in
    /// the overworld. Pokémon have multiple possible abilities but
    /// can have only one ability at a time.
    /// </summary>
    public class Ability : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "ability";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Whether or not this ability originated in the main series of the video games.
        /// </summary>
        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The generation this ability originated in.
        /// </summary>
        public NamedApiResource<Generation> Generation { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this ability has had across version groups.
        /// </summary>
        [JsonProperty("effect_changes")]
        public List<AbilityEffectChange> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of Pokémon that could potentially have this ability.
        /// </summary>
        public List<AbilityPokemon> Pokemon { get; set; }
    }

    /// <summary>
    /// An ability and it's associated versions
    /// </summary>
    public class AbilityEffectChange
    {
        /// <summary>
        /// The previous effect of this ability listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }

        /// <summary>
        /// The version group in which the previous effect of this ability originated.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    /// <summary>
    /// The flavor text for an ability
    /// </summary>
    public class AbilityFlavorText
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this text resource is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }

        /// <summary>
        /// The version group that uses this flavor text.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    /// <summary>
    /// A mapping of an ability to a possible Pokémon
    /// </summary>
    public class AbilityPokemon
    {
        /// <summary>
        /// Whether or not this a hidden ability for the referenced Pokémon.
        /// </summary>
        [JsonProperty("is_hidden")]
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
        public NamedApiResource<Pokemon> Pokemon { get; set; }
    }

    /// <summary>
    /// Characteristics indicate which stat contains a Pokémon's highest IV.
    /// A Pokémon's Characteristic is determined by the remainder of its
    /// highest IV divided by 5 (gene_modulo).
    /// </summary>
    public class Characteristic : ApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "characteristic";

        /// <summary>
        /// The remainder of the highest stat/IV divided by 5.
        /// </summary>
        [JsonProperty("gene_modulo")]
        public int GeneModulo { get; set; }

        /// <summary>
        /// The possible values of the highest stat that would result in
        /// a Pokémon recieving this characteristic when divided by 5.
        /// </summary>
        [JsonProperty("possible_values")]
        public List<int> PossibleValues { get; set; }

        /// <summary>
        /// The highest stat of this characteristic.
        /// </summary>
        [JsonProperty("highest_stat")]
        public NamedApiResource<Stat> HighestStat { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }
    }

    /// <summary>
    /// Egg Groups are categories which determine which Pokémon are able
    /// to interbreed. Pokémon may belong to either one or two Egg Groups.
    /// </summary>
    public class EggGroup : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "egg-group";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        ///	The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of all Pokémon species that are members of this egg group.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Genders were introduced in Generation II for the purposes of
    /// breeding Pokémon but can also result in visual differences or
    /// even different evolutionary lines
    /// </summary>
    public class Gender : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "gender";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of Pokémon species that can be this gender and how likely it
        /// is that they will be.
        /// </summary>
        [JsonProperty("pokemon_species_details")]
        public List<PokemonSpeciesGender> PokemonSpeciesDetails { get; set; }

        /// <summary>
        /// A list of Pokémon species that required this gender in order for a
        /// Pokémon to evolve into them.
        /// </summary>
        [JsonProperty("required_for_evolution")]
        public List<NamedApiResource<PokemonSpecies>> RequiredForEvolution { get; set; }
    }

    /// <summary>
    /// A rate of chance of a Pokémon being a specific gender
    /// </summary>
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
        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Growth rates are the speed with which Pokémon gain levels through experience.
    /// </summary>
    public class GrowthRate : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "growth-rate";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

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
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Information of a level and how much experience is needed to get to it
    /// </summary>
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

    /// <summary>
    /// Natures influence how a Pokémon's stats grow.
    /// </summary>
    public class Nature : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "nature";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The stat decreased by 10% in Pokémon with this nature.
        /// </summary>
        [JsonProperty("decreased_stat")]
        public NamedApiResource<Stat> DecreasedStat { get; set; }

        /// <summary>
        /// The stat increased by 10% in Pokémon with this nature.
        /// </summary>
        [JsonProperty("increased_stat")]
        public NamedApiResource<Stat> IncreasedStat { get; set; }

        /// <summary>
        /// The flavor hated by Pokémon with this nature.
        /// </summary>
        [JsonProperty("hates_flavor")]
        public NamedApiResource<BerryFlavor> HatesFlavor { get; set; }

        /// <summary>
        /// The flavor liked by Pokémon with this nature.
        /// </summary>
        [JsonProperty("likes_flavor")]
        public NamedApiResource<BerryFlavor> LikesFlavor { get; set; }

        /// <summary>
        /// A list of Pokéathlon stats this nature effects and how much it
        /// effects them.
        /// </summary>
        [JsonProperty("pokeathlon_stat_changes")]
        public List<NatureStatChange> PokeathlonStatChanges { get; set; }

        /// <summary>
        /// A list of battle styles and how likely a Pokémon with this nature is
        /// to use them in the Battle Palace or Battle Tent.
        /// </summary>
        [JsonProperty("move_battle_style_preferences")]
        public List<MoveBattleStylePreference> MoveBattleStylePreferences { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// The change information for a nature
    /// </summary>
    public class NatureStatChange
    {
        /// <summary>
        /// The amount of change.
        /// </summary>
        [JsonProperty("max_changes")]
        public int MaxChange { get; set; }

        /// <summary>
        /// The stat being affected.
        /// </summary>
        [JsonProperty("pokeathlon_stat")]
        public NamedApiResource<PokeathlonStat> PokeathlonStat { get; set; }
    }

    /// <summary>
    /// Move information for a battle style
    /// </summary>
    public class MoveBattleStylePreference
    {
        /// <summary>
        /// Chance of using the move, in percent, if HP is under one half.
        /// </summary>
        [JsonProperty("low_hp_preference")]
        public int LowHpPreference { get; set; }

        /// <summary>
        /// Chance of using the move, in percent, if HP is over one half.
        /// </summary>
        [JsonProperty("high_hp_preference")]
        public int HighHpPreference { get; set; }

        /// <summary>
        /// The move battle style.
        /// </summary>
        [JsonProperty("move_battle_style")]
        public NamedApiResource<MoveBattleStyle> MoveBattleStyle { get; set; }
    }

    /// <summary>
    /// Pokeathlon Stats are different attributes of a Pokémon's performance
    /// in Pokéathlons. In Pokéathlons, competitions happen on different
    /// courses; one for each of the different Pokéathlon stats.
    /// </summary>
    public class PokeathlonStat : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokeathlon-stat";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A detail of natures which affect this Pokéathlon stat positively
        /// or negatively.
        /// </summary>
        [JsonProperty("affecting_natures")]
        public NaturePokeathlonStatAffectSets AffectingNatures { get; set; }
    }

    /// <summary>
    /// The natures and how they are changed with the referenced Pokéathlon stat
    /// </summary>
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

    /// <summary>
    /// The change information for a Pokéathlon stat
    /// </summary>
    public class NaturePokeathlonStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced Pokéathlon stat.
        /// </summary>
        [JsonProperty("max_change")]
        public int MaxChange { get; set; }

        /// <summary>
        /// The nature causing the change.
        /// </summary>
        public NamedApiResource<Nature> Nature { get; set; }
    }

    /// <summary>
    /// Pokémon are the creatures that inhabit the world of the Pokémon games.
    /// They can be caught using Pokéballs and trained by battling with other Pokémon.
    /// Each Pokémon belongs to a specific species but may take on a variant which
    /// makes it differ from other Pokémon of the same species, such as base stats,
    /// available abilities and typings.
    /// </summary>
    public class Pokemon : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The base experience gained for defeating this Pokémon.
        /// </summary>
        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        /// <summary>
        /// The height of this Pokémon in decimetres.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Set for exactly one Pokémon used as the default for each species.
        /// </summary>
        [JsonProperty("is_default")]
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
        public List<NamedApiResource<PokemonForm>> Forms { get; set; }

        /// <summary>
        /// A list of game indices relevent to Pokémon item by generation.
        /// </summary>
        [JsonProperty("game_indices")]
        public List<VersionGameIndex> GameIndicies { get; set; }

        /// <summary>
        /// A list of items this Pokémon may be holding when encountered.
        /// </summary>
        [JsonProperty("held_items")]
        public List<PokemonHeldItem> HeldItems { get; set; }

        /// <summary>
        /// A link to a list of location areas, as well as encounter
        /// details pertaining to specific versions.
        /// </summary>
        [JsonProperty("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        /// <summary>
        /// A list of moves along with learn methods and level
        /// details pertaining to specific version groups.
        /// </summary>
        public List<PokemonMove> Moves { get; set; }

        /// <summary>
        /// Type data in previous generations for this Pokemon.
        /// </summary>
        [JsonProperty("past_types")]
        public List<PokemonPastTypes> PastTypes { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon in the game.
        /// </summary>
        public PokemonSprites Sprites { get; set; }

        /// <summary>
        /// The species this Pokémon belongs to.
        /// </summary>
        public NamedApiResource<PokemonSpecies> Species { get; set; }

        /// <summary>
        /// A list of base stat values for this Pokémon.
        /// </summary>
        public List<PokemonStat> Stats { get; set; }

        /// <summary>
        /// A list of details showing types this Pokémon has.
        /// </summary>
        public List<PokemonType> Types { get; set; }
    }

    /// <summary>
    /// A Pokémon ability
    /// </summary>
    public class PokemonAbility
    {
        /// <summary>
        /// Whether or not this is a hidden ability.
        /// </summary>
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        /// <summary>
        /// The slot this ability occupies in this Pokémon species.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The ability the Pokémon may have.
        /// </summary>
        public NamedApiResource<Ability> Ability { get; set; }
    }

    /// <summary>
    /// A Pokémon type
    /// </summary>
    public class PokemonType
    {
        /// <summary>
        /// The order the Pokémon's types are listed in.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The type the referenced Pokémon has.
        /// </summary>
        public NamedApiResource<Type> Type { get; set; }
    }

    /// <summary>
    /// Class for storing a Pokemon's type data in a previous generation.
    /// </summary>
    public class PokemonPastTypes : PastGenerationData<List<PokemonType>>
    {
        /// <summary>
        /// The previous list of types.
        /// </summary>
        public List<PokemonType> Types
        {
            get => Data;
            set { Data = value; }
        }
    }

    /// <summary>
    /// A Pokémon held item
    /// </summary>
    public class PokemonHeldItem
    {
        /// <summary>
        /// The item the referenced Pokémon holds.
        /// </summary>
        public NamedApiResource<Item> Item { get; set; }

        /// <summary>
        /// The details of the different versions in which the item is held.
        /// </summary>
        [JsonProperty("version_details")]
        public List<PokemonHeldItemVersion> VersionDetails { get; set; }
    }

    /// <summary>
    /// A Pokémon held item and version information
    /// </summary>
    public class PokemonHeldItemVersion
    {
        /// <summary>
        /// The version in which the item is held.
        /// </summary>
        public NamedApiResource<Version> Version { get; set; }

        /// <summary>
        /// How often the item is held.
        /// </summary>
        public int Rarity { get; set; }
    }

    /// <summary>
    /// A reference to a move and the version information
    /// </summary>
    public class PokemonMove
    {
        /// <summary>
        /// The move the Pokémon can learn.
        /// </summary>
        public NamedApiResource<Move> Move { get; set; }

        /// <summary>
        /// The details of the version in which the Pokémon can learn the move.
        /// </summary>
        [JsonProperty("version_group_details")]
        public List<PokemonMoveVersion> VersionGroupDetails { get; set; }
    }

    /// <summary>
    /// The moves a Pokémon learns in which versions
    /// </summary>
    public class PokemonMoveVersion
    {
        /// <summary>
        /// The method by which the move is learned.
        /// </summary>
        [JsonProperty("move_learn_method")]
        public NamedApiResource<MoveLearnMethod> MoveLearnMethod { get; set; }

        /// <summary>
        /// The version group in which the move is learned.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }

        /// <summary>
        /// The minimum level to learn the move.
        /// </summary>
        [JsonProperty("level_learned_at")]
        public int LevelLearnedAt { get; set; }
    }

    /// <summary>
    /// A Pokémon stat
    /// </summary>
    public class PokemonStat
    {
        /// <summary>
        /// The stat the Pokémon has.
        /// </summary>
        public NamedApiResource<Stat> Stat { get; set; }

        /// <summary>
        /// The effort points (EV) the Pokémon has in the stat.
        /// </summary>
        public int Effort { get; set; }

        /// <summary>
        /// The base value of the stat.
        /// </summary>
        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }
    }

    /// <summary>
    /// Pokémon sprite information
    /// </summary>
    public class PokemonSprites
    {
        /// <summary>
        /// The default depiction of this Pokémon from the front in battle.
        /// </summary>
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon from the front in battle.
        /// </summary>
        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }

        /// <summary>
        /// The female depiction of this Pokémon from the front in battle.
        /// </summary>
        [JsonProperty("front_female")]
        public string FrontFemale { get; set; }

        /// <summary>
        /// The shiny female depiction of this Pokémon from the front in battle.
        /// </summary>
        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale { get; set; }

        /// <summary>
        /// The default depiction of this Pokémon from the back in battle.
        /// </summary>
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon from the back in battle.
        /// </summary>
        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }

        /// <summary>
        /// The female depiction of this Pokémon from the back in battle.
        /// </summary>
        [JsonProperty("back_female")]
        public string BackFemale { get; set; }

        /// <summary>
        /// The shiny female depiction of this Pokémon from the back in battle.
        /// </summary>
        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale { get; set; }

        /// <summary>
        /// Other sprites
        /// </summary>
        public OtherSprites Other { get; set; }

        /// <summary>
        /// Pókemon sprites versioned by game generation
        /// </summary>
        public VersionSprites Versions { get; set; }

        /// <summary>
        /// Other Pokémon sprites
        /// </summary>
        public class OtherSprites
        {
            /// <summary>
            /// DreamWorld sprites
            /// </summary>
            [JsonProperty("dream_world")]
            public DreamWorldSprites DreamWorld { get; set; }

            /// <summary>
            /// Home sprites
            /// </summary>
            public HomeSprites Home { get; set; }

            /// <summary>
            /// Official Artwork sprites
            /// </summary>
            [JsonProperty("official-artwork")]
            public OfficialArtworkSprites OfficialArtwork { get; set; }

            /// <summary>
            /// DreamWorld Pókemon sprites
            /// </summary>
            public class DreamWorldSprites
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The female depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_female")]
                public string FrontFemale { get; set; }
            }

            /// <summary>
            /// Home Pókemon sprites
            /// </summary>
            public class HomeSprites
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The female depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The shiny depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_shiny")]
                public string FrontShiny { get; set; }

                /// <summary>
                /// The shiny female depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }

            /// <summary>
            /// Official Artwork sprites
            /// </summary>
            public class OfficialArtworkSprites
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_default")]
                public string FrontDefault { get; set; }
                
                /// <summary>
                /// The shiny depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonProperty("front_shiny")]
                public string FrontShiny { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites versioned by game generation
        /// </summary>
        public class VersionSprites
        {
            /// <summary>
            /// Pókemon sprites for Generation I
            /// </summary>
            [JsonProperty("generation-i")]
            public GenerationISprites GenerationI { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation II
            /// </summary>
            [JsonProperty("generation-ii")]
            public GenerationIISprites GenerationII { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation III
            /// </summary>
            [JsonProperty("generation-iii")]
            public GenerationIIISprites GenerationIII { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation IV
            /// </summary>
            [JsonProperty("generation-iv")]
            public GenerationIVSprites GenerationIV { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation V
            /// </summary>
            [JsonProperty("generation-v")]
            public GenerationVSprites GenerationV { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation VI
            /// </summary>
            [JsonProperty("generation-vi")]
            public GenerationVISprites GenerationVI { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation VII
            /// </summary>
            [JsonProperty("generation-vii")]
            public GenerationVIISprites GenerationVII { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation VIII
            /// </summary>
            [JsonProperty("generation-viii")]
            public GenerationVIIISprites GenerationVIII { get; set; }

            /// <summary>
            /// Pókemon sprites for Generation I
            /// </summary>
            public class GenerationISprites
            {
                /// <summary>
                /// Pókemon Red-Blue sprites
                /// </summary>
                [JsonProperty("red-blue")]
                public RedBlueSprites RedBlue { get; set; }

                /// <summary>
                /// Pókemon Yellow sprites
                /// </summary>
                public YellowSprites Yellow { get; set; }

                /// <summary>
                /// Pókemon Red-Blue sprites
                /// </summary>
                public class RedBlueSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle on gray background.
                    /// </summary>
                    [JsonProperty("back_gray")]
                    public string BackGray { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle on transparent background.
                    /// </summary>
                    [JsonProperty("back_transparent")]
                    public string BackTransparent { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on gray background.
                    /// </summary>
                    [JsonProperty("front_gray")]
                    public string FrontGray { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_transparent")]
                    public string FrontTransparent { get; set; }

                }

                /// <summary>
                /// Pókemon Yellow sprites
                /// </summary>
                public class YellowSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle on gray background.
                    /// </summary>
                    [JsonProperty("back_gray")]
                    public string BackGray { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle on transparent background.
                    /// </summary>
                    [JsonProperty("back_transparent")]
                    public string BackTransparent { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on gray background.
                    /// </summary>
                    [JsonProperty("front_gray")]
                    public string FrontGray { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_transparent")]
                    public string FrontTransparent { get; set; }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation II
            /// </summary>
            public class GenerationIISprites
            {
                /// <summary>
                /// Pókemon Crystal sprites
                /// </summary>
                public CrystalSprites Crystal { get; set; }

                /// <summary>
                /// Pókemon Gold sprites
                /// </summary>
                public GoldSprites Gold { get; set; }

                /// <summary>
                /// Pókemon Silver sprites
                /// </summary>
                public SilverSprites Silver { get; set; }

                /// <summary>
                /// Pókemon Crystal sprites
                /// </summary>
                public class CrystalSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle on transparent background.
                    /// </summary>
                    [JsonProperty("back_shiny_transparent")]
                    public string BackShinyTransparent { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle on transparent background.
                    /// </summary>
                    [JsonProperty("back_transparent")]
                    public string BackTransparent { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_shiny_transparent")]
                    public string FrontShinyTransparent { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_transparent")]
                    public string FrontTransparent { get; set; }

                }

                /// <summary>
                /// Pókemon Gold sprites
                /// </summary>
                public class GoldSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_transparent")]
                    public string FrontTransparent { get; set; }
                }

                /// <summary>
                /// Pókemon Silver sprites
                /// </summary>
                public class SilverSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle on transparent background.
                    /// </summary>
                    [JsonProperty("front_transparent")]
                    public string FrontTransparent { get; set; }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation III
            /// </summary>
            public class GenerationIIISprites
            {
                /// <summary>
                /// Pókemon Emerald sprites
                /// </summary>
                [JsonProperty("emerald")]
                public EmeraldSprites Emerald { get; set; }

                /// <summary>
                /// Pókemon Firered/Leafgreen sprites
                /// </summary>
                [JsonProperty("firered-leafgreen")]
                public FireredLeafgreenSprites FireredLeafgreen { get; set; }

                /// <summary>
                /// Pókemon Ruby/Sapphire sprites
                /// </summary>
                [JsonProperty("ruby-sapphire")]
                public RubySapphireSprites RubySapphire { get; set; }

                /// <summary>
                /// Pókemon Emerald sprites
                /// </summary>
                public class EmeraldSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }
                }

                /// <summary>
                /// Pókemon Firered/Leafgreen sprites
                /// </summary>
                public class FireredLeafgreenSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }
                }

                /// <summary>
                /// Pókemon Ruby/Sapphire sprites
                /// </summary>
                public class RubySapphireSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation IV
            /// </summary>
            public class GenerationIVSprites
            {
                /// <summary>
                /// Pókemon Diamond/Pearl sprites
                /// </summary>
                [JsonProperty("diamond-pearl")]
                public DiamondPearlSprites DiamondPearl { get; set; }

                /// <summary>
                /// Pókemon Heartgold/Soulsilver sprites
                /// </summary>
                [JsonProperty("heartgold-soulsilver")]
                public HeartGoldSoulSilverSprites HeartGoldSoulSilver { get; set; }

                /// <summary>
                /// Pókemon Platinum sprites
                /// </summary>
                public PlatinumSprites Platinum { get; set; }

                /// <summary>
                /// Pókemon Diamond/Pearl sprites
                /// </summary>
                public class DiamondPearlSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female in battle.
                    /// </summary>
                    [JsonProperty("back_female")]
                    public string BackFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny_female")]
                    public string BackShinyFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }

                /// <summary>
                /// Pókemon Heartgold/Soulsilver sprites
                /// </summary>
                public class HeartGoldSoulSilverSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female in battle.
                    /// </summary>
                    [JsonProperty("back_female")]
                    public string BackFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny_female")]
                    public string BackShinyFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }

                /// <summary>
                /// Pókemon Platinum sprites
                /// </summary>
                public class PlatinumSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female in battle.
                    /// </summary>
                    [JsonProperty("back_female")]
                    public string BackFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny_female")]
                    public string BackShinyFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation V
            /// </summary>
            public class GenerationVSprites
            {
                /// <summary>
                /// Pókemon Black/White sprites
                /// </summary>
                [JsonProperty("black-white")]
                public BlackWhiteSprites BlackWhite { get; set; }

                /// <summary>
                /// Pókemon Black/White sprites
                /// </summary>
                public class BlackWhiteSprites
                {
                    /// <summary>
                    /// The animated depiction of this Pokémon from the back in battle.
                    /// </summary>
                    public AnimatedSprites Animated { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonProperty("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female in battle.
                    /// </summary>
                    [JsonProperty("back_female")]
                    public string BackFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female shiny in battle.
                    /// </summary>
                    [JsonProperty("back_shiny_female")]
                    public string BackShinyFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }

                    /// <summary>
                    /// The animated depiction of this Pokémon from the back in battle.
                    /// </summary>
                    public class AnimatedSprites
                    {
                        /// <summary>
                        /// The default depiction of this Pokémon from the back in battle.
                        /// </summary>
                        [JsonProperty("back_default")]
                        public string BackDefault { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the back female in battle.
                        /// </summary>
                        [JsonProperty("back_female")]
                        public string BackFemale { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the back shiny in battle.
                        /// </summary>
                        [JsonProperty("back_shiny")]
                        public string BackShiny { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the back female shiny in battle.
                        /// </summary>
                        [JsonProperty("back_shiny_female")]
                        public string BackShinyFemale { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the front in battle.
                        /// </summary>
                        [JsonProperty("front_default")]
                        public string FrontDefault { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the front female in battle.
                        /// </summary>
                        [JsonProperty("front_female")]
                        public string FrontFemale { get; set; }

                        /// <summary>
                        /// The default depiction of this Pokémon from the front shiny in battle.
                        /// </summary>
                        [JsonProperty("front_shiny")]
                        public string FrontShiny { get; set; }

                        // <summary>
                        /// The default depiction of this Pokémon from the front female shiny in battle.
                        /// </summary>
                        [JsonProperty("front_shiny_female")]
                        public string FrontShinyFemale { get; set; }
                    }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation VI
            /// </summary>
            public class GenerationVISprites
            {
                /// <summary>
                /// Pókemon OmegaRuby/AlphaSapphire sprites
                /// </summary>
                [JsonProperty("omegaruby-alphasapphire")]
                public OmegaRubyAlphaSapphireSprites OmegaRubyAlphaSapphire { get; set; }

                /// <summary>
                /// Pókemon X/Y sprites
                /// </summary>
                [JsonProperty("x-y")]
                public XYSprites XY { get; set; }

                /// <summary>
                /// Pókemon OmegaRuby/AlphaSapphire sprites
                /// </summary>
                public class OmegaRubyAlphaSapphireSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }

                /// <summary>
                /// Pókemon X/Y sprites
                /// </summary>
                public class XYSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }

            }

            /// <summary>
            /// Pókemon sprites for Generation VII
            /// </summary>
            public class GenerationVIISprites
            {
                /// <summary>
                /// Pókemon Icons sprites
                /// </summary>
                public IconsSprites Icons { get; set; }

                /// <summary>
                /// Pókemon UltraSun/UltraMoon sprites
                /// </summary>
                [JsonProperty("ultra-sun-ultra-moon")]
                public UltraSunUltraMoonSprites UltraSunUltraMoon { get; set; }

                /// <summary>
                /// Pókemon Icons sprites
                /// </summary>
                public class IconsSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }
                }

                /// <summary>
                /// Pókemon UltraSun/UltraMoon sprites
                /// </summary>
                public class UltraSunUltraMoonSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonProperty("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }
            }

            /// <summary>
            /// Pókemon sprites for Generation VIII
            /// </summary>
            public class GenerationVIIISprites
            {
                /// <summary>
                /// Pókemon Icons sprites
                /// </summary>
                public IconsSprites Icons { get; set; }

                /// <summary>
                /// Pókemon Icons sprites
                /// </summary>
                public class IconsSprites
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonProperty("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonProperty("front_female")]
                    public string FrontFemale { get; set; }
                }
            }
        }
    }

    /// <summary>
    /// A list of possible encounter locations for a Pokémon with the version information
    /// </summary>
    public class LocationAreaEncounter
    {
        /// <summary>
        /// The location area the referenced Pokémon can be encountered in.
        /// </summary>
        [JsonProperty("location_area")]
        public NamedApiResource<LocationArea> LocationArea { get; set; }

        /// <summary>
        /// A list of versions and encounters with the referenced Pokémon
        /// that might happen.
        /// </summary>
        [JsonProperty("version_details")]
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    /// <summary>
    /// Colors used for sorting Pokémon in a Pokédex. The color listed in the
    /// Pokédex is usually the color most apparent or covering each Pokémon's
    /// body. No orange category exists; Pokémon that are primarily orange are
    /// listed as red or brown.
    /// </summary>
    public class PokemonColor : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-color";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of the Pokémon species that have this color.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Some Pokémon may appear in one of multiple, visually different
    /// forms. These differences are purely cosmetic. For variations
    /// within a Pokémon species, which do differ in more than just visuals,
    /// the 'Pokémon' entity is used to represent such a variety.
    /// </summary>
    public class PokemonForm : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-form";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The order in which forms should be sorted within all forms.
        /// Multiple forms may have equal order, in which case they should
        /// fall back on sorting by name.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The order in which forms should be sorted within a species' forms.
        /// </summary>
        [JsonProperty("form_order")]
        public int FormOrder { get; set; }

        /// <summary>
        /// True for exactly one form used as the default for each Pokémon.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Whether or not this form can only happen during battle.
        /// </summary>
        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// Whether or not this form requires mega evolution.
        /// </summary>
        [JsonProperty("is_mega")]
        public bool IsMega { get; set; }

        /// <summary>
        /// The name of this form.
        /// </summary>
        [JsonProperty("form_name")]
        public string FormName { get; set; }

        /// <summary>
        /// The Pokémon that can take on this form.
        /// </summary>
        public NamedApiResource<Pokemon> Pokemon { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon form in the game.
        /// </summary>
        public PokemonFormSprites Sprites { get; set; }

        /// <summary>
        /// The version group this Pokémon form was introduced in.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }

        /// <summary>
        /// The form specific full name of this Pokémon form, or empty if
        /// the form does not have a specific name.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The form specific form name of this Pokémon form, or empty if the
        /// form does not have a specific name.
        /// </summary>
        [JsonProperty("form_names")]
        public List<Names> FormNames { get; set; }
    }

    /// <summary>
    /// Pokémon sprite information with relation to a form
    /// </summary>
    public class PokemonFormSprites
    {
        /// <summary>
        /// The default depiction of this Pokémon form from the front in battle.
        /// </summary>
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the front in battle.
        /// </summary>
        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }

        /// <summary>
        /// The default depiction of this Pokémon form from the back in battle.
        /// </summary>
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the back in battle.
        /// </summary>
        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }
    }

    /// <summary>
    /// Habitats are generally different terrain Pokémon can be found in but
    /// can also be areas designated for rare or legendary Pokémon.
    /// </summary>
    public class PokemonHabitat : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-habitat";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of the Pokémon species that can be found in this habitat.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// Shapes used for sorting Pokémon in a Pokédex.
    /// </summary>
    public class PokemonShape : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-shape";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The "scientific" name of this Pokémon shape listed in
        /// different languages.
        /// </summary>
        [JsonProperty("awesome_names")]
        public List<AwesomeNames> AwesomeNames { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of the Pokémon species that have this shape.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    /// <summary>
    /// The "scientific" name for an API resource and the language information
    /// </summary>
    public class AwesomeNames
    {
        /// <summary>
        /// The localized "scientific" name for an API resource in a
        /// specific language.
        /// </summary>
        [JsonProperty("awesome_name")]
        public string AwesomeName { get; set; }

        /// <summary>
        /// The language this "scientific" name is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }

    /// <summary>
    /// A Pokémon Species forms the basis for at least one Pokémon. Attributes
    /// of a Pokémon species are shared across all varieties of Pokémon within
    /// the species. A good example is Wormadam; Wormadam is the species which
    /// can be found in three different varieties, Wormadam-Trash,
    /// Wormadam-Sandy and Wormadam-Plant.
    /// </summary>
    public class PokemonSpecies : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-species";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The order in which species should be sorted. Based on National Dex
        /// order, except families are grouped together and sorted by stage.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for
        /// genderless.
        /// </summary>
        [JsonProperty("gender_rate")]
        public int GenderRate { get; set; }

        /// <summary>
        /// The base capture rate; up to 255. The higher the number, the easier
        /// the catch.
        /// </summary>
        [JsonProperty("capture_rate")]
        public int? CaptureRate { get; set; }

        /// <summary>
        /// The happiness when caught by a normal Pokéball; up to 255. The higher
        /// the number, the happier the Pokémon.
        /// </summary>
        [JsonProperty("base_happiness")]
        public int? BaseHappiness { get; set; }

        /// <summary>
        /// Whether or not this is a baby Pokémon.
        /// </summary>
        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        /// <summary>
        /// Whether or not this is a legendary Pokémon.
        /// </summary>
        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

        /// <summary>
        /// Whether or not this is a mythical Pokémon.
        /// </summary>
        [JsonProperty("is_mythical")]
        public bool IsMythical { get; set; }

        /// <summary>
        /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps
        /// before this Pokémon's egg hatches, unless utilizing bonuses like
        /// Flame Body's.
        /// </summary>
        [JsonProperty("hatch_counter")]
        public int? HatchCounter { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has visual gender differences.
        /// </summary>
        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has multiple forms and can switch between
        /// them.
        /// </summary>
        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        /// <summary>
        /// The rate at which this Pokémon species gains levels.
        /// </summary>
        [JsonProperty("growth_rate")]
        public NamedApiResource<GrowthRate> GrowthRate { get; set; }

        /// <summary>
        /// A list of Pokedexes and the indexes reserved within them for this
        /// Pokémon species.
        /// </summary>
        [JsonProperty("pokedex_numbers")]
        public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }

        /// <summary>
        /// A list of egg groups this Pokémon species is a member of.
        /// </summary>
        [JsonProperty("egg_groups")]
        public List<NamedApiResource<EggGroup>> EggGroups { get; set; }

        /// <summary>
        /// The color of this Pokémon for Pokédex search.
        /// </summary>
        public NamedApiResource<PokemonColor> Color { get; set; }

        /// <summary>
        /// The shape of this Pokémon for Pokédex search.
        /// </summary>
        public NamedApiResource<PokemonShape> Shape { get; set; }

        /// <summary>
        /// The Pokémon species that evolves into this Pokemon_species.
        /// </summary>
        [JsonProperty("evolves_from_species")]
        public NamedApiResource<PokemonSpecies> EvolvesFromSpecies { get; set; }

        /// <summary>
        /// The evolution chain this Pokémon species is a member of.
        /// </summary>
        [JsonProperty("evolution_chain")]
        public ApiResource<EvolutionChain> EvolutionChain { get; set; }

        /// <summary>
        /// The habitat this Pokémon species can be encountered in.
        /// </summary>
        public NamedApiResource<PokemonHabitat> Habitat { get; set; }

        /// <summary>
        /// The generation this Pokémon species was introduced in.
        /// </summary>
        public NamedApiResource<Generation> Generation { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of encounters that can be had with this Pokémon species in
        /// pal park.
        /// </summary>
        [JsonProperty("pal_park_encounters")]
        public List<PalParkEncounterArea> PalParkEncounters { get; set; }

        /// <summary>
        /// A list of flavor text entries for this Pokémon species.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<PokemonSpeciesFlavorTexts> FlavorTextEntries { get; set; }

        /// <summary>
        /// Descriptions of different forms Pokémon take on within the Pokémon
        /// species.
        /// </summary>
        [JsonProperty("form_descriptions")]
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

    /// <summary>
    /// The flavor text for a Pokémon species
    /// </summary>
    public class PokemonSpeciesFlavorTexts
    {
        /// <summary>
        /// The localized flavor text for an api resource in a specific language
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The game version this flavor text is extracted from.
        /// </summary>
        public NamedApiResource<Version> Version { get; set; }

        /// <summary>
        /// The language this flavor text is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }

    /// <summary>
    /// The genus information for a Pokémon and the associated language
    /// </summary>
    public class Genuses
    {
        /// <summary>
        /// The localized genus for the referenced Pokémon species
        /// </summary>
        public string Genus { get; set; }

        /// <summary>
        /// The language this genus is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }

    /// <summary>
    /// The Pokémon Pokédex entry information
    /// </summary>
    public class PokemonSpeciesDexEntry
    {
        /// <summary>
        /// The index number within the Pokédex.
        /// </summary>
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokédex the referenced Pokémon species can be found in.
        /// </summary>
        public NamedApiResource<Pokedex> Pokedex { get; set; }
    }

    /// <summary>
    /// Information for a PalPark area
    /// </summary>
    public class PalParkEncounterArea
    {
        /// <summary>
        /// The base score given to the player when the referenced Pokémon is
        /// caught during a pal park run.
        /// </summary>
        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering the referenced Pokémon in this pal
        /// park area.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The pal park area where this encounter happens.
        /// </summary>
        public NamedApiResource<PalParkArea> Area { get; set; }
    }

    /// <summary>
    /// A variety of a Pokémon species
    /// </summary>
    public class PokemonSpeciesVariety
    {
        /// <summary>
        /// Whether this variety is the default variety.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// The Pokémon variety.
        /// </summary>
        public NamedApiResource<Pokemon> Pokemon { get; set; }
    }

    /// <summary>
    /// Stats determine certain aspects of battles. Each Pokémon has a value
    /// for each stat which grows as they gain levels and can be altered
    /// momentarily by effects in battles.
    /// </summary>
    public class Stat : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "stat";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// ID the games use for this stat.
        /// </summary>
        [JsonProperty("game_index")]
        public int GameIndex { get; set; }

        /// <summary>
        /// Whether this stat only exists within a battle.
        /// </summary>
        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// A detail of moves which affect this stat positively or negatively.
        /// </summary>
        [JsonProperty("affecting_moves")]
        public MoveStatAffectSets AffectingMoves { get; set; }

        /// <summary>
        /// A detail of natures which affect this stat positively or negatively.
        /// </summary>
        [JsonProperty("affecting_natures")]
        public NatureStatAffectSets AffectingNatures { get; set; }

        /// <summary>
        /// A list of characteristics that are set on a Pokémon when its highest
        /// base stat is this stat.
        /// </summary>
        public List<ApiResource<Characteristic>> Characteristics { get; set; }

        /// <summary>
        /// The public class of damage this stat is directly related to.
        /// </summary>
        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// A list of moves and how they change statuses
    /// </summary>
    public class MoveStatAffectSets
    {
        /// <summary>
        /// A list of moves and how they change the referenced stat.
        /// </summary>
        public List<MoveStatAffect> Increase { get; set; }

        /// <summary>
        /// A list of moves and how they change the referenced stat.
        /// </summary>
        public List<MoveStatAffect> Decrease { get; set; }
    }

    /// <summary>
    /// A reference to a move and the change to a status
    /// </summary>
    public class MoveStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced stat.
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The move causing the change.
        /// </summary>
        public NamedApiResource<Move> Move { get; set; }
    }

    /// <summary>
    /// A reference to a nature and the change to a status
    /// </summary>
    public class NatureStatAffectSets
    {
        /// <summary>
        /// A list of natures and how they change the referenced stat.
        /// </summary>
        public List<NamedApiResource<Nature>> Increase { get; set; }

        /// <summary>
        /// A list of natures and how they change the referenced stat.
        /// </summary>
        public List<NamedApiResource<Nature>> Decrease { get; set; }
    }

    /// <summary>
    /// Types are properties for Pokémon and their moves. Each type has three
    /// properties: which types of Pokémon it is super effective against,
    /// which types of Pokémon it is not very effective against, and which types
    /// of Pokémon it is completely ineffective against.
    /// </summary>
    public class Type : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "type";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A detail of how effective this type is toward others and vice versa.
        /// </summary>
        [JsonProperty("damage_relations")]
        public TypeRelations DamageRelations { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation.
        /// </summary>
        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// The generation this type was introduced in.
        /// </summary>
        public NamedApiResource<Generation> Generation { get; set; }

        /// <summary>
        /// The public class of damage inflicted by this type.
        /// </summary>
        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; set; }

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
        public List<NamedApiResource<Move>> Moves { get; set; }
    }

    /// <summary>
    /// A Pokémon type information
    /// </summary>
    public class TypePokemon
    {
        /// <summary>
        /// The order the Pokémon's types are listed in.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pokémon that has the referenced type.
        /// </summary>
        public NamedApiResource<Pokemon> Pokemon { get; set; }
    }

    /// <summary>
    /// The information for how a type interacts with other types
    /// </summary>
    public class TypeRelations
    {
        /// <summary>
        /// A list of types this type has no effect on.
        /// </summary>
        [JsonProperty("no_damage_to")]
        public List<NamedApiResource<Type>> NoDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is not very effect against.
        /// </summary>
        [JsonProperty("half_damage_to")]
        public List<NamedApiResource<Type>> HalfDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is very effect against.
        /// </summary>
        [JsonProperty("double_damage_to")]
        public List<NamedApiResource<Type>> DoubleDamageTo { get; set; }

        /// <summary>
        /// A list of types that have no effect on this type.
        /// </summary>
        [JsonProperty("no_damage_from")]
        public List<NamedApiResource<Type>> NoDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are not very effective against this type.
        /// </summary>
        [JsonProperty("half_damage_from")]
        public List<NamedApiResource<Type>> HalfDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are very effective against this type.
        /// </summary>
        [JsonProperty("double_damage_from")]
        public List<NamedApiResource<Type>> DoubleDamageFrom { get; set; }
    }
}
