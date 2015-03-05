using ZLand.Actors;
using ZLand.World;

namespace ZLand.Tests.Actors
{
    public class ActorFake : Actor
    {
        public ActorFake(int actionPointsPerTurn, Cell currentPosition, int baseMoveSpeed, Stats stats, int maxHealth, double maximumWeight) 
            : base(actionPointsPerTurn, currentPosition, baseMoveSpeed, stats, maxHealth, maximumWeight)
        {
        }
    }
}