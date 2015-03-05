using ZLand.Actors;
using ZLand.World;

namespace ZLand.Actions
{
    public class Move : OtherCellAction
    {
        public Move(int cost, int range)
            : base(cost, "Move", range)
        {
        }

        public override void Perform(Actor initiatingActor, Cell targetCell)
        {
            //if(initiatingActor.CurrentPosition.DistanceTo(targetCell) < Cost)
        }
    }
}