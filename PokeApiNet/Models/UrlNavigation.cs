using PokeApiNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class UrlNavigation<T> where T : ResourceBase
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}
