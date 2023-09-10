using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Item/Base")]
    public sealed class ItemScriptableObject : ScriptableObject
    {
        [SerializeField] public Item Structure;
    }
}
