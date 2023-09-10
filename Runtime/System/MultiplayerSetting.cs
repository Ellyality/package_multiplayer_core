using UnityEngine;

namespace Elly.Multiplayer
{
    public class MultiplayerSetting : ScriptableObject
    {
        [Header("Client Side")]
        [SerializeField] public string ServerAddress;
        [SerializeField] public PlayerStructureScriptableObject PlayerTemplate;

        [Header("Server Side")]
        [SerializeField] public string Database_Address;

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
