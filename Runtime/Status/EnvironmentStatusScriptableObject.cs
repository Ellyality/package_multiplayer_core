using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Environment")]
    public sealed class EnvironmentStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public EnvironmentStatus Status;
    }
}
