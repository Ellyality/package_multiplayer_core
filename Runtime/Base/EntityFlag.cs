using System;

namespace Elly.Multiplayer
{
    [Flags]
    public enum EntityFlag
    {
        None = 0,
        Player = 1,
        NPC = 2,
        Monster = 4,
        Boss = 8
    }
}
