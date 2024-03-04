using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public class Character
    {
        public Character(int health, int maxHealth, decimal hitStat, decimal defenceStat, int placeholderDamage, decimal doubleHitRollChance, decimal doubleDefenceRollChance, Ability[] abilities)
        {
            id = GetHashCode(); //Not perfect but for the purpose of this program it will suffice
            this.health = health;
            this.maxHealth = maxHealth;
            HitStat = hitStat;
            DefenceStat = defenceStat;
            PlaceholderDamage = placeholderDamage;
            DoubleHitRollChance = doubleHitRollChance;
            DoubleDefenceRollChance = doubleDefenceRollChance;
            DefenceStat = defenceStat;
            Abilities = abilities;
        }
        public int id { get; init; }
        public int health { get; private set; }
        public int maxHealth { get; private set; }
        public decimal HitStat { get; private set; }
        public decimal DefenceStat { get; private set; }
        public decimal DoubleHitRollChance { get; private set; }
        public decimal DoubleDefenceRollChance { get; private set; }
        public int PlaceholderDamage { get; private set; }
        public int Initiative { get; private set; }
        public Ability[] Abilities { get; private set; }

        public void ReceiveDamage(int damage) => health -= damage;
        public Ability ChooseRandomAbility() => Abilities[(int)Dice.Roll(Abilities.Length-1)];
        public void SetInitiative(int initiative) => Initiative = initiative;
        public void ChangeMaxHealth(int newValue) => this.health = newValue;
        public void ChangeHitStat(decimal newValue) => this.HitStat = newValue;
        public void ChangeDefenceStat(decimal newValue) => this.DefenceStat = newValue;
        public void ChangeDoubleHitRollChance(decimal newValue) => this.DoubleHitRollChance = newValue;
        public void ChangeDoubleDefenceRollChance(decimal newValue) => this.DoubleDefenceRollChance = newValue;
        public void ChangePlaceholderDamage(int newValue) => this.PlaceholderDamage = newValue;
        public void ChangeAbilitiesArray(Ability[] newValue) => this.Abilities = newValue;

        public override string ToString()
        {
            return $"{health}, {Initiative}";
        }
    }
}
