using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Berries are small fruits that can provide HP and status condition restoration,
    /// stat enhancement, and even damage negation when eaten by Pokémon.
    /// </summary>
    public class Berry : NamedApiResource, IEquatable<Berry>
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
        [JsonPropertyName("growth_time")]
        public int GrowthTime { get; set; }

        /// <summary>
        /// The maximum number of these berries that can grow
        /// on one tree in Generation IV.
        /// </summary>
        [JsonPropertyName("max_harvest")]
        public int MaxHarvest { get; set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with
        /// this Berry.
        /// </summary>
        [JsonPropertyName("natural_gift_power")]
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
        [JsonPropertyName("soil_dryness")]
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
        [JsonPropertyName("natural_gift_type")]
        public NamedApiResource<Type> NaturalGiftType { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Berry berry = obj as Berry;
            if (berry == null)
                return false;
            else
                return Equals(berry);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public bool Equals(Berry other)
        {
            if (other == null)
                return false;

            bool result = true;

            result &= Id.Equals(other.Id);

            if (Name == null)
                result &= other.Name == null;
            else
                result &= Name.Equals(other.Name);

            result &= GrowthTime.Equals(other.GrowthTime);
            result &= MaxHarvest.Equals(other.MaxHarvest);
            result &= NaturalGiftPower.Equals(other.NaturalGiftPower);
            result &= Size.Equals(other.Size);
            result &= Smoothness.Equals(other.Smoothness);
            result &= SoilDryness.Equals(other.SoilDryness);

            if (Firmness == null)
                result &= other.Firmness == null;
            else
                result &= Firmness.Equals(other.Firmness);

            if (Flavors == null)
                result &= other.Flavors == null;
            else
                result &= Flavors.SequenceEqual(other.Flavors);

            if (Item == null)
                result &= other.Item == null;
            else
                result &= Item.Equals(other.Item);

            if (NaturalGiftType == null)
                result &= other.NaturalGiftType == null;
            else
                result &= NaturalGiftType.Equals(other.NaturalGiftType);

            return result;
        }

        /// <summary>
        /// Hash calculation function
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                const int modifier = 397;
                int hash = Name != null ? Name.GetHashCode() : 0;
                hash = (hash * modifier) ^ GrowthTime.GetHashCode();
                hash = (hash * modifier) ^ MaxHarvest.GetHashCode();
                hash = (hash * modifier) ^ NaturalGiftPower.GetHashCode();
                hash = (hash * modifier) ^ Size.GetHashCode();
                hash = (hash * modifier) ^ Smoothness.GetHashCode();
                hash = (hash * modifier) ^ SoilDryness.GetHashCode();
                hash = (hash * modifier) ^ (Firmness != null ? Firmness.GetHashCode() : 0);

                if (Flavors != null)
                {
                    hash ^= Flavors.Aggregate(487, (current, item) =>
                        (current * 31) + item.GetHashCode());
                }

                return hash;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BerryFlavorMap : IEquatable<BerryFlavorMap>
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

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            BerryFlavorMap mapObj = obj as BerryFlavorMap;
            if (mapObj == null)
                return false;
            else
                return Equals(mapObj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public bool Equals(BerryFlavorMap other)
        {
            if (other == null)
                return false;

            bool result = true;

            result &= Potency.Equals(other.Potency);

            if (Flavor == null)
                result &= other.Flavor == null;
            else
                result &= Flavor.Equals(other.Flavor);

            return result;
        }

        /// <summary>
        /// Hash calculation function
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hash = Potency.GetHashCode();
            hash ^= Flavor.GetHashCode();
            return hash;
        }
    }

    /// <summary>
    /// Berries can be soft or hard.
    /// </summary>
    public class BerryFirmness : NamedApiResource, IEquatable<BerryFirmness>
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

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public bool Equals(BerryFirmness other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hash calculation function
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Flavors determine whether a Pokémon will benefit or suffer from eating
    /// a berry based on their nature.
    /// </summary>
    public class BerryFlavor : NamedApiResource, IEquatable<BerryFlavor>
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
        [JsonPropertyName("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; set; }

        /// <summary>
        /// The name of this resource in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public bool Equals(BerryFlavor other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hash calculation function
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FlavorBerryMap : IEquatable<FlavorBerryMap>
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

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>true if obj is an instance of the object's class and equals the value of this instance; otherwise, false.</returns>
        public bool Equals(FlavorBerryMap other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hash calculation function
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
