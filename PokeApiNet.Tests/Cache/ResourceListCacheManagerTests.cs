using PokeApiNet.Cache;
using System;
using Xunit;

namespace PokeApiNet.Tests.Cache
{
    public class ResourceListCacheManagerTests
    {
        private readonly string testUrl;

        public ResourceListCacheManagerTests()
        {
            testUrl = "unit-test";
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResourceList_WithStoredUri_ReturnsResource()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string url, ApiResourceList<Machine> list) = CreateFakeApiResourceList<Machine>();
            sut.Store(url, list);

            // act
            ApiResourceList<Machine> cached = sut.GetApiResourceList<Machine>(url);

            // assert
            Assert.Same(list, cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResourceList_WithNonStoredUri_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string url, ApiResourceList<Machine> list) = CreateFakeApiResourceList<Machine>();
            sut.Store(url, list);

            // act
            ApiResourceList<Machine> cached = sut.GetApiResourceList<Machine>(testUrl);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetApiResourceList_OnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();

            // act
            ApiResourceList<Machine> cached = sut.GetApiResourceList<Machine>(testUrl);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResourceList_WithStoredUri_ReturnsResource()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string url, NamedApiResourceList<Berry> list) = CreateFakeNamedResourceList<Berry>();
            sut.Store(url, list);

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResourceList<Berry>(url);

            // assert
            Assert.Same(list, cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResourceList_WithNonStoredUri_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string url, NamedApiResourceList<Berry> list) = CreateFakeNamedResourceList<Berry>();
            sut.Store(url, list);

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResourceList<Berry>(testUrl);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetNamedResourceList_OnEmptyCache_ReturnsNull()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();

            // act
            NamedApiResourceList<Berry> cached = sut.GetNamedResourceList<Berry>(testUrl);

            // assert
            Assert.Null(cached);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void AllCacheIsCleared()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string berryUri, NamedApiResourceList<Berry> berryList) = CreateFakeNamedResourceList<Berry>();
            (string machineUri, ApiResourceList<Machine> machineList) = CreateFakeApiResourceList<Machine>();
            sut.Store(berryUri, berryList);
            sut.Store(machineUri, machineList);

            // act
            sut.ClearAll();

            // assert
            NamedApiResourceList<Berry> cacheddBerryList = sut.GetNamedResourceList<Berry>(berryUri);
            ApiResourceList<Machine> cachedMachineList = sut.GetApiResourceList<Machine>(machineUri);
            Assert.Null(cacheddBerryList);
            Assert.Null(cachedMachineList);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CacheIsClearedForSpecificType()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            (string berryUri, NamedApiResourceList<Berry> berryList) = CreateFakeNamedResourceList<Berry>();
            (string machineUri, ApiResourceList<Machine> machineList) = CreateFakeApiResourceList<Machine>();
            sut.Store(berryUri, berryList);
            sut.Store(machineUri, machineList);

            // act
            sut.Clear<Berry>();

            // assert
            NamedApiResourceList<Berry> cachedBerryList = sut.GetNamedResourceList<Berry>(berryUri);
            ApiResourceList<Machine> cachedMachineList = sut.GetApiResourceList<Machine>(machineUri);
            Assert.Null(cachedBerryList);
            Assert.NotNull(cachedMachineList);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void StoreThrowsIfTypeNotSupported()
        {
            // assemble
            ResourceListCacheManager sut = new ResourceListCacheManager();
            TestResourceList list = new TestResourceList();

            // assert
            Assert.Throws<NotSupportedException>(() =>
            {
                // act
                sut.Store(testUrl, list);
            });
        }

        private (string, ApiResourceList<T>) CreateFakeApiResourceList<T>(string url = null)
            where T : ApiResource
        {
            return (url ?? typeof(T).Name, new ApiResourceList<T>());
        }

        private (string, NamedApiResourceList<T>) CreateFakeNamedResourceList<T>(string url = null)
            where T : NamedApiResource
        {
            return (url ?? typeof(T).Name, new NamedApiResourceList<T>());
        }

        private class TestResourceList : ResourceList<TestResource> { }

        private class TestResource : ResourceBase
        {
            public override int Id { get; set; } = 1;

            public new static string ApiEndpoint => "";
        };
    }
}
