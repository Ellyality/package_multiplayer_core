using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Monster/Race")]
    public sealed class MonsterRaceStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public MonsterRaceStructure Structure;
    }
}
