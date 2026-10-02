using GameWPF.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Managers
{
    public class StoreManager
    {
        public static bool CanBuy(Character player, Item item)
        {
            return player.Gold >= item.Price;
        }

        public static bool BuyItem(Character player, Item item)
        {
            bool canBuy = CanBuy(player, item);
            if (canBuy)
            {
                player.Gold -= item.Price;
                player.Inventory.Add(item);
            }
            return canBuy;

        }

        public static IEnumerable<Item> Catalog { get; } = new List<HealingPotion>
        {
            new() { Id = 1, Name = "Weak healing potion", Price = 15, ImagePath="C:\\Users\\oleks\\Downloads\\small_healing_potion_128.png", HealPower = 50 },
            new() { Id = 2, Name = "Healing potion", Price = 50, ImagePath="C:\\Users\\oleks\\Downloads\\medium_healing_potion_128.png", HealPower = 100 },
            new() { Id = 3, Name = "Strong healing potion", Price = 70, ImagePath="C:\\Users\\oleks\\Downloads\\large_healing_potion_128.png", HealPower = 200 },
            new(),
            new(),
        };
    }
}
