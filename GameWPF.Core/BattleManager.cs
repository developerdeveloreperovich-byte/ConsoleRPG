using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleRPG
{
    public static class BattleManager
    {
        public static void AttackNpc(Character character, NPC npc)
        {
            var npcHpBeforeAttack = npc.Health;
            character.Attack(npc);
            Console.WriteLine($"{npc.Name} got injured by {npcHpBeforeAttack - npc.Health} hp");
        }
        public static void AttackCharacter(Character character, NPC npc)
        {
            var charHpBeforeAttack = character.Health;
            npc.Attack(character);
            Console.WriteLine($"YOU got injured by {charHpBeforeAttack - character.Health} hp");
        }

        public static bool TryRun(Character character, NPC npc)
        {
            int randRun = (new Random()).Next(1, 4);
            if (randRun == 1)
            {
                Console.WriteLine("Run run!!");
                return true;
            }
            else
            {
                Console.WriteLine("You failed to escape from the battle");
                BattleManager.AttackCharacter(character, npc);
                return false;
            }
        }
    }
}
