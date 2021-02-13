using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Evolution chains are essentially family trees. They start with
    /// the lowest stage within a family and detail evolution conditions
    /// for each as well as Pokémon they can evolve into up through the
    /// hierarchy.
    /// </summary>
    public class EvolutionChain : ApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "evolution-chain";

        /// <summary>
        /// The item that a Pokémon would be holding
        /// when mating that would trigger the egg hatching
        /// a baby Pokémon rather than a basic Pokémon.
        /// </summary>
        [JsonProperty("baby_trigger_item")]
        public NamedApiResource<Item> BabyTriggerItem { get; set; }

        /// <summary>
        /// The base chain link object. Each link contains
        /// evolution details for a Pokémon in the chain.
        /// Each link references the next Pokémon in the
        /// natural evolution order.
        /// </summary>
        public ChainLink Chain { get; set; }
    }

    /// <summary>
    /// The linking information between a Pokémon and it's evolution(s)
    /// </summary>
    public class ChainLink
    {
        /// <summary>
        /// Whether or not this link is for a baby Pokémon. This would
        /// only ever be true on the base link.
        /// </summary>
        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        /// <summary>
        /// The Pokémon species at this point in the evolution chain.
        /// </summary>
        public NamedApiResource<PokemonSpecies> Species { get; set; }

        /// <summary>
        /// All details regarding the specific details of the referenced
        /// Pokémon species evolution.
        /// </summary>
        [JsonProperty("evolution_details")]
        public List<EvolutionDetail> EvolutionDetails { get; set; }

        /// <summary>
        /// A List of chain objects.
        /// </summary>
        [JsonProperty("evolves_to")]
        public List<ChainLink> EvolvesTo { get; set; }
    }

    /// <summary>
    /// The details for an evolution
    /// </summary>
    public class EvolutionDetail
    {
        /// <summary>
        /// The item required to cause evolution this into Pokémon species.
        /// </summary>
        public NamedApiResource<Item> Item { get; set; }

        /// <summary>
        /// The type of event that triggers evolution into this Pokémon
        /// species.
        /// </summary>
        public NamedApiResource<EvolutionTrigger> Trigger { get; set; }

        /// <summary>
        /// The id of the gender of the evolving Pokémon species must be in
        /// order to evolve into this Pokémon species.
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// The item the evolving Pokémon species must be holding during the
        /// evolution trigger event to evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("held_item")]
        public NamedApiResource<Item> HeldItem { get; set; }

        /// <summary>
        /// The move that must be known by the evolving Pokémon species
        /// during the evolution trigger event in order to evolve into
        /// this Pokémon species.
        /// </summary>
        [JsonProperty("known_move")]
        public NamedApiResource<Move> KnownMove { get; set; }

        /// <summary>
        /// The evolving Pokémon species must know a move with this type
        /// during the evolution trigger event in order to evolve into this
        /// Pokémon species.
        /// </summary>
        [JsonProperty("known_move_type")]
        public NamedApiResource<Type> KnownMoveType { get; set; }

        /// <summary>
        /// The location the evolution must be triggered at.
        /// </summary>
        public NamedApiResource<Location> Location { get; set; }

        /// <summary>
        /// The minimum required level of the evolving Pokémon species to
        /// evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("min_level")]
        public int? MinLevel { get; set; }

        /// <summary>
        /// The minimum required level of happiness the evolving Pokémon
        /// species to evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("min_happiness")]
        public int? MinHappiness { get; set; }

        /// <summary>
        /// The minimum required level of beauty the evolving Pokémon species
        /// to evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("min_beauty")]
        public int? MinBeauty { get; set; }

        /// <summary>
        /// The minimum required level of affection the evolving Pokémon
        /// species to evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("min_affection")]
        public int? MinAffection { get; set; }

        /// <summary>
        /// Whether or not it must be raining in the overworld to cause
        /// evolution this Pokémon species.
        /// </summary>
        [JsonProperty("needs_overworld_rain")]
        public bool NeedsOverworldRain { get; set; }

        /// <summary>
        /// The Pokémon species that must be in the players party in
        /// order for the evolving Pokémon species to evolve into this
        /// Pokémon species.
        /// </summary>
        [JsonProperty("party_species")]
        public NamedApiResource<PokemonSpecies> PartySpecies { get; set; }

        /// <summary>
        /// The player must have a Pokémon of this type in their party
        /// during the evolution trigger event in order for the evolving
        /// Pokémon species to evolve into this Pokémon species.
        /// </summary>
        [JsonProperty("party_type")]
        public NamedApiResource<Type> PartyType { get; set; }

        /// <summary>
        /// The required relation between the Pokémon's Attack and Defense
        /// stats. 1 means Attack > Defense. 0 means Attack = Defense.
        /// -1 means Attack &gt; Defense.
        /// </summary>
        [JsonProperty("relative_physical_stats")]
        public int? RelativePhysicalStats { get; set; }

        /// <summary>
        /// The required time of day. Day or night.
        /// </summary>
        [JsonProperty("time_of_day")]
        public string TimeOfDay { get; set; }

        /// <summary>
        /// Pokémon species for which this one must be traded.
        /// </summary>
        [JsonProperty("trade_species")]
        public NamedApiResource<PokemonSpecies> TradeSpecies { get; set; }

        /// <summary>
        /// Whether or not the 3DS needs to be turned upside-down as this
        /// Pokémon levels up.
        /// </summary>
        [JsonProperty("turn_upside_down")]
        public bool TurnUpsideDown { get; set; }
    }

    /// <summary>
    /// Evolution triggers are the events and conditions that
    /// cause a Pokémon to evolve.
    /// </summary>
    public class EvolutionTrigger : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "evolution-trigger";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of pokemon species that result from this evolution
        /// trigger.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }
}
