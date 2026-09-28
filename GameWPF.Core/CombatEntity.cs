using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public abstract class CombatEntity : ICharacter
    {

        private int _health;
        private int _baseHealth;
        private int _strength;
        private int _defense;
        private Level _level = Level.Level1;
        public string Name { get; protected set; }

        protected CombatEntity(int baseHealth, int strength, int defense, string name, Level level)
        {
            _level = level;
            _baseHealth = baseHealth;
            _health = MaxHealth;
            _strength = strength;
            _defense = defense;
            Name = name;
        }

        public Level Level
        {
            get => _level;
            set => _level = value;
        }

        public int BaseHealth { get => _baseHealth; set => _baseHealth = value; }

        public int MaxHealth
        {
            get => BaseHealth * (int)Level;
        }
        public int Health
        {
            get => _health;
            set => _health = value;
        }
        
        public int Strength
        {
            get => _strength * (int)Level;
            set => _strength = value;
        }

        public int Defense
        {
            get => _defense * (int)Level;
            set => _defense = value;
        }

        public int Damage
        {
            get => Strength;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - Math.Max(1, damage - (Defense / 2)));
        }

        public virtual void Attack(ICharacter target)
        {
            target.TakeDamage(Damage);
        }
        public bool IsDead { get { return Health <= 0; } }

        
    }
}
