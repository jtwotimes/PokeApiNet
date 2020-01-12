using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// An item is an object in the games which the player can
    /// pick up, keep in their bag, and use in some manner. They
    /// have various uses, including healing, powering up, helping
    /// catch Pokémon, or to access a new area.
    /// </summary>
    public class Item : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "item";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The price of this item in stores.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The power of the move Fling when used with this item.
        /// </summary>
        [JsonProperty("fling_power")]
        public int? FlingPower { get; set; }

        /// <summary>
        /// The effect of the move Fling when used with this item.
        /// </summary>
        [JsonProperty("fling_effect")]
        public NamedApiResource<ItemFlingEffect> FlingEffect { get; set; }

        /// <summary>
        /// A list of attributes this item has.
        /// </summary>
        public List<NamedApiResource<ItemAttribute>> Attributes { get; set; }

        /// <summary>
        /// The category of items this item falls into.
        /// </summary>
        public NamedApiResource<ItemCategory> Category { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<VersionGroupFlavorText> FlavorGroupTextEntries { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation.
        /// </summary>
        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// The name of this item listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A set of sprites used to depict this item in the game.
        /// </summary>
        public ItemSprites Sprites { get; set; }

        /// <summary>
        /// A list of Pokémon that might be found in the wild holding this item.
        /// </summary>
        [JsonProperty("held_by_pokemon")]
        public List<ItemHolderPokemon> HeldByPokemon { get; set; }

        /// <summary>
        /// An evolution chain this item requires to produce a baby during mating.
        /// </summary>
        [JsonProperty("baby_trigger_for")]
        public ApiResource<EvolutionChain> BabyTriggerFor { get; set; }

        /// <summary>
        /// A list of the machines related to this item.
        /// </summary>
        public List<MachineVersionDetail> Machines { get; set; }
    }

    /// <summary>
    /// The default description of this item.
    /// </summary>
    public class ItemSprites
    {
        /// <summary>
        /// The default description of this item.
        /// </summary>
        public string Default { get; set; }
    }

    /// <summary>
    /// Information for which Pokémon holds an item
    /// </summary>
    public class ItemHolderPokemon
    {
        /// <summary>
        /// The Pokémon that holds this item.
        /// </summary>
        /// <remarks>The docs lie; this is not a string</remarks>
        public NamedApiResource<Pokemon> Pokemon { get; set; }

        /// <summary>
        /// The details for the version that this item is held in by the Pokémon.
        /// </summary>
        [JsonProperty("version_details")]
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; }
    }

    /// <summary>
    /// Information for which Pokémon hold an item
    /// </summary>
    public class ItemHolderPokemonVersionDetail
    {
        /// <summary>
        /// How often this Pokémon holds this item in this version.
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// The version that this item is held in by the Pokémon.
        /// </summary>
        public NamedApiResource<Version> Version { get; set; }
    }

    /// <summary>
    /// Item attributes define particular aspects of items,
    /// e.g. "usable in battle" or "consumable".
    /// </summary>
    public class ItemAttribute : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "item-attribute";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of items that have this attribute.
        /// </summary>
        public List<NamedApiResource<Item>> Items { get; set; }

        /// <summary>
        /// The name of this item attribute listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The description of this item attribute listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }
    }

    /// <summary>
    /// Item categories determine where items will be placed in the players bag.
    /// </summary>
    public class ItemCategory : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "item-category";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of items that are a part of this category.
        /// </summary>
        public List<NamedApiResource<Item>> Items { get; set; }

        /// <summary>
        /// The name of this item category listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The pocket items in this category would be put in.
        /// </summary>
        public NamedApiResource<ItemPocket> Pocket { get; set; }
    }

    /// <summary>
    /// The various effects of the move "Fling" when used with different items.
    /// </summary>
    public class ItemFlingEffect : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "item-fling-effect";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The result of this fling effect listed in different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }

        /// <summary>
        /// A list of items that have this fling effect.
        /// </summary>
        public List<NamedApiResource<Item>> Items { get; set; }
    }

    /// <summary>
    /// Pockets within the players bag used for storing items by category.
    /// </summary>
    public class ItemPocket : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "item-pocket";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of item categories that are relevant to this item pocket.
        /// </summary>
        public List<NamedApiResource<ItemCategory>> Categories { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }
}
