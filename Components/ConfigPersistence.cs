using UnityEngine;

namespace Sackrany.ConfigSystem.SackranyConfig.Components
{
    /// <summary>
    /// Сохраняет все динамические конфиги при выходе/сворачивании приложения.
    /// Раньше компонент жил на «системной» сцене — теперь сам поднимается на старте
    /// в DontDestroyOnLoad, поэтому ConfigSystem самодостаточен и не требует сцены.
    /// </summary>
    public class ConfigPersistence : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Bootstrap()
        {
            var go = new GameObject(nameof(ConfigPersistence));
            go.AddComponent<ConfigPersistence>();
            DontDestroyOnLoad(go);
        }

        void OnApplicationQuit() => DynamicConfigLoader.SaveAll();

        void OnApplicationPause(bool pause)
        {
            if (pause) DynamicConfigLoader.SaveAll();
        }
    }
}
