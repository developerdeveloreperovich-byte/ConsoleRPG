using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Goblin : NPC
    {
        public Goblin(
            int baseHealth = 45,
            int strength = 8,
            int defense = 4,
            int experienceReward = 4,
            int goldReward = 3,
            string name = "Goblin",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experienceReward, goldReward, name, level)
        {
        }
        public override void Attack(ICharacter target)
        {
            Console.WriteLine("Goblin smash!!");
            target.TakeDamage(Strength + (new Random()).Next(1, 10));
        }
    }
}
