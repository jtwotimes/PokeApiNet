using System;

namespace PokeApiNet
{
    /// <summary>
    /// Represents the cache expiration options applied to a cache entry.
    /// </summary>
    public class CacheExpirationOptions
    {
        /// <summary>
        /// Gets or sets an absolute expiration date for a cache entry.
        /// </summary>
        public DateTimeOffset? AbsoluteExpiration { get; set; }

        /// <summary>
        /// Gets or sets an absolute expiration time, relative to now.
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }

        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed.
        /// This will not extend the entry lifetime beyond the absolute expiration (if set).
        /// </summary>
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
