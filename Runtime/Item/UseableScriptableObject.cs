using UnityEngine;

namespace Ellyality.RPG
{
    [CreateAssetMenu(menuName = "Ellyality/RPG/Item/Usable")]
    public sealed class UseableScriptableObject : ScriptableObject
    {
        [SerializeField] public Usable Structure;
    }
}
