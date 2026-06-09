using UnityEngine;

namespace SackranyConfig.Components
{
    public class ConfigPersistence : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
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
