using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public abstract class NPC : CombatEntity
    {
        private int _experienceReward;
        private int _goldReward;
        public int ExperienceReward
        {
            get => _experienceReward * (int)Level;
            protected set => _experienceReward = value;
        }
        public int GoldReward
        {
            get => _goldReward * (int)Level;
            protected set => _goldReward = value;
        }

        protected NPC(int baseHealth, int strength, int defense, int experienceReward, int goldReward, string name, Level level) : base(baseHealth, strength, defense, name, level)
        {
            ExperienceReward = experienceReward;
            GoldReward = goldReward;
        }
    }
}
