using System;
using System.Collections.Generic;
using System.Text;
using GameWPF.Core.Enums;


namespace GameWPF.Core.Models
{
    public sealed class SaveData
    {
        public int Version { get; set; } = 1;
        public CharacterClass CharacterClass { get; set; }
        public int Health { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public List<int> InventoryItemIds { get; set; } = new();
    }
}
