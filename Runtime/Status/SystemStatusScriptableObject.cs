using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Status/System")]
    public sealed class SystemStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public SystemStatus Status;
    }
}
