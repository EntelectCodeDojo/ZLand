using ZLand.Actors;
using ZLand.DamageTypes;
using ZLand.Services;
using ZLand.World;

namespace ZLand.Actions
{
    public class MeleAttack : Attack
    {
        public MeleAttack(int cost, string name, double minDamage, double maxDamage, DamageType damageType, double criticalHitChance, double criticalMissChance, IRandomiser randomiser)
            : base(cost, name, 1, minDamage, maxDamage, damageType, criticalHitChance, criticalMissChance, randomiser)
        {
        }

        public override void Perform(Actor initiatingActor, Cell targetCell)
        {
            if (targetCell.Actor != null)
            {
                var attackResult = CalculateAttackResult(initiatingActor, targetCell);
                targetCell.Actor.ApplyDamageFromAttack(attackResult);
            }
        }
    }
}