﻿using FifteenPuzzleGame.BusinessLayer.Abstract;
using FifteenPuzzleGame.BusinessLayer.Entities;
using FifteenPuzzleGame.BusinessLayer.Impl.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzleGame.BusinessLayer.Impl.GameCreators
{
    public class RandomisedGameCreator : GameCreator
    {
        public RandomisedGameCreator() : base() { }

        public override Game CreateGame(GameSettings settings)
        {
            return new RandomisedGame(settings);
        }
    }
}
