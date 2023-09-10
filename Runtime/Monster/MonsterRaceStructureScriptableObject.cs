using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Monster/Race")]
    public sealed class MonsterRaceStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public MonsterRaceStructure Structure;
    }
}
