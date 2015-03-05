using ZLand.Actions;
using ZLand.World;

namespace ZLand.Actors
{
    public abstract class Zombie : Actor
    {
        protected Zombie(int actionPointsPerTurn, Cell currentPosition, int baseMoveSpeed, Stats stats, int maxHealth, double maximumWeight, string name, double resurectPercentChance) 
            : base(actionPointsPerTurn, currentPosition, baseMoveSpeed, stats, maxHealth, maximumWeight, name)
        {
            ResurectPercentChance = resurectPercentChance;
            Actions.Add(new Move());
        }

        public double ResurectPercentChance { get; set; }
    }
}