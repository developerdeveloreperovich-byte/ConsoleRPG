using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Warrior : Character
    {
        public Warrior(
            int baseHealth = 110,
            int strength = 16,
            int defense = 12,
            int experience = 0,
            int gold = 0,
            string name = "Warrior",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }

        public override void Attack(ICharacter target)
        {
            Console.WriteLine("Warrior just screamed and attack it`s target by jumping and stabbing it! ");
            target.TakeDamage(Strength + (new Random()).Next(1, 15));
        }
    }
}
