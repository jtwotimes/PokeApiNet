using PokeApiNet.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Manages caches for instances of subclasses from <see cref="ResourceBase"/>
    /// </summary>
    internal sealed class ResourceCacheManager : BaseCacheManager
    {
        private readonly IImmutableDictionary<System.Type, ResourceCache> _allCaches;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceCacheManager()
        {
            _allCaches = ResourceTypes.ToImmutableDictionary(x => x, _ => new ResourceCache());
        }

        /// <summary>
        /// Caches a value
        /// </summary>
        /// <typeparam name="T">Type of object to be cached</typeparam>
        /// <param name="obj">Object to cache</param>
        /// <exception cref="NotSupportedException">The given type is not supported for searching
        /// via PokeAPI</exception>
        public void Store<T>(T obj) where T : ResourceBase
        {
            System.Type targetType = typeof(T);
            if (!IsTypeSupported(targetType))
            {
                throw new NotSupportedException($"{targetType.FullName} is not supported.");
            }

            _allCaches[targetType].Store(obj);
        }

        /// <summary>
        /// Gets a value from cache by id or null if not cached or if not found
        /// </summary>
        /// <typeparam name="T">Type of object to get</typeparam>
        /// <param name="id">Id of the resource</param>
        /// <returns>The cached object or null if not found</returns>
        public T Get<T>(int id) where T : ResourceBase
        {
            System.Type type = typeof(T);
            _allCaches[type].Cache.TryGetValue(id, out ResourceBase value);
            return value as T;
        }

        /// <summary>
        /// Gets a value from cache by name or null if not cached or if not found
        /// </summary>
        /// <typeparam name="T">Type of object to get</typeparam>
        /// <param name="name">Name of the resource</param>
        /// <returns>The cached object or null if not found</returns>
        public T Get<T>(string name) where T : ResourceBase
        {
            System.Type type = typeof(T);
            PropertyInfo nameProperty = type.GetProperties()
                .FirstOrDefault(property => property.Name.Equals("Name"));
            if (nameProperty == null)
            {
                return null;
            }

            ResourceBase matchingObject = null;
            foreach (ResourceBase cacheObj in _allCaches[type].Cache.Values)
            {
                // we wouldn't be here without knowing that T has a Name property
                string value = nameProperty.GetValue(cacheObj) as string;
                if (value.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    matchingObject = cacheObj;
                    break;
                }
            }

            return matchingObject as T;
        }

        /// <summary>
        /// Clears all caches
        /// </summary>
        public void ClearAll()
        {
            foreach (ResourceCache cache in _allCaches.Values)
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
            _allCaches[type].Clear();
        }

        private sealed class ResourceCache
        {
            /// <summary>
            /// The underlying data store for the cache
            /// </summary>
            public readonly ConcurrentDictionary<int, ResourceBase> Cache;

            /// <summary>
            /// Constructor
            /// </summary>
            public ResourceCache()
            {
                Cache = new ConcurrentDictionary<int, ResourceBase>();
            }

            /// <summary>
            /// Stores an object in cache
            /// </summary>
            /// <param name="obj">The object to store</param>
            public void Store(ResourceBase obj)
            {
                Cache.TryAdd(obj.Id, obj);
            }

            /// <summary>
            /// Clears all cache data
            /// </summary>
            public void Clear()
            {
                Cache.Clear();
            }
        }
    }
}