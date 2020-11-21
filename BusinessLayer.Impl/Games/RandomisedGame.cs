using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.Games
{
    public class RandomisedGame : Game
    {
        private readonly Random _random;
        private readonly int _randomMovesCount;

        public RandomisedGame(GameSettings settings) : base(settings) 
        {
            int secondsNow = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            _random = new Random(secondsNow);
            _randomMovesCount = GameField.Rows * GameField.Columns;

            ShuffleService shuffleService = new ShuffleService(GameField, settings.GameLevel, Engine);
            shuffleService.Shuffle();
        }

        public override void MakeMove(Direction direction)
        {
            if (Moves % _randomMovesCount == 0 && _random.NextDouble() >= 0.5)
            {
                MakeRandomTileSwap();
                // TODO: history clearing
                //History.Clear();
                OnFieldUpdated(EventArgs.Empty);
            }
            else
                MakeTileSwap(direction);
        }

        private void MakeTileSwap(Direction direction)
        {
            if (Engine.MakeMove(GameField.SpaceTile, direction, GameField) == true)
                OnFieldUpdated(EventArgs.Empty);
        }

        private void MakeRandomTileSwap()
        {
            for (int i = 0; i * i <= _randomMovesCount; i++)
            {
                Tile randomTile = GameField[_random.Next(GameField.Rows), _random.Next(GameField.Columns)];
                Direction randomDirection = default;
                do
                {
                    int directions = Enum.GetValues(randomDirection.GetType()).Length;
                    randomDirection = (Direction)_random.Next(directions);
                } while (Engine.MakeMove(randomTile, randomDirection, GameField) == false);
            }
        }
    }
}
