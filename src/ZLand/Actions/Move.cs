using System;
using ZLand.Actors;
using ZLand.World;

namespace ZLand.Actions
{
    public class Move : OtherCellAction
    {
        public Move()
            : base(1, "Move", int.MaxValue)
        {
        }
        public override int GetPointsCost(Actor initiatingActor, Cell targetCell)
        {
            var speed = initiatingActor.CurrentSpeed();
            if (speed == 0)
            {
                throw new CantMoveException("You cannot move as your current speed is 0");
            }
            var distance = initiatingActor.CurrentPosition.DistanceTo(targetCell);
            var pointsCostForMovement = (int)Math.Ceiling((double)distance / speed);
            return pointsCostForMovement;
        }

        public override bool IsInRange(Actor initiatingActor, Cell targetCell)
        {
            //Move has an infinite range, but is based on the points cost
            return true;
        }

        public override void Apply(Actor initiatingActor, Cell targetCell)
        {
            if (targetCell.Actor != null)
            {
                throw new CellAlreadyOccupiedException(targetCell);
            }
            base.Apply(initiatingActor, targetCell);
            var oldCell = initiatingActor.CurrentPosition;
            if (oldCell.Equals(targetCell))
            {
                throw new AlreadyAtThatCellException(targetCell);
            }
            oldCell.Actor = null;
            targetCell.Actor = initiatingActor;
        }
    }
}