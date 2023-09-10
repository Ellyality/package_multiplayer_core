using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Monster/Structure")]
    public sealed class MonsterStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public MonsterStructure Structure;
    }
}
