using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Environment")]
    public sealed class EnvironmentStructurecriptableObject : ScriptableObject
    {
        [SerializeField] public EnvironmentStructure Structure;
    }
}
