using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Zombie : NPC
    {
        public Zombie(
            int baseHealth = 60,
            int strength = 10,
            int defense = 5,
            int experienceReward = 5,
            int goldReward = 5,
            string name = "Zombie",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experienceReward, goldReward, name, level)
        {
        }
        public override void Attack(ICharacter target)
        {
            Console.WriteLine("Rarhh..");
            target.TakeDamage(Strength + (new Random()).Next(1, 5));
        }
    }
}
