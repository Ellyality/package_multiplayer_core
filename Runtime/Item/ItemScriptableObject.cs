using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Item/Base")]
    public sealed class ItemScriptableObject : ScriptableObject
    {
        [SerializeField] public Item Structure;
    }
}
