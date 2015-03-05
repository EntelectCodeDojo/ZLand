using ZLand.World;

namespace ZLand.Actions
{
    public class CellAlreadyOccupiedException : DisplayOnUIException
    {
        public CellAlreadyOccupiedException(Cell targetCell)
            :base(string.Format("The target cell [{0},{1}] is already occupied by a {2}", targetCell.XValue,targetCell.YValue, targetCell.Actor.Name))
        {
        }
    }
}