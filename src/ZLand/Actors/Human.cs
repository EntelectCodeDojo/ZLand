using ZLand.Actions;
using ZLand.World;

namespace ZLand.Actors
{
    public abstract class Human : Actor
    {
        protected Human(int actionPointsPerTurn, Cell currentPosition, int baseMoveSpeed, Stats stats, int maxHealth, double maximumWeight, string name) 
            : base(actionPointsPerTurn, currentPosition, baseMoveSpeed, stats, maxHealth, maximumWeight, name)
        {
            Actions.Add(new Move());
        }
    }
}