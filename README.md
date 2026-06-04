# Sackrany.Config

Реестр конфигов с авто-загрузкой из `Resources/Configs` и сохранением динамических
конфигов в `persistentDataPath`. Обязательная зависимость для большинства фич.

**Типы конфигов:**
- `IConfig` — статический конфиг (только чтение из `Resources/Configs/<Имя>.json`).
- `IDynamicConfig` — изменяемый + сохраняемый на диск.

```csharp
class MyConfig : IDynamicConfig { public float Speed = 5f; }

var v = ConfigGet<MyConfig>.Value.Speed;            // чтение
ConfigSet<MyConfig>.DoAndSave(c => c.Speed = 10);   // запись + сохранение
```

`ConfigPersistence` сам поднимается на старте (DontDestroyOnLoad) и сохраняет все
динамические конфиги при выходе/сворачивании — сцена для этого не нужна.

**Зависимости:** `Sackrany.Utils`, Newtonsoft.Json.
**Editor:** `Sackrany/Configs/Save All`, `Sackrany/Configs/Generate Defaults`.
