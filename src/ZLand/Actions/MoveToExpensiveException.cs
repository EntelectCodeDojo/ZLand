namespace ZLand.Actions
{
    public class MoveToExpensiveException : CantMoveException
    {
        public MoveToExpensiveException(int pointsCostForMovement, int currentActionPoints)
            : base(string.Format("To move there costs {0} action points and you currently only have {1} action points.", pointsCostForMovement, currentActionPoints))
        {
        }
    }
}