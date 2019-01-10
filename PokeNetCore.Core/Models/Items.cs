using System;
using System.Collections.Generic;
using System.Text;

namespace PokeNetCore.Core.Models
{
    class Item
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
        /// The price of this item in stores.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The power of the move Fling when used with this item.
        /// </summary>
        public int FlingPower { get; set; }

        /// <summary>
        /// The effect of the move Fling when used with this item.
        /// </summary>
        public NamedApiResource FlingEffect { get; set; }

        /// <summary>
        /// A list of attributes this item has.
        /// </summary>
        public List<NamedApiResource> Attributes { get; set; }

        /// <summary>
        /// The category of items this item falls into.
        /// </summary>
        public ItemCategory Category { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages.
        /// </summary>
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages.
        /// </summary>
        public List<VersionGroupFlavorText> FlavorGroupTextEntries { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation.
        /// </summary>
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
        public List<ItemHolderPokemon> HeldByPokemon { get; set; }

        /// <summary>
        /// An evolution chain this item requires to produce a baby during mating.
        /// </summary>
        public ApiResource BabyTriggerFor { get; set; }

        /// <summary>
        /// A list of the machines related to this item.
        /// </summary>
        public List<MachineVersionDetail> Machines { get; set; }
    }

    class ItemSprites
    {
        /// <summary>
        /// The default descritpion of this item.
        /// </summary>
        public string Default { get; set; }
    }

    class ItemHolderPokemon
    {
        /// <summary>
        /// The Pokémon that holds this item.
        /// </summary>
        public string Pokemon { get; set; }

        /// <summary>
        /// The details for the version that this item is held in by the Pokémon.
        /// </summary>
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; }
    }

    class ItemHolderPokemonVersionDetail
    {
        /// <summary>
        /// How often this Pokémon holds this item in this version.
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// The version that this item is held in by the Pokémon.
        /// </summary>
        public NamedApiResource Version { get; set; }
    }

    class ItemAttribute
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
        /// A list of items that have this attribute.
        /// </summary>
        public List<NamedApiResource> Items { get; set; }

        /// <summary>
        /// The name of this item attribute listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The description of this item attribute listed in different languages.
        /// </summary>
        public List<Descriptions> Descriptions { get; set; }
    }

    class ItemCategory
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
        /// A list of items that are a part of this category.
        /// </summary>
        public List<NamedApiResource> Items { get; set; }

        /// <summary>
        /// The name of this item category listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The pocket items in this category would be put in.
        /// </summary>
        public NamedApiResource Pocket { get; set; }
    }

    class ItemFlingEffect
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
        /// The result of this fling effect listed in different languages.
        /// </summary>
        public List<Effects> EffectEntries { get; set; }

        /// <summary>
        /// A list of items that have this fling effect.
        /// </summary>
        public List<NamedApiResource> Items { get; set; }
    }

    class ItemPocket
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
        /// A list of item categories that are relevant to this item pocket.
        /// </summary>
        public List<NamedApiResource> Categories { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }
}
