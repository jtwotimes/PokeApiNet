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

## Navigation URLs
PokeAPI uses navigation urls for many of the resource's properties to keep requests lightweight, but require subsequent requests in order to resolve this data. Example:
```cs
Pokemon pikachu = await pokeClient.GetResourceAsync<Pokemon>("pikachu");
```

`pikachu.Species` only has a `Name` and `Url` property. In order to load this data, an additonal request is needed; this is more of a problem when the property is a list of navigation URLs, such as `pikachu.Moves`.

Each navigation object (specifically classes `NamedApiResource` and `ApiResource`) includes a method to help with resolving these resources. Example:
```cs
// to resolve a single navigation url property
PokemonSpecies species = await pikachu.Species.ResolveAsync(client);

// to resolve a list of them
List<Move> allMoves = (await Task.WhenAll(pikachu.Moves.Select(m => m.Move.ResolveAsync(client)))).ToList();
```

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