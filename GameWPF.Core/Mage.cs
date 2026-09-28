using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Mage : Character
    {
        public Mage(
            int baseHealth = 65,
            int strength = 22,
            int defense = 4,
            int experience = 0,
            int gold = 0,
            string name = "Mage",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }
        
    }
}
