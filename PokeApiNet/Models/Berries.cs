using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Berries are small fruits that can provide HP and status condition restoration,
    /// stat enhancement, and even damage negation when eaten by Pokémon.
    /// </summary>
    [ApiEndpoint("berry")]
    public class Berry : ICanBeCached
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
        /// Time it takes the tree to grow one stage, in hours.
        /// Berry trees go through four of these growth stages
        /// before they can be picked.
        /// </summary>
        public int GrowthTime { get; set; }

        /// <summary>
        /// The maximum number of these berries that can grow
        /// on one tree in Generation IV.
        /// </summary>
        public int MaxHarvest { get; set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with
        /// this Berry.
        /// </summary>
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
        public int SoilDryness { get; set; }

        /// <summary>
        /// The firmness of this berry, used in making Pokeblocks
        /// or Poffins.
        /// </summary>
        public NamedApiResource Firmness { get; set; }

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
        public NamedApiResource Item { get; set; }

        /// <summary>
        /// The type inherited by "Natural Gift" when used with
        /// this Berry.
        /// </summary>
        public NamedApiResource NaturalGiftType { get; set; }
    }

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
        public NamedApiResource Flavor { get; set; }
    }

    /// <summary>
    /// Berries can be soft or hard.
    /// </summary>
    [ApiEndpoint("berry-firmness")]
    public class BerryFirmness : ICanBeCached
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
        /// A list of berries with this firmness.
        /// </summary>
        public List<NamedApiResource> Berries { get; set; }

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
    [ApiEndpoint("berry-flavor")]
    public class BerryFlavor : ICanBeCached
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
        /// A list of berries with this firmness.
        /// </summary>
        public List<FlavorBerryMap> Berries { get; set; }

        /// <summary>
        /// The contest type that correlates with this berry
        /// flavor.
        /// </summary>
        public NamedApiResource ContentType { get; set; }

        /// <summary>
        /// The name of this resource in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

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
        public NamedApiResource Berry { get; set; }
    }
}
