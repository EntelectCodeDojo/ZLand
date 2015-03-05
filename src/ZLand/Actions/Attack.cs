using System;
using ZLand.Actors;
using ZLand.DamageTypes;
using ZLand.World;

namespace ZLand.Actions
{
    public abstract class Attack : OtherCellAction
    {
        protected Attack(int cost, string name, int range, double minDamage, double maxDamage, DamageType damageType, double criticalHitChance, double criticalMissChance) 
            : base(cost, name, range)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            DamageType = damageType;
            CriticalHitChance = criticalHitChance;
            CriticalMissChance = criticalMissChance;
        }

        public double MinDamage { get; private set; }
        public double MaxDamage { get; private set; }
        public DamageType DamageType { get; private set; }
        public double CriticalHitChance { get; private set; }
        public double CriticalMissChance { get; private set; }

        protected AttackResult CalculateAttackResult(Actor actor, Cell targetCell)
        {
            var random = new Random();
            var range = MaxDamage - MinDamage;
            var calculatedDamage = random.NextDouble()*range + MinDamage;
            return new AttackResult
            (
                calculatedDamage : calculatedDamage,
                criticalFailure : false, //todo
                criticalHit : false, //todo
                damageType : DamageType,
                hitPercentage : 100 //todo
            );
        }
    }
}