using PokeApi.Net.Data;
using PokeApi.Net.Directives;
using PokeApi.Net.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokeApi.Net.Tests.Data
{
    public class CacheManagerTests
    {
        [Fact]
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
        public void CacheManagerStoreThrowsTest()
        {
            // assemble
            CacheManager cacheManager = new CacheManager();
            TestClass test = new TestClass { Id = 1 };

            // assert
            Assert.Throws<KeyNotFoundException>(() => 
            {
                // act
                cacheManager.Store(test);
            });
        }

        [Fact]
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

        class TestClass : ICanBeCached { public int Id { get; set; } };
    }
}
