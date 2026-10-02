using GameWPF.Core.Constants;
using GameWPF.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Models
{
    public class Archer : Character
    {
        public Archer(
            int baseHealth = GameConstants.DefaultArcherBaseHealth,
            int strength = GameConstants.DefaultArcherStrength,
            int defense = GameConstants.DefaultArcherDefense,
            int experience = GameConstants.DefaultCharacterExperience,
            int gold = GameConstants.DefaultCharacterGold,
            string name = GameConstants.DefaultArcherName,
            Level level = GameConstants.DefaultLevel)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }
        
    }
}
