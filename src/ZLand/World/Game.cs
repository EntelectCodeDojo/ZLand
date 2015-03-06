using System;

namespace ZLand.World
{
    public class Game
    {
        private readonly IPersistanceService _persistanceService;

        public Game(Map map, IPersistanceService persistanceService, int? maxTurns = null)
        {
            _persistanceService = persistanceService;
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

        public void Save()
        {
            _persistanceService.Save(this);
        }
    }
}