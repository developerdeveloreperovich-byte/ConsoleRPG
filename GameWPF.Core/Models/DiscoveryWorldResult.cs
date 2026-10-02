using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Models
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
