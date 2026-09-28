using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class Orc : NPC
    {
        public Orc(
            int baseHealth = 75,
            int strength = 12,
            int defense = 8,
            int experienceReward = 7,
            int goldReward = 6,
            string name = "Orc",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experienceReward, goldReward, name, level)
        {
        }
        public override void Attack(ICharacter target)
        {
            Console.WriteLine("Orc just hit you in the face");
            target.TakeDamage(Strength + (new Random()).Next(1, 10));
        }
    }
}
