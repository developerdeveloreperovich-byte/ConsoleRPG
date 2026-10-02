using GameWPF.Core.Constants;
using GameWPF.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Models
{
    public class Mage : Character
    {
        public Mage(
            int baseHealth = GameConstants.DefaultMageBaseHealth,
            int strength = GameConstants.DefaultMageStrength,
            int defense = GameConstants.DefaultMageDefense,
            int experience = GameConstants.DefaultCharacterExperience,
            int gold = GameConstants.DefaultCharacterGold,
            string name = GameConstants.DefaultMageName,
            Level level = GameConstants.DefaultLevel)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }
        
    }
}
