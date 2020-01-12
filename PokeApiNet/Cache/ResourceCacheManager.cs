using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Immutable;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceBase"/>
    /// </summary>
    internal sealed class ResourceCacheManager : BaseCacheManager
    {
        private readonly IImmutableDictionary<System.Type, ResourceCache> _resourceCaches;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceCacheManager()
        {
            // TODO allow configuration of experiation policies
            _resourceCaches = ResourceTypes.ToImmutableDictionary(x => x, _ => new ResourceCache());
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
            // overload of Store is invoked.
            // The use of `dynamic` requires the nuget package `Microsoft.CSharp`
            _resourceCaches[resourceType].Store(obj as dynamic);
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
            return _resourceCaches[resourceType].Get(id) as T;
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
            return _resourceCaches[resourceType].Get(name) as T;
        }

        /// <summary>
        /// Clears all caches
        /// </summary>
        public override void ClearAll()
        {
            foreach (ResourceCache cache in _resourceCaches.Values)
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
            _resourceCaches[type].Clear();
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public override void Dispose()
        {
            foreach (ResourceCache cache in _resourceCaches.Values)
            {
                cache.Dispose();
            }
        }

        private sealed class ResourceCache : BaseExpirableCache
        {
            private readonly MemoryCache _idCache;
            private readonly MemoryCache _nameCache;

            /// <summary>
            /// Constructor
            /// </summary>
            public ResourceCache()
            {
                // TODO allow configuration of expiration policies
                _idCache = new MemoryCache(new MemoryCacheOptions());
                _nameCache = new MemoryCache(new MemoryCacheOptions());
            }


            /// <summary>
            /// Stores an object in cache
            /// </summary>
            /// <param name="obj">The object to store</param>
            public void Store(ApiResource obj)
            {
                _idCache.Set(obj.Id, obj, CacheEntryOptions);
            }

            /// <summary>
            /// Stores an object in cache
            /// </summary>
            /// <param name="obj">The object to store</param>
            public void Store(NamedApiResource obj)
            {
                // TODO enforce non-nullable name
                if (obj.Name != null)
                {
                    _nameCache.Set(obj.Name.ToLowerInvariant(), obj, CacheEntryOptions);
                }

                _idCache.Set(obj.Id, obj, CacheEntryOptions);
            }

            /// <summary>
            /// Gets a resource from cache by id
            /// </summary>
            /// <param name="id">The id of the resource</param>
            /// <returns>The object from cache with the matching id</returns>
            public ResourceBase Get(int id) =>
                _idCache.Get<ResourceBase>(id);

            /// <summary>
            /// Gets a resource from cache by name
            /// </summary>
            /// <param name="name">The name of the resource</param>
            /// <returns>The object from cache with the matching name</returns>
            public ResourceBase Get(string name) =>
                _nameCache.Get<ResourceBase>(name.ToLowerInvariant());

            /// <summary>
            /// Dispose object
            /// </summary>
            public override void Dispose()
            {
                Clear();
                _idCache.Dispose();
                _nameCache.Dispose();
            }
        }
    }
}