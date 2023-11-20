using PokeApiNet.Cache;
using System;
using Xunit;

namespace PokeApiNet.Tests.Cache
{
    public class ResourceCacheManagerTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Get_StoredId_ReturnsResource()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            sut.Store(berry);

            // act
            var retrievedBerry = sut.Get<Berry>(berry.Id);

            // assert
            Assert.Same(berry, retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_NonStoredId_ReturnsNull()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            sut.Store(berry);

            // act
            var retrievedBerry = sut.Get<Berry>(2);

            // assert
            Assert.Null(retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void StoreThrowsIfTypeNotSupported()
        {
            // assemble
            ResourceCacheManager sut = new();
            TestClass test = new() { Id = 1 };

            // assert
            Assert.Throws<NotSupportedException>(() =>
            {
                // act
                sut.Store(test);
            });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_ByIdOnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceCacheManager sut = new();

            // act
            var retrievedPokedex = sut.Get<Pokedex>(1);

            // assert
            Assert.Null(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_ByNameOnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceCacheManager sut = new();

            // act
            var retrievedPokemon = sut.Get<Pokemon>("pikachu");

            // assert
            Assert.Null(retrievedPokemon);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_StoredName_ReturnsResource()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            sut.Store(berry);

            // act
            var retrievedBerry = sut.Get<Berry>("cheri");

            // assert
            Assert.Same(berry, retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_NonStoredName_ReturnsNull()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            sut.Store(berry);

            // act
            var retrievedBerry = sut.Get<Berry>("abc123");

            // assert
            Assert.Null(retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void AllCacheIsCleared()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            var pokedex = new Pokedex { Name = "dex", Id = 1 };
            sut.Store(berry);
            sut.Store(pokedex);

            // act
            sut.ClearAll();

            // assert
            var retrievedBerry = sut.Get<Berry>(berry.Id);
            var retrievedPokedex = sut.Get<Pokedex>(pokedex.Id);
            Assert.Null(retrievedBerry);
            Assert.Null(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheIsClearedForSpecificType()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "cheri", Id = 1 };
            var pokedex = new Pokedex { Name = "cheri", Id = 1 };
            sut.Store(berry);
            sut.Store(pokedex);

            // act
            sut.Clear<Berry>();

            // assert
            var retrievedBerry = sut.Get<Berry>(berry.Id);
            var retrievedPokedex = sut.Get<Pokedex>(pokedex.Id);
            Assert.Null(retrievedBerry);
            Assert.NotNull(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Get_StoredNameWithDifferentCasing_ReturnsResource()
        {
            // assemble
            ResourceCacheManager sut = new();
            var berry = new Berry { Name = "CHERI" };
            sut.Store(berry);

            // act
            var retrievedBerry = sut.Get<Berry>("cheri");

            // assert
            Assert.Same(berry, retrievedBerry);
        }

        class TestClass : ResourceBase
        {
            public override int Id { get; set; } = 1;

            public new static string ApiEndpoint => "";
        };
    }
}
