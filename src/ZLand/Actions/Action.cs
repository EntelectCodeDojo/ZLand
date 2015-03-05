using ZLand.Actors;

namespace ZLand.Actions
{
    public abstract class Action
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int BaseCost { get; private set; }

        protected Action(int baseCost, string name)
        {
            BaseCost = baseCost;
            Name = name;
            Description = string.Empty;
        }

        protected void EnsureHasEnoughPoints(Actor initiatingActor, int calculatedCost)
        {
            if (initiatingActor.CurrentActionPoints < calculatedCost)
            {
                throw new NotEnoughActionPointsException(initiatingActor.CurrentActionPoints, calculatedCost);
            }
        }
    }
}