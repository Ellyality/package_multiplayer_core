using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Environment")]
    public sealed class EnvironmentStructurecriptableObject : ScriptableObject
    {
        [SerializeField] public EnvironmentStructure Structure;
    }
}
