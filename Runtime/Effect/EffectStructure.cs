using UnityEngine;

namespace Ellyality.RPG
{
    [System.Serializable]
    public class EffectStructure : ObjectBase
    {
        /// <summary>
        /// The image that display on the effect list, or effect menu
        /// </summary>
        public Texture2D Image;
        public int StackLimit = 0;
        public bool NegativeEffect = false;

        public bool CanStack => StackLimit > 0;
    }
}
