using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace PokeApiNet
{
    /// <summary>
    /// Based on https://source.dot.net/#Microsoft.AspNetCore.WebUtilities/QueryHelpers.cs,1c1b023fbf834a3d
    /// </summary>
    /// <remarks>
    /// Once could opt for depending on https://www.nuget.org/packages/Microsoft.AspNetCore.WebUtilities/ instead of vendoring
    /// the class in the library, but the nuget package contains a lot more than whats required in this lib.
    /// </remarks>
    internal static class QueryHelpers
    {
        /// <summary>
        /// Append the given query keys and values to the URI.
        /// </summary>
        /// <param name="uri">The base URI.</param>
        /// <param name="queryString">A dictionary of query keys and values to append.</param>
        /// <returns>The combined result.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
        public static string AddQueryString(string uri, IDictionary<string, string?> queryString)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryString == null)
            {
                throw new ArgumentNullException(nameof(queryString));
            }

            return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string?>>)queryString);
        }

        /// <summary>
        /// Append the given query keys and values to the URI.
        /// </summary>
        /// <param name="uri">The base URI.</param>
        /// <param name="queryString">A collection of name value query pairs to append.</param>
        /// <returns>The combined result.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
        private static string AddQueryString(
            string uri,
            IEnumerable<KeyValuePair<string, string?>> queryString)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryString == null)
            {
                throw new ArgumentNullException(nameof(queryString));
            }

            var anchorIndex = uri.IndexOf('#');
            var uriToBeAppended = uri;
            var anchorText = "";
            // If there is an anchor, then the query string must be inserted before its first occurence.
            if (anchorIndex != -1)
            {
                anchorText = uri.Substring(anchorIndex);
                uriToBeAppended = uri.Substring(0, anchorIndex);
            }

            var queryIndex = uriToBeAppended.IndexOf('?');
            var hasQuery = queryIndex != -1;

            var sb = new StringBuilder();
            sb.Append(uriToBeAppended);
            foreach (var parameter in queryString)
            {
                if (parameter.Value == null)
                {
                    continue;
                }

                sb.Append(hasQuery ? '&' : '?');
                sb.Append(UrlEncoder.Default.Encode(parameter.Key));
                sb.Append('=');
                sb.Append(UrlEncoder.Default.Encode(parameter.Value));
                hasQuery = true;
            }

            sb.Append(anchorText);
            return sb.ToString();
        }
    }
}
