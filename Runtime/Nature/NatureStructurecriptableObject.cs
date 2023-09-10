using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Nature")]
    public sealed class NatureStructurecriptableObject : ScriptableObject
    {
        [SerializeField] public NatureStructure Structure;
    }
}
