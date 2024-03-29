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
    public class ClassicalGame : Game
    {
        public ClassicalGame(GameEngine engine, GameField gameField) : base(engine, gameField)
        {
        }

        public override void MakeMove(Direction direction)
        {
            if (Engine.MakeMove(GameField.SpaceTile, direction, GameField) == true)
            {
                OnFieldUpdated(EventArgs.Empty);
                Moves++;
            }
        }
    }
}
