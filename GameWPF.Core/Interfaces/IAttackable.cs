using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Interfaces
{
    public interface IAttackable
    {
        void Attack(ICharacter target);
    }
}
