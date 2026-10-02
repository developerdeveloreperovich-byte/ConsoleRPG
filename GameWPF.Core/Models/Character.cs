using GameWPF.Core.Enums;
using GameWPF.Core.Models;
using System.Collections.ObjectModel;
public abstract class Character : CombatEntity
{
    private int _experience;
    private int _gold;
    public ObservableCollection<Item> Inventory { get; } = new();
    public int Experience
    {
        get { return _experience; }
        set
        {
            _experience = value;
            if (Experience >= 500)
                Level = Level.Level5;
            else if (Experience >= 280)
                Level = Level.Level4;
            else if (Experience >= 100)
                Level = Level.Level3;
            else if (Experience >= 30)
                Level = Level.Level2;
            else
                Level = Level.Level1;
        }
    }
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    protected Character(int baseHealth, int strength, int defense, int experience, int gold, string name, Level level = Level.Level1) : base(baseHealth, strength, defense, name, level)
    {
        Experience = experience;
        Gold = gold;
    }

}