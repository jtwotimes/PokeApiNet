using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PokeApiNet
{
    /// <summary>
    /// Thin wrapper class for all serialization in the PokeApiNet solution
    /// </summary>
    /// <remarks>This class exists so that the serializer can be swapped out for a different implementation
    /// in the future without breaking the existing API. This also allows for any common settings for all
    /// serialization operations to take place automatically.</remarks>
    internal static class PokeApiSerializer
    {
        private readonly static JsonSerializerOptions _defauleSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _defauleSerializerOptions);
        }

        public static async Task<T> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, _defauleSerializerOptions, cancellationToken);
        }
    }
}
