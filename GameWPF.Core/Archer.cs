using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Archer : Character
    {
        public Archer(
            int baseHealth = 80,
            int strength = 20,
            int defense = 7,
            int experience = 0,
            int gold = 0,
            string name = "Archer",
            Level level = Level.Level1)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }
        
    }
}
