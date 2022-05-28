# Changelog

## 3.0.4
### Fix
- Ensure HTTP responses are only processed after the content of the request has been read, instead of just the headers: [#29](https://github.com/mtrdp642/PokeApiNet/issues/29)
- Updated dependencies
- Bump test project to .Net 6.0

## 3.0.3
### Added
- Updated `Pokemon` model to include new property: `past_types`

## 3.0.2
### Added
- Updated `PokemonSpecies` model to include new properties: `IsLegendary`, `IsMythical`
- Code cleanup and small performance improvements

## 3.0.1
### Added
- `PokeApiClient` constructor that accepts an `HttpClient` instance; for use with the `IHttpClientFactory` interface
- Updated test dependencies

## 3.0.0
### Breaking Changes
- All classes under the `PokeApiNet.Models` namespace were moved to `PokeApiNet`
- Namespace `PokeApiNet.Models` has been removed

### Added
- Support for .Net Standard 2.1
- Updated dependencies

## 2.0.0
### Breaking Changes
- Class `PokeApiClient` moved namespace; was `PokeApiNet.Data` now `PokeApiNet`
- Namespace `PokeApiNet.Data` has been removed
- Method `PokeApiClient.ClearCache<T>` was renamed to `PokeApiClient.ClearResourceCache<T>`
- Stricter constraints on type parameters for `PokeApiClient.GetResourceAsync<T>(string)` and `PokeApiClient.GetResourceAsync<T>(string, CancellationToken)`

### Added
- Resource lists are now cached automatically (closes [#10](https://github.com/mtrdp642/PokeApiNet/issues/10))
- Resource list caches can be cleared via `PokeApiClient.ClearResourceListCache` and typed overload for more granular clearing
