using FifteenPuzzleGame.BusinessLayer.Entities;
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

        public ShuffleService(GameField gameField, GameLevel gameLevel, GameEngine engine)
        {
            _gameField = gameField;
            _engine = engine;
            _shuffleCount = GetShuffleCount(gameLevel);
        }

        public void Shuffle()
        {
            int secondsNow = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            Random random = new Random(secondsNow);

            for (int i = 0; i < _shuffleCount; i++)
            {
                Tile randomTile = _gameField[random.Next(_gameField.Rows), random.Next(_gameField.Columns)];
                Direction randomDirection = default;
                do
                {
                    int directions = Enum.GetValues(randomDirection.GetType()).Length;
                    randomDirection = (Direction)random.Next(directions);
                } while (_engine.MakeMove(randomTile, randomDirection, _gameField) == false);
            }
        }

        private int GetShuffleCount(GameLevel gameLevel)
        {
            int shuffles = 0;
            int numbersProduct = _gameField.Rows * _gameField.Columns;
            switch (gameLevel)
            {
                case GameLevel.Easy:
                    shuffles = numbersProduct;
                    break;
                case GameLevel.Medium:
                    shuffles = numbersProduct * (int)Math.Sqrt(numbersProduct);
                    break;
                case GameLevel.Hard:
                    shuffles = numbersProduct * (_gameField.Rows + _gameField.Columns);
                    break;
            }
            return shuffles;
        }
    }
}
