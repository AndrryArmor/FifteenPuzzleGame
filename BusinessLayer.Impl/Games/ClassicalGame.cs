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
    public class ClassicalGame : Game
    {
        public ClassicalGame(GameSettings settings) : base(settings)
        {
            ShuffleService shuffleService = new ShuffleService(GameField, settings.GameLevel, Engine);
            shuffleService.Shuffle();
        }

        public override void MakeMove(Direction direction)
        {
            if (Engine.MakeMove(GameField.SpaceTile, direction, GameField) == true)
                OnFieldUpdated(EventArgs.Empty);
        }
    }
}
