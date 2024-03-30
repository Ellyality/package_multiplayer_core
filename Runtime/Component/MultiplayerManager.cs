using UnityEngine;

namespace Ellyality.RPG
{
    [AddComponentMenu("Ellyality/RPG/RPG Manager")]
    public class MultiplayerManager : MonoBehaviour
    {
        [HideInInspector] MultiplayerSetting setting;

        private void OnEnable()
        {
            setting = MultiplayerSetting.Load();
        }
    }
}
