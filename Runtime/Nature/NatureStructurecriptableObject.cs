using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Nature")]
    public sealed class NatureStructurecriptableObject : ScriptableObject
    {
        [SerializeField] public NatureStructure Structure;
    }
}
