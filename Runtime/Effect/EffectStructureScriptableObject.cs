using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Effect")]
    public sealed class EffectStructureScriptableObject : ScriptableObject
    {
        [SerializeField] public EffectStructure Structure;
    }
}
