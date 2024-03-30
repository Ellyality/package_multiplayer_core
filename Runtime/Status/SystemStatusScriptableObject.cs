using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/System")]
    public sealed class SystemStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public SystemStatus Status;
    }
}
