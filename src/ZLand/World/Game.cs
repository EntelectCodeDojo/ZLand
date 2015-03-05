using System;

namespace ZLand.World
{
    public class Game
    {
        public Game(Map map, int? maxTurns= null)
        {
            if (map == null)
            {
                throw new ArgumentNullException("map", "Map cannot be null");
            }
            Map = map;
            MaxTurns = maxTurns;
            CurrentTurn = 1;
        }

        public int CurrentTurn { get; private set; }
        public int? MaxTurns { get; private set; }
        public Map Map { get; private set; }
    }
}