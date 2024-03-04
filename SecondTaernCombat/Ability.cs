using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaernCombat
{
    public struct Ability
    {
        public string Name;
        //determines when attack can be used in the initiative and what defensive stati will be used to block it
        public byte AttackType;
        public decimal DamageModifier;
        public decimal AccuracyModyfier;
        public Character user;
        public Character target;

        public Ability(string name, byte attackType, decimal damageModifier, decimal accuracyModyfier)
        {
            Name = name;
            AttackType = attackType;
            DamageModifier = damageModifier;
            AccuracyModyfier = accuracyModyfier;
        }
        public void SetUserAndTarget(Character user, Character target)
        {
            this.user = user;
            this.target = target;
        }
        public void SetTarget(Character target) => this.target = target;
        public bool IsUserDead()
        {
            if (user.health <= 0) return true;
            else return false;
        }
        public bool IsTargetDead()
        {
            if (target.health <= 0) return true;
            else return false;
        }
        public void ExecuteAbilityEffect()
        {
            if (DoesAttackHit() == false && DoesDoubleAttackRollHit() == false)
            {
                return;
            }
            // if chance to double roll defence, block attack, end method
            if (DoesDoubleDefenceRollBlock() == true)
            {
                return;
            }
            DoAttack();
        }
        private void DoAttack() => target.ReceiveDamage((int)(user.PlaceholderDamage*DamageModifier));
        private bool DoesAttackHit() => Dice.Roll(1000) / 1000 <= CalculateHitChance(); //if Dice roll is equal or less then chance to hit return true 
        private bool DoesDoubleAttackRollHit()
        {
            // if Double Hit roll triggers roll second time to hit
            if (Dice.Roll(1000) / 1000 < user.DoubleHitRollChance)
            {
                if (DoesAttackHit()) { return true; }
            }
            return false;
        }
        private bool DoesDoubleDefenceRollBlock()
        {
            // if Double Defence roll triggers roll second time to hit
            if (Dice.Roll(1000) / 1000 < target.DoubleDefenceRollChance)
            {
                if (!DoesAttackHit()) { return true; }
            }
            return false;
        }
        private decimal CalculateHitChance()
        {
            return (user.HitStat * AccuracyModyfier) / (user.HitStat + target.DefenceStat);
        }
    }
}
