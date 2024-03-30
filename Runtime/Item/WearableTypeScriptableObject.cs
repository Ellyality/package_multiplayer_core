using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Item/WearableType")]
    public sealed class WearableTypeScriptableObject : ScriptableObject
    {
        [SerializeField] public WearableType Structure;
    }
}
