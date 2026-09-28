using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public static class RewardManager
    {
        public static Reward GetReward(NPC enemy)
        {
            return new Reward { XP = enemy.ExperienceReward, Gold = enemy.GoldReward};
        }
        public static int GenGoldFromWorldDiscovery()
        {
            return new Random().Next(1,10);
        }
        public static void RewardPlayer(Character character, NPC enemy)
        {
            Reward reward = RewardManager.GetReward(enemy);
            character.Experience += reward.XP;
            character.Gold += reward.Gold;
        }
        public static void RewardPlayer(Character character, int goldAmount)
        {
            character.Gold += goldAmount;
        }
    }
}
