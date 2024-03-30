using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Structure")]
    public sealed class PlayerStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public PlayerStructure Structure;
    }
}
