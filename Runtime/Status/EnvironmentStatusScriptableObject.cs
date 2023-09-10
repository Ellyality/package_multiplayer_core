using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Status/Environment")]
    public sealed class EnvironmentStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public EnvironmentStatus Status;
    }
}
