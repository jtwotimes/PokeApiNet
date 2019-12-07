using System;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class UrlNavigation<T> : IEquatable<UrlNavigation<T>>
        where T : ResourceBase
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            UrlNavigation<T> urlObj = obj as UrlNavigation<T>;
            if (urlObj == null)
                return false;
            else
                return Equals(urlObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(UrlNavigation<T> other)
        {
            if (other == null)
                return false;

            bool result = true;

            if (Url == null)
                result &= other.Url == null;
            else
                result &= Url.Equals(other.Url);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = Url.GetHashCode();
            return hash;
        }
    }
}
