using ZLand.World;

namespace ZLand.Actions
{
    public class AlreadyAtThatCellException : CantMoveException
    {
        public AlreadyAtThatCellException(Cell targetCell)
            : base(string.Format("Unable to move to cell [{0},{1}] as the actor is already at that cell", targetCell.XValue, targetCell.YValue))
        {
        }
    }
}