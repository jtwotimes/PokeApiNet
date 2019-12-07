using PokeApiNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace PokeApiNet.Tests
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>These tests ensures that the serialization is working properly and that the used serialization
    /// settings allow for a proper mapping between the JSON and the object.</remarks>
    public class PokeApiSerializerTests
    {
        // System.Text.Json requires that double-quotes are used in the JSON, so we have to escape all instances within the string.
        // this JSON and the below object must be kept in-sync with any changes to property values.
        public const string BERRY_JSON = "{\"firmness\":{\"name\":\"soft\",\"url\":\"https://pokeapi.co/api/v2/berry-firmness/2/\"}," +
            "\"flavors\":[{\"flavor\":{\"name\":\"spicy\",\"url\":\"https://pokeapi.co/api/v2/berry-flavor/1/\"},\"potency\":10}," +
                        "{\"flavor\":{\"name\":\"dry\",\"url\":\"https://pokeapi.co/api/v2/berry-flavor/2/\"},\"potency\":0}," +
                        "{\"flavor\":{\"name\":\"sweet\",\"url\":\"https://pokeapi.co/api/v2/berry-flavor/3/\"},\"potency\":0}," +
                        "{\"flavor\":{\"name\":\"bitter\",\"url\":\"https://pokeapi.co/api/v2/berry-flavor/4/\"},\"potency\":0}," +
                        "{\"flavor\":{\"name\":\"sour\",\"url\":\"https://pokeapi.co/api/v2/berry-flavor/5/\"},\"potency\":0}]," +
            "\"growth_time\":3,\"id\":1,\"item\":{\"name\":\"cheri-berry\",\"url\":\"https://pokeapi.co/api/v2/item/126/\"},\"max_harvest\":5," +
            "\"name\":\"cheri\",\"natural_gift_power\":60,\"natural_gift_type\":{\"name\":\"fire\",\"url\":\"https://pokeapi.co/api/v2/type/10/\"}," +
            "\"size\":20,\"smoothness\":25,\"soil_dryness\":15}";

        public static readonly Berry BERRY_OBJ = new Berry
        {
            Firmness = new NamedApiResource<BerryFirmness> { Name = "soft", Url = "https://pokeapi.co/api/v2/berry-firmness/2/" },
            Flavors = new List<BerryFlavorMap>
            {
                new BerryFlavorMap
                {
                    Flavor = new NamedApiResource<BerryFlavor> { Name = "spicy", Url = "https://pokeapi.co/api/v2/berry-flavor/1/" },
                    Potency = 10
                },
                new BerryFlavorMap
                {
                    Flavor = new NamedApiResource<BerryFlavor> { Name = "dry", Url = "https://pokeapi.co/api/v2/berry-flavor/2/" },
                    Potency = 0
                },
                new BerryFlavorMap
                {
                    Flavor = new NamedApiResource<BerryFlavor> { Name = "sweet", Url = "https://pokeapi.co/api/v2/berry-flavor/3/" },
                    Potency = 0
                },
                new BerryFlavorMap
                {
                    Flavor = new NamedApiResource<BerryFlavor> { Name = "bitter", Url = "https://pokeapi.co/api/v2/berry-flavor/4/" },
                    Potency = 0
                },
                new BerryFlavorMap
                {
                    Flavor = new NamedApiResource<BerryFlavor> { Name = "sour", Url = "https://pokeapi.co/api/v2/berry-flavor/5/" },
                    Potency = 0
                }
            },
            GrowthTime = 3,
            Id = 1,
            Item = new NamedApiResource<Item> { Name = "cheri-berry", Url = "https://pokeapi.co/api/v2/item/126/" },
            MaxHarvest = 5,
            Name = "cheri",
            NaturalGiftPower = 60,
            NaturalGiftType = new NamedApiResource<Models.Type> { Name = "fire", Url = "https://pokeapi.co/api/v2/type/10/" },
            Size = 20,
            Smoothness = 25,
            SoilDryness = 15
        };

        [Fact]
        [Trait("Category", "Unit")]
        public void BerrySerializationTest()
        {
            Berry deserializedBerry = PokeApiSerializer.Deserialize<Berry>(BERRY_JSON);
            Assert.Equal(BERRY_OBJ, deserializedBerry);
        }
    }
}
