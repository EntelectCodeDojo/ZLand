using ZLand.Actors;
using ZLand.World;

namespace ZLand.Actions
{
    public abstract class OtherCellAction : Action
    {
        protected OtherCellAction(int baseCost, string name, int range)
            : base(baseCost, name)
        {
            Range = range;
        }

        public int Range { get; set; }

        public virtual void Apply(Actor initiatingActor, Cell targetCell)
        {
            var cost = GetPointsCost(initiatingActor, targetCell);
            EnsureHasEnoughPoints(initiatingActor, cost);
            EnsureInRange(initiatingActor, targetCell);
            initiatingActor.SpendActionPoints(cost);
        }

        public virtual int GetPointsCost(Actor initiatingActor, Cell targetCell)
        {
            return BaseCost*Range;
        }

        protected virtual void EnsureInRange(Actor initiatingActor, Cell targetCell)
        {
            if (!IsInRange(initiatingActor, targetCell))
            {
                throw new NotInRangeException();
            }
        }

        public virtual bool IsInRange(Actor initiatingActor, Cell targetCell)
        {
            var distance = initiatingActor.CurrentPosition.DistanceTo(targetCell);
            return distance <= Range;
        }
    }
}