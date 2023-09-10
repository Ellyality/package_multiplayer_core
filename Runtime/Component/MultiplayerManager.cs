using UnityEngine;

namespace Elly.Multiplayer
{
    [AddComponentMenu("Elly/Multiplayer/Manager")]
    public class MultiplayerManager : MonoBehaviour
    {
        [HideInInspector] MultiplayerSetting setting;

        private void OnEnable()
        {
            setting = MultiplayerSetting.Load();
        }
    }
}
