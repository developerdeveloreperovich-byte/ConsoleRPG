using GameWPF.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Interfaces
{
    public interface ICharacter : IDamageable, IAttackable
    {
        public Level Level { get; set; }
    }
}
