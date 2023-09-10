using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Item/WearableType")]
    public sealed class WearableTypeScriptableObject : ScriptableObject
    {
        [SerializeField] public WearableType Structure;
    }
}
