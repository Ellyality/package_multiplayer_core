using UnityEngine;

namespace Elly.Multiplayer
{
    public class MultiplayerSetting : ScriptableObject
    {
        [SerializeField] string ServerAddress;
        [SerializeField] PlayerStructureScriptableObject PlayerTemplate;

        public const string CONFIG_NAME = "com.ellyality.multiplayer.settings";

        public static MultiplayerSetting instance;

        private void OnEnable()
        {
            if (instance == null) instance = this;
        }

        public static MultiplayerSetting Load()
        {
            if (instance) return instance;
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject(CONFIG_NAME, out instance);
#else
            // Loads from the memory.
            instance = FindObjectOfType<MultiplayerSetting>();
#endif
            return instance;
        }
    }
}
