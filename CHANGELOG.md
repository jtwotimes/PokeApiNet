# Changelog

## 2.1.0
### Added
- Now supports .Net Standard 2.1
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