using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Status/Creature")]
    public sealed class CreatureStatusScriptableObject : ScriptableObject
    {
        [SerializeField] public CreatureStatus Status;
    }
}
