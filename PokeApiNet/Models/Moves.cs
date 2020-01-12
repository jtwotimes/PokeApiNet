using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Moves are the skills of Pokémon in battle. In battle, a Pokémon
    /// uses one move each turn. Some moves (including those learned by
    /// Hidden Machine) can be used outside of battle as well, usually
    /// for the purpose of removing obstacles or exploring new areas.
    /// </summary>
    public class Move : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The percent value of how likely this move is to be successful.
        /// </summary>
        public int? Accuracy { get; set; }

        /// <summary>
        /// The percent value of how likely it is this moves effect will happen.
        /// </summary>
        [JsonProperty("effect_chance")]
        public int? EffectChance { get; set; }

        /// <summary>
        /// Power points. The number of times this move can be used.
        /// </summary>
        public int? Pp { get; set; }

        /// <summary>
        /// A value between -8 and 8. Sets the order in which moves are executed
        /// during battle. See
        /// [Bulbapedia](http://bulbapedia.bulbagarden.net/wiki/Priority)
        /// for greater detail.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The base power of this move with a value of 0 if it does not have
        /// a base power.
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// A detail of normal and super contest combos that require this move.
        /// </summary>
        [JsonProperty("contest_combos")]
        public ContestComboSets ContestCombos { get; set; }

        /// <summary>
        /// The type of appeal this move gives a Pokémon when used in a contest.
        /// </summary>
        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; set; }

        /// <summary>
        /// The effect the move has when used in a contest.
        /// </summary>
        [JsonProperty("contest_effect")]
        public ApiResource<ContestEffect> ContestEffect { get; set; }

        /// <summary>
        /// The type of damage the move inflicts on the target, e.g. physical.
        /// </summary>
        [JsonProperty("damage_class")]
        public NamedApiResource<MoveDamageClass> DamageClass { get; set; }

        /// <summary>
        /// The effect of this move listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this move has had across version
        /// groups of the games.
        /// </summary>
        [JsonProperty("effect_changes")]
        public List<AbilityEffectChange> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this move listed in different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<MoveFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// The generation in which this move was introduced.
        /// </summary>
        public NamedApiResource<Generation> Generation { get; set; }

        /// <summary>
        /// A list of the machines that teach this move.
        /// </summary>
        public List<MachineVersionDetail> Machines { get; set; }

        /// <summary>
        /// Metadata about this move
        /// </summary>
        public MoveMetaData Meta { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of move resource value changes across version groups
        /// of the game.
        /// </summary>
        [JsonProperty("past_values")]
        public List<PastMoveStatValues> PastValues { get; set; }

        /// <summary>
        /// A list of stats this moves effects and how much it
        /// effects them.
        /// </summary>
        [JsonProperty("stat_changes")]
        public List<MoveStatChange> StatChanges { get; set; }

        /// <summary>
        /// The effect the move has when used in a super contest.
        /// </summary>
        [JsonProperty("super_contest_effect")]
        public ApiResource<SuperContestEffect> SuperContestEffect { get; set; }

        /// <summary>
        /// The type of target that will receive the effects of the attack.
        /// </summary>
        public NamedApiResource<MoveTarget> Target { get; set; }

        /// <summary>
        /// The elemental type of this move.
        /// </summary>
        public NamedApiResource<Type> Type { get; set; }
    }

    /// <summary>
    /// A set of moves that are combos
    /// </summary>
    public class ContestComboSets
    {
        /// <summary>
        /// A detail of moves this move can be used before or after,
        /// granting additional appeal points in contests.
        /// </summary>
        public ContestComboDetail Normal { get; set; }

        /// <summary>
        /// A detail of moves this move can be used before or after,
        /// granting additional appeal points in super contests.
        /// </summary>
        public ContestComboDetail Super { get; set; }
    }

    /// <summary>
    /// A detailed list of combos
    /// </summary>
    public class ContestComboDetail
    {
        /// <summary>
        /// A list of moves to use before this move.
        /// </summary>
        [JsonProperty("use_before")]
        public List<NamedApiResource<Move>> UseBefore { get; set; }

        /// <summary>
        /// A list of moves to use after this move.
        /// </summary>
        [JsonProperty("use_after")]
        public List<NamedApiResource<Move>> UseAfter { get; set; }
    }

    /// <summary>
    /// The flavor text for a move
    /// </summary>
    public class MoveFlavorText
    {
        /// <summary>
        /// The localized flavor text for an api resource in a
        /// specific language.
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }

        /// <summary>
        /// The version group that uses this flavor text.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    /// <summary>
    /// The additional data for a move
    /// </summary>
    public class MoveMetaData
    {
        /// <summary>
        /// The status ailment this move inflicts on its target.
        /// </summary>
        public NamedApiResource<MoveAilment> Ailment { get; set; }

        /// <summary>
        /// The category of move this move falls under, e.g. damage or
        /// ailment.
        /// </summary>
        public NamedApiResource<MoveCategory> Category { get; set; }

        /// <summary>
        /// The minimum number of times this move hits. Null if it always
        /// only hits once.
        /// </summary>
        [JsonProperty("min_hits")]
        public int? MinHits { get; set; }

        /// <summary>
        /// The maximum number of times this move hits. Null if it always
        /// only hits once.
        /// </summary>
        [JsonProperty("max_hits")]
        public int? MaxHits { get; set; }

        /// <summary>
        /// The minimum number of turns this move continues to take effect.
        /// Null if it always only lasts one turn.
        /// </summary>
        [JsonProperty("min_turns")]
        public int? MinTurns { get; set; }

        /// <summary>
        /// The maximum number of turns this move continues to take effect.
        /// Null if it always only lasts one turn.
        /// </summary>
        [JsonProperty("max_turns")]
        public int? MaxTurns { get; set; }

        /// <summary>
        /// HP drain (if positive) or Recoil damage (if negative), in percent
        /// of damage done.
        /// </summary>
        public int Drain { get; set; }

        /// <summary>
        /// The amount of hp gained by the attacking Pokemon, in percent of
        /// it's maximum HP.
        /// </summary>
        public int Healing { get; set; }

        /// <summary>
        /// Critical hit rate bonus.
        /// </summary>
        [JsonProperty("crit_rate")]
        public int CritRate { get; set; }

        /// <summary>
        /// The likelihood this attack will cause an ailment.
        /// </summary>
        [JsonProperty("ailment_chance")]
        public int AilmentChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause the target Pokémon to flinch.
        /// </summary>
        [JsonProperty("flinch_chance")]
        public int FlinchChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause a stat change in the target
        /// Pokémon.
        /// </summary>
        [JsonProperty("stat_chance")]
        public int StatChance { get; set; }
    }

    /// <summary>
    /// The status and the change for a move
    /// </summary>
    public class MoveStatChange
    {
        /// <summary>
        /// The amount of change
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The stat being affected.
        /// </summary>
        public NamedApiResource<Stat> Stat { get; set; }
    }

    /// <summary>
    /// Move status values
    /// </summary>
    public class PastMoveStatValues
    {
        /// <summary>
        /// The percent value of how likely this move is to be successful.
        /// </summary>
        public int? Accuracy { get; set; }

        /// <summary>
        /// The percent value of how likely it is this moves effect will
        /// take effect.
        /// </summary>
        [JsonProperty("effect_chance")]
        public int? EffectChance { get; set; }

        /// <summary>
        /// The base power of this move with a value of 0 if it does not have
        /// a base power.
        /// </summary>
        /// <remarks>The docs lie - this is null</remarks>
        public int? Power { get; set; }

        /// <summary>
        /// Power points. The number of times this move can be used.
        /// </summary>
        public int? Pp { get; set; }

        /// <summary>
        /// The effect of this move listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The elemental type of this move.
        /// </summary>
        public NamedApiResource<Type> Type { get; set; }

        /// <summary>
        /// The version group in which these move stat values were in effect.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    /// <summary>
    /// Move Ailments are status conditions caused by moves used during battle.
    /// </summary>
    public class MoveAilment : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-ailment";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that cause this ailment.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// Styles of moves when used in the Battle Palace.
    /// </summary>
    public class MoveBattleStyle : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-battle-style";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// Very general categories that loosely group move effects.
    /// </summary>
    public class MoveCategory : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-category";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that fall into this category.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }
    }

    /// <summary>
    /// Damage classes moves can have, e.g. physical, special, or non-damaging.
    /// </summary>
    public class MoveDamageClass : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-damage-class";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that fall into this damage public class.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// Methods by which Pokémon can learn moves.
    /// </summary>
    public class MoveLearnMethod : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-learn-method";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of version groups where moves can be learned through this method.
        /// </summary>
        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    /// <summary>
    /// Targets moves can be directed at during battle. Targets can be Pokémon,
    /// environments or even other moves.
    /// </summary>
    public class MoveTarget : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-target";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }

        /// <summary>
        /// A list of moves that that are directed at this target.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }
}
