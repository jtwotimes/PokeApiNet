using PokeApi.Net.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    [ApiEndpoint("evolution-chain")]
    public class EvolutionChain : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item that a Pokémon would be holding
        /// when mating that would trigger the egg hatching
        /// a baby Pokémon rather than a basic Pokémon.
        /// </summary>
        public NamedApiResource BabyTriggerItem { get; set; }

        /// <summary>
        /// The base chain link object. Each link contains
        /// evolution details for a Pokémon in the chain.
        /// Each link references the next Pokémon in the
        /// natural evolution order.
        /// </summary>
        public ChainLink Chain { get; set; }
    }

    public class ChainLink
    {
        /// <summary>
        /// Whether or not this link is for a baby Pokémon. This would
        /// only ever be true on the base link.
        /// </summary>
        public bool IsBaby { get; set; }

        /// <summary>
        /// The Pokémon species at this point in the evolution chain.
        /// </summary>
        public NamedApiResource Species { get; set; }

        /// <summary>
        /// All details regarding the specific details of the referenced
        /// Pokémon species evolution.
        /// </summary>
        public List<EvolutionDetail> EvolutionDetails { get; set; }

        /// <summary>
        /// A List of chain objects.
        /// </summary>
        public List<ChainLink> EvolvesTo { get; set; }
    }

    public class EvolutionDetail
    {
        /// <summary>
        /// The item required to cause evolution this into Pokémon species.
        /// </summary>
        public NamedApiResource Item { get; set; }

        /// <summary>
        /// The type of event that triggers evolution into this Pokémon
        /// species.
        /// </summary>
        public NamedApiResource Trigger { get; set; }

        /// <summary>
        /// The id of the gender of the evolving Pokémon species must be in
        /// order to evolve into this Pokémon species.
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// The item the evolving Pokémon species must be holding during the
        /// evolution trigger event to evolve into this Pokémon species.
        /// </summary>
        public NamedApiResource HeldItem { get; set; }

        /// <summary>
        /// The move that must be known by the evolving Pokémon species
        /// during the evolution trigger event in order to evolve into
        /// this Pokémon species.
        /// </summary>
        public NamedApiResource KnownMove { get; set; }

        /// <summary>
        /// The evolving Pokémon species must know a move with this type
        /// during the evolution trigger event in order to evolve into this
        /// Pokémon species.
        /// </summary>
        public NamedApiResource KnownMoveType { get; set; }

        /// <summary>
        /// The location the evolution must be triggered at.
        /// </summary>
        public NamedApiResource Location { get; set; }

        /// <summary>
        /// The minimum required level of the evolving Pokémon species to
        /// evolve into this Pokémon species.
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// The minimum required level of happiness the evolving Pokémon
        /// species to evolve into this Pokémon species.
        /// </summary>
        public int MinHappiness { get; set; }

        /// <summary>
        /// The minimum required level of beauty the evolving Pokémon species
        /// to evolve into this Pokémon species.
        /// </summary>
        public int MinBeauty { get; set; }

        /// <summary>
        /// The minimum required level of affection the evolving Pokémon
        /// species to evolve into this Pokémon species.
        /// </summary>
        public int MinAffection { get; set; }

        /// <summary>
        /// Whether or not it must be raining in the overworld to cause
        /// evolution this Pokémon species.
        /// </summary>
        public bool NeedsOverworldRain { get; set; }

        /// <summary>
        /// The Pokémon species that must be in the players party in
        /// order for the evolving Pokémon species to evolve into this
        /// Pokémon species.
        /// </summary>
        public NamedApiResource PartySpecies { get; set; }

        /// <summary>
        /// The player must have a Pokémon of this type in their party
        /// during the evolution trigger event in order for the evolving
        /// Pokémon species to evolve into this Pokémon species.
        /// </summary>
        public NamedApiResource PartyType { get; set; }

        /// <summary>
        /// The required relation between the Pokémon's Attack and Defense
        /// stats. 1 means Attack > Defense. 0 means Attack = Defense.
        /// -1 means Attack &gt; Defense.
        /// </summary>
        public int RelativePhysicalStats { get; set; }

        /// <summary>
        /// The required time of day. Day or night.
        /// </summary>
        public string TimeOfDay { get; set; }

        /// <summary>
        /// Pokémon species for which this one must be traded.
        /// </summary>
        public NamedApiResource TradeSpecies { get; set; }

        /// <summary>
        /// Whether or not the 3DS needs to be turned upside-down as this
        /// Pokémon levels up.
        /// </summary>
        public bool TurnUpsideDown { get; set; }
    }

    [ApiEndpoint("evolution-trigger")]
    public class EvolutionTrigger : ICanBeCached
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
        /// A list of pokemon species that result from this evolution
        /// trigger.
        /// </summary>
        public List<NamedApiResource> PokemonSpecies { get; set; }
    }
}
