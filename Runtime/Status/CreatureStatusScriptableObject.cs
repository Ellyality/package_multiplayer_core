using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Creature")]
    public sealed class CreatureStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public CreatureStatus Status;
    }
}
