using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Interfaces
{
    public interface IDefendable
    {
        bool IsDefending { get; }

        void Defend();
    }
}
