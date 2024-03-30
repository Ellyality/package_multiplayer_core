using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Monster/Structure")]
    public sealed class MonsterStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public MonsterStructure Structure;
    }
}
