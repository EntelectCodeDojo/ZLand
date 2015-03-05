using ZLand.DamageTypes;

namespace ZLand.Actions
{
    public class AttackResult
    {
        public bool CriticalHit { get; set; }
        public bool CriticalFailure { get; set; }
        public double CalculatedDamage { get; set; }
        public double HitPercentage { get; set; }
        public DamageType DamageType { get; set; }
    }
}