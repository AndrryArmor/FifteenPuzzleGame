﻿using FifteenPuzzleGame.BusinessLayer.Abstract;
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

        public RandomisedGame(GameEngine engine, GameField gameField) : base(engine, gameField)
        {
            int secondsNow = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            _random = new Random(secondsNow);
            _randomMovesCount = GameField.Rows * GameField.Columns;
        }

        public override void MakeMove(Direction direction)
        {
            if (Moves > 0 && Moves % _randomMovesCount == 0 && _random.NextDouble() >= 0.5)
            {
                MakeRandomTileSwap();
                OnFieldUpdated(EventArgs.Empty);
            }
            else
                MakeTileSwap(direction);
        }

        private void MakeTileSwap(Direction direction)
        {
            if (Engine.MakeMove(GameField.SpaceTile, direction, GameField) == true)
            {
                OnFieldUpdated(EventArgs.Empty);
                Moves++;
            }
        }

        private void MakeRandomTileSwap()
        {
            for (int i = 0; i < (int)Math.Log(_randomMovesCount); i++)
            {
                Direction randomDirection = default;
                do
                {
                    int directions = Enum.GetValues(randomDirection.GetType()).Length;
                    randomDirection = (Direction)_random.Next(directions);
                } while (Engine.MakeMove(GameField.SpaceTile, randomDirection, GameField) == false);
            }
            Moves++;
        }
    }
}
