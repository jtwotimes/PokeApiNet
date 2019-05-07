# PokeApiNet
A .Net wrapper for the Pokemon API at [https://pokeapi.co](https://pokeapi.co).

Targets .Net Standard 2.0.

[![CircleCI](https://circleci.com/gh/mtrdp642/PokeApiNet/tree/master.svg?style=svg)](https://circleci.com/gh/mtrdp642/PokeApiNet/tree/master)

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

`pikachu.Species` only has a `Name` and `Url` property. In order to load this data, an additonal request is needed; this is more of a problem when the property is a list of navigation URLs, such as the `pikachu.Moves.Move` collection.

`GetResouceAsync` includes overloads to assist with resolving these navigation properties. Example:
```cs
// to resolve a single navigation url property
PokemonSpecies species = await pokeClient.GetResourceAsync(pikachu.Species);

// to resolve a list of them
List<Move> allMoves = await pokeClient.GetResourceAsync(pikachu.Moves.Select(move => move.Move));
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
