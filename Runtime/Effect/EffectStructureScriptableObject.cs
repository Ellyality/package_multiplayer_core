using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Effect")]
    public sealed class EffectStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public EffectStructure Structure;
    }
}
