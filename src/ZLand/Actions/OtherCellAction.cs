using ZLand.Actors;
using ZLand.World;

namespace ZLand.Actions
{
    public abstract class OtherCellAction : Action
    {
        protected OtherCellAction(int cost, string name, int range)
            : base(cost, name)
        {
            Range = range;
        }

        public int Range { get; set; }

        public abstract void Apply(Actor initiatingActor, Cell targetCell);
    }
}