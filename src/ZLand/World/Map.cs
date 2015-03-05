namespace ZLand.World
{
    public class Map
    {
        public int Width { get { return Cells.GetLength(0); } }
        public int Height { get { return Cells.GetLength(1); } }

        public Map(int width, int height)
        {
            Cells = new Cell[width, height];
            InstantiateCells();
        }

        protected void InstantiateCells()
        {
            for (int xValue = 0; xValue < Width; xValue++)
            {
                for (int yValue = 0; yValue < Height; yValue++)
                {
                    Cells[xValue, yValue] = new Cell(xValue, yValue);
                }
            }
        }
        

        public Cell[,] Cells { get; private set; }
    }
}