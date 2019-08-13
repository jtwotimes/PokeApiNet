using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using PokeApiNet.Models;
using System;
using System.Collections.Immutable;
using System.Threading;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceBase"/>
    /// </summary>
    internal sealed class ResourceCacheManager : BaseCacheManager, IDisposable
    {
        private IImmutableDictionary<System.Type, ResourceCache> resourceCaches;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceCacheManager()
        {
            // TODO allow configuration of experiation policies
            resourceCaches = ResourceTypes.ToImmutableDictionary(x => x, _ => new ResourceCache());
        }

        /// <summary>
        /// Caches a value
        /// </summary>
        /// <typeparam name="T">Type of object to be cached</typeparam>
        /// <param name="obj">Object to cache</param>
        /// <exception cref="NotSupportedException">
        /// The given type is not supported for searching via PokeAPI
        /// </exception>
        public void Store<T>(T obj) where T : ResourceBase
        {
            System.Type resourceType = typeof(T);
            if (!IsTypeSupported(resourceType))
            {
                throw new NotSupportedException($"{resourceType.FullName} is not supported.");
            }

            // Defer type inference to runtime, so that the correct
            // overload of Store is invoked
            resourceCaches[resourceType].Store(obj as dynamic);
        }

        /// <summary>
        /// Gets a value from cache by id or null if not cached or if not found
        /// </summary>
        /// <typeparam name="T">Type of object to get</typeparam>
        /// <param name="id">Id of the resource</param>
        /// <returns>The cached object or null if not found</returns>
        public T Get<T>(int id) where T : ResourceBase
        {
            System.Type resourceType = typeof(T);
            return resourceCaches[resourceType].Get(id) as T;
        }

        /// <summary>
        /// Gets a value from cache by name or null if not cached or if not found
        /// </summary>
        /// <typeparam name="T">Type of object to get</typeparam>
        /// <param name="name">Name of the resource</param>
        /// <returns>The cached object or null if not found</returns>
        public T Get<T>(string name) where T : NamedApiResource
        {
            System.Type resourceType = typeof(T);
            return resourceCaches[resourceType].Get(name) as T;
        }

        /// <summary>
        /// Clears all caches
        /// </summary>
        public void ClearAll()
        {
            foreach (ResourceCache cache in resourceCaches.Values)
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
            resourceCaches[type].Clear();
        }

        public void Dispose()
        {
            foreach(ResourceCache cache in this.resourceCaches.Values)
            {
                cache.Dispose();
            }
            this.resourceCaches = null;
        }

        private sealed class ResourceCache : IDisposable
        {
            private MemoryCache IdCache;
            private MemoryCache NameCache;

            /// <summary>
            /// Constructor
            /// </summary>
            public ResourceCache()
            {
                // TODO allow configuration of expiration policies
                IdCache = new MemoryCache(new MemoryCacheOptions());
                NameCache = new MemoryCache(new MemoryCacheOptions());
                this.ClearToken = new CancellationTokenSource();
            }

            private CancellationTokenSource ClearToken { get; set; }


            /// <summary>
            /// Stores an object in cache
            /// </summary>
            /// <param name="obj">The object to store</param>
            public void Store(ApiResource obj)
            {
                IdCache.Set(obj.Id, obj, CreateEntryOptions());
            }

            public void Store(NamedApiResource obj)
            {
                // TODO enforce non-nullable name
                if (obj.Name != null)
                {
                    NameCache.Set(obj.Name.ToLowerInvariant(), obj, CreateEntryOptions());
                }

                IdCache.Set(obj.Id, obj, CreateEntryOptions());
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

            public ResourceBase Get(int id) => IdCache.Get<ResourceBase>(id);

            public ResourceBase Get(string name) => NameCache.Get<ResourceBase>(name.ToLowerInvariant());

            /// <remarks>
            /// New options instance has to be constantly instantiated instead of shared
            /// as a consequence of <see cref="ClearToken"/> being mutable
            /// </remarks>
            private MemoryCacheEntryOptions CreateEntryOptions() => new MemoryCacheEntryOptions()
                    .AddExpirationToken(new CancellationChangeToken(ClearToken.Token));

            public void Dispose()
            {
                this.Clear();
                this.ClearToken = null;
                this.IdCache.Dispose();
                this.NameCache.Dispose();
                this.IdCache = null;
                this.NameCache = null;
            }
        }
    }
}