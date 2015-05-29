using System;
using ZLand.Actors;
using ZLand.DamageTypes;
using ZLand.Services;
using ZLand.World;

namespace ZLand.Actions
{
    public abstract class Attack : OtherCellAction
    {
        protected Attack(int baseCost, string name, int range, double minDamage, double maxDamage, DamageType damageType, double criticalHitChance, double criticalMissChance, IRandomiser randomiser) 
            : base(baseCost, name, range)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            DamageType = damageType;
            CriticalHitChance = criticalHitChance;
            CriticalMissChance = criticalMissChance;
            Randomiser = randomiser;
        }

        public double MinDamage { get; private set; }
        public double MaxDamage { get; private set; }
        public DamageType DamageType { get; private set; }
        public double CriticalHitChance { get; private set; }
        public double CriticalMissChance { get; private set; }
        public IRandomiser Randomiser { get; private set; }

        protected AttackResult CalculateAttackResult(Actor actor, Cell targetCell)
        {
            var damageRange = MaxDamage - MinDamage;
            var calculatedDamage = Randomiser.Double() * damageRange + MinDamage;
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