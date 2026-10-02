using GameWPF.Core.Enums;
using GameWPF.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Constants
{
    public class GameConstants
    {
        #region Warrior constants

        public const int DefaultWarriorBaseHealth = 110;
        public const int DefaultWarriorStrength = 16;
        public const int DefaultWarriorDefense = 12;
        public const string DefaultWarriorName = "Warrior";

        #endregion

        #region Archer constants

        public const int DefaultArcherBaseHealth = 80;
        public const int DefaultArcherStrength = 20;
        public const int DefaultArcherDefense = 7;
        public const string DefaultArcherName = "Archer";

        #endregion

        #region Mage constants

        public const int DefaultMageBaseHealth = 65;
        public const int DefaultMageStrength = 22;
        public const int DefaultMageDefense = 4;
        public const string DefaultMageName = "Mage";

        #endregion


        public const int DefaultCharacterExperience = 0;
        public const int DefaultCharacterGold = 0;
        public const Level DefaultLevel = Level.Level1;
    }
}
