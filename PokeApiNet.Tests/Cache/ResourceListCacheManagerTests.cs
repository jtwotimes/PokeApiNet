using PokeApiNet.Cache;
using PokeApiNet.Models;
using System;
using Xunit;

namespace PokeApiNet.Tests.Cache
{
    public class ResourceListCacheManagerTests
    {
        private readonly string testUri;

        public ResourceListCacheManagerTests()
        {
            testUri = "unit-test";
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResources_WithStoredUri_ReturnsResource()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string uri, ApiResourceList<Machine> list) = CreateFakeApiResourceList<Machine>();
            sut.Store(uri, list);

            // act
            ApiResourceList<Machine> cached = sut.GetApiResources<Machine>(uri);

            // assert
            Assert.Same(list, cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResources_WithNonStoredUri_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string uri, ApiResourceList<Machine> list) = CreateFakeApiResourceList<Machine>();
            sut.Store(uri, list);

            // act
            ApiResourceList<Machine> cached = sut.GetApiResources<Machine>(testUri);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResources_OnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();

            // act
            ApiResourceList<Machine> cached = sut.GetApiResources<Machine>(testUri);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResources_WithStoredUri_ReturnsResource()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string uri, NamedApiResourceList<Berry> list) = CreateFakeNamedResourceList<Berry>();
            sut.Store(uri, list);

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResources<Berry>(uri);

            // assert
            Assert.Same(list, cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResources_WithNonStoredUri_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string uri, NamedApiResourceList<Berry> list) = CreateFakeNamedResourceList<Berry>();
            sut.Store(uri, list);

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResources<Berry>(testUri);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResources_OnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResources<Berry>(testUri);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void AllCacheIsCleared()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string berryUri, NamedApiResourceList<Berry> berryList) = CreateFakeNamedResourceList<Berry>();
            (string machineUri, ApiResourceList<Machine> machineList) = CreateFakeApiResourceList<Machine>();
            sut.Store(berryUri, berryList);
            sut.Store(machineUri, machineList);

            // act
            sut.ClearAll();

            // assert
            NamedApiResourceList<Berry> cacheddBerryList = sut.GetNamedResources<Berry>(berryUri);
            ApiResourceList<Machine> cachedMachineList = sut.GetApiResources<Machine>(machineUri);
            Assert.Null(cacheddBerryList);
            Assert.Null(cachedMachineList);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheIsClearedForSpecificType()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            (string berryUri, NamedApiResourceList<Berry> berryList) = CreateFakeNamedResourceList<Berry>();
            (string machineUri, ApiResourceList<Machine> machineList) = CreateFakeApiResourceList<Machine>();
            sut.Store(berryUri, berryList);
            sut.Store(machineUri, machineList);

            // act
            sut.Clear<Berry>();

            // assert
            NamedApiResourceList<Berry> cachedBerryList = sut.GetNamedResources<Berry>(berryUri);
            ApiResourceList<Machine> cachedMachineList = sut.GetApiResources<Machine>(machineUri);
            Assert.Null(cachedBerryList);
            Assert.NotNull(cachedMachineList);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void StoreThrowsIfTypeNotSupported()
        {
            // assemble
            ResourceListCacheManager sut = CreateSut();
            TestResourceList list = new TestResourceList();

            // assert
            Assert.Throws<NotSupportedException>(() =>
            {
                // act
                sut.Store(testUri, list);
            });
        }

        private (string, ApiResourceList<T>) CreateFakeApiResourceList<T>(string uri = null)
            where T : ApiResource
        {
            return (uri ?? typeof(T).Name, new ApiResourceList<T>());
        }

        private (string, NamedApiResourceList<T>) CreateFakeNamedResourceList<T>(string uri = null)
            where T : NamedApiResource
        {
            return (uri ?? typeof(T).Name, new NamedApiResourceList<T>());
        }

        private static ResourceListCacheManager CreateSut()
        {
            return new ResourceListCacheManager();
        }

        private class TestResourceList : ResourceList<TestResource> { }

        private class TestResource : ResourceBase
        {
            public override int Id { get; set; } = 1;

            public new static string ApiEndpoint => "";
        };
    }
}
