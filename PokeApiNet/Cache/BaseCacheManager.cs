using PokeApiNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PokeApiNet.Cache
{
    /// <summary>
    /// Base class for a cache manager implementation.
    /// </summary>
    /// <remarks>
    /// Main goal of the class is to cache the enumeration of types that are subclasses of <see cref="ResourceBase"/> in the assembly.
    /// </remarks>
    internal abstract class BaseCacheManager
    {
        protected static readonly IReadOnlyCollection<System.Type> ResourceTypes;

        static BaseCacheManager()
        {
            ResourceTypes = new HashSet<System.Type>(Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ApiResource)) || type.IsSubclassOf(typeof(NamedApiResource))));
        }

        protected bool IsTypeSupported(System.Type type) => ResourceTypes.Contains(type);
    }
}
