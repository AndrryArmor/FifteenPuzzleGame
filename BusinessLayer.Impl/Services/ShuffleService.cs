using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.Services
{
    public class ShuffleService
    {
        private readonly GameField _gameField;
        private readonly GameEngine _engine;
        private readonly int _shuffleCount;

        public ShuffleService(GameField gameField, GameEngine engine, int shuffleCount)
        {
            _gameField = gameField;
            _engine = engine;
            _shuffleCount = shuffleCount;
        }

        public void Shuffle()
        {

        }

        private int GetShuffleCount()
        {

        }
    }
}
