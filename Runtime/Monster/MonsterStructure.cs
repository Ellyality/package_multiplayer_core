using System;
using System.Collections.Generic;

namespace Ellyality.RPG
{
    [System.Serializable]
    public class MonsterStructure : MonsterBase
    {
        public MonsterRaceStructureScriptableObject Race;
        public bool Aggressive;
        public List<Pair<string>> StatusString;
        public List<Pair<int>> StatusInt;
        public List<Pair<float>> StatusFloat;
    }
}
