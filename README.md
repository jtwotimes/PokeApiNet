# PokeApiNet
A .Net wrapper for the Pokemon API at [https://pokeapi.co](https://pokeapi.co).

Targets .Net Standard 2.0.

# Use
```cs
using PokeApiNet.Data;
using PokeApiNet.Models;

...

// instantiate client
PokeApiClient pokeClient = new PokeApiClient();

// get a resource by name
Pokemon hoOh = await pokeClient.GetResourceAsync<Pokemon>("ho-oh");

// ... or by id
Item clawFossil = await pokeClient.GetResourceAsync<Item>(100);
```

To see all the resources that are available, see the [PokeAPI docs site](https://pokeapi.co/docs/v2.html).

## Caching
Every request response is automatically cached in memory, making all subsequent requests for the same resource pull cached data. Example:
```cs
// this will fetch the data from the API
Pokemon mew = await pokeClient.GetResourceAsync<Pokemon>(151);

// another call to the same resource will fetch from the cache
Pokemon mewCached = await pokeClient.GetResourceAsync<Pokemon>("mew");
```

To clear the cache of data:
```cs
// clear all caches
pokeClient.ClearCache();

// clear a particular resource type's cache
pokeClient.ClearCache<Item>();
```

# Build
```
dotnet build
```
# Test
The test bank includes unit tests and integration tests. Integration tests will actually ping the PokeApi server for data while the unit tests run off of mocked data.
```
dotnet test --filter "Category = Unit"
dotnet test --filter "Category = Integration"
```