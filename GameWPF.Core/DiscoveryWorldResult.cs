using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public abstract class DiscoveryObject { }
    public class Gold : DiscoveryObject
    {
        public int GoldAmount { get; init; }
    }

    public class DiscoveredNPC : DiscoveryObject
    {
        public NPC NPC { get; init; }
    }
}
