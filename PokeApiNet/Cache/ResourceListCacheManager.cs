using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using PokeApiNet.Models;
using System;
using System.Collections.Immutable;
using System.Threading;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceList{T}"/>
    /// </summary>
    internal sealed class ResourceListCacheManager : BaseCacheManager, IDisposable
    {
        private IImmutableDictionary<System.Type, ListCache> listCaches;

        public ResourceListCacheManager()
        {
            // TODO allow configuration of experiation policies
            this.listCaches = ResourceTypes.ToImmutableDictionary(x => x, _ => new ListCache());
        }

        /// <summary>
        /// Caches a value
        /// </summary>
        /// <typeparam name="T">Type of object to be cached</typeparam>
        /// <param name="uri">The relative path associated to the resource list</param>
        /// <param name="obj">The resource list to cache</param>
        /// <exception cref="NotSupportedException">
        /// The given type is not supported for searching via PokeAPI
        /// </exception>
        public void Store<T>(string uri, ResourceList<T> obj)
            where T : ResourceBase
        {
            System.Type resourceType = typeof(T);
            if (!IsTypeSupported(resourceType))
            {
                throw new NotSupportedException($"{resourceType.FullName} is not supported.");
            }

            listCaches[resourceType].Store(uri, obj);
        }

        public ApiResourceList<T> GetApiResources<T>(string uri) where T : ApiResource
        {
            System.Type resourceType = typeof(T);
            return listCaches[resourceType].Get<T>(uri) as ApiResourceList<T>;
        }

        public NamedApiResourceList<T> GetNamedResources<T>(string uri) where T : NamedApiResource
        {
            System.Type resourceType = typeof(T);
            return listCaches[resourceType].Get<T>(uri) as NamedApiResourceList<T>;
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

        private sealed class ListCache : IDisposable
        {
            private MemoryCache uriCache;

            public ListCache()
            {
                // TODO allow configuration of expiration policies
                uriCache = new MemoryCache(new MemoryCacheOptions());
                this.ClearToken = new CancellationTokenSource();
            }

            private CancellationTokenSource ClearToken { get; set; }

            public void Store<T>(string uri, ResourceList<T> resourceList)
                where T : ResourceBase
            {
                uriCache.Set(uri, resourceList, CreateEntryOptions());
            }

            /// <summary>
            /// Clears all cache data
            /// </summary>
            public void Clear()
            {
                // TODO add lock?
                if (ClearToken != null && !ClearToken.IsCancellationRequested && ClearToken.Token.CanBeCanceled)
                {
                    ClearToken.Cancel();
                    ClearToken.Dispose();
                }

                ClearToken = new CancellationTokenSource();
            }

            /// <remarks>
            /// New options instance has to be constantly instantiated instead of shared
            /// as a consecuence of <see cref="ClearToken"/> being mutable
            /// </remarks>
            private MemoryCacheEntryOptions CreateEntryOptions() => new MemoryCacheEntryOptions()
                    .AddExpirationToken(new CancellationChangeToken(ClearToken.Token));

            public ResourceList<T> Get<T>(string uri) where T : ResourceBase => uriCache.Get<ResourceList<T>>(uri);

            public void Dispose()
            {
                this.Clear();
                ClearToken = null;
                uriCache.Dispose();
                uriCache = null;
            }
        }
    }
}
