using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Berries are small fruits that can provide HP and status condition restoration,
    /// stat enhancement, and even damage negation when eaten by Pokémon.
    /// </summary>
    public class Berry : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "berry";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Time it takes the tree to grow one stage, in hours.
        /// Berry trees go through four of these growth stages
        /// before they can be picked.
        /// </summary>
        [JsonProperty("growth_time")]
        public int GrowthTime { get; set; }

        /// <summary>
        /// The maximum number of these berries that can grow
        /// on one tree in Generation IV.
        /// </summary>
        [JsonProperty("max_harvest")]
        public int MaxHarvest { get; set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with
        /// this Berry.
        /// </summary>
        [JsonProperty("natural_gift_power")]
        public int NaturalGiftPower { get; set; }

        /// <summary>
        /// The size of this Berry, in millimeters.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The smoothness of this Berry, used in making
        /// Pokeblocks of Poffins.
        /// </summary>
        public int Smoothness { get; set; }

        /// <summary>
        /// The speed at which this Berry dries out the soil as
        /// it grows. A higher rate means the soil dries out
        /// more quickly.
        /// </summary>
        [JsonProperty("soil_dryness")]
        public int SoilDryness { get; set; }

        /// <summary>
        /// The firmness of this berry, used in making Pokeblocks
        /// or Poffins.
        /// </summary>
        public NamedApiResource<BerryFirmness> Firmness { get; set; }

        /// <summary>
        /// A list of references to each flavor a berry can have
        /// and the potency of each of those flavors in regards
        /// to this berry.
        /// </summary>
        public List<BerryFlavorMap> Flavors { get; set; }

        /// <summary>
        /// Berries are actually items. This is a reference to
        /// the item specific data for this berry.
        /// </summary>
        public NamedApiResource<Item> Item { get; set; }

        /// <summary>
        /// The type inherited by "Natural Gift" when used with
        /// this Berry.
        /// </summary>
        [JsonProperty("natural_gift_type")]
        public NamedApiResource<Type> NaturalGiftType { get; set; }
    }

    /// <summary>
    /// The potency and flavor that a berry can have
    /// </summary>
    public class BerryFlavorMap
    {
        /// <summary>
        /// How powerful the referenced flavor is for this
        /// berry.
        /// </summary>
        public int Potency { get; set; }

        /// <summary>
        /// The referenced berry flavor.
        /// </summary>
        public NamedApiResource<BerryFlavor> Flavor { get; set; }
    }

    /// <summary>
    /// Berries can be soft or hard.
    /// </summary>
    public class BerryFirmness : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "berry-firmness";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of berries with this firmness.
        /// </summary>
        public List<NamedApiResource<Berry>> Berries { get; set; }

        /// <summary>
        /// The name of this resource listed in different
        /// languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// Flavors determine whether a Pokémon will benefit or suffer from eating
    /// a berry based on their nature.
    /// </summary>
    public class BerryFlavor : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "berry-flavor";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of berries with this firmness.
        /// </summary>
        public List<FlavorBerryMap> Berries { get; set; }

        /// <summary>
        /// The contest type that correlates with this berry
        /// flavor.
        /// </summary>
        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; set; }

        /// <summary>
        /// The name of this resource in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    /// <summary>
    /// The potency and flavor that a berry can have
    /// </summary>
    public class FlavorBerryMap
    {
        /// <summary>
        /// How powerful this referenced flavor is for this
        /// berry.
        /// </summary>
        public int Potency { get; set; }

        /// <summary>
        /// The berry with the referenced flavor.
        /// </summary>
        public NamedApiResource<Berry> Berry { get; set; }
    }
}
