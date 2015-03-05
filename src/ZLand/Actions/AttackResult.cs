using ZLand.DamageTypes;

namespace ZLand.Actions
{
    public class AttackResult
    {
        public AttackResult(bool criticalHit, bool criticalFailure, double calculatedDamage, double hitPercentage, DamageType damageType)
        {
            CriticalHit = criticalHit;
            CriticalFailure = criticalFailure;
            CalculatedDamage = calculatedDamage;
            HitPercentage = hitPercentage;
            DamageType = damageType;
        }

        public bool CriticalHit { get; private set; }
        public bool CriticalFailure { get; private set; }
        public double CalculatedDamage { get; private set; }
        public double HitPercentage { get; private set; }
        public DamageType DamageType { get; private set; }
    }
}