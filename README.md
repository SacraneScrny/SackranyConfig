# SackranyConfig

A configuration registry for Unity. Static configs are auto-loaded from
`Resources/Configs`, and dynamic configs are persisted to disk in
`Application.persistentDataPath`.

## Config types

- `IConfig` — static, read-only config loaded from `Resources/Configs/<Name>.json`.
- `IDynamicConfig` — mutable config that is also saved to disk and reloaded on the next run.

## Usage

```csharp
class MyConfig : IDynamicConfig { public float Speed = 5f; }

float v = ConfigGet<MyConfig>.Value.Speed;          // read
ConfigSet<MyConfig>.DoAndSave(c => c.Speed = 10);   // write + save
```

`ConfigGet<T>` returns the registered instance of a config. `ConfigSet<T>`
mutates a dynamic config, with optional or explicit persistence
(`Do`, `DoAndSave`).

## Loading and persistence

- `ConfigLoader` runs before the first scene loads, builds a map of all `IConfig`
  types, and populates static configs from `Resources/Configs`.
- `DynamicConfigLoader` loads dynamic configs from `persistentDataPath/Configs`,
  creating default files when none exist, and exposes `Save<T>`, `SaveAll`, and
  `Reset<T>`.
- `ConfigPersistence` bootstraps itself on start under `DontDestroyOnLoad` and
  saves all dynamic configs when the application quits or is paused, so no scene
  setup is required.
- `ConfigSerializer` serializes and restores all registered configs to and from a
  single JSON string.

WebGL builds skip disk persistence automatically.

## Editor

- `Sackrany/Configs/Save All` — write the current state of every config to
  `Assets/Resources/Configs`.
- `Sackrany/Configs/Generate Defaults` — generate default JSON files for any
  config that does not yet have one.

## Dependencies

- `Sackrany.Utils`
- Newtonsoft.Json
