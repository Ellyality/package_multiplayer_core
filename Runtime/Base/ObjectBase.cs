using UnityEngine;

namespace Elly.Multiplayer
{
    /// <summary>
    /// Contain database query keyword, and display name and description.
    /// </summary>
    public class ObjectBase
    {
        /// <summary>
        /// Display name
        /// </summary>
        public string Name;
        /// <summary>
        /// For database column name
        /// </summary>
        public string Keyword;
        /// <summary>
        /// Show, when mouse hover
        /// </summary>
        [TextArea(1, 15)]
        public string Description;
    }
}
