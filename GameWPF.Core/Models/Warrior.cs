using GameWPF.Core.Constants;
using GameWPF.Core.Enums;
using GameWPF.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Models
{
    public class Warrior : Character
    {
        public Warrior(
            int baseHealth = GameConstants.DefaultWarriorBaseHealth,
            int strength = GameConstants.DefaultWarriorStrength,
            int defense = GameConstants.DefaultWarriorDefense,
            int experience = GameConstants.DefaultCharacterExperience,
            int gold = GameConstants.DefaultCharacterGold,
            string name = GameConstants.DefaultWarriorName,
            Level level = GameConstants.DefaultLevel)
            : base(baseHealth, strength, defense, experience, gold, name, level)
        {
        }

        public override void Attack(ICharacter target)
        {
            //Console.WriteLine("Warrior just screamed and attack it`s target by jumping and stabbing it! ");
            target.TakeDamage(Strength + (new Random()).Next(1, 15));
        }
    }
}
