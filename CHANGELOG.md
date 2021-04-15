# Changelog

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