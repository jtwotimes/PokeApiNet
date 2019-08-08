using PokeApiNet.Data;
using PokeApiNet.Models;
using System;
using Xunit;

namespace PokeApiNet.Tests.Data
{
    public class CacheManagerTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetByIdTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Id = 1 };

            // act
            cacheManager.Store(berry);

            // assert
            Berry retrievedBerry = cacheManager.Get<Berry>(1);
            Assert.Same(berry, retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetByIdDoesNotExistTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Id = 1 };

            // act
            cacheManager.Store(berry);

            // assert
            Berry retrievedBerry = cacheManager.Get<Berry>(2);
            Assert.Null(retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerStoreThrowsTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            TestClass test = new TestClass { Id = 1 };

            // assert
            Assert.Throws<NotSupportedException>(() =>
            {
                // act
                cacheManager.Store(test);
            });
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetEmptyIsNullTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();

            // act
            Pokedex retrievedPokedex = cacheManager.Get<Pokedex>(1);

            // assert
            Assert.Null(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetByNameTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Name = "cheri", Id = 1 };
            cacheManager.Store(berry);

            // act
            Berry retrievedBerry = cacheManager.Get<Berry>("cheri");

            // assert
            Assert.Same(berry, retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetByNameDoesNotExistTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Name = "cheri", Id = 1 };
            cacheManager.Store(berry);

            // act
            Berry retrievedBerry = cacheManager.Get<Berry>("abc123");

            // assert
            Assert.Null(retrievedBerry);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerClearAllTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Id = 1 };
            Pokedex pokedex = new Pokedex { Id = 1 };
            cacheManager.Store(berry);
            cacheManager.Store(pokedex);

            // act
            cacheManager.ClearAll();

            // assert
            Berry retrievedBerry = cacheManager.Get<Berry>(1);
            Pokedex retrievedPokedex = cacheManager.Get<Pokedex>(1);
            Assert.Null(retrievedBerry);
            Assert.Null(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManageClearTypeTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Id = 1 };
            Pokedex pokedex = new Pokedex { Id = 1 };
            cacheManager.Store(berry);
            cacheManager.Store(pokedex);

            // act
            cacheManager.Clear<Berry>();

            // assert
            Berry retrievedBerry = cacheManager.Get<Berry>(1);
            Pokedex retrievedPokedex = cacheManager.Get<Pokedex>(1);
            Assert.Null(retrievedBerry);
            Assert.NotNull(retrievedPokedex);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheManagerGetsAreCaseInsensitive()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            Berry berry = new Berry { Name = "CHERI" };
            cacheManager.Store(berry);

            // act
            Berry retrievedBerry = cacheManager.Get<Berry>("cheri");

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
