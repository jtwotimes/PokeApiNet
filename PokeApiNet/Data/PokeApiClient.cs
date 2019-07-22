using Newtonsoft.Json;
using PokeApiNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PokeApiNet.Data
{
    /// <summary>
    /// Gets data from the PokeAPI service
    /// </summary>
    public class PokeApiClient : IDisposable
    {
        /// <summary>
        /// The default `User-Agent` header value used by instances of <see cref="PokeApiClient"/>.
        /// </summary>
        public static readonly ProductHeaderValue DefaultUserAgent = GetDefaultUserAgent();
        private readonly HttpClient _client;
        private readonly Uri _baseUri = new Uri("https://pokeapi.co/api/v2/");
        private readonly CacheManager _cacheManager = new CacheManager();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PokeApiClient()
            : this(DefaultUserAgent)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgent">The value for the default `User-Agent` header.</param>
        public PokeApiClient(ProductHeaderValue userAgent)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            _client = new HttpClient() { BaseAddress = _baseUri };
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent));
        }

        /// <summary>
        /// Constructor with message handler
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        public PokeApiClient(HttpMessageHandler messageHandler)
            : this(messageHandler, DefaultUserAgent)
        {
        }

        /// <summary>
        /// Constructor with message handler
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        /// <param name="userAgent">The value for the default `User-Agent` header.</param>
        public PokeApiClient(HttpMessageHandler messageHandler, ProductHeaderValue userAgent)
        {
            if (userAgent == null)
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            _client = new HttpClient(messageHandler) { BaseAddress = _baseUri };
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(userAgent));
        }

        /// <summary>
        /// Close resources
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        private static ProductHeaderValue GetDefaultUserAgent()
        {
            var version = typeof(PokeApiClient).Assembly.GetName().Version;
            return new ProductHeaderValue("PokeApiNet", $"{version.Major}.{version.Minor}");
        }

        /// <summary>
        /// Send a request to the api and serialize the response into the specified type
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="apiParam">The name or id of the resource</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <exception cref="HttpRequestException">Something went wrong with your request</exception>
        /// <returns>An instance of the specified type with data from the request</returns>
        private async Task<T> GetResourcesWithParamsAsync<T>(string apiParam, CancellationToken cancellationToken) where T : ResourceBase
        {
            // lowercase the resource name as the API doesn't recognize upper case and lower case as the same
            string sanitizedApiParam = apiParam.ToLowerInvariant();

            string apiEndpoint = GetApiEndpointString<T>();
            HttpResponseMessage response = await _client.GetAsync($"{apiEndpoint}/{sanitizedApiParam}/", cancellationToken);        // trailing slash is needed!

            response.EnsureSuccessStatusCode();

            string resp = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resp);
        }

        /// <summary>
        /// Gets a resource from a navigation url; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="url">Navigation url</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <exception cref="NotSupportedException">Navigation url doesn't contain the resource id</exception>
        /// <returns>The object of the resource</returns>
        internal async Task<T> GetResourceByUrlAsync<T>(string url, CancellationToken cancellationToken) where T : ResourceBase
        {
            // need to parse out the id in order to check if it's cached.
            // navigation urls always use the id of the resource
            string trimmedUrl = url.TrimEnd('/');
            string resourceId = trimmedUrl.Substring(trimmedUrl.LastIndexOf('/') + 1);

            if (!int.TryParse(resourceId, out int id))
            {
                // not sure what to do here...
                throw new NotSupportedException($"Navigation url '{url}' is in an unexpected format");
            }

            T resource = _cacheManager.Get<T>(id);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(resourceId, cancellationToken);
                _cacheManager.Store<T>(resource);
            }

            return resource;
        }

        /// <summary>
        /// Gets a resource by id; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="id">Id of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(int id) where T : ResourceBase
        {
            return await GetResourceAsync<T>(id, CancellationToken.None);
        }

        /// <summary>
        /// Gets a resource by id; resource is retrieved from cache if possible
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="id">Id of resource</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(int id, CancellationToken cancellationToken) where T : ResourceBase
        {
            T resource = _cacheManager.Get<T>(id);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(id.ToString(), cancellationToken);
                _cacheManager.Store(resource);
            }

            return resource;
        }

        /// <summary>
        /// Gets a resource by name; resource is retrieved from cache if possible. This lookup
        /// is case insensitive.
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name) where T : ResourceBase
        {
            return await GetResourceAsync<T>(name, CancellationToken.None);
        }

        /// <summary>
        /// Gets a resource by name; resource is retrieved from cache if possible. This lookup
        /// is case insensitive.
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="name">Name of resource</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The object of the resource</returns>
        public async Task<T> GetResourceAsync<T>(string name, CancellationToken cancellationToken) where T : ResourceBase
        {
            string sanitizedName = name
                .Replace(" ", "-")      // no resource can have a space in the name; API uses -'s in their place
                .Replace("'", "")       // looking at you, Farfetch'd
                .Replace(".", "");      // looking at you, Mime Jr. and Mr. Mime

            // Nidoran is interesting as the API wants 'nidoran-f' or 'nidoran-m'

            T resource = _cacheManager.Get<T>(sanitizedName);
            if (resource == null)
            {
                resource = await GetResourcesWithParamsAsync<T>(sanitizedName, cancellationToken);
                _cacheManager.Store(resource);
            }

            return resource;
        }

        /// <summary>
        /// Resolves all navigation properties in a collection
        /// </summary>
        /// <typeparam name="T">Navigation type</typeparam>
        /// <param name="collection">The collection of navigation objects</param>
        /// <returns>A list of resolved objects</returns>
        public async Task<List<T>> GetResourceAsync<T>(IEnumerable<UrlNavigation<T>> collection) where T : ResourceBase
        {
            return await GetResourceAsync<T>(collection, CancellationToken.None);
        }

        /// <summary>
        /// Resolves all navigation properties in a collection
        /// </summary>
        /// <typeparam name="T">Navigation type</typeparam>
        /// <param name="collection">The collection of navigation objects</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>A list of resolved objects</returns>
        public async Task<List<T>> GetResourceAsync<T>(IEnumerable<UrlNavigation<T>> collection, CancellationToken cancellationToken) where T : ResourceBase
        {
            return (await Task.WhenAll(collection.Select(m => GetResourceAsync(m, cancellationToken)))).ToList();
        }

        /// <summary>
        /// Resolves a single navigation property
        /// </summary>
        /// <typeparam name="T">Navigation type</typeparam>
        /// <param name="urlResource">The single navigation object to resolve</param>
        /// <returns>A resolved object</returns>
        public async Task<T> GetResourceAsync<T>(UrlNavigation<T> urlResource) where T : ResourceBase
        {
            return await GetResourceByUrlAsync<T>(urlResource.Url, CancellationToken.None);
        }

        /// <summary>
        /// Resolves a single navigation property
        /// </summary>
        /// <typeparam name="T">Navigation type</typeparam>
        /// <param name="urlResource">The single navigation object to resolve</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>A resolved object</returns>
        public async Task<T> GetResourceAsync<T>(UrlNavigation<T> urlResource, CancellationToken cancellationToken) where T : ResourceBase
        {
            return await GetResourceByUrlAsync<T>(urlResource.Url, cancellationToken);
        }

        /// <summary>
        /// Clears all cached data
        /// </summary>
        public void ClearCache()
        {
            _cacheManager.ClearAll();
        }

        /// <summary>
        /// Clears the cached data for a specific resource
        /// </summary>
        /// <typeparam name="T">The type of cache</typeparam>
        public void ClearCache<T>() where T : ResourceBase
        {
            _cacheManager.Clear<T>();
        }

        /// <summary>
        /// Gets a single page of named resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <returns>The paged resource object</returns>
        public async Task<NamedApiResourceList<T>> GetNamedResourcePageAsync<T>() where T : NamedApiResource
        {
            return await GetNamedResourcePageAsync<T>(CancellationToken.None);
        }

        /// <summary>
        /// Gets a single page of named resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public async Task<NamedApiResourceList<T>> GetNamedResourcePageAsync<T>(CancellationToken cancellationToken) where T : NamedApiResource
        {
            string resp = await GetPageAsync<T>(cancellationToken);
            return JsonConvert.DeserializeObject<NamedApiResourceList<T>>(resp);
        }

        /// <summary>
        /// Gets the specified page of named resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="limit">The number of resources in a list page</param>
        /// <param name="offset">Page offset</param>
        /// <returns>The paged resource object</returns>
        public async Task<NamedApiResourceList<T>> GetNamedResourcePageAsync<T>(int limit, int offset) where T : NamedApiResource
        {
            return await GetNamedResourcePageAsync<T>(limit, offset, CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified page of named resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="limit">The number of resources in a list page</param>
        /// <param name="offset">Page offset</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public async Task<NamedApiResourceList<T>> GetNamedResourcePageAsync<T>(int limit, int offset, CancellationToken cancellationToken) where T : NamedApiResource
        {
            string resp = await GetPageAsync<T>(cancellationToken, limit, offset);
            return JsonConvert.DeserializeObject<NamedApiResourceList<T>>(resp);
        }

        /// <summary>
        /// Gets a single page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <returns>The paged resource object</returns>
        public async Task<ApiResourceList<T>> GetApiResourcePageAsync<T>() where T : ApiResource
        {
            return await GetApiResourcePageAsync<T>(CancellationToken.None);
        }

        /// <summary>
        /// Gets a single page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public async Task<ApiResourceList<T>> GetApiResourcePageAsync<T>(CancellationToken cancellationToken) where T : ApiResource
        {
            string resp = await GetPageAsync<T>(cancellationToken);
            return JsonConvert.DeserializeObject<ApiResourceList<T>>(resp);
        }

        /// <summary>
        /// Gets the specified page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="limit">The number of resources in a list page</param>
        /// <param name="offset">Page offset</param>
        /// <returns>The paged resource object</returns>
        public async Task<ApiResourceList<T>> GetApiResourcePageAsync<T>(int limit, int offset) where T : ApiResource
        {
            return await GetApiResourcePageAsync<T>(limit, offset, CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="limit">The number of resources in a list page</param>
        /// <param name="offset">Page offset</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public async Task<ApiResourceList<T>> GetApiResourcePageAsync<T>(int limit, int offset, CancellationToken cancellationToken) where T : ApiResource
        {
            string resp = await GetPageAsync<T>(cancellationToken, limit, offset);
            return JsonConvert.DeserializeObject<ApiResourceList<T>>(resp);
        }

        private async Task<string> GetPageAsync<T>(CancellationToken cancellationToken, int? limit = null, int? offset = null) where T : ResourceBase
        {
            string apiEndpoint = GetApiEndpointString<T>();
            string queryParameters = String.Empty;

            // limit and offset cannot both be null
            if (limit != null)
            {
                queryParameters = $"?limit={limit}";
                if (offset != null)
                {
                    queryParameters += $"&offset={offset}";
                }
            }

            HttpResponseMessage response = await _client.GetAsync($"{apiEndpoint}{queryParameters}", cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private string GetApiEndpointString<T>()
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty("ApiEndpoint", BindingFlags.Static | BindingFlags.NonPublic);
            return propertyInfo.GetValue(null).ToString();
        }
    }
}
