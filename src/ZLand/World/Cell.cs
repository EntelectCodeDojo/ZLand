using System;
using ZLand.Actors;

namespace ZLand.World
{
    public class Cell
    {
        public int XValue { get; private set; }
        public int YValue { get; private set; }

        public Cell(int xValue, int yValue)
        {
            if (xValue < 0)
            {
                throw new ArgumentException("xValue must be greater than or equal to 0");
            }
            XValue = xValue;
            if (yValue < 0)
            {
                throw new ArgumentException("yValue must be greater than or equal to 0");
            }
            YValue = yValue;
        }

        public Actor Actor { get; set; }

        /// <summary>
        /// Calculates the distances from this cell to the target cell, allowing for diagonal moves.
        /// </summary>
        /// <param name="targetsCell">The targets cell.</param>
        /// <returns>Distance in cells</returns>
        public int DistanceTo(Cell targetsCell)
        {
            return Math.Max(Math.Abs(XValue - targetsCell.XValue), Math.Abs(YValue - targetsCell.YValue));
        }
    }
}