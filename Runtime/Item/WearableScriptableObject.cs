using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Item/Wearable")]
    public sealed class WearableScriptableObject : ScriptableObject
    {
        [SerializeField] public Wearable Structure;
    }
}
