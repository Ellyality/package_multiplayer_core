using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Item/Wearable")]
    public sealed class WearableScriptableObject : ScriptableObject
    {
        [SerializeField] public Wearable Structure;
    }
}
