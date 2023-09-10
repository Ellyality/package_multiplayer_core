using UnityEngine;

namespace Elly.Multiplayer
{
    [CreateAssetMenu(menuName = "Multiplayer/Item/Usable")]
    public sealed class UseableScriptableObject : ScriptableObject
    {
        [SerializeField] public Usable Structure;
    }
}
