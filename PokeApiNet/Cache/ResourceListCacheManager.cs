using Microsoft.Extensions.Caching.Memory;
using PokeApiNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceList{T}"/>
    /// </summary>
    internal sealed class ResourceListCacheManager : BaseCacheManager, IDisposable
    {
        private IReadOnlyDictionary<System.Type, ListCache> listCaches;

        public ResourceListCacheManager(IObservable<CacheExpirationOptions> expirationOptionsProvider)
        {
            this.listCaches = ResourceTypes.ToDictionary(x => x, _ => new ListCache(expirationOptionsProvider));
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
        public void ClearAll()
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

        public void Dispose()
        {
            foreach(ListCache cache in listCaches.Values)
            {
                cache.Dispose();
            }
            listCaches = null;
        }

        private sealed class ListCache : BaseExpirableCache, IDisposable
        {
            private readonly MemoryCache urlCache;

            public ListCache(IObservable<CacheExpirationOptions> expirationOptionsProvider)
                : base(expirationOptionsProvider)
            {
                urlCache = new MemoryCache(new MemoryCacheOptions());
            }

            public void Store<T>(string url, ResourceList<T> resourceList)
                where T : ResourceBase
            {
                urlCache.Set(url, resourceList, CacheEntryOptions);
            }

            /// <summary>
            /// Clears all cache data
            /// </summary>
            public void Clear()
            {
                ExpireAll();
            }

            public ResourceList<T> Get<T>(string url) where T : ResourceBase => urlCache.Get<ResourceList<T>>(url);

            public override void Dispose()
            {
                // Ensures that created cache entries are expired
                base.Dispose();
                urlCache.Dispose();
            }
        }
    }
}
