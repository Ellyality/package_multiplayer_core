using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Player/Structure")]
    public sealed class PlayerStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public PlayerStructure Structure;
    }
}
