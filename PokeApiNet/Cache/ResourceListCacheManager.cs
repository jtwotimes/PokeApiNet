using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Immutable;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceList{T}"/>
    /// </summary>
    internal sealed class ResourceListCacheManager : BaseCacheManager
    {
        private readonly IImmutableDictionary<System.Type, ListCache> listCaches;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceListCacheManager()
        {
            // TODO allow configuration of experiation policies
            this.listCaches = ResourceTypes.ToImmutableDictionary(x => x, _ => new ListCache());
        }

        /// <summary>
        /// Caches a value
        /// </summary>
        /// <typeparam name="T">Type of object to be cached</typeparam>
        /// <param name="url">The URL associated to the resource list</param>
        /// <param name="obj">The resource list to cache</param>
        /// <exception cref="NotSupportedException">
        /// The given type is not supported for searching via PokeAPI
        /// </exception>
        public void Store<T>(string url, ResourceList<T> obj)
            where T : ResourceBase
        {
            System.Type resourceType = typeof(T);
            if (!IsTypeSupported(resourceType))
            {
                throw new NotSupportedException($"{resourceType.FullName} is not supported.");
            }

            listCaches[resourceType].Store(url, obj);
        }

        /// <summary>
        /// Gets the <see cref="ApiResourceList{T}"/> stored in cache associated to a URL.
        /// </summary>
        /// <typeparam name="T">The type of resource in the resource list.</typeparam>
        /// <param name="url">The URL to access the cache with.</param>
        /// <returns>
        /// A <see cref="ApiResourceList{T}"/> in case of a cache hit; null otherwise.
        /// </returns>
        public ApiResourceList<T> GetApiResourceList<T>(string url) where T : ApiResource
        {
            System.Type resourceType = typeof(T);
            return listCaches[resourceType].Get<T>(url) as ApiResourceList<T>;
        }

        /// <summary>
        /// Gets the <see cref="NamedApiResourceList{T}"/> stored in cache associated to a URL.
        /// </summary>
        /// <typeparam name="T">The type of resource in the resource list.</typeparam>
        /// <param name="url">The URL to access the cache with.</param>
        /// <returns>
        /// A <see cref="NamedApiResourceList{T}"/> in case of a cache hit; null otherwise.
        /// </returns>
        public NamedApiResourceList<T> GetNamedResourceList<T>(string url) where T : NamedApiResource
        {
            System.Type resourceType = typeof(T);
            return listCaches[resourceType].Get<T>(url) as NamedApiResourceList<T>;
        }

        /// <summary>
        /// Clears all caches
        /// </summary>
        public override void ClearAll()
        {
            foreach (ListCache cache in listCaches.Values)
            {
                cache.Clear();
            }
        }

        /// <summary>
        /// Clears a specific cache
        /// </summary>
        /// <typeparam name="T">The type of cache to clear</typeparam>
        public void Clear<T>() where T : ResourceBase
        {
            System.Type type = typeof(T);
            listCaches[type].Clear();
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public override void Dispose()
        {
            foreach (ListCache cache in listCaches.Values)
            {
                cache.Dispose();
            }
        }

        private sealed class ListCache : BaseExpirableCache
        {
            private readonly MemoryCache _urlCache;

            /// <summary>
            /// Constructor
            /// </summary>
            public ListCache()
            {
                // TODO allow configuration of expiration policies
                _urlCache = new MemoryCache(new MemoryCacheOptions());
            }

            /// <summary>
            /// Stores a resource list in cache
            /// </summary>
            /// <param name="url">The url of the resource list</param>
            /// <param name="resourceList">The list of resources</param>
            /// <typeparam name="T">The type of objects in the resource list</typeparam>
            public void Store<T>(string url, ResourceList<T> resourceList)
                where T : ResourceBase
            {
                _urlCache.Set(url, resourceList, CacheEntryOptions);
            }

            /// <summary>
            /// Gets a resource list from cache
            /// </summary>
            /// <param name="url">The url of the resource list</param>
            /// <typeparam name="T">The type of objects in the resource list</typeparam>
            /// <returns>The resource list from cache</returns>
            public ResourceList<T> Get<T>(string url) where T : ResourceBase =>
                _urlCache.Get<ResourceList<T>>(url);

            /// <summary>
            /// Dispose object
            /// </summary>
            public override void Dispose()
            {
                Clear();
                _urlCache.Dispose();
            }
        }
    }
}
