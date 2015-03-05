using ZLand.Actors;

namespace ZLand.Actions
{
    public abstract class SameCellAction : Action
    {
        protected SameCellAction(int baseCost, string name)
            : base(baseCost, name)
        {
        }

        public virtual int GetPointsCost()
        {
            return BaseCost;
        }

        public virtual void Apply(Actor initiatingActor)
        {
            var cost = GetPointsCost();
            EnsureHasEnoughPoints(initiatingActor, cost);
            initiatingActor.SpendActionPoints(cost);
        }

    }
}